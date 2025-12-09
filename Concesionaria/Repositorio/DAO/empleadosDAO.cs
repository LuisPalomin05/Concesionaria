using Concesionaria.Models;
using Concesionaria.Repositorio;
using Microsoft.Data.SqlClient;

namespace Concesionaria.Repositorio.DAO
{
    public class empleadosDAO
    {
        private readonly string cadena = string.Empty;

        public empleadosDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public Empleados GetEmpleado(int id)
        {
            return GetEmpleados().FirstOrDefault(e => e.idEmpleado == id);
        }

        public IEnumerable<Empleados> GetEmpleados()
        {
            List<Empleados> lista = new List<Empleados>();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEmpleados", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Empleados
                    {
                        idEmpleado = dr.GetInt32(0),
                        nombreEmpleado = dr.GetString(1),
                        apellidoEmpleado = dr.GetString(2),
                        dniEmpleado = dr.GetString(3),
                        direccionEmpleado = dr.GetString(4),
                        telefonoEmpleado = dr.GetString(5),
                        emailEmpleado = dr.GetString(6),
                        tipoEmpleado = dr.GetInt32(7)
                    });
                }
                dr.Close();
            }
            return lista;
        }

        public string insertEmpleados(Empleados empleado)
        {
            string mensaje = string.Empty;
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_InsertarEmpleado", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombreEmpleado", empleado.nombreEmpleado);
                    cmd.Parameters.AddWithValue("@apellidoEmpleado", empleado.apellidoEmpleado);
                    cmd.ExecuteNonQuery();
                    mensaje = "Empleado insertado correctamente.";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al insertar el empleado: " + ex.Message;
                }
            }
            return mensaje;
        }

        public string updateEmpleados(Empleados empleado)
        {
            string mensaje = string.Empty;
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ActualizarEmpleado", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", empleado.idEmpleado);
                    cmd.Parameters.AddWithValue("@nombreEmpleado", empleado.nombreEmpleado);
                    cmd.Parameters.AddWithValue("@apellidoEmpleado", empleado.apellidoEmpleado);
                    cmd.ExecuteNonQuery();
                    mensaje = "Empleado actualizado correctamente.";
                }
                catch (Exception ex)
                {
                    mensaje = "Error al actualizar el empleado: " + ex.Message;
                }
            }
            return mensaje;
        }


    }
}
