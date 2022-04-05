using Microsoft.EntityFrameworkCore.Migrations;

namespace Wrish_BackEnd.Migrations
{
    public partial class ProductsalesCountAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalesCount",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalesCount",
                table: "Products");
        }
    }
}
