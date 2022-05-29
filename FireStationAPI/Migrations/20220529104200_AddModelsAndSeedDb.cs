using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireStationAPI.Migrations
{
    public partial class AddModelsAndSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    IdAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NeedSpecialEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Action_pk", x => x.IdAction);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck",
                columns: table => new
                {
                    IdFiretruck = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SpecialEquipment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Firetruck_pk", x => x.IdFiretruck);
                });

            migrationBuilder.CreateTable(
                name: "FireTruck_Action",
                columns: table => new
                {
                    IdFiretruck = table.Column<int>(type: "int", nullable: false),
                    IdAction = table.Column<int>(type: "int", nullable: false),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FireTruck_Action_pk", x => new { x.IdAction, x.IdFiretruck });
                    table.ForeignKey(
                        name: "FiretruckAction_Action",
                        column: x => x.IdAction,
                        principalTable: "Action",
                        principalColumn: "IdAction");
                    table.ForeignKey(
                        name: "FiretruckAction_Firetruck",
                        column: x => x.IdFiretruck,
                        principalTable: "FireTruck",
                        principalColumn: "IdFiretruck");
                });

            migrationBuilder.InsertData(
                table: "Action",
                columns: new[] { "IdAction", "EndTime", "NeedSpecialEquipment", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 19, 0, 0, 0, 0, DateTimeKind.Local), true, new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2022, 5, 19, 22, 42, 0, 288, DateTimeKind.Local).AddTicks(1010), true, new DateTime(2022, 5, 19, 12, 42, 0, 288, DateTimeKind.Local).AddTicks(1010) },
                    { 3, null, false, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, new DateTime(2022, 5, 25, 0, 0, 0, 0, DateTimeKind.Local), false, new DateTime(2022, 5, 24, 4, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "FireTruck",
                columns: new[] { "IdFiretruck", "OperationNumber", "SpecialEquipment" },
                values: new object[,]
                {
                    { 1, "51", true },
                    { 2, "10", false },
                    { 3, "104", false },
                    { 4, "321", true },
                    { 5, "161", false },
                    { 6, "571", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FireTruck_Action_IdFiretruck",
                table: "FireTruck_Action",
                column: "IdFiretruck");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FireTruck_Action");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "FireTruck");
        }
    }
}
