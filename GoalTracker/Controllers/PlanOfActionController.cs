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
    public class PlanOfActionController : Controller
    {
        // GET: Goal
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new PlanService(userId);
            var model = service.GetPlans();

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
        public ActionResult Create(PlanCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlanService();

            if (service.CreatePlan(model))
            {
                TempData["SaveResult"] = "Your plan of action was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlanService();
            var model = svc.GetPlanById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlanService();
            var detail = service.GetPlanById(id);
            var model =
                new PlanEdit
                {
                    PlanId = detail.PlanId,
                    PlanName = detail.PlanName,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlanEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlanId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlanService();

            if (service.UpdatePlan(model))
            {
                TempData["SaveResult"] = "Your plan of action was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your plan could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlanService();
            var model = svc.GetPlanById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlanService();
            service.DeletePlan(id);
            TempData["SaveResult"] = "Your plan was deleted";

            return RedirectToAction("Index");
        }

        private PlanService CreatePlanService()
        {
            var userId = User.Identity.GetUserId();
            var service = new PlanService(userId);
            return service;
        }
    }
}