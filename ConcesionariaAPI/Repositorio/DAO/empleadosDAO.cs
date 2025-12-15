using ConcesionariaAPI.Models;
using ConcesionariaAPI.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;

namespace ConcesionariaAPI.Repositorio.DAO
{
    public class empleadosDAO : IEmpleados
    {
        private readonly string cadena = string.Empty;

        public empleadosDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public IEnumerable<Empleados> ListarEmpleados()
        {
           
            List<Empleados> lista = new List<Empleados>();
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand("sp_listar_empleados", conexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Empleados empleado = new Empleados()
                        {
                            idEmpleado = dr.GetInt32(0),
                            nombreEmpleado = dr.GetString(1),
                            apellidoEmpleado = dr.GetString(2),
                            dniEmpleado = dr.GetString(3),
                            direccionEmpleado = dr.GetString(4),
                            telefonoEmpleado = dr.GetString(5),
                            emailEmpleado = dr.GetString(6),
                        };
                        lista.Add(empleado);
                    }
                }
            }
            return lista;

        }
    }
}
