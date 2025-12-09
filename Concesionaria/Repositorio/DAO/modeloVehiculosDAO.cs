using Concesionaria.Models;
using Concesionaria.Repositorio;
using Microsoft.Data.SqlClient;

namespace Concesionaria.Repositorio.DAO
{
    public class modeloVehiculosDAO
    {
        private readonly string cadena = string.Empty;
        public modeloVehiculosDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public IEnumerable<ModeloVehiculos> GetModeloVehiculos()
        {
            List<ModeloVehiculos> lista = new List<ModeloVehiculos>();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarModeloVehiculos", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new ModeloVehiculos
                    {
                        idModeloVehiculo= dr.GetInt32(0),
                        nombreModeloVehiculo= dr.GetString(1)
                    });
                }
                dr.Close();
            }
            return lista;
        }

    }
}
