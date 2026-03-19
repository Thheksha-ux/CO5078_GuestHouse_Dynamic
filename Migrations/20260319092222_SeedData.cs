using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CO5078_GuestHouse_Dynamic.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Description", "Features", "Location", "MainImage", "PricePerNight", "Title" },
                values: new object[] { 1, "Beautiful coastal room", "WiFi, Sea View", "Cornwall", "room1.jpg", 150m, "Cornwall Sea View Room" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
