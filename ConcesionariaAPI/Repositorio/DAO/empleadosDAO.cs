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

        public Empleados InsertarEmpleado(Empleados empleados)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_empleado", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombreEmpleado", empleados.NombreEmpleado);
                cmd.Parameters.AddWithValue("@apellidoEmpleado", empleados.ApellidoEmpleado);
                cmd.Parameters.AddWithValue("@dniEmpleado", empleados.DniEmpleado);
                cmd.Parameters.AddWithValue("@direccionEmpleado", empleados.DireccionEmpleado);
                cmd.Parameters.AddWithValue("@telefonoEmpleado", empleados.TelefonoEmpleado);
                cmd.Parameters.AddWithValue("@emailEmpleado", empleados.EmailEmpleado);

                cn.Open();

                // Capturamos el ID generado
                empleados.IdEmpleado = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return empleados;
        }

        public IEnumerable<Empleados> ListarEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_empleados", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Empleados
                    {
                        IdEmpleado = dr.GetInt32(0),
                        NombreEmpleado = dr.GetString(1),
                        ApellidoEmpleado = dr.GetString(2),
                        DniEmpleado = dr.GetString(3),
                        DireccionEmpleado = dr.GetString(4),
                        TelefonoEmpleado = dr.GetString(5),
                        EmailEmpleado = dr.GetString(6)
                    });
                }
            }

            return lista;
        }
    }
}
