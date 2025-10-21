using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using UsuarioModel.Models;

public class LoginModel : PageModel
{
    private readonly MySqlConnection _conn;

    public string Mensaje { get; set; }  //  Aquí guardaremos el texto del alert

    public LoginModel(MySqlConnection conn)
    {
        _conn = conn;
    }
    
    public void OnPostAcceder(string nombre, string contrasenna)
    {
        string contrasennaCif = Ejercicio2Model.cifrarContrasenna(contrasenna);
        _conn.Open();
        string sqlNombre = "SELECT Count(*) FROM usuarios WHERE nombre=@nombre";
        string sqlPass = "SELECT * FROM usuarios WHERE nombre=@nombre AND contrasenna=@contrasennaCif";

        using (var cmd = new MySqlCommand(sqlNombre, _conn))
        {
            cmd.Parameters.AddWithValue("@nombre", nombre);
            int filas = Convert.ToInt32(cmd.ExecuteScalar());

            if (filas > 0)
            {
                using (var cme = new MySqlCommand(sqlPass, _conn))
                {
                    cme.Parameters.AddWithValue("@contrasennaCif", contrasennaCif);
                    cme.Parameters.AddWithValue("@nombre", nombre);

                    int filasPass = 0;
                    using (var lector = cme.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            filasPass++;
                        }
                    }

                    if (filasPass > 0)
                        Mensaje = "Acceso concedido";
                    else
                        Mensaje = "Contraseña incorrecta";
                }
            }
            else
            {
                Mensaje = "Nombre de usuario incorrecto";
            }
        }
    }
}
