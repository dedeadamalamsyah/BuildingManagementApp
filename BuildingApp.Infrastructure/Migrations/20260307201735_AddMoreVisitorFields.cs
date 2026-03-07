using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuildingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreVisitorFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Visitors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "Visitors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "Visitors");
        }
    }
}
