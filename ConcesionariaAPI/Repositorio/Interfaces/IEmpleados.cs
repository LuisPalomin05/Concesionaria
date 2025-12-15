

using ConcesionariaAPI.Models;

namespace ConcesionariaAPI.Repositorio.Interfaces
{
    public interface IEmpleados
    {
        IEnumerable<Empleados> ListarEmpleados();

        Empleados InsertarEmpleado(Empleados empleados);

    }
}
