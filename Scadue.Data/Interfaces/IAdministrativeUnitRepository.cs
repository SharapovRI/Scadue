using Scadue.Data.Models;
using System.Threading.Tasks;

namespace Scadue.Data.Interfaces
{
    public interface IAdministrativeUnitRepository : IBaseRepository<AdministrativeUnitEntity>
    {
        Task<AdministrativeUnitEntity> GetUnitByName(string unit_name, bool IsCoordinateNeed = true);
    }
}
