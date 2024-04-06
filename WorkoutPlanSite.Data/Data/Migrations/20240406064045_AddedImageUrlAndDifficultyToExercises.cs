using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPlanSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedImageUrlAndDifficultyToExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "difficulty",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "difficulty",
                table: "Exercises");
        }
    }
}
