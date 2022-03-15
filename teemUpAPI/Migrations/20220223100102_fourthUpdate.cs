using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teemUpAPI.Migrations
{
    public partial class fourthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "teamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teamId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teamMembers_teams_teamId",
                        column: x => x.teamId,
                        principalTable: "teams",
                        principalColumn: "teamId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_teamMembers_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teamMembers_teamId",
                table: "teamMembers",
                column: "teamId");

            migrationBuilder.CreateIndex(
                name: "IX_teamMembers_userId",
                table: "teamMembers",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "teamMembers");
        }
    }
}
