using System;
using System.Collections.Generic;
using System.Text;

namespace TelemetriaPCan.Application.DTOs
{
    public class TelemetryDTO
    {
        public string? IdTelemetry { get; set; }
        public int? IdVehicle { get; set; }
        public decimal? FuelLevel { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
