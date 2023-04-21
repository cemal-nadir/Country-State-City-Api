using AutoMapper;
using CNG.Core;
using Country.Application.Dtos.Main;
using Country.Application.Repositories.EF.Main;
using Country.Application.Services.Main;
using Microsoft.EntityFrameworkCore;

namespace Country.Persistence.Services.Main
{
    public class CountryService:ServiceRepository<Domain.Entities.EF.Main.Country,CountryDto,int,ICountryRepository>,ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryService(ICountryRepository repository, IMapper mapper, ICountryRepository countryRepository) : base(repository, mapper)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
        }

        public async Task<List<CountriesDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
           var models=await _countryRepository.AsNoTracking.Include(x => x.States)!
               .ThenInclude(x => x.Cities)
               .Include(x=>x.Translations)!.ThenInclude(x=>x.Language)
               .Include(x=>x.Timezones)
                .ToListAsync(cancellationToken);
           return _mapper.Map<List<CountriesDto>>(models);
        }

        public  async Task<CountriesDto> GetDetailAsync(int id, CancellationToken cancellationToken = default)
        {
            var model = await _countryRepository.AsNoTracking.Include(x => x.States)!
                .ThenInclude(x => x.Cities)
                .Include(x => x.Translations)!.ThenInclude(x => x.Language)
                .Include(x => x.Timezones)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            return _mapper.Map<CountriesDto>(model);
        }

        public async Task<List<SelectList<int>>> CountrySelectList(CancellationToken cancellationToken = default)
        {
            return await _countryRepository.AsNoTracking.Select(x => new SelectList<int>(x.Id, x.Name ?? "")).ToListAsync(cancellationToken);
        }


    }
}
