﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartPTUI.Business.Transactions;
using SmartPTUI.Business.ViewModelRepo;
using SmartPTUI.Data.DomainModels;
using System.Threading.Tasks;

namespace SmartPTUI.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly IWorkoutTransaction _workoutTransaction;
        public WorkoutController(IWorkoutTransaction workoutTransaction)
        {
            _workoutTransaction = workoutTransaction;
        }

        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> Index(int workoutId)
        {
            var workoutPlan = await _workoutTransaction.GetWorkoutPlan(workoutId);

            return View(workoutPlan);
        }




        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> WorkoutWeek(int id)
        {
            var workoutWeek = await _workoutTransaction.GetWorkoutWeek(id);

            return View(workoutWeek);
        }




        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> WorkoutSession(int id)
        {
            var workoutSession = await _workoutTransaction.GetWorkoutSession(id);


            return View(workoutSession);
        }




        [Authorize(Roles = "APPUSERROLE")]
        public async Task<IActionResult> ExcersizeMeta(int id)
        {
            var excersizeMeta = await _workoutTransaction.GetExcersizeMeta(id);

            return View(excersizeMeta);
        }




        [Authorize(Roles = "APPUSERROLE")]
        [HttpPost]
        public async Task<IActionResult> SubmitExcersizeMeta(ExcersizeMeta excersizeMeta)
        {
            if (!ModelState.IsValid)
            {
                return View("ExcersizeMeta", excersizeMeta);
            }

            //If the form has no validation issues set flag as complete, save to db and return to workout session parent page
            excersizeMeta.isCompletedExcersizeMeta = true;
            await _workoutTransaction.SaveExcersizeMeta(excersizeMeta);

            return RedirectToAction("WorkoutSession", "Workout", new { id = excersizeMeta.Workout.WorkoutSessionId });
        }




        [Authorize(Roles = "APPUSERROLE")]
        [HttpPost]
        public async Task<IActionResult> SubmitWorkoutSession(WorkoutSession workoutSession)
        {
            
            //Performs validation to ensure nested Excersize Meta's are complete
            if (!await ValidateWorkoutSession(workoutSession.WorkoutSessionId))
            {
                return RedirectToAction("WorkoutSession", "Workout", new { id = workoutSession.WorkoutSessionId });
            }


            workoutSession.isCompletedWorkoutSession = true;
            await _workoutTransaction.SaveWorkoutSession(workoutSession);

            return RedirectToAction("WorkoutWeek", "Workout", new { id = workoutSession.WorkoutWeek.WorkoutWeekId });
        }




        [Authorize(Roles = "APPUSERROLE")]
        [HttpPost]
        public async Task<IActionResult> SubmitWorkoutWeek(WorkoutWeek workoutWeek)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("WorkoutWeek", "Workout", new { id = workoutWeek.WorkoutWeekId });
            }

            //Performs validation to ensure nested workout sessions are complete
            if (!await ValidateWorkoutWeek(workoutWeek.WorkoutWeekId))
            {
                return RedirectToAction("WorkoutWeek", "Workout", new { id = workoutWeek.WorkoutWeekId });
            }

            workoutWeek.isCompletedWorkoutWeek = true;
            await _workoutTransaction.SaveWorkoutWeek(workoutWeek);

            //Based on this workout week's data next week's is calculated
            await _workoutTransaction.CalculateNextWorkoutWeek(workoutWeek.WorkoutPlan.WorkoutPlanId);

            return RedirectToAction("Index", "Workout", new { workoutId = workoutWeek.WorkoutPlan.WorkoutPlanId });
        }



        [Authorize(Roles = "APPUSERROLE")]
        [HttpPost]
        public async Task<IActionResult> SubmitWorkoutPlan(WorkoutPlan workoutPlan)
        {

            if (!ModelState.IsValid)
            {
                return View("WorkoutPlan", workoutPlan);
            }

            //Performs validation ensuring nested workout weeks are complete
            if (!await ValidateWorkoutPlan(workoutPlan.WorkoutPlanId))
            {
                return RedirectToAction("Index", "Workout", new { workoutId = workoutPlan.WorkoutPlanId });
            }

            workoutPlan.isCompletedWorkoutPlan = true;
            await _workoutTransaction.SaveWorkoutPlan(workoutPlan);

            return RedirectToAction("Index", "Workout", new { workoutId = workoutPlan.WorkoutPlanId });
        }




        private async Task<bool> ValidateWorkoutSession(int workoutSessionId)
        {
            var workoutSession = await _workoutTransaction.GetWorkoutSession(workoutSessionId);


            foreach (var excersize in workoutSession.Excersizes)
            {
                if (!excersize.isCompletedExcersizeMeta)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> ValidateWorkoutWeek(int workoutWeekId)
        {
            var workoutWeek = await _workoutTransaction.GetWorkoutWeek(workoutWeekId);


            foreach (var workoutSession in workoutWeek.Workout)
            {
                if (!workoutSession.isCompletedWorkoutSession)
                {
                    return false;
                }
            }

            return true;
        }

        private async Task<bool> ValidateWorkoutPlan(int workoutPlanId)
        {
            var workoutWeek = await _workoutTransaction.GetWorkoutPlan(workoutPlanId);


            foreach (var workoutSession in workoutWeek.WorkoutWeek)
            {
                if (!workoutSession.isCompletedWorkoutWeek)
                {
                    return false;
                }
            }

            return true;
        }



    }
}
