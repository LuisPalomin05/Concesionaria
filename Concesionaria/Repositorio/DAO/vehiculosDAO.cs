namespace Concesionaria.Repositorio.DAO
{
    public class vehiculosDAO
    {
        private readonly string cadena = string.Empty;

        public vehiculosDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }


    }
}
