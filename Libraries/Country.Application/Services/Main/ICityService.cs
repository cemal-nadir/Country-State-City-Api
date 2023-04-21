using Country.Application.Dtos.Main;
using CNG.Abstractions.Repositories;
using CNG.Core;

namespace Country.Application.Services.Main
{
    public interface ICityService:IServiceRepository<CityDto,int>
    {
        Task<List<SelectList<int>>> CitySelectList(int stateId, CancellationToken cancellationToken = default);
        Task<List<CitiesDto>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
