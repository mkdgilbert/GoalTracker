using Microsoft.AspNet.Identity;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoalTracker.Controllers
{
    [Authorize]
    public class GoalController : Controller
    {
        // GET: Goal
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new GoalService(userId);
            var model = service.GetGoals();

            return View(model);
        }

        //get
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GoalCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGoalService();

            if (service.CreateGoal(model))
            {
                TempData["SaveResult"] = "Your Goal was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Goal could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGoalService();
            var model = svc.GetGoalById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGoalService();
            var detail = service.GetGoalById(id);
            var model =
                new GoalEdit
                {
                    GoalId = detail.GoalId,
                    GoalCost = detail.GoalCost,
                    //FinanceOption = detail.FinanceOption,
                    //OutOfPocketOption = detail.OutOfPocketOption,
                    GoalName = detail.GoalName,
                    GoalType = detail.GoalType,
                    NumberOfYears= detail.NumberOfYears,
                    InterestRate = detail.InterestRate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GoalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GoalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGoalService();

            if (service.UpdateGoal(model))
            {
                TempData["SaveResult"] = "Your goal was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your goal could not be updated.");
            return View();
        }
        
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateGoalService();
            var model = svc.GetGoalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGoalService();
            service.DeleteGoal(id);
            TempData["SaveResult"] = "Your Goal was deleted";

            return RedirectToAction("Index");
        }

        private GoalService CreateGoalService()
        {
            var userId = User.Identity.GetUserId();
            var service = new GoalService(userId);
            return service;
        }
    }
}