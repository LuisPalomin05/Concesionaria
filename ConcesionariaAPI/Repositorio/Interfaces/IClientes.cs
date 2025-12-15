

using Concesionaria.Models;

namespace Concesionaria.Repositorio.Interfaces
{
    public interface IClientes
    {
        IEnumerable<Clientes> ListarClientes();
        IEnumerable<Clientes> BuscarClientesPorDNI(string nombre);

        Clientes InsertarCliente(Clientes clientes);


    }
}
