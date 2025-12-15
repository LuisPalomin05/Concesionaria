

using ConcesionariaAPI.Models;

namespace ConcesionariaAPI.Repositorio.Interfaces
{
    public interface IVehiculos
    {
        IEnumerable<Vehiculos> ListarVehiculos();

        Vehiculos InsertarVehiculo(Vehiculos vehiculos);


    }
}
