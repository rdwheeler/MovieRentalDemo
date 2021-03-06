using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace CustomerService.Infrastructure
{
    partial class MainDbContextModel
    {
        partial void Initialize()
        {
            var creditCard = CreditCardEntityType.Create(this);
            var customer = CustomerEntityType.Create(this);

            CreditCardEntityType.CreateForeignKey1(creditCard, customer);

            CreditCardEntityType.CreateAnnotations(creditCard);
            CustomerEntityType.CreateAnnotations(customer);

            AddAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");
            AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            AddAnnotation("ProductVersion", "6.0.0-preview.5.21301.9");
            AddAnnotation("Relational:MaxIdentifierLength", 63);
        }
    }
}
