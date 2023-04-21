using CNG.EntityFrameworkCore;
using Country.Application.Repositories.EF.Main;
using Country.Domain.Entities.EF.Main;
using Microsoft.EntityFrameworkCore;

namespace Country.Persistence.Repositories.EF.Main
{
    public class TranslationRepository : EfRepository<Translation, Guid>, ITranslationRepository
    {
        public TranslationRepository(DbContext context) : base(context)
        {
        }
    }
}
