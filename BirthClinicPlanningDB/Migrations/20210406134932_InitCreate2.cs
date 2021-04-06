using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class InitCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "Clinicians",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomID",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Clinicians_RoomID",
                table: "Clinicians",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RoomID",
                table: "Appointments",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_ChildID",
                table: "Room",
                column: "ChildID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_ParentsID",
                table: "Room",
                column: "ParentsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Room_RoomID",
                table: "Appointments",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clinicians_Room_RoomID",
                table: "Clinicians",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "RoomID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Room_RoomID",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Clinicians_Room_RoomID",
                table: "Clinicians");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Clinicians_RoomID",
                table: "Clinicians");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_RoomID",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Clinicians");

            migrationBuilder.DropColumn(
                name: "RoomID",
                table: "Appointments");
        }
    }
}
