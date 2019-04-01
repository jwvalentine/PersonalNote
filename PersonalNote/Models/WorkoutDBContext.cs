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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=myTestDB;Persist Security Info=True;Integrated Security = true");
            }
        }
    }
}
