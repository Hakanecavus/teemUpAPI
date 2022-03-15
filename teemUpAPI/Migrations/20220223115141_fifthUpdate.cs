using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teemUpAPI.Migrations
{
    public partial class fifthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dutyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    definition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dutyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "licenseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    definition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_licenseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "taskAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskId = table.Column<int>(type: "int", nullable: false),
                    taskstaskId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: false),
                    usersuserId = table.Column<int>(type: "int", nullable: true),
                    dutyId = table.Column<int>(type: "int", nullable: false),
                    dutyTypesId = table.Column<int>(type: "int", nullable: true),
                    progress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taskAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_taskAssignment_dutyTypes_dutyTypesId",
                        column: x => x.dutyTypesId,
                        principalTable: "dutyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_taskAssignment_tasks_taskstaskId",
                        column: x => x.taskstaskId,
                        principalTable: "tasks",
                        principalColumn: "taskId");
                    table.ForeignKey(
                        name: "FK_taskAssignment_users_usersuserId",
                        column: x => x.usersuserId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateTable(
                name: "license",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    usersuserId = table.Column<int>(type: "int", nullable: true),
                    registrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userTypeId = table.Column<int>(type: "int", nullable: false),
                    licenseTypesId = table.Column<int>(type: "int", nullable: true),
                    expirationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_license", x => x.Id);
                    table.ForeignKey(
                        name: "FK_license_licenseTypes_licenseTypesId",
                        column: x => x.licenseTypesId,
                        principalTable: "licenseTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_license_users_usersuserId",
                        column: x => x.usersuserId,
                        principalTable: "users",
                        principalColumn: "userId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_license_licenseTypesId",
                table: "license",
                column: "licenseTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_license_usersuserId",
                table: "license",
                column: "usersuserId");

            migrationBuilder.CreateIndex(
                name: "IX_taskAssignment_dutyTypesId",
                table: "taskAssignment",
                column: "dutyTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_taskAssignment_taskstaskId",
                table: "taskAssignment",
                column: "taskstaskId");

            migrationBuilder.CreateIndex(
                name: "IX_taskAssignment_usersuserId",
                table: "taskAssignment",
                column: "usersuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "license");

            migrationBuilder.DropTable(
                name: "taskAssignment");

            migrationBuilder.DropTable(
                name: "licenseTypes");

            migrationBuilder.DropTable(
                name: "dutyTypes");
        }
    }
}
