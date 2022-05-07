using Scadue.Business.Models.Request;
using Scadue.Business.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scadue.Business.Interfaces
{
    public interface IUnitInfoService
    {
        Task<IList<BuildingResponseBusinessModel>> GetUnitInfo(int adminLevel, string unitName);
        Task<BuildingResponseBusinessModel> CreateAsync(BuildingRequestBusinessModel buildingRequestBusinessModel);

        Task GetAsync(int id);

        Task GetListAsync();

        Task UpdateAsync();

        Task DeleteAsync(int id);
    }
}
