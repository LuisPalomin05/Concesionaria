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
            throw new NotImplementedException();
        }

        public IEnumerable<Empleados> ListarEmpleados()
        {
            throw new NotImplementedException();
        }
    }
}
