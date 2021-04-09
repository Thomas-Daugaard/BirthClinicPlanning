using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class NewInitialInclCompleteSeedingNoErrorProne : Migration
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
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Occupied = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
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
                name: "Appointments",
                columns: table => new
                {
                    AppointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    ParentsID = table.Column<int>(type: "int", nullable: true),
                    ChildID = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Childs_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Childs",
                        principalColumn: "ChildID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Parents_ParentsID",
                        column: x => x.ParentsID,
                        principalTable: "Parents",
                        principalColumn: "ParentsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clinicians",
                columns: table => new
                {
                    ClinicianID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicians", x => x.ClinicianID);
                    table.ForeignKey(
                        name: "FK_Clinicians_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Childs",
                columns: new[] { "ChildID", "BirthDate", "DisplayDate", "FirstName", "LastName", "Length", "Weight" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "08-06-2020", "Pascal", "Pedersen", 56, 3500 },
                    { 2, new DateTime(2020, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "07-06-2020", "Viggo", "Mortensen", 56, 3500 },
                    { 1, new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "06-06-2020", "Leif", "Knudsen", 56, 3500 }
                });


            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "ParentsID", "ChildID", "DadCPR", "DadFirstName", "DadLastName", "MomCPR", "MomFirstName", "MomLastName" },
                values: new object[,]
                {
                    { 3, 3, "2105898569", "Per", "Gudrundsen", "2005928596", "Hilda", "Gudrundsen" },
                    { 2, 2, "2104898569", "Knabe", "Frederiksen", "2004928596", "Tove", "Frederiksen" },
                    { 1, 1, "2103898569", "Lars", "Thomsen", "2003928596", "Camilla", "Thomsen" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomID", "Discriminator", "Occupied", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 21, "MaternityRoom", false, 15, "Maternity Room" },
                    { 20, "MaternityRoom", false, 14, "Maternity Room" },
                    { 19, "MaternityRoom", false, 13, "Maternity Room" },
                    { 17, "MaternityRoom", false, 11, "Maternity Room" },
                    { 22, "MaternityRoom", false, 16, "Maternity Room" },
                    { 16, "MaternityRoom", false, 10, "Maternity Room" },
                    { 18, "MaternityRoom", false, 12, "Maternity Room" },
                    { 5, "RestRoom", false, 5, "Rest Room" },
                    { 29, "MaternityRoom", false, 22, "Maternity Room" },
                    { 24, "MaternityRoom", false, 18, "Maternity Room" },
                    { 25, "MaternityRoom", false, 19, "Maternity Room" },
                    { 27, "MaternityRoom", false, 20, "Maternity Room" },
                    { 28, "MaternityRoom", false, 21, "Maternity Room" },
                    { 1, "RestRoom", false, 1, "Rest Room" },
                    { 2, "RestRoom", false, 2, "Rest Room" },
                    { 15, "MaternityRoom", false, 9, "Maternity Room" },
                    { 23, "MaternityRoom", false, 17, "Maternity Room" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomID", "Discriminator", "Occupied", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 14, "MaternityRoom", false, 8, "Maternity Room" },
                    { 32, "BirthRoom", false, 4, "Birth Room" },
                    { 12, "MaternityRoom", false, 6, "Maternity Room" },
                    { 6, "RestRoom", false, 6, "Rest Room" },
                    { 43, "BirthRoom", false, 15, "Birth Room" },
                    { 42, "BirthRoom", false, 14, "Birth Room" },
                    { 41, "BirthRoom", false, 13, "Birth Room" },
                    { 40, "BirthRoom", false, 12, "Birth Room" },
                    { 39, "BirthRoom", false, 11, "Birth Room" },
                    { 38, "BirthRoom", false, 10, "Birth Room" },
                    { 37, "BirthRoom", false, 9, "Birth Room" },
                    { 36, "BirthRoom", false, 8, "Birth Room" },
                    { 13, "MaternityRoom", false, 7, "Maternity Room" },
                    { 35, "BirthRoom", false, 7, "Birth Room" },
                    { 33, "BirthRoom", false, 5, "Birth Room" },
                    { 31, "BirthRoom", false, 3, "Birth Room" },
                    { 30, "BirthRoom", false, 2, "Birth Room" },
                    { 4, "BirthRoom", false, 1, "Birth Room" },
                    { 3, "MaternityRoom", false, 1, "Maternity Room" },
                    { 8, "MaternityRoom", false, 2, "Maternity Room" },
                    { 9, "MaternityRoom", false, 3, "Maternity Room" },
                    { 10, "MaternityRoom", false, 4, "Maternity Room" },
                    { 11, "MaternityRoom", false, 5, "Maternity Room" },
                    { 34, "BirthRoom", false, 6, "Birth Room" },
                    { 7, "RestRoom", false, 7, "Rest Room" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "ChildID", "EndTime", "ParentsID", "RoomID", "StartTime" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2021, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "ClinicianID", "AppointmentID", "FirstName", "LastName", "Type" },
                values: new object[,]
                {
                    { 40, null, "Mogens", "Morgensur", "Nurse" },
                    { 39, null, "Heinz", "Heino", "Nurse" },
                    { 38, null, "Keine", "Inspiration", "Nurse" },
                    { 37, null, "Gunnar", "Big Gun", "Nurse" },
                    { 36, null, "Uno", "Dos Tres", "Nurse" },
                    { 34, null, "Kim", "Karate", "Nurse" },
                    { 33, null, "Inge", "Ingenveddet", "Nurse" },
                    { 32, null, "Carla", "Carletti", "Nurse" },
                    { 31, null, "Yda", "Ydermeget", "Nurse" },
                    { 30, null, "Kvart", "Palle", "Nurse" },
                    { 29, null, "Ine", "Indelukket", "SOSU Assistant" },
                    { 28, null, "Knud", "Kattekilling", "SOSU Assistant" },
                    { 27, null, "Mads", "Middelmådig", "SOSU Assistant" },
                    { 26, null, "Lone", "Large", "SOSU Assistant" },
                    { 25, null, "Benny", "Balsam", "SOSU Assistant" },
                    { 41, null, "Bolette", "Børnelokker", "Nurse" },
                    { 42, null, "Line", "Linedanser", "Nurse" },
                    { 44, null, "Toke", "Son of Loke", "Nurse" },
                    { 24, null, "Hans", "Haard", "SOSU Assistant" },
                    { 59, null, "Inger", "Ikkefler", "Midwife" },
                    { 58, null, "Peter", "Pop", "Midwife" },
                    { 57, null, "Niels", "Nukommerbaby", "Midwife" },
                    { 56, null, "Kirsten", "CuntWhisperer", "Midwife" },
                    { 55, null, "Palle", "Pres Pres", "Midwife" },
                    { 54, null, "Ole", "Opigen", "Midwife" },
                    { 53, null, "Palle", "Peekaboo", "Midwife" },
                    { 52, null, "Puk", "Push Push", "MidWife" },
                    { 51, null, "Bjørk", "Babypuller", "Midwife" },
                    { 50, null, "Dine", "The deliverer", "Midwife" },
                    { 49, null, "Frank", "BodHoldt Jakobsen", "Nurse" },
                    { 48, null, "Queen", "Bee", "Nurse" },
                    { 47, null, "Sir", "Elton John", "Nurse" },
                    { 46, null, "Arne", "Analfabet", "Nurse" },
                    { 45, null, "Svetlana", "From Havanna", "Nurse" },
                    { 43, null, "Mikkel", "Pampers", "Nurse" },
                    { 23, null, "Garn", "Svensker", "SOSU Assistant" },
                    { 35, null, "Ymer", "Johansen", "Nurse" }
                });

            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "ClinicianID", "AppointmentID", "FirstName", "LastName", "Type" },
                values: new object[,]
                {
                    { 21, null, "Kathrine", "Klit", "SOSU Assistant" },
                    { 22, null, "Richard", "Rust", "SOSU Assistant" },
                    { 2, 2, "Thomas", "Daugaard", "Doctor" },
                    { 3, 2, "Emil", "Garder", "Doctor" },
                    { 4, null, "Camilla", "Boesen", "Doctor" },
                    { 5, null, "Thomas", "Boesen", "Doctor" },
                    { 6, null, "Emil", "Boesen", "Secretary" },
                    { 7, 2, "Camilla", "Mikkelsen", "Secretary" },
                    { 8, null, "Thomas", "Mikkelsen", "Secretary" },
                    { 9, null, "Emil", "Mikkelsen", "Secretary" },
                    { 10, null, "Camilla", "Overgaard", "SOSU Assistant" },
                    { 1, 1, "Camilla", "Holmstoel", "Doctor" },
                    { 20, null, "Kirsten", "Nedersø", "SOSU Assistant" },
                    { 12, null, "Emil", "Overgaard", "SOSU Assistant" },
                    { 13, null, "Jørgen", "Poulsen", "SOSU Assistant" },
                    { 14, 1, "Jan", "Hellesøe", "SOSU Assistant" },
                    { 15, null, "Lonny", "Luderhår", "SOSU Assistant" },
                    { 16, null, "Sleske", "Svend", "SOSU Assistant" },
                    { 17, null, "Bo", "Bedre", "SOSU Assistant" },
                    { 18, null, "Tåløse", "Tomme", "SOSU Assistant" },
                    { 19, null, "Linée", "Havnedronning", "SOSU Assistant" },
                    { 11, null, "Thomas", "Overgaard", "SOSU Assistant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ChildID",
                table: "Appointments",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ParentsID",
                table: "Appointments",
                column: "ParentsID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomID",
                table: "Appointments",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_AppointmentID",
                table: "Clinicians",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_ChildID",
                table: "Parents",
                column: "ChildID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clinicians");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Childs");
        }
    }
}
