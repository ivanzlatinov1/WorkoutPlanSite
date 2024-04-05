using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
            };
            builder.Entity<Type>().HasData(types);
            builder.Entity<Equipment>().Navigation(e => e.Type).AutoInclude();
            base.OnModelCreating(builder);
        }
    }
}
