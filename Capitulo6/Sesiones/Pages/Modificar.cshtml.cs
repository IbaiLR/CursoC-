using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using UsuarioModel.Models;

public class ModificarModel : PageModel
{
    private readonly MySqlConnection _conn;
    public string Mensaje { get; set; } = "";

    //  Propiedades visibles en la vista
    public string? NombreUsuario { get; set; }
    public string? EmailUsuario { get; set; }
    [BindProperty(SupportsGet = true)] //Esto captura el parametro de la URL
    public int id{ get; set; }
    

    public ModificarModel(MySqlConnection conn)
    {
        _conn = conn;
    }

    public void OnGet()
    {
        try
        {
            _conn.Open();
            string sql = "SELECT * FROM usuarios WHERE id=@id";
            using (var cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        NombreUsuario = reader.GetString("Nombre");
                        EmailUsuario = reader.GetString("Email");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        finally { _conn.Close(); }
    }
    
    public IActionResult OnPostModificar(string nombre, string email)
    {
        try
        {
            string sql = "UPDATE usuarios SET Nombre= @Nombre, Email= @Email WHERE id=@id";
            _conn.Open();
            using (var cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                Mensaje = "Usuario Modificado";
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
        return Page();
    }
    
    
}