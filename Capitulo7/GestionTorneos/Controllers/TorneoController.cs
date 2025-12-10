using GestionTorneos.Models;
using GestionTorneos.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GestionTorneos.Controllers
{
    public class TorneoController : Controller
    {
        private readonly IConfiguration _configuration;
        public TorneoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            try
            {
                var listaJuegos = Juego.getAll(_configuration);
                ViewBag.Juegos = listaJuegos;
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Create(CreateTorneoViewModel t)
        {
            var listaJuegos = Juego.getAll(_configuration);
            ViewBag.Juegos = listaJuegos;

            if (!ModelState.IsValid)
                return View(t);

            try
            {
                if (t.FechaInicio > t.FechaFin)
                {
                    TempData["Mensaje"] = "La fecha de inicio no puede ser mayor que la de fin";
                    return View(t);
                }

                if (!listaJuegos.Any(j => j.JuegoId == t.JuegoId))
                {
                    TempData["Mensaje"] = "Juego inválido";
                    return View(t);
                }

                var torneo = new Torneo
                {
                    Nombre = t.Nombre,
                    FechaInicio = t.FechaInicio,
                    FechaFin = t.FechaFin,
                    Premio = t.Premio,
                    Formato = t.Formato,
                    JuegoId = t.JuegoId
                };

                torneo.Create(_configuration);

                TempData["Mensaje"] = "Torneo creado correctamente";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error inesperado: " + ex.Message;
                return View(t);
            }
        }

     
    }
}