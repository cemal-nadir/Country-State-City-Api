using AutoMapper;
using Country.Application.Dtos.Main;
using Country.Application.Repositories.EF.Main;
using Country.Domain.Entities.EF.Main;
using Country.Application.Services.Main;
using Microsoft.EntityFrameworkCore;
using CNG.Core;

namespace Country.Persistence.Services.Main
{
    public class StateService : ServiceRepository<State, StateDto, int, IStateRepository>,IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public StateService(IStateRepository repository, IMapper mapper, IStateRepository stateRepository) : base(repository, mapper)
        {
            _mapper = mapper;
            _stateRepository = stateRepository;
        }
        public async Task<List<StatesDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var models = await _stateRepository.AsNoTracking.Include(x=>x.Cities)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<StatesDto>>(models);
        }
        public async Task<List<SelectList<int>>> StateSelectList(int countryId, CancellationToken cancellationToken = default)
        {
            return await _stateRepository.AsNoTracking.Where(x => x.CountryId == countryId).Select(x => new SelectList<int>(x.Id, x.Name ?? "")).ToListAsync(cancellationToken);
        }


    }
}
