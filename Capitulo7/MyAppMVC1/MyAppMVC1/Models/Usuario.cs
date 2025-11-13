using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace MyAppMVC1.Models;

public class Usuario
{
    [Key] public int id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string nombre { get; set; }

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    public string apellidos { get; set; }

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Formato de correo no válido")]
    public string email { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria")]
    public string contrasenna { get; set; }

    // ⬇️ devuelve true/false y además saca el error si lo hay
    public bool Insertar(IConfiguration configuration, out string? error)
    {
        error = null;
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        try
        {
            using var conexion = new MySqlConnection(connectionString);
            conexion.Open();

            var query = @"INSERT INTO usuarios (nombre, apellidos, email, contrasenna)
                          VALUES (@nombre, @apellidos, @email, @contrasenna)";
            using var cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellidos);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@contrasenna", contrasenna);

            var filas = cmd.ExecuteNonQuery();
            return filas == 1;
        }
        catch (MySqlException ex)
        {
            error = ex.Message; // error SQL real (columna no existe, acceso denegado, etc.)
            return false;
        }
        catch (Exception ex)
        {
            error = ex.Message;
            return false;
        }
    }

    public static List<Usuario> GetAll(IConfiguration configuration)
    {
        var usuarios = new List<Usuario>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        try
        {
            using var conexion = new MySqlConnection(connectionString);
            conexion.Open();
            string sql = "SELECT * FROM usuarios";
            using var cmd = new MySqlCommand(sql, conexion);


            using var lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                var usuario = new Usuario
                {
                    id = lector.GetInt32("id"),
                    nombre = lector.GetString("nombre"),
                    apellidos = lector.GetString("apellidos"),
                    email = lector.GetString("email"),
                    contrasenna = lector.GetString("contrasenna")
                };
                usuarios.Add(usuario);
            }
            return usuarios;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }



    }
    public static Usuario getById(int id, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        using var conexion = new MySqlConnection(connectionString);
        conexion.Open();
        string sql = "SELECT * FROM usuarios WHERE id= @id";
        using var cmd = new MySqlCommand(sql, conexion);
        cmd.Parameters.AddWithValue("id", id);
        var lector = cmd.ExecuteReader();
        Usuario usuario = null;
        if (lector.Read())
        {
             usuario = new Usuario
            {
                id = lector.GetInt32("id"),
                nombre = lector.GetString("nombre"),
                apellidos = lector.GetString("apellidos"),
                email = lector.GetString("email"),
                contrasenna = lector.GetString("contrasenna")


            };
        }
        return usuario;
    }
    public Usuario GetByEmail(string email, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        using var conexion = new MySqlConnection(connectionString);
        conexion.Open();
        string sql = "SELECT * FROM usuarios WHERE email= @email";
        using var cmd = new MySqlCommand(sql, conexion);
        cmd.Parameters.AddWithValue("email", email);

        var lector = cmd.ExecuteReader();
        if (!lector.Read()) return null;
        
            return new Usuario
            {
                id = lector.GetInt32("id"),
                nombre = lector.GetString("nombre"),
                apellidos = lector.GetString("apellidos"),
                email = lector.GetString("email"),
                contrasenna = lector.GetString("contrasenna")


            };
       
        
    }

}
