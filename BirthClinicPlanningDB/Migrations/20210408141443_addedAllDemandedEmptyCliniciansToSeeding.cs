using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class addedAllDemandedEmptyCliniciansToSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clinicians",
                columns: new[] { "ClinicianID", "FirstName", "LastName", "RoomID" },
                values: new object[,]
                {
                    { 4, "Camilla", "Boesen", null },
                    { 5, "Thomas", "Boesen", null },
                    { 6, "Emil", "Boesen", null },
                    { 7, "Camilla", "Mikkelsen", null },
                    { 8, "Thomas", "Mikkelsen", null },
                    { 9, "Emil", "Mikkelsen", null },
                    { 10, "Camilla", "Overgaard", null },
                    { 11, "Thomas", "Overgaard", null },
                    { 12, "Emil", "Overgaard", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clinicians",
                keyColumn: "ClinicianID",
                keyValue: 12);
        }
    }
}
