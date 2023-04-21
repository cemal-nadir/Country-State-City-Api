using CNG.EntityFrameworkCore.Enums;
using CNG.EntityFrameworkCore.Extensions;
using CNG.EntityFrameworkCore.Models;
using Country.Domain.Entities.EF.Main;
using Country.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Country.Persistence.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext()
        {

        }
        public MainContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SetDataType(DatabaseType.PostgreSql);
            modelBuilder.MapConfiguration();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<City>? Cities { get; set; }
        public DbSet<global::Country.Domain.Entities.EF.Main.Country>? Countries { get; set; }
        public DbSet<Language>? Languages { get; set; }
        public DbSet<State>? States { get; set; }
        public DbSet<Timezone>? Timezones { get; set; }
        public DbSet<Translation>? Translations { get; set; }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainContext>
    {
        public MainContext CreateDbContext(string[] args) =>
            MyDbContextDesignTimeFactoryExtensions.CreateDbContext<MainContext>(args,
                new DatabaseOption(DatabaseType.PostgreSql, "localhost", "CountryDB", "postgres", "cMYZ9ATA7P__",
                    1000));
    }
}
