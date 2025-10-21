using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class Ejercicio3Model : PageModel
{
    public List<Producto> productos{ get; set; }

    public void OnGet()
    {
        productos = new List<Producto>();

        productos.Add(new Producto { nombre = "Camiseta", precio = 50 });
        productos.Add(new Producto { nombre = "Pantalón", precio = 70 });
        productos.Add(new Producto { nombre = "Calcetines", precio = 10 });
    }
}

public class Producto
{
    public string nombre { get; set; }
    public double precio { get; set; }
}