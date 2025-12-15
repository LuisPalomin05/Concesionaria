namespace Concesionaria.Models
{
    public class Clientes
    {
        public int idCliente { get; set; }
        public string nombreCliente { get; set; } = string.Empty;
        public string apellidoCliente { get; set; } = string.Empty;
        public string dniCliente { get; set; } = string.Empty;
        public string direccionCliente { get; set; } = string.Empty;
        public string telefonoCliente { get; set; } = string.Empty;
        public string emailCliente { get; set; } = string.Empty;
        public DateTime fechaNacimientoCliente { get; set; }

    }
}
