using Microsoft.AspNetCore.Mvc;
using GestionTorneos.Models;

namespace GestionTorneos.Controllers
{
    public class JuegoController : Controller
    {
        private readonly IConfiguration _configuration; 
        public JuegoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Index");
        }
        [HttpPost]
        public IActionResult Create(Juego juego)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("No es valido el model state");
                TempData["Mensaje"] = "Error al obtener los datos del usuario";
                return View("Index", juego);
            }
            try
            {
                Console.WriteLine("Llega al try");
                juego.Create(_configuration);
                return RedirectToAction("Index", "Home");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                TempData["Mensaje"] = "Error al intentar crear el Juego: " + ex.Message;
                return View("Index", juego);
            }
        }
    }


    }

