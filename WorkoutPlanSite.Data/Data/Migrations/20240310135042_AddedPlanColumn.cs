using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPlanSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlanColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Plan",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plan",
                table: "Equipments");
        }
    }
}
