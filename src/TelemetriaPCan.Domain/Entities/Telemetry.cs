using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetriaPCan.Domain.Entities
{
    public class Telemetry
    {

        public string IdTelemetry { get; set; }
        public int IdVehicle { get; set; }
        public decimal FuelLevel { get; set; }
    }
}
