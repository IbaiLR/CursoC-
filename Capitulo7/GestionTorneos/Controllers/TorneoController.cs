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
    }
}
