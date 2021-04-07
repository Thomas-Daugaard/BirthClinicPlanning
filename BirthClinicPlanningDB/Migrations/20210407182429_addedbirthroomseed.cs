using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicPlanningDB.Migrations
{
    public partial class addedbirthroomseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomID", "ChildID", "Discriminator", "Occupied", "ParentsID", "RoomNumber", "RoomType" },
                values: new object[] { 4, null, "BirthRoom", true, 1, 5, "Birth Room" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "RoomID",
                keyValue: 4);
        }
    }
}
