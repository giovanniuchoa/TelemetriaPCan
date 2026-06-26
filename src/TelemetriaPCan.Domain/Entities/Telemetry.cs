using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetriaPCan.Domain.Entities
{
    public class Telemetry
    {

        public string IdTelemetry { get; set; } = null!;
        public int IdVehicle { get; set; }
        public decimal FuelLevel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
