using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalNote.Models;

namespace PersonalNote.Controllers
{
    public class JournalController : Controller
    {
        JournalDataAccessLayer objrnl = new JournalDataAccessLayer();
        public IActionResult Index(string searchString)
        {
            List<JournalReport> lst = new List<JournalReport>();
            lst = objrnl.GetAllReports().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                lst = objrnl.GetSearchResults(searchString).ToList();
            }
            return View(lst);
        }

        public ActionResult AddEditJournal(int id)
        {
            JournalReport model = new JournalReport();
            if (id > 0)
            {
                model = objrnl.GetJournaltData(id);
            }
            return PartialView("_journalForm", model);
        }

        [HttpPost]
        public ActionResult Create(JournalReport newJournal)
        {
            if (ModelState.IsValid)
            {
                if (newJournal.Id > 0)
                {
                    objrnl.UpdateJournal(newJournal);
                }
                else
                {
                    objrnl.AddJournal(newJournal);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost("/Journal/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            objrnl.DeleteJournal(id);
            return RedirectToAction("Index");
        }

    }
}