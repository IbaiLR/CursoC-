using Microsoft.AspNetCore.Mvc;
using MyAppMVC1.Models;

namespace MyAppMVC1.Controllers;

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


        public IActionResult IniciarSesion(Usuario usuario)
        {
            var email = usuario.email;
            var contrasenna = usuario.contrasenna;

            var listaUsuarios = Usuario.GetAll(_configuration);

            if (listaUsuarios == null)
            {
                ViewBag.Error = "Error al conectar con la base de datos.";
                return View();
            }

            Usuario userEncontrado = null;

            foreach (var u in listaUsuarios)
            {
                if (u.email == email && u.contrasenna == contrasenna)
                {
                    userEncontrado = u;
                    break;
                }
            }

            // si NO se encontró el usuario
            if (userEncontrado == null)
            {
                ViewBag.Error = "Credenciales incorrectas.";
                return View();
            }

            // recuperar usuario completo de la BD
            var user = usuario.GetByEmail(userEncontrado.email, _configuration);

            if (user == null)
            {
                ViewBag.Error = "Error inesperado al recuperar datos.";
                return View();
            }

            // GUARDAR EN SESIÓN
            HttpContext.Session.SetString("usuarioEmail", user.email);
            HttpContext.Session.SetString("usuarioNombre", user.nombre);

            // redirigir a una vista de éxito
            return View("ExitoLogin", user);
        }



    public IActionResult verDetalles(int id)
    {
        Usuario u = Usuario.getById(id, _configuration);
        if(u!=null)
        return View("DetallesUsuario", u);
        return RedirectToAction("Index");
    }

        public IActionResult cerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }

