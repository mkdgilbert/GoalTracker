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
    public class AssetController : Controller
    {
        // GET: Goal
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new AssetService(userId);
            var model = service.GetAssets();

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
        public ActionResult Create(AssetCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAssetService();

            if (service.CreateAsset(model))
            {
                TempData["SaveResult"] = "Your Assets were created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Asset could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAssetService();
            var model = svc.GetAssetById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAssetService();
            var detail = service.GetAssetById(id);
            var model =
                new AssetEdit
                {
                    AssetId = detail.AssetId,
                    HouseAppraisal = detail.HouseAppraisal,
                    HouseDebt = detail.HouseDebt,
                    AvailableCash = detail.AvailableCash,
                    YearlyIncome = detail.YearlyIncome,
                    TotalDebt = detail.TotalDebt,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssetEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AssetId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateAssetService();

            if (service.UpdateAsset(model))
            {
                TempData["SaveResult"] = "Your asset was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your asset could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAssetService();
            var model = svc.GetAssetById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAssetService();
            service.DeleteAsset(id);
            TempData["SaveResult"] = "Your asset was deleted";

            return RedirectToAction("Index");
        }

        private AssetService CreateAssetService()
        {
            var userId = User.Identity.GetUserId();
            var service = new AssetService(userId);
            return service;
        }
    }
}