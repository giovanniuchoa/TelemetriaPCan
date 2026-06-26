using System;
using System.Collections.Generic;
using System.Text;
using TelemetriaPCan.Application.DTOs;

namespace TelemetriaPCan.Application.Interfaces.Services
{
    public interface ITelemetryService
    {

        Task<bool> CreateAsync(TelemetryDTO dto);

        Task<bool> ProcessFramesAsync(CanFrameDTO dto);

    }
}
