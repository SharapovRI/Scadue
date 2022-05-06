using Scadue.Business.Models.Request;
using Scadue.Business.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Scadue.Business.Interfaces
{
    public interface IAdministrativeUnitService
    {
        Task<AdministrativeUnitResponseBusinessModel> CreateAsync(AdministrativeUnitRequestBusinessModel hotelModel);

        Task<AdministrativeUnitResponseBusinessModel> GetAsync(int id);

        Task<IEnumerable<AdministrativeUnitResponseBusinessModel>> GetListAsync();

        Task<AdministrativeUnitResponseBusinessModel> GetCountryAsync(string unitName);

        Task<IList<AdministrativeUnitResponseBusinessModel>> GetChildUnitsAsync(string parentName);

        Task<AdministrativeUnitResponseBusinessModel> GetUnitByNameAsync(string unitName);

        Task<AdministrativeUnitResponseBusinessModel> UpdateAsync(AdministrativeUnitRequestBusinessModel hotelModel);

        Task<AdministrativeUnitResponseBusinessModel> DeleteAsync(int id);
    }
}
