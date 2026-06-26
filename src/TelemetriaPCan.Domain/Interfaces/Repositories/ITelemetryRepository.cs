using System;
using System.Collections.Generic;
using System.Text;
using TelemetriaPCan.Domain.Entities;

namespace TelemetriaPCan.Domain.Interfaces.Repositories
{
    public interface ITelemetryRepository
    {

        Task<bool> CreateAsync(Telemetry model);

    }
}
