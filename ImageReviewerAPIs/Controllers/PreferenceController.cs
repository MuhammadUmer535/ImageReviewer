using EFCore;
using ImageReviewerAPIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ImageReviewerAPIs.Controllers
{
    public class PreferenceController : ApiController
    {
        private ImageReviewerDBEntities db = new ImageReviewerDBEntities();

        // GET api/preference/getUserPreferences/1
        public List<UserImagePreference> GetUserPreferences(int userId)
        {
            List<UserImagePreference> preferences = new List<UserImagePreference>();

            var lstpreferences = db.tblUserImagePreferences.Where(p => p.UserId == userId && p.Preference != null).ToList();

            foreach (var item in lstpreferences)
            {
                UserImagePreference uip = new UserImagePreference
                {
                    Id = item.Id,
                    ImagePath = item.tblImage.ImagePath.Trim(),
                    Preference = item.Preference
                };

                preferences.Add(uip);
            }

            return preferences;
        }

        // GET api/preference/getRandomImage
        public UserImagePreference GetRandomImage()
        {
            UserImagePreference preference = new UserImagePreference();

            var mdlpreference = db.tblUserImagePreferences.Where(p => p.Preference == null).FirstOrDefault();

            if (mdlpreference != null)
            {
                preference = new UserImagePreference
                {
                    Id = mdlpreference.Id,
                    ImagePath = mdlpreference.tblImage.ImagePath.Trim(),
                    Preference = mdlpreference.Preference
                };
            }

            return preference;
        }

        // POST api/preference/saveUserPreference
        public void SaveUserPreference(int id, bool? preference)
        {
            var mdlpreference = db.tblUserImagePreferences.Find(id);

            if (mdlpreference != null)
            {
                mdlpreference.Preference = preference;
                db.SaveChanges();
            }
        }
    }
}
