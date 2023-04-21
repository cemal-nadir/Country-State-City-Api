using Country.Infrastructure.Roots.Main;

namespace Country.Infrastructure.Services.Main
{
    public interface IPullService
    {
        Task<List<CountryRoot>?> PullCountries(CancellationToken cancellationToken = default);

        Task<List<StateRoot>?> PullStates(CancellationToken cancellationToken = default);

        Task<List<CityRoot>?> PullCities(CancellationToken cancellationToken = default);

    }
}
