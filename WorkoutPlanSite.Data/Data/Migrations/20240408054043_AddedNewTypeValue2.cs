using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPlanSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewTypeValue2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "No equipment" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
