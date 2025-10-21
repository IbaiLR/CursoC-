using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
public class Producto
{
    public int id { get; set; }
    public string nombre { get; set; }
}

public class Ejercicio1Model : PageModel
{
    private readonly MySqlConnection _conn;
    public List<Producto> productos { get; set; } = new();

    public Ejercicio1Model(MySqlConnection conn)
    {
        _conn = conn;
    }

    public void OnGet()
    {
        llenarListaProductos();
    }
    public IActionResult OnPostInsertar(string nombre)
    {
        insertarProductos(nombre);
        return RedirectToPage();

    }

    public IActionResult OnGetBorrar(int id)
    {
        borrarProductoPorId(id);
        return RedirectToPage();
    }
    public void llenarListaProductos()
    {
        productos.Clear();
        _conn.Open();

        using (var cmd = new MySqlCommand("SELECT id, nombre FROM lista_compra", _conn))
        {
            using (var lector = cmd.ExecuteReader())
            {
                int idIdx = lector.GetOrdinal("id");
                int nombreIdx = lector.GetOrdinal("nombre");

                while (lector.Read())
                {
                    Producto p = new Producto
                    {
                        id = lector.IsDBNull(idIdx) ? 0 : lector.GetInt32(idIdx),
                        nombre = lector.IsDBNull(nombreIdx) ? "" : lector.GetString(nombreIdx)
                    };
                    productos.Add(p);
                }
            }
        }
    }

    public void insertarProductos(string nombre)
    {
        try
        {
            _conn.Open();
            using (var cmd = new MySqlCommand(@"INSERT INTO lista_compra(nombre)
                                            VALUES(@nombre)",_conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
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
}