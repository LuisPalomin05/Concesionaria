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


    }
}
