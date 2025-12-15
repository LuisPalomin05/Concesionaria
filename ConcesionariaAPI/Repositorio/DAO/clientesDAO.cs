using Concesionaria.Models;
using Concesionaria.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;

namespace ConcesionariaAPI.Repositorio.DAO
{
    public class clientesDAO : IClientes
    {
        private readonly string cadena = string.Empty;

        public clientesDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public IEnumerable<Clientes> BuscarClientesPorDNI(string dni)
        {
            List<Clientes> lista = new List<Clientes>();

            using (SqlConnection cn = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand("sp_buscar_cliente_dni", cn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dni", dni);

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Clientes
                        {
                            idCliente = dr.GetInt32(0),
                            nombreCliente = dr.GetString(1),
                            apellidoCliente = dr.GetString(2),
                            dniCliente = dr.GetString(3),
                            direccionCliente = dr.IsDBNull(4) ? string.Empty : dr.GetString(4),
                            telefonoCliente = dr.IsDBNull(5) ? string.Empty : dr.GetString(5),
                            emailCliente = dr.IsDBNull(6) ? string.Empty : dr.GetString(6),
                            fechaNacimientoCliente = dr.GetDateTime(7)
                        });
                    }
                }
            }

            return lista;
        }


        public Clientes InsertarCliente(Clientes clientes)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_cliente", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", clientes.nombreCliente);
                cmd.Parameters.AddWithValue("@apellido", clientes.apellidoCliente);
                cmd.Parameters.AddWithValue("@dni", clientes.dniCliente);
                cmd.Parameters.AddWithValue("@direccion", clientes.direccionCliente);
                cmd.Parameters.AddWithValue("@telefono", clientes.telefonoCliente);
                cmd.Parameters.AddWithValue("@email", clientes.emailCliente);

                cn.Open();
                clientes.idCliente = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return clientes;
        }


        public IEnumerable<Clientes> ListarClientes()
        {
            List<Clientes> lista = new List<Clientes>();

            using (SqlConnection cn = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand("sp_listar_clientes", cn))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Clientes
                        {
                            idCliente = dr.GetInt32(0),
                            nombreCliente = dr.GetString(1),
                            apellidoCliente = dr.GetString(2),
                            dniCliente = dr.GetString(3),

                            direccionCliente = dr.IsDBNull(4) ? string.Empty : dr.GetString(4),
                            telefonoCliente = dr.IsDBNull(5) ? string.Empty : dr.GetString(5),
                            emailCliente = dr.IsDBNull(6) ? string.Empty : dr.GetString(6),

                            fechaNacimientoCliente = dr.GetDateTime(7)
                        });
                    }
                }
            }

            return lista;
        }


    }
}
