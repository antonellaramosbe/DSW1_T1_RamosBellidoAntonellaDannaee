using Microsoft.AspNetCore.Mvc;
using DSW1_T1_RamosBellidoAntonellaDannaee.Models;
using DSW1_T1_RamosBellidoAntonellaDannaee.Services;

namespace DSW1_T1_RamosBellidoAntonellaDannaee.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroServices iLibroServices;

        public LibroController(ILibroServices iLibroServices)
        {
            this.iLibroServices = iLibroServices;
        }

        public IActionResult Index()
        {
            IEnumerable<Libro> listLibros = iLibroServices.ListarLibros();

            ViewBag.Mensaje = TempData["Mensaje"];

            return View(listLibros);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                string resultado = iLibroServices.RegistrarLibro(libro);

                TempData["Mensaje"] = resultado == "Exitoso"
                    ? "Libro registrado exitosamente."
                    : "No se pudo registrar el libro.";

                return RedirectToAction("Index");
            }

            return View(libro);
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Libro? libro = iLibroServices.ObtenerLibroPorId(id);

            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        [HttpPost]
        public IActionResult Editar(Libro libro)
        {
            if (ModelState.IsValid)
            {
                string resultado = iLibroServices.ActualizarLibro(libro);

                TempData["Mensaje"] = resultado == "Exitoso"
                    ? "Libro actualizado exitosamente."
                    : "No se pudo actualizar el libro.";

                return RedirectToAction("Index");
            }

            return View(libro);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            string resultado = iLibroServices.EliminarLibro(id);

            if (resultado != "Exitoso")
            {
                TempData["Mensaje"] = "No se pudo eliminar el libro.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult BuscarPorAutor(string? autor)
        {
            ViewBag.Autor = autor;

            IEnumerable<Libro> listLibros =
                iLibroServices.ListarLibrosPorAutor(autor ?? "");

            return View(listLibros);
        }
    }
}
