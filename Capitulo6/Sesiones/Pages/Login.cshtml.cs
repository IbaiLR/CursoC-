using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using UsuarioModel.Models;

public class LoginModel : PageModel
{
    private readonly MySqlConnection _conn;
    public string Mensaje { get; set; } = "";
    
    //  Propiedades visibles en la vista
    public string? NombreUsuario { get; set; }
    public string? EmailUsuario { get; set; }

    public LoginModel(MySqlConnection conn)
    {
        _conn = conn;
    }

    public void OnGet()
    {
        //  Al cargar la página, leer la sesión si existe
        NombreUsuario = HttpContext.Session.GetString("Usuario");
        EmailUsuario = HttpContext.Session.GetString("Email");
    }

  public IActionResult OnPostAcceder(string nombre, string contrasenna)
{
    string contrasennaCif = SesionesModel.cifrarContrasenna(contrasenna);

    try
    {
        _conn.Open();

        string sqlNombre = "SELECT COUNT(*) FROM usuarios WHERE nombre=@nombre";
        string sqlPass = "SELECT * FROM usuarios WHERE nombre=@nombre AND contrasenna=@contrasennaCif";

        using (var cmd = new MySqlCommand(sqlNombre, _conn))
        {
            cmd.Parameters.AddWithValue("@nombre", nombre);
            int filas = Convert.ToInt32(cmd.ExecuteScalar());

            if (filas > 0)
            {
                using (var cme = new MySqlCommand(sqlPass, _conn))
                {
                    cme.Parameters.AddWithValue("@nombre", nombre);
                    cme.Parameters.AddWithValue("@contrasennaCif", contrasennaCif);

                    using (var lector = cme.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            Mensaje = "Acceso concedido";
                            lector.Close();
                            Console.WriteLine("GUARDANDO SESION PARA: " + nombre);

                                var u = obtenerUsuario(nombre, _conn);
                            System.Console.WriteLine(u.nombre);
                            if (u != null)
                            {
                                    guardarUsuarioEnSession(u);
                                  return RedirectToPage("/Login");
                            }
                        }
                        else
                        {
                            Mensaje = "Contraseña incorrecta";
                        }
                    }
                }
            }
            else
            {
                Mensaje = "Nombre de usuario incorrecto";
            }
        }
    }
    catch (Exception ex)
    {
        Mensaje = "Error: " + ex.Message;
    }
    finally
    {
        _conn.Close();
    }

    return Page(); // si no hubo login correcto
}
    public Usuario obtenerUsuario(string nombre, MySqlConnection conn)
    {
    
            
            string sql = "SELECT * FROM usuarios WHERE nombre=@nombre";
        using (var cmd = new MySqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@nombre", nombre);
            using (var lector = cmd.ExecuteReader())
            {
                if (lector.Read())
                {
                    return new Usuario
                    {
                        id = lector.GetInt32("id"),
                        nombre = lector.GetString("nombre"),
                        email = lector.GetString("email"),
                        contrasenna = lector.GetString("contrasenna")
                    };
                }
            }
        }
            
                return null;
        }
      

    
    

    public void guardarUsuarioEnSession(Usuario u)
    {
        try
        {
            HttpContext.Session.SetInt32("Id", u.id);
            HttpContext.Session.SetString("Usuario", u.nombre);
            HttpContext.Session.SetString("Email", u.email);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public IActionResult OnPostCerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToPage("/Login");
    }
}
