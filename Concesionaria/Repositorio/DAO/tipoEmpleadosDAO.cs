using Concesionaria.Models;
using Concesionaria.Repositorio;
using Microsoft.Data.SqlClient;

namespace Concesionaria.Repositorio.DAO
{
    public class tipoEmpleadosDAO
    {
        private readonly string cadena = string.Empty;
        public tipoEmpleadosDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public IEnumerable<TipoEmpleados> GetTipoEmpleados()
        {
            List<TipoEmpleados> lista = new List<TipoEmpleados>();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTipoEmpleados", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new TipoEmpleados
                    {
                        idTipoEmpleado = dr.GetInt32(0),
                        nombreTipoEmpleado = dr.GetString(1)
                    });
                }
                dr.Close();
            }
            return lista;
        }


    }
}
