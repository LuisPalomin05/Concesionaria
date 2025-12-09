namespace ConcesionariaWeb.Models
{
    public class Ventas
    {
        public int idVenta { get; set; }
        public int idCliente { get; set; }
        public int idVehiculo { get; set; }
        public int idEmpleado { get; set; }
        public DateTime fechaVenta { get; set; }
        public int precioVenta { get; set; }
        public int metodoPago { get; set; }
        public int estadoVenta { get; set; }


    }
}
