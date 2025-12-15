using ConcesionariaAPI.Models;
using ConcesionariaAPI.Repositorio.Interfaces;
using Microsoft.Data.SqlClient;

namespace ConcesionariaAPI.Repositorio.DAO
{
    public class ventasDAO : IVentas
    {
        private readonly string cadena = string.Empty;

        public ventasDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }

        public Ventas CrearVenta(Ventas venta)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ventas> ListarVentas()
        {
            throw new NotImplementedException();
        }
    }
}
