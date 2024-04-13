using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkoutPlanSite.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededEquipmentAndExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "Id", "ImageUrl", "Metric", "Name", "Plan", "TypeId", "Weight" },
                values: new object[,]
                {
                    { 1, "https://m.media-amazon.com/images/I/31vTXdGDWLL.jpg", 0, "Barbell", 1, 3, 20.0 },
                    { 2, "https://imgs.search.brave.com/Q6ZRty_7PTVms2Ni56mUW1fXs4NQqg7t399z1sP3QSA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRs/aW5lcGx1cy5nb3Yv/aW1hZ2VzL0JvZHlX/ZWlnaHQuanBn", 0, "Body Weight", 0, 4, 0.0 },
                    { 3, "https://imgs.search.brave.com/vzhkhzilFvRdJdKWOORL3c2c2KZ40_We6VCCf8_WszE/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMudW5zcGxhc2gu/Y29tL3Bob3RvLTE1/NzY2Nzg5Mjc0ODQt/Y2M5MDc5NTcwODhj/P3E9ODAmdz0xMDAw/JmF1dG89Zm9ybWF0/JmZpdD1jcm9wJml4/bGliPXJiLTQuMC4z/Jml4aWQ9TTN3eE1q/QTNmREI4TUh4elpX/RnlZMmg4TW54OFpI/VnRZbUpsYkd4emZH/VnVmREI4ZkRCOGZI/d3c", 0, "Dumbells", 0, 2, 10.0 },
                    { 4, "https://imgs.search.brave.com/h9Uqz_X203ywQAK6tSpJ62bzBBeT2b9UGXP-uAIA2g8/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTg2/OTY0OTAyMC9waG90/by9tYW4tZXhlcmNp/c2luZy1vbi1sZWct/cHJlc3MuanBnP3M9/NjEyeDYxMiZ3PTAm/az0yMCZjPVZhQWVa/Y21nY3BkbTZVZ2hW/eDZUUW1SSDBQM0xk/d3RpR2wzMmpQalpm/Vm89", 0, "Leg Press", 2, 1, 160.0 },
                    { 5, "https://imgs.search.brave.com/zodUy4Bq1GO6EcDYqj7PLEdi2da2XwI1lRFIjU8-CyI/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9hdGxh/bnRpc3N0cmVuZ3Ro/LmNvbS9hcHAvdXBs/b2Fkcy8yMDIyLzAx/L3B3NDQ5XzItNDE2/eDQxOC5wbmc", 1, "ShoulderPressMachine", 1, 1, 44.0 },
                    { 6, "https://imgs.search.brave.com/SpT2VHXiOA03VRnEXdGRZ7zWWbuFy1W2UYsUco2dbI4/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tLm1l/ZGlhLWFtYXpvbi5j/b20vaW1hZ2VzL0kv/ODFOS0tqUkgtbkwu/anBn", 0, "Light Dumbells", 0, 2, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "EquipmentId", "ImageURL", "Name", "Repetitions", "Sets", "difficulty" },
                values: new object[,]
                {
                    { 1, "Adding weight increases the difficulty.", 1, "https://imgs.search.brave.com/WsIfyLRdsOp2l_b93ZuNovQ0N6xWwRlmd7J60YcQpdA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly90My5m/dGNkbi5uZXQvanBn/LzAwLzc4LzQyLzY0/LzM2MF9GXzc4NDI2/NDc2XzFiMG5vRzFF/bDk2MUFiamFRMG4w/cDloVkJhcVo2OWZ5/LmpwZw", "Bench Press", 10, 5, 2 },
                    { 2, "An exercise that affects many muscle groups.", 2, "https://imgs.search.brave.com/txguJTQwUh-aVLcTs5KN5-R9d2wygtXauaQRnoTDFqE/rs:fit:500:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/cHJlbWl1bS1waG90/by9tdXNjdWxhci1t/YW4tZG9pbmctcHVz/aHVwc18xMzMzOS0x/NTExMDMuanBnP3Np/emU9NjI2JmV4dD1q/cGc", "Push Ups", 20, 5, 0 },
                    { 3, "Best shoulder exercise.", 3, "https://imgs.search.brave.com/pE3uivlySZ9u5Krg650stNPFS7GSBqkqbqprETtZd3k/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9oaXBz/LmhlYXJzdGFwcHMu/Y29tL2htZy1wcm9k/L2ltYWdlcy9sYXRl/cmFsLXJhaXNlcy0x/NjY3NTYzMjE4Lmpw/Zz9yZXNpemU9OTgw/Oio", "Lateral Raises", 20, 3, 1 },
                    { 4, "The casual shoulder press.", 5, "https://imgs.search.brave.com/FffOzDwfbcV5YLP8coMNa0t1YsS0NNZJOSn0fhAdWEs/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9maXRs/aWZlZmFuYXRpY3Mu/Y29tL3dwLWNvbnRl/bnQvdXBsb2Fkcy8y/MDIwLzA1L3Nob3Vs/ZGVyLXByZXNzLW1h/Y2hpbmVzLTc4MHg0/NzAuanBn", "Shoulder Press", 15, 3, 1 },
                    { 5, "Requires lots of endurance.", 4, "https://imgs.search.brave.com/4g4i0m7XWDQazbokaw4CImRFLEgjQLFJAVZXYvQkEJE/rs:fit:860:0:0/g:ce/aHR0cHM6Ly90NC5m/dGNkbi5uZXQvanBn/LzAwLzkyLzg4LzI3/LzM2MF9GXzkyODgy/Nzk2XzVwSldta1Mx/YXMxMUFnZERJTkp3/T05ZQkE1NWEzUGZ6/LmpwZw", "Leg Press", 20, 5, 2 },
                    { 6, "An old school exercise.", 3, "https://imgs.search.brave.com/TaoILpBPBJPPH5z3HtuoWIXcIOMingymHVe4ew4ZNEA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pMC53/cC5jb20vd3d3Lm11/c2NsZWFuZGZpdG5l/c3MuY29tL3dwLWNv/bnRlbnQvdXBsb2Fk/cy8yMDE4LzEwLzEx/MDktLUJpY2VwLUN1/cmwtR2V0dHlJbWFn/ZXMtNTkxNDAzNjQ1/LmpwZz9xdWFsaXR5/PTg2JnN0cmlwPWFs/bA", "Bicep Curls", 15, 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
