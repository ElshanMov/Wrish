using Microsoft.EntityFrameworkCore.Migrations;

namespace Wrish_BackEnd.Migrations
{
    public partial class SizeTableFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeCount",
                table: "ProductSizes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeCount",
                table: "ProductSizes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
