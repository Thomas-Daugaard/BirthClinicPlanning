using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class addedseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Childs_Parents_ParentsID",
                table: "Childs");

            migrationBuilder.DropIndex(
                name: "IX_Parents_ChildID",
                table: "Parents");

            migrationBuilder.DropIndex(
                name: "IX_Childs_ParentsID",
                table: "Childs");

            migrationBuilder.DropColumn(
                name: "ParentsID",
                table: "Childs");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 1,
                columns: new[] { "BirthDate", "DisplayDate" },
                values: new object[] { new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "06-06-2020" });

            migrationBuilder.UpdateData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 2,
                columns: new[] { "BirthDate", "DisplayDate" },
                values: new object[] { new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "07-06-2020" });

            migrationBuilder.UpdateData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 3,
                columns: new[] { "BirthDate", "DisplayDate" },
                values: new object[] { new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "08-06-2020" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 1,
                column: "RoomType",
                value: "RestRoom");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 2,
                column: "RoomType",
                value: "RestRoom");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 3,
                column: "RoomType",
                value: "MaternityRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ChildID",
                table: "Parents",
                column: "ChildID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parents_ChildID",
                table: "Parents");

            migrationBuilder.AddColumn<int>(
                name: "ParentsID",
                table: "Childs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 1,
                columns: new[] { "BirthDate", "DisplayDate" },
                values: new object[] { new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "06-04-2020" });

            migrationBuilder.UpdateData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 2,
                columns: new[] { "BirthDate", "DisplayDate" },
                values: new object[] { new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "07-04-2020" });

            migrationBuilder.UpdateData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 3,
                columns: new[] { "BirthDate", "DisplayDate" },
                values: new object[] { new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "08-04-2020" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 1,
                column: "RoomType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 2,
                column: "RoomType",
                value: null);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 3,
                column: "RoomType",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ChildID",
                table: "Parents",
                column: "ChildID",
                unique: true,
                filter: "[ChildID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Childs_ParentsID",
                table: "Childs",
                column: "ParentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Childs_Parents_ParentsID",
                table: "Childs",
                column: "ParentsID",
                principalTable: "Parents",
                principalColumn: "ParentsID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
