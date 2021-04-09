using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class addedmanytomanyclinicianAndAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clinicians_Appointments_AppointmentID",
                table: "Clinicians");

            migrationBuilder.DropIndex(
                name: "IX_Clinicians_AppointmentID",
                table: "Clinicians");

            migrationBuilder.DropColumn(
                name: "AppointmentID",
                table: "Clinicians");

            migrationBuilder.CreateTable(
                name: "AppointmentClinician",
                columns: table => new
                {
                    AppointmentsAppointmentID = table.Column<int>(type: "int", nullable: false),
                    CliniciansClinicianID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentClinician", x => new { x.AppointmentsAppointmentID, x.CliniciansClinicianID });
                    table.ForeignKey(
                        name: "FK_AppointmentClinician_Appointments_AppointmentsAppointmentID",
                        column: x => x.AppointmentsAppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentClinician_Clinicians_CliniciansClinicianID",
                        column: x => x.CliniciansClinicianID,
                        principalTable: "Clinicians",
                        principalColumn: "ClinicianID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 5,
                column: "RoomNumber",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 6,
                column: "RoomNumber",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 7,
                column: "RoomNumber",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentClinician_CliniciansClinicianID",
                table: "AppointmentClinician",
                column: "CliniciansClinicianID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentClinician");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentID",
                table: "Clinicians",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 5,
                column: "RoomNumber",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 6,
                column: "RoomNumber",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 7,
                column: "RoomNumber",
                value: 7);

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_AppointmentID",
                table: "Clinicians",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clinicians_Appointments_AppointmentID",
                table: "Clinicians",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "AppointmentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
