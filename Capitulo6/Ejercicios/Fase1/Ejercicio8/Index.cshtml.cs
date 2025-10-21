using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

public class Alumno
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellidos { get; set; } = "";
    public string Email { get; set; } = "";
    public int Edad { get; set; }
}

public class Ejercicio7Model : PageModel
{
    private readonly MySqlConnection _conn;

    public Ejercicio7Model(MySqlConnection conn)
    {
        _conn = conn;
    }

    public List<Alumno> Alumnos { get; set; } = new();

    // Detalle a mostrar en la página
    public Alumno? AlumnoSeleccionado { get; set; }

    [TempData] public string Mensaje { get; set; } = "";

    public void OnGet()
    {
        CargarAlumnos();
    }

    // INSERT
    public IActionResult OnPost(string nombre, string apellidos, string email, int edad)
    {
        InsertarAlumno(nombre, apellidos, email, edad);
        return RedirectToPage(); // PRG
    }

    // DELETE
    public IActionResult OnPostBorrar(int id)
    {
        BorrarAlumno(id);
        return RedirectToPage(); // PRG
    }

    // DETALLES (no PRG: devolvemos la misma Page para mostrar los datos)
    public IActionResult OnPostDetalles(int id)
    {
        AlumnoSeleccionado = ObtenerAlumnoPorId(id);
        CargarAlumnos(); // mantenemos la lista visible
        return Page();   // renderiza la misma página con el detalle
    }

    private void CargarAlumnos()
    {
        Alumnos.Clear();
        _conn.Open();
        using (var cmd = new MySqlCommand("SELECT id, nombre FROM alumnos", _conn))
        using (var reader = cmd.ExecuteReader())
        {
            int idIdx = reader.GetOrdinal("id");
            int nombreIdx = reader.GetOrdinal("nombre");

            while (reader.Read())
            {
                var a = new Alumno
                {
                    Id = reader.IsDBNull(idIdx) ? 0 : reader.GetInt32(idIdx),
                    Nombre = reader.IsDBNull(nombreIdx) ? "" : reader.GetString(nombreIdx)
                };
                Alumnos.Add(a);
            }
        }
        _conn.Close();
    }

    private Alumno? ObtenerAlumnoPorId(int id)
    {
        Alumno? alumno = null;
        _conn.Open();

        const string sql = "SELECT id, nombre, apellidos, email, edad FROM alumnos WHERE id=@id";
        using (var cmd = new MySqlCommand(sql, _conn))
        {
            cmd.Parameters.AddWithValue("@id", id);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    int idIdx = reader.GetOrdinal("id");
                    int nombreIdx = reader.GetOrdinal("nombre");
                    int apellidosIdx = reader.GetOrdinal("apellidos");
                    int emailIdx = reader.GetOrdinal("email");
                    int edadIdx = reader.GetOrdinal("edad");

                    alumno = new Alumno
                    {
                        Id = reader.IsDBNull(idIdx) ? 0 : reader.GetInt32(idIdx),
                        Nombre = reader.IsDBNull(nombreIdx) ? "" : reader.GetString(nombreIdx),
                        Apellidos = reader.IsDBNull(apellidosIdx) ? "" : reader.GetString(apellidosIdx),
                        Email = reader.IsDBNull(emailIdx) ? "" : reader.GetString(emailIdx),
                        Edad = reader.IsDBNull(edadIdx) ? 0 : reader.GetInt32(edadIdx)
                    };
                }
            }
        }

        _conn.Close();
        return alumno;
    }

    private void InsertarAlumno(string nombre, string apellidos, string email, int edad)
    {
        try
        {
            _conn.Open();
            const string sql = @"INSERT INTO alumnos(nombre, apellidos, email, edad)
                                 VALUES (@nombre, @apellidos, @email, @edad)";
            using (var cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@edad", edad);

                cmd.ExecuteNonQuery();
                Mensaje = "✅ Alumno insertado correctamente";
            }
        }
        catch (Exception ex)
        {
            Mensaje = "❌ Error al insertar: " + ex.Message;
        }
        finally
        {
            _conn.Close();
        }
    }

    private void BorrarAlumno(int id)
    {
        try
        {
            _conn.Open();
            const string sql = "DELETE FROM alumnos WHERE id=@id";
            using (var cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Mensaje = "🗑️ Alumno eliminado correctamente";
            }
        }
        catch (Exception ex)
        {
            Mensaje = "❌ Error al eliminar: " + ex.Message;
        }
        finally
        {
            _conn.Close();
        }
    }
}
