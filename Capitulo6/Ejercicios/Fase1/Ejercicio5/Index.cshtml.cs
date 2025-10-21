using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

public class Ejercicio5Model : PageModel
{
    [BindProperty]
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string nombre { get; set; }

    [BindProperty]
    [EmailAddress(ErrorMessage = "Por favor ingresa un email valido")]
    public string email { get; set; }

    [BindProperty]
    [Range(18, 100, ErrorMessage = "La edad debe estar entre 18 y 100 años")]
    public int edad { get; set; }

    public bool valido { get; set; }

    // Método que maneja la solicitud POST
    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            // Si el formulario es válido, establece 'valido' a true
            valido = true;
        }
    }
}
