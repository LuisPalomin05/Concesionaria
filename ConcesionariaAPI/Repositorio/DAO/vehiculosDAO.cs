using ConcesionariaAPI.Models;
using ConcesionariaAPI.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;


namespace ConcesionariaAPI.Repositorio.DAO
{
    public class vehiculosDAO : IVehiculos
    {
        private readonly string cadena = string.Empty;

        public vehiculosDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public IEnumerable<Vehiculos> ListarVehiculos()
        {
            List<Vehiculos> lista = new List<Vehiculos>();
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_listar_vehiculos", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehiculos vehiculo = new Vehiculos()
                        {
                            idVehiculo = dr.GetInt32(0),
                            marcaVehiculo = dr.GetString(1),
                            modeloVehiculo = dr.GetString(2),
                            anioVehiculo = dr.GetInt32(3),
                            precioVehiculo = dr.GetDecimal(4),
                            disponibilidadVehiculo = dr.GetInt32(5),
                            colorVehiculo = dr.GetString(6),
                        };
                        lista.Add(vehiculo);
                    }
                }
            }
            return lista;
        }



    }
}
