using Microsoft.EntityFrameworkCore;

namespace TelemetriaPCan.Infrastructure.Data
{
    public class BaseRepository
    {

        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

    }
}
