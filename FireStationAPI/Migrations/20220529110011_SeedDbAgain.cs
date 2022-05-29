using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireStationAPI.Migrations
{
    public partial class SeedDbAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 5, 19, 23, 0, 11, 400, DateTimeKind.Local).AddTicks(2120), new DateTime(2022, 5, 19, 13, 0, 11, 400, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.InsertData(
                table: "FireTruck_Action",
                columns: new[] { "IdAction", "IdFiretruck", "AssignmentDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 1, 4, new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, 6, new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 2, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 3, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, 5, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 1, new DateTime(2022, 5, 29, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, 5, new DateTime(2022, 5, 24, 4, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFiretruck" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFiretruck" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFiretruck" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFiretruck" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFiretruck" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFiretruck" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFiretruck" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "FireTruck_Action",
                keyColumns: new[] { "IdAction", "IdFiretruck" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.UpdateData(
                table: "Action",
                keyColumn: "IdAction",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 5, 19, 22, 42, 0, 288, DateTimeKind.Local).AddTicks(1010), new DateTime(2022, 5, 19, 12, 42, 0, 288, DateTimeKind.Local).AddTicks(1010) });
        }
    }
}
