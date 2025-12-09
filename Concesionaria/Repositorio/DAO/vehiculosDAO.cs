using Concesionaria.Models;
using Concesionaria.Repositorio;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Concesionaria.Repositorio.DAO
{
    public class vehiculosDAO
    {
        private readonly string cadena = string.Empty;

        public vehiculosDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public Vehiculos GetVehiculo(int id)
        {
            return GetVehiculos().FirstOrDefault(v => v.idVehiculo == id);
        }

        public IEnumerable<Vehiculos> GetVehiculos()
        {
            List<Vehiculos> lista = new List<Vehiculos>();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarVehiculos", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Vehiculos()
                    {
                        idVehiculo = dr.GetInt32(0),
                        marcaVehiculo = dr.GetInt32(1),
                        modeloVehiculo = dr.GetInt32(2),
                        anioVehiculo = dr.GetInt32(3),
                        tipoVehiculo = dr.GetInt32(4),
                        precioVehiculo = dr.GetInt32(5),
                        disponibilidadVehiculo = dr.GetInt32(6),
                        colorVehiculo = dr.GetInt32(7),
                        descripcionVehiculo = dr.GetInt32(8)







                    });

                }
                dr.Close();
            }
            return lista;
        }

        public string insertVehiculos(Vehiculos vehiculo)
        {
            string mensaje = string.Empty;
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarVehiculo", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Modelo", vehiculo.modeloVehiculo);
                    cmd.Parameters.AddWithValue("@Anio", vehiculo.anioVehiculo);
                    cmd.Parameters.AddWithValue("@Precio", vehiculo.precioVehiculo);
                    cmd.ExecuteNonQuery();

                    mensaje = "Vehículo insertado correctamente.";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al insertar el vehículo: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
                return mensaje;
            }
        }



    }
}
