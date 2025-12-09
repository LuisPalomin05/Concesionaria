using Concesionaria.Models;

namespace Concesionaria.Repositorio.Interfaces
{
    public interface ITipoVehiculo
    {
        IEnumerable<TipoVehiculos> GetAllTipoVehiculos();
        TipoVehiculos GetTipoVehiculos(int id);



    }
}
