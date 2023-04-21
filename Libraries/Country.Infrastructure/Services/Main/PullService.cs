using CNG.Http.Services;
using Country.Infrastructure.Roots.Main;

namespace Country.Infrastructure.Services.Main
{
    public class PullService : IPullService
    {
        private readonly IHttpClientService _client;

        public PullService(IHttpClientService httpClientService)
        {
            _client = httpClientService;
        }

        public async Task<List<CountryRoot>?> PullCountries(CancellationToken cancellationToken = default)
        {
            var root = await _client.GetAsync<List<CountryRoot>>(Defaults.Main.CountryUrl, cancellationToken);
            return root.Data;
        }
        public async Task<List<StateRoot>?> PullStates(CancellationToken cancellationToken = default)
        {
            var root = await _client.GetAsync<List<StateRoot>>(Defaults.Main.StateUrl, cancellationToken);
            return root.Data;
        }
        public async Task<List<CityRoot>?> PullCities(CancellationToken cancellationToken = default)
        {
            var root = await _client.GetAsync<List<CityRoot>>(Defaults.Main.CityUrl, cancellationToken);
            return root.Data;
        }
    }
}
