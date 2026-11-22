using DSW1_T1_RamosBellidoAntonellaDannaee.Models;
using DSW1_T1_RamosBellidoAntonellaDannaee.Repositories;

namespace DSW1_T1_RamosBellidoAntonellaDannaee.Services
{
    public class LibroServices : ILibroServices
    {
        private readonly ILibroRepository _iLibroRepository;

        public LibroServices(ILibroRepository iLibroRepository)
        {
            _iLibroRepository = iLibroRepository;
        }

        public IEnumerable<Libro> ListarLibros()
        {
            return _iLibroRepository.recuperarDatos(
                "usp_ListarLibros",
                new Dictionary<string, dynamic>());
        }

        public Libro? ObtenerLibroPorId(int id)
        {
            Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
            parametros.Add("@Id", id);

            return _iLibroRepository.recuperarDatos(
                "usp_ObtenerLibroPorId", parametros).FirstOrDefault();
        }

        public string RegistrarLibro(Libro libro)
        {
            Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
            parametros.Add("@NombreLibro", libro.NombreLibro);
            parametros.Add("@Autor", libro.Autor);
            parametros.Add("@NombreEditorial", libro.NombreEditorial);

            try
            {
                return _iLibroRepository.EnviarDatos(
                    "usp_RegistrarLibro", parametros);
            }
            catch (Exception)
            {
                return "Fallo";
            }
        }

        public string ActualizarLibro(Libro libro)
        {
            Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
            parametros.Add("@Id", libro.Id);
            parametros.Add("@NombreLibro", libro.NombreLibro);
            parametros.Add("@Autor", libro.Autor);
            parametros.Add("@NombreEditorial", libro.NombreEditorial);

            try
            {
                return _iLibroRepository.EnviarDatos(
                    "usp_ActualizarLibro", parametros);
            }
            catch (Exception)
            {
                return "Fallo";
            }
        }

        public string EliminarLibro(int id)
        {
            Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
            parametros.Add("@Id", id);

            try
            {
                return _iLibroRepository.EnviarDatos(
                    "usp_EliminarLibro", parametros);
            }
            catch (Exception)
            {
                return "Fallo";
            }
        }

        public IEnumerable<Libro> ListarLibrosPorAutor(string autor)
        {
            Dictionary<string, dynamic> parametros = new Dictionary<string, dynamic>();
            parametros.Add("@Autor", autor);

            return _iLibroRepository.recuperarDatos(
                "usp_ListarLibrosPorAutor", parametros);
        }
    }
}
