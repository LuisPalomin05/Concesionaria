namespace Concesionaria.Repositorio.DAO
{
    public class clientesDAO
    {
        private readonly string cadena = string.Empty;

        public clientesDAO()
        {
            cadena = new ConfigurationBuilder().
                AddJsonFile("appsettings.json").
                Build().GetConnectionString("sql");
        }





    }
}
