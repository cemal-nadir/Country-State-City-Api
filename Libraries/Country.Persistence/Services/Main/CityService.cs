using AutoMapper;
using Country.Application.Dtos.Main;
using Country.Application.Repositories.EF.Main;
using CNG.Core;
using Country.Application.Services.Main;
using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;

namespace Country.Persistence.Services.Main
{
    public class CityService : ServiceRepository<City, CityDto, int, ICityRepository>,ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository repository, IMapper mapper, ICityRepository cityRepository) : base(repository, mapper)
        {
            _mapper = mapper;
            _cityRepository = cityRepository;
        }

        public async Task<List<SelectList<int>>> CitySelectList(int stateId, CancellationToken cancellationToken = default)
        {
            return await _cityRepository.AsNoTracking.Where(x => x.StateId == stateId).Select(x => new SelectList<int>(x.Id, x.Name ?? "")).ToListAsync(cancellationToken);
        }

        public async Task<List<CitiesDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var models = await _cityRepository.AsNoTracking
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<CitiesDto>>(models);
        }

    }
}
