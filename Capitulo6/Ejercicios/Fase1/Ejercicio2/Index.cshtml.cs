using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

public class Ejercicio2Model : PageModel
{
    [BindProperty]
    public string Nombre { get; set; }

    [BindProperty]
    public string Email { get; set; }

    public bool IsSubmitted { get; set; }

    public void OnPost()
    {
        if (ModelState.IsValid)
        {
            IsSubmitted = true;
        }
    }

}


