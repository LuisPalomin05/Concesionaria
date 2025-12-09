using Concesionaria.Models;
using Concesionaria.Repositorio;
using Microsoft.Data.SqlClient;

namespace Concesionaria.Repositorio.DAO
{
    public class tipoVehiculoDAO
    {
        private readonly string cadena = string.Empty;
        public tipoVehiculoDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public IEnumerable<TipoVehiculos> GetTipoVehiculos()
        {
            List<TipoVehiculos> lista = new List<TipoVehiculos>();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarTipoVehiculos", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new TipoVehiculos
                    {
                    idTipoVehiculo = dr.GetInt32(0),
                    nombreTipoVehiculo = dr.GetString(1)

                    });
                }
                dr.Close();
            }
            return lista;
        }
    }
}
