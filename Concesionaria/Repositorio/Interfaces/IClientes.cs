using Concesionaria.Models;

namespace Concesionaria.Repositorio.Interfaces
{
    public interface IClientes
    {
        IEnumerable<Clientes> GetAllClientes();
        Clientes GetClientes();
        string insertClientes(Clientes cliente);
        string updateClientes(Clientes cliente);

    }
}
