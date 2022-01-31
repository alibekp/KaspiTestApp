using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaspiTestApp.Migrations
{
    public partial class DbNamesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "provider",
                table: "Payments",
                newName: "Provider");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Payments",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Provider",
                table: "Payments",
                newName: "provider");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Payments",
                newName: "date");
        }
    }
}
