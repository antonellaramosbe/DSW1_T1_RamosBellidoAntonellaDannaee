using DSW1_T1_RamosBellidoAntonellaDannaee.Models;

namespace DSW1_T1_RamosBellidoAntonellaDannaee.Services
{
    public interface ILibroServices
    {
        IEnumerable<Libro> ListarLibros();
        Libro? ObtenerLibroPorId(int id);
        string RegistrarLibro(Libro libro);
        string ActualizarLibro(Libro libro);
        string EliminarLibro(int id);
        IEnumerable<Libro> ListarLibrosPorAutor(string autor);
    }
}

