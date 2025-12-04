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
            var contador = 0;
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                if (t.FechaInicio > t.FechaFin)
                {
                    TempData["Mensaje"] = "La fecha de inicio no puede ser mayor que la de fin";
                    return View("Create", t);
                }
                foreach (var juego in listaJuegos)
                {
                    if (juego.JuegoId == t.JuegoId)
                        contador++;
                }
                if (contador != 1)
                {
                    TempData["Mensaje"] = "Error al seleccionar el juego";
                    return View("Create", t);
                }
                var torneo = new Torneo
                {
                    Nombre = t.Nombre,
                    FechaInicio = t.FechaInicio,
                    FechaFin = t.FechaFin,
                    Premio = t.Premio,
                    Formato = t.Formato
                };
                torneo.Create(_configuration);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error inesperado";
                Console.WriteLine(ex.Message);
                return View("Create", t);
            }
        }

        [HttpGet]
        public IActionResult CreatePrueba(Torneo t)
        {
            var listaJuegos = Juego.getAll(_configuration);
            var contador = 0;
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                if (t.FechaInicio > t.FechaFin)
                {
                    TempData["Mensaje"] = "La fecha de inicio no puede ser mayor que la de fin";
                    return View("Create", t);
                }
                foreach (var juego in listaJuegos)
                {
                    if (juego.JuegoId == t.JuegoId)
                        contador++;
                }
                if (contador != 1)
                {
                    TempData["Mensaje"] = "Error al seleccionar el juego";
                    return View("Create", t);
                }
                var torneo = new Torneo
                {
                    Nombre = t.Nombre,
                    FechaInicio = t.FechaInicio,
                    FechaFin = t.FechaFin,
                    Premio = t.Premio,
                    Formato = t.Formato,
                    JuegoId= t.JuegoId
                };
                torneo.Create(_configuration);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error inesperado";
                Console.WriteLine(ex.Message);
                return View("Create", t);
            }
        }
    }
}
