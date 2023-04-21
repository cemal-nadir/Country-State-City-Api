using System.Reflection;
using Country.Application.Repositories.EF.Main;
using Country.Application.Services.Main;
using Country.Domain.Entities.EF.Main;
using Country.Infrastructure.Roots.Main;
using Country.Infrastructure.Services.Main;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Country.Persistence.Services.Main
{
    public class MainService:IMainService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ITimezoneRepository _timezoneRepository;
        private readonly ITranslationRepository _translationRepository;
        private readonly IPullService _pullService;

        public MainService(ICountryRepository countryRepository, IPullService pullService, ITimezoneRepository timezoneRepository, ITranslationRepository translationRepository, IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _countryRepository = countryRepository;
            _pullService = pullService;
            _timezoneRepository = timezoneRepository;
            _translationRepository = translationRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        #region Database Services

        public async Task<bool> DatabaseIsReady(CancellationToken cancellationToken = default)
        {
            var country = _countryRepository.AsNoTracking.AnyAsync( cancellationToken);
            var state = _stateRepository.AsNoTracking.AnyAsync( cancellationToken);
            var city = _cityRepository.AsNoTracking.AnyAsync( cancellationToken);

            await Task.WhenAll(country, state, city);
            return country.Result && state.Result && city.Result;
        }

       

        #endregion

        #region Download Services

        public async Task DownloadCountries(CancellationToken cancellationToken = default)
        {
            var remoteCountries = _pullService.PullCountries(cancellationToken);
            var currentCountries =
                 _countryRepository.GetAllAsync(null, cancellationToken);
            await Task.WhenAll(remoteCountries, currentCountries);

            if (remoteCountries.Result is null) return;

            var updateEntities = remoteCountries.Result.Where(x => currentCountries.Result.Any(y => y.Id == x.Id))
                .ToList();
            var insertEntities = remoteCountries.Result.Where(x => currentCountries.Result.All(y => y.Id != x.Id))
                .ToList();

            if (insertEntities.Any())
            {
                await _countryRepository.InsertRangeAsync(ToModel(insertEntities), cancellationToken);

                await _timezoneRepository.InsertRangeAsync(ToModelTimezone(insertEntities), cancellationToken);

                await _translationRepository.InsertRangeAsync(ToModelTranslation(insertEntities), cancellationToken);

            }

            if (updateEntities.Any())
            {
                await _countryRepository.UpdateRangeAsync(ToModel(updateEntities), cancellationToken);

                var timezones = await _timezoneRepository.AsNoTracking.Where(x =>
                      updateEntities.Select(y => y.Id).ToList().Contains(x.CountryId)).ToListAsync(cancellationToken);

                await _timezoneRepository.DeleteRangeAsync(timezones, cancellationToken);

                await _timezoneRepository.InsertRangeAsync(ToModelTimezone(updateEntities), cancellationToken);

                var translations = await _translationRepository.AsNoTracking
                    .Where(x => updateEntities.Select(y => y.Id).ToList().Contains(x.CountryId))
                    .ToListAsync(cancellationToken);

                await _translationRepository.DeleteRangeAsync(translations, cancellationToken);

                await _translationRepository.InsertRangeAsync(ToModelTranslation(updateEntities), cancellationToken);
            }



        }
        public async Task DownloadStates(CancellationToken cancellationToken = default)
        {
            var remoteStates = _pullService.PullStates(cancellationToken);
            var currentStates = _stateRepository.GetAllAsync(null, cancellationToken);
            await Task.WhenAll(remoteStates, currentStates);

            if (remoteStates.Result is null) return;

            var updateEntities = remoteStates.Result.Where(x => currentStates.Result.Any(y => y.Id == x.Id))
                .ToList();
            var insertEntities = remoteStates.Result.Where(x => currentStates.Result.All(y => y.Id != x.Id))
                .ToList();

            if (insertEntities.Any())
            {

                await _stateRepository.InsertRangeAsync(ToModel(insertEntities), cancellationToken);

            }

            if (updateEntities.Any())
            {

                await _stateRepository.UpdateRangeAsync(ToModel(updateEntities), cancellationToken);

            }
        }
        public async Task DownloadCities(CancellationToken cancellationToken = default)
        {
            var remoteCities = _pullService.PullCities(cancellationToken);
            var currentCities = _cityRepository.GetAllAsync(null, cancellationToken);
            await Task.WhenAll(remoteCities, currentCities);

            if (remoteCities.Result is null) return;

            var updateEntities = remoteCities.Result.Where(x => currentCities.Result.Any(y => y.Id == x.Id))
                .ToList();
            var insertEntities = remoteCities.Result.Where(x => currentCities.Result.All(y => y.Id != x.Id))
                .ToList();

            if (insertEntities.Any())
            {

                await _cityRepository.InsertRangeAsync(ToModel(insertEntities), cancellationToken);

            }

            if (updateEntities.Any())
            {

                await _cityRepository.UpdateRangeAsync(ToModel(updateEntities), cancellationToken);

            }
        }

        #endregion

        #region Private Helpers

        #region Country

        private List<Domain.Entities.EF.Main.Country> ToModel(List<CountryRoot> roots) =>
        roots.Select(x => new Domain.Entities.EF.Main.Country
        {
            Id = x.Id,
            Name = x.Name,
            Capital = x.Capital,
            Currency = x.Currency,
            CurrencyName = x.CurrencyName,
            CurrencySymbol = x.CurrencySymbol,
            Emoji = x.Emoji,
            EmojiU = x.EmojiU,
            Iso2 = x.Iso2,
            Iso3 = x.Iso3,
            Latitude = x.Latitude,
            Longitude = x.Longitude,
            Native = x.Native,
            NumericCode = x.NumericCode,
            PhoneCode = x.PhoneCode,
            Region = x.Region,
            Tld = x.Tld,
            SubRegion = x.SubRegion
        }).ToList();
        private List<Timezone> ToModelTimezone(List<CountryRoot> roots)
        {
            List<Timezone> timezones = new();
            foreach (var entity in roots.Where(entity => entity.Timezones != null))
            {
                if (entity.Timezones == null) continue;
                timezones.AddRange(entity.Timezones.Select(x => new Timezone
                {
                    Abbreviation = x.Abbreviation,
                    CountryId = entity.Id,
                    GmtOffset = x.GmtOffset,
                    GmtOffsetName = x.GmtOffsetName,
                    TzName = x.TzName,
                    ZoneName = x.ZoneName
                }).ToList());
            }
            return timezones;
        }
        private List<Translation> ToModelTranslation(List<CountryRoot> roots) =>
            (from entity in roots.Where(entity => entity.Translation != null)
             where entity.Translation != null
             from value in entity.Translation?.GetType().GetProperties()
                 .Where(x => x.GetValue(entity.Translation, null) != null) ?? Array.Empty<PropertyInfo>()
             let languageId = (typeof(CountryRoot.Translations).GetProperty(value.Name))
                 ?.GetCustomAttribute<JsonPropertyAttribute>()
                 ?.PropertyName
             select new Translation()
             {
                 CountryId = entity.Id,
                 LanguageId = languageId,
                 Description = value.GetValue(entity.Translation, null)?.ToString()
             }).ToList();


        #endregion

        #region State

        private List<State> ToModel(List<StateRoot> roots) =>
            roots.Select(x => new State
            {
                CountryCode = x.CountryCode,
                CountryId = x.CountryId,
                CountryName = x.CountryName,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Name = x.Name,
                StateCode = x.StateCode,
                Type = x.Type,
                Id = x.Id,
            }).ToList();

        #endregion

        #region City

        private List<City> ToModel(List<CityRoot> roots) =>
            roots.Select(x => new City
            {
                CountryCode = x.CountryCode,
                CountryId = x.CountryId,
                CountryName = x.CountryName,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Name = x.Name,
                StateCode = x.StateCode,
                Id = x.Id,
                StateId = x.StateId,
                StateName = x.StateName,
                WikiDataId = x.WikiDataId
            }).ToList();

        #endregion

        #endregion

    }
}
