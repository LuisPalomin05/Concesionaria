using Concesionaria.Models;

namespace Concesionaria.Repositorio.Interfaces
{
    public interface IVehiculos
    {
        IEnumerable<Vehiculos> GetAllVehiculos();
        Vehiculos GetVehiculos(int id);
        string insertVehiculos(Vehiculos vehiculo);
        string updateVehiculos(Vehiculos vehiculo);
    }
}
