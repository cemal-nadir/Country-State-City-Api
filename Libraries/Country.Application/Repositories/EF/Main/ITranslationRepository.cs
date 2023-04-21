using CNG.Abstractions.Repositories;
using Country.Domain.Entities.EF.Main;

namespace Country.Application.Repositories.EF.Main
{
    public interface ITranslationRepository : IEfRepository<Translation, Guid>
    {
    }
}
