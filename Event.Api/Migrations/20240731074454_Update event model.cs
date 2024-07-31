using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event.Api.Migrations
{
    public partial class Updateeventmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventItems");

            migrationBuilder.DropColumn(
                name: "IsFull",
                table: "EventItems");

            migrationBuilder.DropColumn(
                name: "Organizer",
                table: "EventItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "EventItems");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EventItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventItems");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsFull",
                table: "EventItems",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Organizer",
                table: "EventItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "EventItems",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
