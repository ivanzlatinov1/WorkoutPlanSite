using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPlanSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMetricsForWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Metric",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Metric",
                table: "Equipments");
        }
    }
}
