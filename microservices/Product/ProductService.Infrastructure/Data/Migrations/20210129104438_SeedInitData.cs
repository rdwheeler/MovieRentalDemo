using Microsoft.EntityFrameworkCore.Migrations;
using Commerce.Infrastructure.EfCore;

namespace ProductService.Infrastructure.Data.Migrations
{
    public partial class SeedInitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.MigrateDataFromScript();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
