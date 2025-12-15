

using ConcesionariaAPI.Models;

namespace ConcesionariaAPI.Repositorio.Interfaces
{
    public interface IVentas
    {
        IEnumerable<Ventas> ListarVentas();

        Ventas CrearVenta(Ventas venta);



    }
}
