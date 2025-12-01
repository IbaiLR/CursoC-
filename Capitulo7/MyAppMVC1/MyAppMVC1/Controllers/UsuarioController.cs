using Microsoft.AspNetCore.Mvc;
using MyAppMVC1.Models;
using MyAppMVC1.Models.ViewModels;

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
        if (HttpContext.Session.GetString("usuarioEmail") == null)
        {
            return View();
        }
        else
        {
            TempData["Mensaje"] = "No puedes registrar un usuario con la sesión iniciada";
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
        if (HttpContext.Session.GetString("usuarioEmail") == null)
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
        else
        {
            TempData["Mensaje"] = "No puedes registrar un usuario con la sesión iniciada";
            return RedirectToAction("Index", "Home");
        }
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
            var user = Usuario.GetByEmail(userEncontrado.email, _configuration);

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

    [HttpGet]
    public IActionResult mostrarEditarPerfil(string email)
    {
        try
        {
            if (HttpContext.Session.GetString("usuarioEmail") != null)
            {
                Usuario usuarioSesion = Usuario.GetByEmail(HttpContext.Session.GetString("usuarioEmail"), _configuration);

                Usuario u = Usuario.GetByEmail(email, _configuration);
                if (usuarioSesion.email != u.email)
                {
                    TempData["Mensaje"] = "Solo puedes editar tu perfil.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    var vm = new EditarPerfilViewModel
                    {
                        id = u.id,
                        nombre = u.nombre,
                        apellidos = u.apellidos,
                        email = u.email,
                    };
                    if (u == null)
                        return View();
                    return View("EditarPerfil", vm);
                }
            }
            else
            {
                TempData["Mensaje"] = "Debes de iniciar sesión para poder editar tu perfil";
                return RedirectToAction("Index", "Home");

            }
        }catch(Exception ex)
        {
            TempData["Mensaje"] = "Error al editar el perfil";
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    public IActionResult editarPerfil(EditarPerfilViewModel vm)
    { 

        if (!ModelState.IsValid) {
            foreach (var e in ModelState)
            {
                foreach (var err in e.Value.Errors)
                    Console.WriteLine($" - {e.Key}: {err.ErrorMessage}");
            }
        
            return View("EditarPerfil", vm);
        }

        var usuario = Usuario.getById(vm.id, _configuration);
        if (usuario == null)
            return NotFound();
        usuario.nombre = vm.nombre;
        usuario.apellidos = vm.apellidos;
        usuario.email = vm.email;

        bool ok = usuario.Update(_configuration, out string? error);
        if (!ok)
        {
            return View("EditarPerfil", vm);
        }
        HttpContext.Session.SetString("usuarioNombre", usuario.nombre);
        HttpContext.Session.SetString("usuarioEmail", usuario.email);

       
        return RedirectToAction("mostrarEditarPerfil", new {email = usuario.email});

       
    }


    public IActionResult verDetalles(int id)
    {
        Usuario u = Usuario.getById(id, _configuration);
        if(u!=null)
        return View("DetallesUsuario", u);
        return RedirectToAction("Index");
    }

    public IActionResult eliminarUsuario(int id)
    {
        //Usuario usuarioSesion = Usuario.GetByEmail(HttpContext.Session.GetString("usuarioEmail"),_configuration);
        if (HttpContext.Session.GetString("usuarioEmail") != null)
        {
            Usuario u = Usuario.getById(id, _configuration);
            if (u != null)
                Usuario.eliminarUsuario(id, _configuration);
        }
        else
        {
            TempData["Mensaje"] = "Debes iniciar sesión antes.";
        }
            return RedirectToAction("Index");
        


    }

        public IActionResult cerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }

