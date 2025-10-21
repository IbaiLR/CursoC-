using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

public class Ejercicio4Model : PageModel
{

    [BindProperty]

    public string nombre { get; set; }
    public string pass { get; set; }

    public bool isSubmitted { get; set; }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            isSubmitted = true;

            return RedirectToPage("/Gracias");
        }
        return Page(); //si no es válido regresa a la misma página
    }
}