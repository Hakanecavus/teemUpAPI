using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teemUpAPI.Migrations
{
    public partial class sixthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "teamMembers");

            migrationBuilder.AddColumn<int>(
                name: "positionId",
                table: "teamMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userPositionsId",
                table: "teamMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "userPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userPositions", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_teamMembers_userPositions_userPositionsId",
                table: "teamMembers");

            migrationBuilder.DropTable(
                name: "userPositions");

            migrationBuilder.DropIndex(
                name: "IX_teamMembers_userPositionsId",
                table: "teamMembers");

            migrationBuilder.DropColumn(
                name: "positionId",
                table: "teamMembers");

            migrationBuilder.DropColumn(
                name: "userPositionsId",
                table: "teamMembers");

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "teamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
