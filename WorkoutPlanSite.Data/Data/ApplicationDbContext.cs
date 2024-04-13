using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkoutPlanSite.Data.Data.Models.Enums;
using WorkoutPlanSite.Data.Models;
using Type = WorkoutPlanSite.Data.Models.Type;

namespace WorkoutPlanSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Type[] types = new Type[]
            {
                new()
                {
                    Id = 1,
                    Name = "Machines",
                },
                new()
                {
                    Id = 2,
                    Name = "Dumbells",
                },
                 new()
                {
                    Id = 3,
                    Name = "Bars",
                },
                 new()
                {
                    Id = 4,
                    Name = "No equipment",
                },
            };
            builder.Entity<Type>().HasData(types);
            builder.Entity<Equipment>().Navigation(e => e.Type).AutoInclude();
            builder.Entity<Exercise>().Navigation(e => e.Equipment).AutoInclude();

            Equipment[] equipments = new Equipment[] 
            {
                new Equipment { Id = 1, TypeId = 3, Name = "Barbell", Weight = 20, Plan = Plan.Intermediate, ImageUrl = "https://m.media-amazon.com/images/I/31vTXdGDWLL.jpg", Metric = Metric.kg},
                new Equipment { Id = 2, TypeId = 4, Name = "Body Weight", Weight = 0, Plan = Plan.Beginner, ImageUrl = "https://imgs.search.brave.com/Q6ZRty_7PTVms2Ni56mUW1fXs4NQqg7t399z1sP3QSA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRs/aW5lcGx1cy5nb3Yv/aW1hZ2VzL0JvZHlX/ZWlnaHQuanBn", Metric = Metric.kg},
                new Equipment { Id = 3, TypeId = 2, Name = "Dumbells", Weight = 10, Plan = Plan.Beginner, ImageUrl = "https://imgs.search.brave.com/vzhkhzilFvRdJdKWOORL3c2c2KZ40_We6VCCf8_WszE/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWFn/ZXMudW5zcGxhc2gu/Y29tL3Bob3RvLTE1/NzY2Nzg5Mjc0ODQt/Y2M5MDc5NTcwODhj/P3E9ODAmdz0xMDAw/JmF1dG89Zm9ybWF0/JmZpdD1jcm9wJml4/bGliPXJiLTQuMC4z/Jml4aWQ9TTN3eE1q/QTNmREI4TUh4elpX/RnlZMmg4TW54OFpI/VnRZbUpsYkd4emZH/VnVmREI4ZkRCOGZI/d3c", Metric = Metric.kg},
                new Equipment { Id = 4, TypeId = 1, Name = "Leg Press", Weight = 160, Plan = Plan.Advanced, ImageUrl = "https://imgs.search.brave.com/h9Uqz_X203ywQAK6tSpJ62bzBBeT2b9UGXP-uAIA2g8/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5nZXR0eWltYWdl/cy5jb20vaWQvMTg2/OTY0OTAyMC9waG90/by9tYW4tZXhlcmNp/c2luZy1vbi1sZWct/cHJlc3MuanBnP3M9/NjEyeDYxMiZ3PTAm/az0yMCZjPVZhQWVa/Y21nY3BkbTZVZ2hW/eDZUUW1SSDBQM0xk/d3RpR2wzMmpQalpm/Vm89", Metric = Metric.kg},
                new Equipment { Id = 5, TypeId = 1, Name = "ShoulderPressMachine", Weight = 44, Plan = Plan.Intermediate, ImageUrl = "https://imgs.search.brave.com/zodUy4Bq1GO6EcDYqj7PLEdi2da2XwI1lRFIjU8-CyI/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9hdGxh/bnRpc3N0cmVuZ3Ro/LmNvbS9hcHAvdXBs/b2Fkcy8yMDIyLzAx/L3B3NDQ5XzItNDE2/eDQxOC5wbmc", Metric = Metric.lbs},
                new Equipment { Id = 6, TypeId = 2, Name = "Light Dumbells", Weight = 5, Plan = Plan.Beginner, ImageUrl = "https://imgs.search.brave.com/SpT2VHXiOA03VRnEXdGRZ7zWWbuFy1W2UYsUco2dbI4/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tLm1l/ZGlhLWFtYXpvbi5j/b20vaW1hZ2VzL0kv/ODFOS0tqUkgtbkwu/anBn", Metric = Metric.kg},
            };
            builder.Entity<Equipment>().HasData(equipments);

            Exercise[] exercises = new Exercise[]
            {
                new Exercise { Id = 1, Name = "Bench Press", Description = "Adding weight increases the difficulty.", Sets = 5, EquipmentId = 1, ImageURL = "https://imgs.search.brave.com/WsIfyLRdsOp2l_b93ZuNovQ0N6xWwRlmd7J60YcQpdA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly90My5m/dGNkbi5uZXQvanBn/LzAwLzc4LzQyLzY0/LzM2MF9GXzc4NDI2/NDc2XzFiMG5vRzFF/bDk2MUFiamFRMG4w/cDloVkJhcVo2OWZ5/LmpwZw", difficulty = ExerciseDifficulty.Hard, Repetitions = 10},
                new Exercise { Id = 2, Name = "Push Ups", Description = "An exercise that affects many muscle groups.", Sets = 5, EquipmentId = 2, ImageURL = "https://imgs.search.brave.com/txguJTQwUh-aVLcTs5KN5-R9d2wygtXauaQRnoTDFqE/rs:fit:500:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/cHJlbWl1bS1waG90/by9tdXNjdWxhci1t/YW4tZG9pbmctcHVz/aHVwc18xMzMzOS0x/NTExMDMuanBnP3Np/emU9NjI2JmV4dD1q/cGc", difficulty = ExerciseDifficulty.Easy, Repetitions = 20},
                new Exercise { Id = 3, Name = "Lateral Raises", Description = "Best shoulder exercise.", Sets = 3, EquipmentId = 3, ImageURL = "https://imgs.search.brave.com/pE3uivlySZ9u5Krg650stNPFS7GSBqkqbqprETtZd3k/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9oaXBz/LmhlYXJzdGFwcHMu/Y29tL2htZy1wcm9k/L2ltYWdlcy9sYXRl/cmFsLXJhaXNlcy0x/NjY3NTYzMjE4Lmpw/Zz9yZXNpemU9OTgw/Oio", difficulty = ExerciseDifficulty.Medium, Repetitions = 20},
                new Exercise { Id = 4, Name = "Shoulder Press", Description = "The casual shoulder press.", Sets = 3, EquipmentId = 5, ImageURL = "https://imgs.search.brave.com/FffOzDwfbcV5YLP8coMNa0t1YsS0NNZJOSn0fhAdWEs/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9maXRs/aWZlZmFuYXRpY3Mu/Y29tL3dwLWNvbnRl/bnQvdXBsb2Fkcy8y/MDIwLzA1L3Nob3Vs/ZGVyLXByZXNzLW1h/Y2hpbmVzLTc4MHg0/NzAuanBn", difficulty = ExerciseDifficulty.Medium, Repetitions = 15},
                new Exercise { Id = 5, Name = "Leg Press", Description = "Requires lots of endurance.", Sets = 5, EquipmentId = 4, ImageURL = "https://imgs.search.brave.com/4g4i0m7XWDQazbokaw4CImRFLEgjQLFJAVZXYvQkEJE/rs:fit:860:0:0/g:ce/aHR0cHM6Ly90NC5m/dGNkbi5uZXQvanBn/LzAwLzkyLzg4LzI3/LzM2MF9GXzkyODgy/Nzk2XzVwSldta1Mx/YXMxMUFnZERJTkp3/T05ZQkE1NWEzUGZ6/LmpwZw", difficulty = ExerciseDifficulty.Hard, Repetitions = 20},
                new Exercise { Id = 6, Name = "Bicep Curls", Description = "An old school exercise.", Sets = 4, EquipmentId = 3, ImageURL = "https://imgs.search.brave.com/TaoILpBPBJPPH5z3HtuoWIXcIOMingymHVe4ew4ZNEA/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pMC53/cC5jb20vd3d3Lm11/c2NsZWFuZGZpdG5l/c3MuY29tL3dwLWNv/bnRlbnQvdXBsb2Fk/cy8yMDE4LzEwLzEx/MDktLUJpY2VwLUN1/cmwtR2V0dHlJbWFn/ZXMtNTkxNDAzNjQ1/LmpwZz9xdWFsaXR5/PTg2JnN0cmlwPWFs/bA", difficulty = ExerciseDifficulty.Medium, Repetitions = 15}
            };
            builder.Entity<Exercise>().HasData(exercises);

            base.OnModelCreating(builder);
        }
    }
}
