using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class Ejercicio6Model : PageModel
{
    [BindProperty]
    public string Nombre { get; set; }
    [BindProperty]
    public string Email { get; set; }

    public List<Usuario> usuarios = new List<Usuario>();

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            usuarios.Add(new Usuario
            {
                Nombre = Nombre,
                Email = Email
            });
        }
    }

}

    

public class Usuario
{
    public string Nombre { get; set; }
    public string Email { get; set; }
}
