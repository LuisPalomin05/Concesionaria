namespace ConcesionariaAPI.Models
{
    public class Ventas
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdVehiculo { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal PrecioVenta { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public string EstadoVenta { get; set; }= string.Empty;


    }
}
