using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PracticaMVC.Models;
using PracticaMVC.Servicios;

namespace PracticaMVC.Controllers
{
    public class EquiposController : Controller
    {
        private readonly equiposDbContext _equiposDBcontext;

        public EquiposController(equiposDbContext equiposDBcontext)
        {
            _equiposDBcontext = equiposDBcontext;
        }
        [Autenticacion]
        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDBcontext.marcas
                                 select m).ToList();

            ViewData["listadoDeMarcas"]= new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listadoDeEquipos = (from e in _equiposDBcontext.equipos
                                    join m in _equiposDBcontext.marcas
                                    on e.marca_id equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();

            ViewData["ListadoEquipo"] = listadoDeEquipos;





            var listaDeEstado = (from m in _equiposDBcontext.estados_equipo
                                 select m).ToList();
            ViewData["listadoDeEstado"] = new SelectList(listaDeEstado, "id", "nombre");



            var listaDeTipo = (from m in _equiposDBcontext.tipo_equipo
                                 select m).ToList();
            ViewData["listadoDeTipo"] = new SelectList(listaDeTipo, "equipo_id", "nombre");

            return View();
        }
        [Autenticacion]
        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDBcontext.Add(nuevoEquipo);
            _equiposDBcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
