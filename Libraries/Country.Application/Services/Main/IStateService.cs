using Country.Application.Dtos.Main;
using CNG.Abstractions.Repositories;
using CNG.Core;

namespace Country.Application.Services.Main
{
    public interface IStateService:IServiceRepository<StateDto,int>
    {
        Task<List<SelectList<int>>> StateSelectList(int countryId, CancellationToken cancellationToken = default);
        Task<List<StatesDto>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
