using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PersonalNote.Models
{
    public class WorkoutDataAccessLayer
    {
        WorkoutDBContext db = new WorkoutDBContext();
        public IEnumerable<WorkoutReport> GetAllReports()
        {
            try
            {
                return db.WorkoutReport.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<WorkoutReport> GetSearchResults(string searchString)
        {
            List<WorkoutReport> wo = new List<WorkoutReport>();
            try
            {
                wo = GetAllReports().ToList();
                return wo.Where(x =>
                x.ItemName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }


        public void AddWorkout(WorkoutReport workout)
        {
            try
            {
                db.WorkoutReport.Add(workout);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int UpdateWorkout(WorkoutReport workout)
        {
            try
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public WorkoutReport GetWorkoutData(int id)
        {
            try
            {
                WorkoutReport workout = db.WorkoutReport.Find(id);
                return workout;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteWorkout(int id)
        {
            try
            {
                WorkoutReport wo = db.WorkoutReport.Find(id);
                db.WorkoutReport.Remove(wo);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // TODO: calculate the last six months
        public Dictionary<string, float> CalculateMonthlyWorkouts()
        {
            WorkoutDataAccessLayer objwo = new WorkoutDataAccessLayer();
            List<WorkoutReport> lstEmployee = new List<WorkoutReport>();

            Dictionary<string, float> dictMonthlySum = new Dictionary<string, float>();

            float cardioSum = db.WorkoutReport.Where
                (cat => cat.Category == "Cardio" && (cat.WorkoutDate > DateTime.Now.AddMonths(-7)))
                .Select(cat => cat.Calories)
                .Sum();

            dictMonthlySum.Add("Cardio", cardioSum);

            return dictMonthlySum;
        }
    }
}