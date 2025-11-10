using Microsoft.AspNetCore.Mvc;
using MyAppMVC1.Models;

namespace MyAppMVC1.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Overview()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nombre = "Juan",
                Apellidos = "Pérez",
                Email = "juan.perez@email.com",
                Contrasenna = "password123"

            };
            return View(usuario);
        }
    }
}
