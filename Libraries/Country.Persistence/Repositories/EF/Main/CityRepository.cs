using CNG.Core;
using CNG.EntityFrameworkCore;
using Country.Application.Repositories.EF.Main;
using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;

namespace Country.Persistence.Repositories.EF.Main;

public class CityRepository : EfRepository<City, int>, ICityRepository
{
    public CityRepository(DbContext context) : base(context)
    {
    }

    public async Task<List<SelectList<int>>> SelectListAsync(int stateId, CancellationToken cancellationToken = default)
    {
        return await AsNoTracking.Where(x => x.StateId == stateId).Select(x => new SelectList<int>(x.Id, x.Name ?? "")).ToListAsync(cancellationToken);
    }
}