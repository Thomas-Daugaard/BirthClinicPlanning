using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class addedseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Parents_ChildID",
                table: "Parents");

            migrationBuilder.DeleteData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "ParentsID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "ParentsID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "ParentsID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: -1);

            migrationBuilder.AddColumn<int>(
                name: "ParentsID",
                table: "Childs",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Childs",
                columns: new[] { "ChildID", "BirthDate", "DisplayDate", "FirstName", "LastName", "Length", "ParentsID", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "06-04-2020", "Leif", "Knudsen", 56, 1, 3500 },
                    { 2, new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "07-04-2020", "Viggo", "Mortensen", 56, 2, 3500 },
                    { 3, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "08-04-2020", "Pascal", "Pedersen", 56, 3, 3500 }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentsID", "ChildID", "DadCPR", "DadFirstName", "DadLastName", "MomCPR", "MomFirstName", "MomLastName" },
                values: new object[,]
                {
                    { 1, 1, "2103898569", "Lars", "Thomsen", "2003928596", "Camilla", "Thomsen" },
                    { 2, 2, "2104898569", "Knabe", "Frederiksen", "2004928596", "Tove", "Frederiksen" },
                    { 3, 3, "2105898569", "Per", "Gudrundsen", "2005928596", "Hilda", "Gudrundsen" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomID", "ChildID", "Discriminator", "Occupied", "ParentsID", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 1, 1, "Room", false, 1, 1, "RestRoom" },
                    { 2, 2, "Room", false, 2, 2, "RestRoom" },
                    { 3, 3, "Room", false, 3, 3, "MaternityRoom"}
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "BirthInProgess", "Date", "RoomID" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2021, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, false, new DateTime(2021, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Childs",
                keyColumn: "ChildID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "ParentsID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "ParentsID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parents",
                keyColumn: "ParentsID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ParentsID",
                table: "Childs");

            migrationBuilder.InsertData(
                table: "Childs",
                columns: new[] { "ChildID", "BirthDate", "DisplayDate", "FirstName", "LastName", "Length", "Weight" },
                values: new object[,]
                {
                    { -1, new DateTime(2020, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "06-04-2020", "Leif", "Knudsen", 56, 3500 },
                    { -2, new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "07-04-2020", "Viggo", "Mortensen", 56, 3500 },
                    { -3, new DateTime(2020, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "08-04-2020", "Pascal", "Pedersen", 56, 3500 }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentsID", "ChildID", "DadCPR", "DadFirstName", "DadLastName", "MomCPR", "MomFirstName", "MomLastName" },
                values: new object[,]
                {
                    { -1, null, "2103898569", "Lars", "Thomsen", "2003928596", "Camilla", "Thomsen" },
                    { -2, null, "2104898569", "Knabe", "Frederiksen", "2004928596", "Tove", "Frederiksen" },
                    { -3, null, "2105898569", "Per", "Gudrundsen", "2005928596", "Hilda", "Gudrundsen" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomID", "ChildID", "Discriminator", "Occupied", "ParentsID", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { -1, null, "Room", false, null, 1, null },
                    { -2, null, "Room", false, null, 2, null },
                    { -3, null, "Room", false, null, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ChildID",
                table: "Parents",
                column: "ChildID");
        }
    }
}
