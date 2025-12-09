using Concesionaria.Models;

namespace Concesionaria.Repositorio.Interfaces
{
    public interface ITipoEmpleado
    {
        IEnumerable<TipoEmpleados> GetAllTipoEmpleado();
        TipoEmpleados GetTipoEmpleados(int id);

    }
}
