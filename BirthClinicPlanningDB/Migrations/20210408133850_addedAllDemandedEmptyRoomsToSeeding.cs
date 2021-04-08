using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class addedAllDemandedEmptyRoomsToSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 4,
                columns: new[] { "Occupied", "RoomNumber" },
                values: new object[] { false, 4 });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomID", "Discriminator", "Occupied", "RoomNumber", "RoomType" },
                values: new object[,]
                {
                    { 15, null, "MaternityRoom", false, null, 15, "Maternity Room" },
                    { 16, null, "MaternityRoom", false, null, 16, "Maternity Room" },
                    { 17, null, "MaternityRoom", false, null, 17, "Maternity Room" },
                    { 18, null, "MaternityRoom", false, null, 18, "Maternity Room" },
                    { 19, null, "MaternityRoom", false, null, 19, "Maternity Room" },
                    { 20, null, "MaternityRoom", false, null, 20, "Maternity Room" },
                    { 21, null, "MaternityRoom", false, null, 21, "Maternity Room" },
                    { 14, null, "MaternityRoom", false, null, 14, "Maternity Room" },
                    { 22, null, "MaternityRoom", false, null, 22, "Maternity Room" },
                    { 24, null, "MaternityRoom", false, null, 24, "Maternity Room" },
                    { 25, null, "MaternityRoom", false, null, 25, "Maternity Room" },
                    { 27, null, "MaternityRoom", false, null, 27, "Maternity Room" },
                    { 28, null, "MaternityRoom", false, null, 28, "Maternity Room" },
                    { 29, null, "MaternityRoom", false, null, 29, "Maternity Room" },
                    { 5, null, "RestRoom", false, null, 5, "Rest Room" },
                    { 6, null, "RestRoom", false, null, 6, "Rest Room" },
                    { 23, null, "MaternityRoom", false, null, 23, "Maternity Room" },
                    { 7, null, "RestRoom", false, null, 7, "Rest Room" },
                    { 13, null, "MaternityRoom", false, null, 13, "Maternity Room" },
                    { 11, null, "MaternityRoom", false, null, 11, "Maternity Room" },
                    { 31, null, "BirthRoom", false, null, 31, "Birth Room" },
                    { 32, null, "BirthRoom", false, null, 32, "Birth Room" },
                    { 33, null, "BirthRoom", false, null, 33, "Birth Room" },
                    { 34, null, "BirthRoom", false, null, 34, "Birth Room" },
                    { 35, null, "BirthRoom", false, null, 35, "Birth Room" },
                    { 36, null, "BirthRoom", false, null, 36, "Birth Room" },
                    { 37, null, "BirthRoom", false, null, 37, "Birth Room" },
                    { 12, null, "MaternityRoom", false, null, 12, "Maternity Room" },
                    { 38, null, "BirthRoom", false, null, 38, "Birth Room" },
                    { 40, null, "BirthRoom", false, null, 40, "Birth Room" },
                    { 41, null, "BirthRoom", false, null, 41, "Birth Room" },
                    { 42, null, "BirthRoom", false, null, 42, "Birth Room" },
                    { 43, null, "BirthRoom", false, null, 43, "Birth Room" },
                    { 8, null, "MaternityRoom", false, null, 8, "Maternity Room" },
                    { 9, null, "MaternityRoom", false, null, 9, "Maternity Room" },
                    { 10, null, "MaternityRoom", false, null, 10, "Maternity Room" },
                    { 39, null, "BirthRoom", false, null, 39, "Birth Room" },
                    { 30, null, "BirthRoom", false, null, 30, "Birth Room" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 4,
                columns: new[] { "Occupied", "RoomNumber" },
                values: new object[] { true, 5 });
        }
    }
}
