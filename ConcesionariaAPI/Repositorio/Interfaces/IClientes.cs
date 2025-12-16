

using ConcesionariaAPI.Models;

namespace ConcesionariaAPI.Repositorio.Interfaces
{
    public interface IClientes
    {
        IEnumerable<Clientes> ListarClientes();
        IEnumerable<Clientes> BuscarClientesPorDNI(string nombre);

        Clientes InsertarCliente(Clientes clientes);


    }
}
