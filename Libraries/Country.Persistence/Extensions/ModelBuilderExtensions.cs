using System.Reflection;
using CNG.EntityFrameworkCore.Enums;
using Microsoft.EntityFrameworkCore;

namespace Country.Persistence.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void MapConfiguration(this ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public static void SetDataType(this ModelBuilder mb,DatabaseType databaseType)
        {
            var mBuilders = mb.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(x => x is { IsOwnership: false, DeleteBehavior: DeleteBehavior.Cascade }).ToList();

            foreach (var fk in mBuilders) fk.DeleteBehavior = DeleteBehavior.Restrict;

            var properties = mb.Model.GetEntityTypes().SelectMany(t => t.GetProperties().OrderBy(x => x.Name));
            foreach (var property in properties)
            {
                if (property.ClrType == typeof(decimal)) property.SetColumnType("decimal(18,4)");

                if (property.ClrType == typeof(bool)) property.SetDefaultValue(false);

                if (property.ClrType == typeof(byte) || property.ClrType == typeof(short) ||
                    property.ClrType == typeof(int) || property.ClrType == typeof(long) ||
                    property.ClrType == typeof(float) || property.ClrType == typeof(double) || property.ClrType == typeof(decimal))
                {
                    if (!property.IsNullable && !property.IsPrimaryKey() && !property.IsForeignKey())
                        property.SetDefaultValue(0);
                }
                else if (property.ClrType == typeof(string))
                {
                    property.IsNullable = false;
                    property.SetDefaultValueSql(databaseType is DatabaseType.MsSql ? "SPACE(0)" : "NULL");
                }
                else if (property.ClrType == typeof(DateTime) && !property.IsNullable)
                {
                    if (!property.IsNullable)
                        property.SetDefaultValueSql("Convert(Date,GetDate())");
                }
                else if (property.ClrType == typeof(TimeSpan))
                {
                    if (!property.IsNullable)
                        property.SetDefaultValueSql("'00:00'");
                }
                else if (property.ClrType == typeof(Guid))
                {
                    if (!property.IsNullable && !property.IsPrimaryKey() && !property.IsForeignKey())
                        property.SetDefaultValueSql("NewId()");
                }

                switch (property.Name)
                {
                    case "Zip":
                        property.SetMaxLength(10);
                        break;
                    case "Phone":
                    case "Barcode":
                        property.SetMaxLength(15);
                        break;
                    case "Country":
                    case "City":
                    case "State":
                    case "Sku":
                    case "UniqueId":
                    case "ErpCode":
                    case "Description":
                        property.SetMaxLength(100);
                        break;

                    case "CreatedUser":
                    case "UpdatedUser":
                        property.SetMaxLength(61);
                        property.IsNullable = true;
                        break;

                    case "CreatedAt":
                    case "UpdatedAt":
                        property.SetDefaultValueSql("GetDate()");
                        break;
                }
            }
        }
    }
}
