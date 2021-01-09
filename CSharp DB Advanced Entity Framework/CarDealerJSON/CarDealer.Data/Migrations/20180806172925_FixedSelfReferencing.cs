using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Data.Migrations
{
    public partial class FixedSelfReferencing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sales_CarId",
                table: "Sales");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CarId",
                table: "Sales",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sales_CarId",
                table: "Sales");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CarId",
                table: "Sales",
                column: "CarId",
                unique: true);
        }
    }
}
