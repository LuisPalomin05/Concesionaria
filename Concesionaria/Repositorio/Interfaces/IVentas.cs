using Concesionaria.Models;

namespace Concesionaria.Repositorio.Interfaces
{
    public interface IVentas
    {
        IEnumerable<Ventas> GetAllVentas();
        Ventas GetVentas(int id);
        string insertVentas(Ventas venta);
        string updateVentas(Ventas venta);



    }
}
