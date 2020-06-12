using Microsoft.EntityFrameworkCore.Migrations;

namespace Kennisbank.Migrations
{
    public partial class AddedPropertyFilePathToDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Document",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Document");
        }
    }
}
