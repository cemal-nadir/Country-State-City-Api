using CNG.Core;
using CNG.EntityFrameworkCore;
using Country.Application.Repositories.EF.Main;
using Microsoft.EntityFrameworkCore;

namespace Country.Persistence.Repositories.EF.Main
{
    public class CountryRepository : EfRepository<Domain.Entities.EF.Main.Country, int>, ICountryRepository
    {
        public CountryRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<SelectList<int>>> SelectListAsync(CancellationToken cancellationToken = default)
        {
            return await AsNoTracking.Select(x => new SelectList<int>(x.Id, x.Name ?? "")).ToListAsync(cancellationToken);
        }
    }
}
