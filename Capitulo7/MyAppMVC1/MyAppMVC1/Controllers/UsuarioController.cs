using Microsoft.AspNetCore.Mvc;
using MyAppMVC1.Models;

namespace MyAppMVC1.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            var ok = usuario.Insertar(_configuration, out var error);
            if (ok)
                return View("Exito", usuario);

            // enseña el motivo en el formulario
            ModelState.AddModelError(string.Empty, error ?? "Error desconocido al insertar.");
            return View(usuario);
        }

        public IActionResult Index()
        {
            var usuarios = Usuario.GetAll(_configuration);

            if (usuarios == null)
            {
                ViewBag.Error = "No se pudieron cargar los usuarios.";
                return View("Error"); 
            }

            if (!usuarios.Any())
            {
                ViewBag.Mensaje = "No hay usuarios registrados todavía.";
                return View("Index", new List<Usuario>());
            }
            return View(usuarios);
        }




    }
}
