using EFCore;
using ImageReviewerAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageReviewerAPIs.Controllers;

namespace ImageReviewer.Controllers
{
    public class HomeController : Controller
    {
        private static int defaultUser = 1;

        private ImageReviewerDBEntities db = new ImageReviewerDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RandomImage()
        {
            ViewBag.Message = "Your application description page.";

            PreferenceController pref = new PreferenceController();

            var preference = pref.GetRandomImage();

            return View(preference);
        }

        public ActionResult PreferenceHistory()
        {
            ViewBag.Message = "Your preference page.";

            PreferenceController pref = new PreferenceController();

            var preferences = pref.GetUserPreferences(defaultUser);
            //var preferences = Helper.APIAccessor(defaultUser);

            return View(preferences);
        }

        [HttpPost]
        public JsonResult UpdatePreference(int id, bool? preference)
        {
            string success = "";
            PreferenceController pref = new PreferenceController();
            try
            {
                pref.SaveUserPreference(id, preference);
                success = "true";
            }
            catch
            {
                success = "false";
            }

            return Json(new { success = success });
        }
    }
}