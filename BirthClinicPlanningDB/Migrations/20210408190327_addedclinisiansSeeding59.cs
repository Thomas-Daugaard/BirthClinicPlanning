using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class addedclinisiansSeeding59 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "ClinicianID", "AppointmentID", "FirstName", "LastName", "Type" },
                values: new object[,]
                {
                    { 13, null, "Jørgen", "Poulsen", "SOSU Assistant" },
                    { 38, null, "Keine", "Inspiration", "Nurse" },
                    { 39, null, "Heinz", "Heino", "Nurse" },
                    { 40, null, "Mogens", "Morgensur", "Nurse" },
                    { 41, null, "Bolette", "Børnelokker", "Nurse" },
                    { 42, null, "Line", "Linedanser", "Nurse" },
                    { 43, null, "Mikkel", "Pampers", "Nurse" },
                    { 44, null, "Toke", "Son of Loke", "Nurse" },
                    { 45, null, "Svetlana", "From Havanna", "Nurse" },
                    { 46, null, "Arne", "Analfabet", "Nurse" },
                    { 37, null, "Gunnar", "Big Gun", "Nurse" },
                    { 47, null, "Sir", "Elton John", "Nurse" },
                    { 49, null, "Frank", "BodHoldt Jakobsen", "Nurse" },
                    { 50, null, "Dine", "The deliverer", "Midwife" },
                    { 51, null, "Bjørk", "Babypuller", "Midwife" },
                    { 52, null, "Puk", "Push Push", "MidWife" },
                    { 53, null, "Palle", "Peekaboo", "Midwife" },
                    { 54, null, "Ole", "Opigen", "Midwife" },
                    { 55, null, "Palle", "Pres Pres", "Midwife" },
                    { 56, null, "Kirsten", "CuntWhisperer", "Midwife" },
                    { 57, null, "Niels", "Nukommerbaby", "Midwife" },
                    { 48, null, "Queen", "Bee", "Nurse" },
                    { 58, null, "Peter", "Pop", "Midwife" },
                    { 36, null, "Uno", "Dos Tres", "Nurse" },
                    { 34, null, "Kim", "Karate", "Nurse" },
                    { 14, null, "Jan", "Hellesøe", "SOSU Assistant" },
                    { 15, null, "Lonny", "Luderhår", "SOSU Assistant" },
                    { 16, null, "Sleske", "Svend", "SOSU Assistant" },
                    { 17, null, "Bo", "Bedre", "SOSU Assistant" },
                    { 18, null, "Tåløse", "Tomme", "SOSU Assistant" },
                    { 19, null, "Linée", "Havnedronning", "SOSU Assistant" },
                    { 20, null, "Kirsten", "Nedersø", "SOSU Assistant" },
                    { 21, null, "Kathrine", "Klit", "SOSU Assistant" },
                    { 22, null, "Richard", "Rust", "SOSU Assistant" },
                    { 35, null, "Ymer", "Johansen", "Nurse" },
                    { 23, null, "Garn", "Svensker", "SOSU Assistant" },
                    { 25, null, "Benny", "Balsam", "SOSU Assistant" },
                    { 26, null, "Lone", "Large", "SOSU Assistant" },
                    { 27, null, "Mads", "Middelmådig", "SOSU Assistant" },
                    { 28, null, "Knud", "Kattekilling", "SOSU Assistant" },
                    { 29, null, "Ine", "Indelukket", "SOSU Assistant" },
                    { 30, null, "Kvart", "Palle", "Nurse" }
                });

            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "ClinicianID", "AppointmentID", "FirstName", "LastName", "Type" },
                values: new object[,]
                {
                    { 31, null, "Yda", "Ydermeget", "Nurse" },
                    { 32, null, "Carla", "Carletti", "Nurse" },
                    { 33, null, "Inge", "Ingenveddet", "Nurse" },
                    { 24, null, "Hans", "Haard", "SOSU Assistant" },
                    { 59, null, "Inger", "Ikkefler", "Midwife" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 59);
        }
    }
}
