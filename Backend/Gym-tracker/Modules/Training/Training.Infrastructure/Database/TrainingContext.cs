using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Core.Domain;

namespace Training.Infrastructure.Database
{
    public class TrainingContext : DbContext
    {
        public DbSet<Workout> Workouts { get; set; }

        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Workout>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .ValueGeneratedOnAdd();  

                entity.ToTable("Workouts", "training"); 
            });
        }
    }
}
