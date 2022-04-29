using Microsoft.EntityFrameworkCore;
using Scadue.Data.Interfaces;
using Scadue.Data.Models;
using System.Linq;

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
            .Include(p => p.ChildUnits);
    }
}
