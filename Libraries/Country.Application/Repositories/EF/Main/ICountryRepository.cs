using CNG.Abstractions.Repositories;

namespace Country.Application.Repositories.EF.Main
{
    public interface ICountryRepository : IEfRepository<Domain.Entities.EF.Main.Country, int>
    {
       
    }
}
