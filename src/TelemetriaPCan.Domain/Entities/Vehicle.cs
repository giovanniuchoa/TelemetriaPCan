namespace TelemetriaPCan.Domain.Entities
{
    public class Vehicle
    {

        public int IdVehicle { get; set; }
        public string? SerialNumber { get; set; }
        public string? Vin { get; set; } //Vehicle Identification Number
        public DateTime? CreatedAt { get; set; }

    }
}
