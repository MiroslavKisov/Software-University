using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentSystem.Data.Migrations
{
    public partial class AddLicensesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_License_Resources_ResourceId",
                table: "License");

            migrationBuilder.DropPrimaryKey(
                name: "PK_License",
                table: "License");

            migrationBuilder.RenameTable(
                name: "License",
                newName: "Licenses");

            migrationBuilder.RenameIndex(
                name: "IX_License_ResourceId",
                table: "Licenses",
                newName: "IX_Licenses_ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Licenses_Resources_ResourceId",
                table: "Licenses",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Licenses_Resources_ResourceId",
                table: "Licenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses");

            migrationBuilder.RenameTable(
                name: "Licenses",
                newName: "License");

            migrationBuilder.RenameIndex(
                name: "IX_Licenses_ResourceId",
                table: "License",
                newName: "IX_License_ResourceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_License",
                table: "License",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_License_Resources_ResourceId",
                table: "License",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
