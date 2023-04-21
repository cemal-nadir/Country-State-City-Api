using Country.Application.Dtos.Main;
using CNG.Abstractions.Repositories;
using CNG.Core;

namespace Country.Application.Services.Main
{
    public interface ICountryService:IServiceRepository<CountryDto,int>
    {
        Task<List<SelectList<int>>> CountrySelectList(CancellationToken cancellationToken = default);
        Task<CountriesDto> GetDetailAsync(int id, CancellationToken cancellationToken = default);
        Task<List<CountriesDto>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
