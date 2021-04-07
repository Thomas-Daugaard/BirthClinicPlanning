using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Childs",
                columns: table => new
                {
                    ChildID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childs", x => x.ChildID);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MomCPR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MomFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MomLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DadCPR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DadFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DadLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentsID);
                    table.ForeignKey(
                        name: "FK_Parents_Childs_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Childs",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupied = table.Column<bool>(type: "bit", nullable: false),
                    ParentsID = table.Column<int>(type: "int", nullable: true),
                    ChildID = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Room_Childs_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Childs",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_Parents_ParentsID",
                        column: x => x.ParentsID,
                        principalTable: "Parents",
                        principalColumn: "ParentsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthInProgess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clinicians",
                columns: table => new
                {
                    ClinicianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicians", x => x.ClinicianID);
                    table.ForeignKey(
                        name: "FK_Clinicians_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                table: "Clinicians",
                columns: new[] { "ClinicianID", "FirstName", "LastName", "RoomID" },
                values: new object[,]
                {
                    { 1, "Camilla", "Holmstoel", null },
                    { 2, "Thomas", "Daugaard", null },
                    { 3, "Emil", "Garder", null }
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
                name: "IX_Appointments_RoomID",
                table: "Appointments",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_RoomID",
                table: "Clinicians",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ChildID",
                table: "Parents",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_ChildID",
                table: "Room",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_ParentsID",
                table: "Room",
                column: "ParentsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Clinicians");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Childs");
        }
    }
}
