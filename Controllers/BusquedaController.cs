using System.Linq;
using Bryan_Rodriguez_PC3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bryan_Rodriguez_PC3.Controllers
{
    public class BusquedaController : Controller
    {
        private readonly BuscoContext _context;
        public BusquedaController(BuscoContext context){
            _context = context;
        }

        public IActionResult Producto() {
            var productos = _context.Productos.Include(x => x.Categoria).OrderBy(r => r.NombreProducto).ToList();
            return View(productos);
        }

        public IActionResult Categoria(){
            return View();
        }

        public IActionResult RegistrarProducto(){
            ViewBag.Categorias = _context.Categorias.ToList().Select(c => new SelectListItem(c.Nombre, c.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarProducto(Producto p){
            if(ModelState.IsValid){
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("ConfirmarRegistro");
            }
            return View(p);
        }

        public IActionResult ConfirmarRegistro(){
            return View();
        }

        public IActionResult ModificarProducto(int id) {
            var producto = _context.Productos.Find(id);
            return View(producto);
        }

        [HttpPost]
        public IActionResult ModificarProducto(Producto p) {
            if (ModelState.IsValid) {
                var personaje = _context.Productos.Find(p.Id);
                personaje.NombreComprador = p.NombreComprador;
                _context.SaveChanges();
                return RedirectToAction("ConfirmarModificacion");
            }
            return View(p);
        }

        public IActionResult ConfirmarModificacion(){
            return View();
        }

        [HttpPost]
        public IActionResult EliminarProducto(int id) {
            var producto = _context.Productos.Find(id);
            _context.Remove(producto);
            _context.SaveChanges();

            return RedirectToAction("Producto");
        }
    }
}