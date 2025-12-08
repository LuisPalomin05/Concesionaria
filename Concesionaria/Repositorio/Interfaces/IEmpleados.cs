using Concesionaria.Models;

namespace Concesionaria.Repositorio.Interfaces
{
    public interface IEmpleados
    {
        IEnumerable<Empleados> GetAllEmpleados();
        Empleados GetEmpleados(int id);
        string insertEmpleados(Empleados empleado);
        string updateEmpleados(Empleados empleado);



    }
}
