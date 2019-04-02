﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalNote.Models;

namespace PersonalNote.Controllers
{
    public class WorkoutController : Controller
    {
        WorkoutDataAccessLayer objwo = new WorkoutDataAccessLayer();
        public IActionResult Index(string searchString)
        {
            List<WorkoutReport> lstEmployee = new List<WorkoutReport>();
            lstEmployee = objwo.GetAllReports().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                lstEmployee = objwo.GetSearchResults(searchString).ToList();
            }
            return View(lstEmployee);
        }

        public ActionResult AddEditWorkout(int id)
        {
            WorkoutReport model = new WorkoutReport();
            if (id > 0)
            {
                model = objwo.GetWorkoutData(id);
            }
            return PartialView("_workoutForm", model);
        }

        [HttpPost]
        public ActionResult Create(WorkoutReport newWorkout)
        {
            if (ModelState.IsValid)
            {
                if (newWorkout.Id > 0)
                {
                    objwo.UpdateWorkout(newWorkout);
                }
                else
                {
                    objwo.AddWorkout(newWorkout);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            objwo.DeleteWorkout(id);
            return RedirectToAction("Index");
        }

        public ActionResult WorkoutSummary()
        {
            return PartialView("_workoutReport");
        }

        public JsonResult GetMonthlyWorkout()
        {
            Dictionary<string, float> monthlyWorkout = objwo.CalculateMonthlyWorkouts();
            return new JsonResult(monthlyWorkout);
        }
    }
}