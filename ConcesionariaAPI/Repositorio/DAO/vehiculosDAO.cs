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
            throw new NotImplementedException();
        }

        public IEnumerable<Vehiculos> ListarVehiculos()
        {
            throw new NotImplementedException();
        }
    }
}
