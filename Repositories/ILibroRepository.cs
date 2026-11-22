using DSW1_T1_RamosBellidoAntonellaDannaee.Models;

namespace DSW1_T1_RamosBellidoAntonellaDannaee.Repositories
{
    public interface ILibroRepository
    {
        IEnumerable<Libro> recuperarDatos(string storeProcedure, Dictionary<string, dynamic> parametros);

        string EnviarDatos(string storeProcedure, Dictionary<string, dynamic> parametros);

    }
 }


