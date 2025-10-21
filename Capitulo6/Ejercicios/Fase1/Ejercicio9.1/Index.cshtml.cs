using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

public class Producto
{
    public int id { get; set; }
    public string nombre { get; set; }
}

public class Ejercicio9Model : PageModel
{
    private readonly MySqlConnection _conn;
    public List<Producto> productos { get; set; } = new();
    
    public Ejercicio9Model(MySqlConnection conn)
    {
        _conn = conn;
    }

    public void OnGet()
    {
        llenarProductos();
    }

    public IActionResult OnGetBorrar(int id)
    {
        borrarProductoPorId(id);
        return RedirectToPage();
    }

    public IActionResult OnPostInsertar(string nombre)
    {
        insertarProducto(nombre);
        return RedirectToPage();
    }

    public IActionResult OnPostVaciar()
    {
        vaciarLista();
        return RedirectToPage();
    }
    public void insertarProducto(string nombre)
    {
        try
        {
            _conn.Open();
            const string sql = @"INSERT INTO lista_compra(nombre)
                            VALUES(@nombre)";
            using (var cmd = new MySqlCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);

                cmd.ExecuteNonQuery();

            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    public void borrarProductoPorId(int id)
    {
        try
        {
            _conn.Open();
            using (var cmd = new MySqlCommand("DELETE FROM lista_compra WHERE id=@id", _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
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
    public void vaciarLista()
    {
        try
        {
            _conn.Open();
            using (var cmd = new MySqlCommand("DELETE FROM lista_compra", _conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
    
    public void llenarProductos()
    {
        productos.Clear();
        _conn.Open();
        using (var cmd = new MySqlCommand("SELECT id, nombre FROM lista_compra", _conn))
        using (var lector = cmd.ExecuteReader())
        {
            int idIdx = lector.GetOrdinal("id");
            int nombreIdx = lector.GetOrdinal("nombre");

            while (lector.Read())
            {
                var producto = new Producto
                {
                    id = lector.IsDBNull(idIdx) ? 0 : lector.GetInt32(idIdx),
                    nombre = lector.IsDBNull(nombreIdx) ? "" : lector.GetString(nombreIdx)
                };
                productos.Add(producto);
            }
        }
        _conn.Close();
    }
}