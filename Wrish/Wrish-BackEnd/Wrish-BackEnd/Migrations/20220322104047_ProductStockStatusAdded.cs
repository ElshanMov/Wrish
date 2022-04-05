using Microsoft.EntityFrameworkCore.Migrations;

namespace Wrish_BackEnd.Migrations
{
    public partial class ProductStockStatusAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StockStatus",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockStatus",
                table: "Products");
        }
    }
}
