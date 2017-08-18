using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Logbook_System.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Learner()
        {
            return View();
        }

        public ActionResult Mentor()
        {
            return View();
        }

    }
}
