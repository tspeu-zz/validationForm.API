namespace pruebaJM.API.Models
{
    // [Serializable]
    public class VehicleRequest
    {
        public int VehicleId { get; set; }
        public string Type { get; set; }
        public string ManufacturerNameShort { get; set; }
        public decimal Price { get; set; }
    }
}