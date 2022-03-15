using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teemUpAPI.Migrations
{
    public partial class tenthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_license_licenseTypes_licenseTypesId",
                table: "license");

            migrationBuilder.DropColumn(
                name: "userTypeId",
                table: "license");

            migrationBuilder.AlterColumn<int>(
                name: "licenseTypesId",
                table: "license",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_license_licenseTypes_licenseTypesId",
                table: "license",
                column: "licenseTypesId",
                principalTable: "licenseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_license_licenseTypes_licenseTypesId",
                table: "license");

            migrationBuilder.AlterColumn<int>(
                name: "licenseTypesId",
                table: "license",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "userTypeId",
                table: "license",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_license_licenseTypes_licenseTypesId",
                table: "license",
                column: "licenseTypesId",
                principalTable: "licenseTypes",
                principalColumn: "Id");
        }
    }
}
