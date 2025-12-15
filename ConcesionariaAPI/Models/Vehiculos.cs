namespace ConcesionariaAPI.Models
{
    public class Vehiculos
    {
        public int IdVehiculo { get; set; }
        public string MarcaVehiculo { get; set; } = string.Empty;
        public string ModeloVehiculo { get; set; } = string.Empty;
        public decimal PrecioVehiculo { get; set; }
        public int StockVehiculo { get; set; }
        public string ColorVehiculo { get; set; } = string.Empty;
        public string DescripcionVehiculo { get; set; } = string.Empty;


    }
}
