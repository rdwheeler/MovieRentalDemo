// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace SettingService.Infrastructure
{
    partial class MainDbContextModel
    {
        partial void Initialize()
        {
            var country = CountryEntityType.Create(this);

            CountryEntityType.CreateAnnotations(country);

            AddAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
            AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            AddAnnotation("ProductVersion", "6.0.0-preview.5.21301.9");
            AddAnnotation("Relational:MaxIdentifierLength", 63);
        }
    }
}
