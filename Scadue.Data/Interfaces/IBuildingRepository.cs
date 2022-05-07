using Scadue.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scadue.Data.Interfaces
{
    public interface IBuildingRepository : IBaseRepository<BuildingEntity>
    {
        Task CreateRangeAsync(IList<BuildingEntity> entity);
    }
}
