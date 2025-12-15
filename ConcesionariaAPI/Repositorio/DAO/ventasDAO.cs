using ConcesionariaAPI.Models;
using ConcesionariaAPI.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;

namespace ConcesionariaAPI.Repositorio.DAO
{
    public class ventasDAO : IVentas
    {
        private readonly string cadena = string.Empty;

        public ventasDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public IEnumerable<Ventas> ListarVentas()
        {

            List<Ventas> lista = new List<Ventas>();
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_listar_ventas", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Ventas venta = new Ventas()
                        {
                            idVenta = dr.GetInt32(0),
                            idCliente = dr.GetInt32(1),
                            idEmpleado = dr.GetInt32(2),
                            idVehiculo = dr.GetInt32(3),
                            fechaVenta = dr.GetDateTime(4),
                            precioVenta = dr.GetDecimal(5),
                            metodoPago = dr.GetString(6),
                            estadoVenta = dr.GetString(7)

                        };
                        lista.Add(venta);
                    }
                }
            }
            return lista;
        }


    }
}
