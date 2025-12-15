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

        public Vehiculos InsertarVehiculo(Vehiculos vehiculos)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_vehiculo", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@marcaVehiculo", vehiculos.MarcaVehiculo);
                cmd.Parameters.AddWithValue("@modeloVehiculo", vehiculos.ModeloVehiculo);
                cmd.Parameters.AddWithValue("@precioVehiculo", vehiculos.PrecioVehiculo);
                cmd.Parameters.AddWithValue("@stockVehiculo", vehiculos.StockVehiculo);
                cmd.Parameters.AddWithValue("@colorVehiculo", vehiculos.ColorVehiculo);
                cmd.Parameters.AddWithValue("@descripcionVehiculo", vehiculos.DescripcionVehiculo);

                cn.Open();

                
                vehiculos.IdVehiculo = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return vehiculos;
        }

        public IEnumerable<Vehiculos> ListarVehiculos()
        {
            List<Vehiculos> lista = new List<Vehiculos>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_vehiculos", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Vehiculos
                    {
                        IdVehiculo = dr.GetInt32(0),
                        MarcaVehiculo = dr.GetString(1),
                        ModeloVehiculo = dr.GetString(2),
                        PrecioVehiculo = dr.GetDecimal(3),
                        StockVehiculo = dr.GetInt32(4),
                        ColorVehiculo = dr.GetString(5),
                        DescripcionVehiculo = dr.GetString(6)
                    });
                }
            }

            return lista;
        }

    }
}
