using Concesionaria.Models;
using Concesionaria.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;

namespace ConcesionariaAPI.Repositorio.DAO
{
    public class clientesDAO: IClientes
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
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_buscar_clientes_por_dni", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@dniCliente", dni);
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Clientes cliente = new Clientes()
                        {
                            idCliente = dr.GetInt32(0),
                            nombreCliente = dr.GetString(1),
                            apellidoCliente = dr.GetString(2),
                            dniCliente = dr.GetString(3),
                            direccionCliente = dr.GetString(4),
                            telefonoCliente = dr.GetString(5),
                            emailCliente = dr.GetString(6),
                        };
                        lista.Add(cliente);
                    }
                }
            }
            return lista;


        }

        public IEnumerable<Clientes> ListarClientes()
        {
            
            List<Clientes> lista = new List<Clientes>();
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_listar_clientes", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Clientes cliente = new Clientes()
                        {
                            idCliente = dr.GetInt32(0),
                            nombreCliente = dr.GetString(1),
                            apellidoCliente = dr.GetString(2),
                            dniCliente = dr.GetString(3),
                            direccionCliente = dr.GetString(4),
                            telefonoCliente = dr.GetString(5),
                            emailCliente = dr.GetString(6),
                        };
                        lista.Add(cliente);
                    }
                }
            }
            return lista;


        }
    }
}
