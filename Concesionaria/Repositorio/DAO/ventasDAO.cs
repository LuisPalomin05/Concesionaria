using Concesionaria.Models;
using Concesionaria.Repositorio;
using Microsoft.Data.SqlClient;


namespace Concesionaria.Repositorio.DAO
{
    public class ventasDAO
    {
        private readonly string cadena = string.Empty;

        public ventasDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public Ventas GetCliente(int id)
        {
            return GetVentas().FirstOrDefault(v => v.idVenta == id);

        }

        public IEnumerable<Ventas> GetVentas()
        {
            List<Ventas> lista = new List<Ventas>();

            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ListarVentas", conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Ventas
                    {
                        idVenta = Convert.ToInt32(dr["idVenta"]),
                        idCliente = Convert.ToInt32(dr["idCliente"]),
                        idVehiculo = Convert.ToInt32(dr["idVehiculo"]),
                        idEmpleado = Convert.ToInt32(dr["idEmpleado"]),
                        fechaVenta = Convert.ToDateTime(dr["fechaVenta"]),
                        precioVenta = Convert.ToInt32(dr["precioVenta"]),
                        metodoPago = Convert.ToInt32(dr["metodoPago"]),
                        estadoVenta = Convert.ToInt32(dr["estadoVenta"])
                    });

                }

                dr.Close();
            }
            return lista;
        }

        public string insertVentas(Ventas ventas)
        {
            string mensaje = string.Empty;

            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {


                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarVentas", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCliente", ventas.idCliente);
                    cmd.Parameters.AddWithValue("@idVehiculo", ventas.idVehiculo);
                    cmd.Parameters.AddWithValue("@idEmpleado", ventas.idEmpleado);
                    cmd.Parameters.AddWithValue("@fechaVenta", ventas.fechaVenta);
                    cmd.Parameters.AddWithValue("@precioVenta", ventas.precioVenta);
                    cmd.Parameters.AddWithValue("@metodoPago", ventas.metodoPago);
                    cmd.Parameters.AddWithValue("@estadoVenta", ventas.estadoVenta);
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        mensaje = "Venta registrada correctamente.";
                    }
                    else
                    {
                        mensaje = "No se pudo registrar la venta.";
                    }
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                }
                finally
                {
                    conn.Close();

                }
                return mensaje;
            }
            }

        public string updateVentas(Ventas ventas)
        {

            string mensaje = string.Empty;
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizarVentas", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idVenta", ventas.idVenta);
                    cmd.Parameters.AddWithValue("@idCliente", ventas.idCliente);
                    cmd.Parameters.AddWithValue("@idVehiculo", ventas.idVehiculo);
                    cmd.Parameters.AddWithValue("@idEmpleado", ventas.idEmpleado);
                    cmd.Parameters.AddWithValue("@fechaVenta", ventas.fechaVenta);
                    cmd.Parameters.AddWithValue("@precioVenta", ventas.precioVenta);
                    cmd.Parameters.AddWithValue("@metodoPago", ventas.metodoPago);
                    cmd.Parameters.AddWithValue("@estadoVenta", ventas.estadoVenta);
                    int filas = cmd.ExecuteNonQuery();
                    if (filas > 0)
                    {
                        mensaje = "Venta actualizada correctamente.";

                    }
                    else
                    {
                        mensaje = "No se pudo actualizar la venta.";
                    }


                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
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
