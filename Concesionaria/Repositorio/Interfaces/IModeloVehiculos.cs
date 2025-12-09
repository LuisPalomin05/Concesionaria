using Concesionaria.Models;

namespace Concesionaria.Repositorio.Interfaces
{
    public interface IModeloVehiculos
    {
        IEnumerable<ModeloVehiculos> GetAllModeloVehiculos();
        Empleados GetModeloVehiculo(int id);

    }
   
}
