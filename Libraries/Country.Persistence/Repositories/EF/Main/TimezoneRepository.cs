using CNG.EntityFrameworkCore;
using Country.Application.Repositories.EF.Main;
using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;

namespace Country.Persistence.Repositories.EF.Main
{
    public class TimezoneRepository : EfRepository<Timezone, Guid>, ITimezoneRepository
    {
        public TimezoneRepository(DbContext context) : base(context)
        {
        }
    }
}
