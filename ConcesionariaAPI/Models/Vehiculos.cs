namespace ConcesionariaAPI.Models
{
    public class Vehiculos
    {
        public int idVehiculo { get; set; }
        public string marcaVehiculo { get; set; } = string.Empty;
        public string modeloVehiculo { get; set; } = string.Empty;
        public int anioVehiculo { get; set; }
        public decimal precioVehiculo { get; set; }
        public int disponibilidadVehiculo { get; set; }
        public string colorVehiculo { get; set; } = string.Empty;
        public int descripcionVehiculo { get; set; }


    }
}
