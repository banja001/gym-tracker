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
    }
}
