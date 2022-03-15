using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teemUpAPI.Migrations
{
    public partial class eightthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teamMembers_userPositions_userPositionsId",
                table: "teamMembers");

            migrationBuilder.DropIndex(
                name: "IX_teamMembers_userPositionsId",
                table: "teamMembers");

            migrationBuilder.DropColumn(
                name: "userPositionsId",
                table: "teamMembers");

            migrationBuilder.RenameColumn(
                name: "positionId",
                table: "teamMembers",
                newName: "userPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_teamMembers_userPositionId",
                table: "teamMembers",
                column: "userPositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_teamMembers_userPositions_userPositionId",
                table: "teamMembers",
                column: "userPositionId",
                principalTable: "userPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teamMembers_userPositions_userPositionId",
                table: "teamMembers");

            migrationBuilder.DropIndex(
                name: "IX_teamMembers_userPositionId",
                table: "teamMembers");

            migrationBuilder.RenameColumn(
                name: "userPositionId",
                table: "teamMembers",
                newName: "positionId");

            migrationBuilder.AddColumn<int>(
                name: "userPositionsId",
                table: "teamMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_teamMembers_userPositionsId",
                table: "teamMembers",
                column: "userPositionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_teamMembers_userPositions_userPositionsId",
                table: "teamMembers",
                column: "userPositionsId",
                principalTable: "userPositions",
                principalColumn: "Id");
        }
    }
}
