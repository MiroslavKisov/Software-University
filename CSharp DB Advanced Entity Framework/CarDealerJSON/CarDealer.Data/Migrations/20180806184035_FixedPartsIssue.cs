using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Data.Migrations
{
    public partial class FixedPartsIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Parts",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Parts");
        }
    }
}
