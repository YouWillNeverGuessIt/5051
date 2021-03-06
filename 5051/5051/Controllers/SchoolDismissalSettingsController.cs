﻿using System.Web.Mvc;
using _5051.Models;
using _5051.Backend;

namespace _5051.Controllers
{
    /// <summary>
    /// School Dismissal Settings defaults to a single record.  So no Create or Delete, just Read, and Update
    /// </summary>

    public class SchoolDismissalSettingsController : Controller
    {
        // The Backend Data source
        private SchoolDismissalSettingsBackend SchoolDismissalSettingsBackend = SchoolDismissalSettingsBackend.Instance;

        /// <summary>
        /// Read information on a single SchoolDismissalSettings
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: SchoolDismissalSettings/Details/5
        public ActionResult Read(string id = null)
        {
            var myData = SchoolDismissalSettingsBackend.Read(id);
            if (myData == null)
            {
                // If no ID is passed in, get the first one.
                myData = SchoolDismissalSettingsBackend.GetDefault();
                if (myData == null)
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            return View(myData);
        }

        /// <summary>
        /// This will show the details of the SchoolDismissalSettings to update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: SchoolDismissalSettings/Edit/5
        public ActionResult Update(string id = null)
        {
            var myData = SchoolDismissalSettingsBackend.Read(id);
            if (myData == null)
            {
                return RedirectToAction("Error", "Home");
            }

            return View(myData);
        }

        /// <summary>
        /// This updates the SchoolDismissalSettings based on the information posted from the udpate page
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        // POST: SchoolDismissalSettings/Update/5
        [HttpPost]
        public ActionResult Update([Bind(Include=
                                        "Id," +
                                        "StartNormal," +
                                        "StartEarly," +
                                        "StartLate," +
                                        "EndNormal," +
                                        "EndEarly," +
                                        "EndLate," +
                                        "DayFirst," +
                                        "DayLast," +

                                        "")] SchoolDismissalSettingsModel data)
        {
            if (!ModelState.IsValid)
            {
                // Send back for edit
                return View(data);
            }

            if (data == null)
            {
                // Send to Error Page
                return RedirectToAction("Error", new { route = "Home", action = "Error" });
            }

            if (string.IsNullOrEmpty(data.Id))
            {
                // Send back for edit
                return View(data);
            }

            SchoolDismissalSettingsBackend.Update(data);

            return RedirectToAction("Index", "Calendar");
        }
    }
}
