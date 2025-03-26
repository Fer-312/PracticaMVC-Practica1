using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PracticaMVC.Models;
using PracticaMVC.Servicios;

namespace PracticaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly equiposDbContext _context;

        public HomeController(ILogger<HomeController> logger, equiposDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Autenticacion]
        public IActionResult Index()
        {
            var tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            var nombreUsuario = HttpContext.Session.GetString("NombreUsuario");


            ViewBag.nombre = nombreUsuario;
            ViewData["tipoUsuario"] = tipoUsuario;
            return View();
        }
        public IActionResult Autenticar()
        {
            ViewData["ErrorMessage"] = "";
            return View();
        }
        [HttpPost]
        public IActionResult Autenticar(string txtUsuario, string txtClave)
        {
            var usuario = (from u in _context.usuarios
                           where u.email == txtUsuario
                           && u.contrasenia == txtClave
                           && u.activo == "S"
                           && u.bloqueado == "N"
                           select u).FirstOrDefault();
            if (usuario != null)
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.id_usuario);
                HttpContext.Session.SetString("TipoUsuario", usuario.tipo_usuario);
                HttpContext.Session.SetString("NombreUsuario", usuario.nombre);

                return RedirectToAction("Index", "Home");
            }
            ViewData["ErrorMessage"] = "Error, usuario invalido!!!";
            return View();
                
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
