using Concesionaria.Models;
using Concesionaria.Repositorio;
using Microsoft.Data.SqlClient;

namespace Concesionaria.Repositorio.DAO
{
    public class clientesDAO
    {
        private readonly string cadena = string.Empty;

        public clientesDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public Clientes GetCliente(int id)
        {
            return GetClientes().FirstOrDefault(c => c.idCliente == id);
        }

        public IEnumerable<Clientes> GetClientes()
        {
            List<Clientes> lista = new List<Clientes>();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarClientes", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Clientes
                    {
                        idCliente = dr.GetInt32(0),
                        nombreCliente = dr.GetString(1),
                        apellidoCliente = dr.GetString(2),
                        dniCliente = dr.GetString(3),
                        direccionCliente = dr.GetString(4),
                        telefonoCliente = dr.GetString(5),
                        emailCliente = dr.GetString(6),
                        fechaNacimientoCliente = dr.GetDateTime(7)


                    });
                }
                dr.Close();
            }
            return lista;
        }

        public string insertClientes(Clientes cliente)
        {
            string mensaje = string.Empty;
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarCliente", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombreCliente", cliente.nombreCliente);
                    cmd.Parameters.AddWithValue("@apellidoCliente", cliente.apellidoCliente);
                    cmd.Parameters.AddWithValue("@telefonoCliente", cliente.telefonoCliente);
                    cmd.Parameters.AddWithValue("@emailCliente", cliente.emailCliente);
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente insertado correctamente.";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al insertar el cliente: " + ex.Message;
                }
            }
            return mensaje;
        }

        public string updateClientes(Clientes cliente)
        {
            string mensaje = string.Empty;
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizarCliente", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                    cmd.Parameters.AddWithValue("@nombreCliente", cliente.nombreCliente);
                    cmd.Parameters.AddWithValue("@apellidoCliente", cliente.apellidoCliente);
                    cmd.Parameters.AddWithValue("@telefonoCliente", cliente.telefonoCliente);
                    cmd.Parameters.AddWithValue("@emailCliente", cliente.emailCliente);
                    cmd.ExecuteNonQuery();
                    mensaje = "Cliente actualizado correctamente.";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al actualizar el cliente: " + ex.Message;
                }
            }
            return mensaje;
        }



    }
}
