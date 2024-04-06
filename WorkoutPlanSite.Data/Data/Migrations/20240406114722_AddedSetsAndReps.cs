using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPlanSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedSetsAndReps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Exercises",
                newName: "Sets");

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Exercises");

            migrationBuilder.RenameColumn(
                name: "Sets",
                table: "Exercises",
                newName: "Duration");
        }
    }
}
