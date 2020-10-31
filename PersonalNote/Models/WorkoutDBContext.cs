using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PersonalNote.Models
{
    public class WorkoutDBContext : DbContext
    {


        public virtual DbSet<WorkoutReport> WorkoutReport { get; set; }
        public virtual DbSet<JournalReport> JournalReport { get; set; }

        public WorkoutDBContext(DbContextOptions<WorkoutDBContext> options)
        {
            this.Database.EnsureCreated();
         
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=/app/wwwroot/PersonalNote.db");
              
            }

        }
    }
}
