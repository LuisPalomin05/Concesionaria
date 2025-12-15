namespace ConcesionariaAPI.Models
{
    public class Ventas
    {
        public int idVenta { get; set; }
        public int idCliente { get; set; }
        public int idVehiculo { get; set; }
        public int idEmpleado { get; set; }
        public DateTime fechaVenta { get; set; }
        public decimal precioVenta { get; set; }
        public string metodoPago { get; set; } = string.Empty;
        public string estadoVenta { get; set; }= string.Empty;


    }
}
