using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PersonalNote.Models
{
    public class JournalDataAccessLayer
    {
        WorkoutDBContext db = new WorkoutDBContext();
        public IEnumerable<JournalReport> GetAllReports()
        {
            try
            {
                return db.JournalReport.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<JournalReport> GetSearchResults(string searchString)
        {
            List<JournalReport> journal = new List<JournalReport>();
            try
            {
                journal = GetAllReports().ToList();
                return journal.Where(x =>
                x.Title.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }

        public void AddJournal(JournalReport journal)
        {
            try
            {
                db.JournalReport.Add(journal);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public int UpdateJournal(JournalReport journal)
        {
            try
            {
                db.Entry(journal).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public JournalReport GetJournaltData(int id)
        {
            try
            {
                JournalReport journal = db.JournalReport.Find(id);
                return journal;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteJournal(int id)
        {
            try
            {
                if (id > 0)
                {
                    JournalReport journal = db.JournalReport.Find(id);
                    db.JournalReport.Remove(journal);
                    db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}