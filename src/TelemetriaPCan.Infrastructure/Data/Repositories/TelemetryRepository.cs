using System;
using System.Collections.Generic;
using System.Text;
using TelemetriaPCan.Domain.Entities;
using TelemetriaPCan.Domain.Interfaces.Repositories;

namespace TelemetriaPCan.Infrastructure.Data.Repositories
{
    public class TelemetryRepository : BaseRepository, ITelemetryRepository
    {

        public TelemetryRepository(AppDbContext context) : base(context) { }

        public async Task<bool> CreateAsync(Telemetry model)
        {
            await _context.Telemetry.AddAsync(model);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
