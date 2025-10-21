using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

public class Ejercicio7Model : PageModel
{
    private readonly MySqlConnection _conn;

    public Ejercicio7Model(MySqlConnection conn)
    {
        _conn = conn;
    }

    public List<string> Alumnos { get; set; } = new();

    public void OnGet()
    {
        cargarAlumnos();
    }
    public string Mensaje { get; set; } = "";

    public IActionResult OnPost(string nombre, string apellidos, string email, int edad)
    {
        insertarAlumno(nombre, apellidos, email, edad);
        return RedirectToPage();
}

private void cargarAlumnos()
{
    Alumnos.Clear();
    _conn.Open();
    using (var cmd = new MySqlCommand("SELECT nombre FROM alumnos", _conn))
    using (var reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            Alumnos.Add(reader.GetString("nombre"));
        }
    }
    _conn.Close();
}

    private void insertarAlumno(string nombre, string apellidos, string email, int edad)
    {
        try
        {
            _conn.Open();
            string sql = @"INSERT INTO alumnos(nombre, apellidos, email, edad)
                        VALUES (@nombre, @apellidos, @email, @edad)";
            using (var cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@edad", edad);

                cmd.ExecuteNonQuery();
                Mensaje = "Alumno insertado correctamente";
            }
        }
        catch (Exception ex)
        {
            Mensaje = "Error" + ex.Message;
        }
        finally
        {
            _conn.Close();
        }
    }
}
