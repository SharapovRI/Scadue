using Microsoft.EntityFrameworkCore;
using Scadue.Data.Interfaces;
using Scadue.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scadue.Data.Repositories
{
    public class BuildingRepository : BaseRepository<BuildingEntity>, IBuildingRepository
    {
        public BuildingRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
        protected override IQueryable<BuildingEntity> SetWithIncludes => _set
            .Include(p => p.Unit);

        public async Task CreateRangeAsync(IList<BuildingEntity> entity)
        {
            _set.AddRange(entity);

            await _context.SaveChangesAsync();
        }
    }
}
