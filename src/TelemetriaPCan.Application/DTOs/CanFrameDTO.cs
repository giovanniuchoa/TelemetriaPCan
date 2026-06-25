namespace TelemetriaPCan.Application.DTOs
{
    public class CanFrameDTO
    {

        public uint Id { get; init; }
        public byte[] Data { get; init; } = Array.Empty<byte>();
        public DateTimeOffset Timestamp { get; init; } = DateTimeOffset.UtcNow;
        public bool IsExtendedFrame { get; init; }
        public int DataLength => Data.Length;
        public string? SerialNumber { get; init; }
        public string? Vin { get; init; }

    }
}
