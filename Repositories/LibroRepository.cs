using DSW1_T1_RamosBellidoAntonellaDannaee.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSW1_T1_RamosBellidoAntonellaDannaee.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly IConfiguration _configuration;

        public LibroRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Libro> recuperarDatos(string storeProcedure, Dictionary<string, dynamic> parametros)
        {
            List<Libro> listLibros = new List<Libro>();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:BD"]))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(storeProcedure, sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, dynamic> param in parametros)
                {
                    sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                }

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    listLibros.Add(new Libro()
                    {
                        Id = sqlDataReader.GetInt32(0),
                        NombreLibro = sqlDataReader.GetString(1),
                        Autor = sqlDataReader.GetString(2),
                        NombreEditorial = sqlDataReader.GetString(3),
                        ISDN = sqlDataReader.GetString(4)
                    });
                }
            }

            return listLibros;
        }

        public string EnviarDatos(string storeProcedure, Dictionary<string, dynamic> parametros)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_configuration["ConnectionStrings:BD"]))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(storeProcedure, sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (KeyValuePair<string, dynamic> param in parametros)
                {
                    sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                }

                return sqlCommand.ExecuteNonQuery() > 0? "Exitoso" : "Fallo";
            }
            }
        }
}

