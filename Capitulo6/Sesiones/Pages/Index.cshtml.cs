using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Collections.Generic;
using UsuarioModel.Models;
using ZstdSharp;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
using System.Security;
public class SesionesModel : PageModel
{
    private readonly MySqlConnection _conn;
    public List<Usuario> usuarios { get; set; } = new();
    public SesionesModel(MySqlConnection conn)
    {
        _conn = conn;
    }

    public void OnGet()
    {
        llenarUsuarios();
      

    }
    public IActionResult OnPostInsertar(string nombre, string email, string contrasenna)
    {
        string contrasennaCif = cifrarContrasenna(contrasenna);
        if (!string.IsNullOrEmpty(contrasennaCif))
        {
            insertarUsuario(nombre, email, contrasennaCif);

        }
        return RedirectToPage();
    }
    public IActionResult OnGetEliminar(int id)
    {
        try
        {
            _conn.Open();
            string sql = "DELETE FROM usuarios WHERE id=@id";
            using (var cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                int filas = cmd.ExecuteNonQuery();
                _conn.Close();

                if (filas > 0)
                {
                    return new JsonResult(new { mensaje = "ok" });
                }
                else
                {
                    return new JsonResult(new { mensaje = "no encontrado" });
                }
            }
        }
        catch (Exception ex)
        {
            return new JsonResult(new { error = ex.Message });
        }


    }
    
public JsonResult OnGetById(int id)
{
    try
    {
        _conn.Open();
        string sql = "SELECT * FROM usuarios WHERE id=@id";
        using (var cmd = new MySqlCommand(sql, _conn))
        {
            cmd.Parameters.AddWithValue("@id", id);
            using (var lector = cmd.ExecuteReader())
            {
                if (lector.Read())
                {
                    var usuario = new Usuario
                    {
                        id = lector.GetInt32("id"),
                        nombre = lector.GetString("nombre"),
                        email = lector.GetString("email"),
                        contrasenna = lector.GetString("contrasenna")
                    };
                    return new JsonResult(usuario);
                }
            }
        }
        return new JsonResult(new { mensaje = "no encontrado" });
    }
    catch (Exception ex)
    {
        return new JsonResult(new { error = ex.Message });
    }
    finally
    {
        _conn.Close();
    }
}

    public static string cifrarContrasenna(string contrasenna)
    {
        try
        {
            if (contrasenna.Length > 6)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    // Convertimos la contraseña a bytes
                    byte[] bytes = Encoding.UTF8.GetBytes(contrasenna);
                    // Calculamos el hash
                    byte[] hashBytes = sha256.ComputeHash(bytes);
                    // Convertimos el hash a texto hexadecimal
                    StringBuilder sb = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        sb.Append(b.ToString("x2")); // “x2” = formato hexadecimal
                    }
                    return sb.ToString();
                }
            }
            else
            {
                throw new Exception("La contraseña tiene que tener mínimo 6 caracteres");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
            return null;
        }
    }

    public void insertarUsuario(string nombre, string email, string contrasenna)
    {
        try
        {
            _conn.Open();
            using (var cmd = new MySqlCommand(@"INSERT INTO usuarios(nombre,email, contrasenna)
                                        VALUES(@nombre, @email,@contrasenna)", _conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@contrasenna", contrasenna);

                cmd.ExecuteNonQuery();

            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            _conn.Close();
        }
    }

    public void llenarUsuarios()
    {
        try
        {
            _conn.Open();
            using (var cmd = new MySqlCommand("SELECT id, nombre, email, contrasenna FROM usuarios", _conn))
            {
                cmd.ExecuteNonQuery();
                using (var lector = cmd.ExecuteReader())
                {
                    int idIdx = lector.GetOrdinal("id");
                    int nombreIdx = lector.GetOrdinal("nombre");
                    int emailIdx = lector.GetOrdinal("email");
                    int contrasennaIdx = lector.GetOrdinal("contrasenna");
                    while (lector.Read())
                    {
                        var u = new Usuario
                        {
                            id = lector.IsDBNull(idIdx) ? 0 : lector.GetInt32(idIdx),
                            nombre = lector.IsDBNull(nombreIdx) ? "" : lector.GetString(nombreIdx),
                            email = lector.IsDBNull(emailIdx) ? "" : lector.GetString(emailIdx),
                            contrasenna = lector.IsDBNull(contrasennaIdx) ? "" : lector.GetString(contrasennaIdx),
                        };
                        usuarios.Add(u);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally
        {
            _conn.Close();
        }
    }

    // public void borrarUsuarioPorId(int id)
    // {
    //     try
    //     {
    //         _conn.Open();
    //         using (var cmd = new MySqlCommand("DELETE FROM usuarios WHERE id= @id", _conn))
    //         {
    //             cmd.Parameters.AddWithValue("@id", id);
    //             cmd.ExecuteNonQuery();
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         System.Console.WriteLine(ex.Message);
    //     }
    //     finally
    //     {
    //         _conn.Close();
    //     }
    // }
    
}