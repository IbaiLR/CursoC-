using Microsoft.AspNetCore.Mvc;
using MyAppMVC1.Models;
using System.Diagnostics.CodeAnalysis;

namespace MyAppMVC1.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Overview()
        {
            var item = new Item { Name = "keyboard" };
            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content("id= " + id);
        }
    }
}
