using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoShare.Data.Migrations
{
    public partial class LogSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLoged",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLoged",
                table: "Users");
        }
    }
}
