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
    }
}
