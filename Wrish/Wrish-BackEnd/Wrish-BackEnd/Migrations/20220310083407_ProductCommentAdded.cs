using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wrish_BackEnd.Migrations
{
    public partial class ProductCommentAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(maxLength: 500, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    FullName = table.Column<string>(maxLength: 50, nullable: true),
                    Rate = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComment_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComment_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_AppUserId",
                table: "ProductComment",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_ProductId",
                table: "ProductComment",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductComment");
        }
    }
}
