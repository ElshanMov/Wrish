using Microsoft.EntityFrameworkCore.Migrations;

namespace Wrish_BackEnd.Migrations
{
    public partial class FaqTableRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "QuestionTitle",
                table: "Faqs");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Faqs",
                maxLength: 3000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionsTitle",
                table: "Faqs",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "QuestionsTitle",
                table: "Faqs");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Faqs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Faqs",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "QuestionTitle",
                table: "Faqs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
