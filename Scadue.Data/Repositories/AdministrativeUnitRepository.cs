using Microsoft.EntityFrameworkCore;
using Scadue.Data.Interfaces;
using Scadue.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Scadue.Data.Repositories
{
    public class AdministrativeUnitRepository : BaseRepository<AdministrativeUnitEntity>, IAdministrativeUnitRepository
    {
        public AdministrativeUnitRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
        protected override IQueryable<AdministrativeUnitEntity> SetWithIncludes => _set
            .Include(p => p.ParentAdministrativeUnit)
            .Include(p => p.ChildUnits)
            .Include(p => p.Buildings);

        public async Task<AdministrativeUnitEntity> GetUnitByName(string unit_name, bool IsCoordinateNeed = true)
        {
            if (IsCoordinateNeed)
            {
                return await SetWithIncludes.FirstOrDefaultAsync(p => p.Name == unit_name);
            }
            else
            {
                return await _set.FirstOrDefaultAsync(p => p.Name == unit_name);
            }
        }
    }
}
