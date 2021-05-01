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
    public class UserInfoController : Controller
    {
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new UserInfoService(userId);
            var model = service.GetUserInfo();

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
        public ActionResult Create(UserInfoCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateUserService();

            if (service.CreateUserInfo(model))
            {
                TempData["SaveResult"] = "Your user information was added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your user information couldn't be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateUserService();
            var model = svc.GetUserById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateUserService();
            var detail = service.GetUserById(id);
            var model =
                new UserInfoEdit
                {
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserInfoEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.UserInfoId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateUserService();

            if (service.UpdateUserInfo(model))
            {
                TempData["SaveResult"] = "Your user information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your user information could not be updated.");
            return View();
        }
        
        private UserInfoService CreateUserService()
        {
            var userId = User.Identity.GetUserId();
            var service = new UserInfoService(userId);
            return service;
        }
    }
}
