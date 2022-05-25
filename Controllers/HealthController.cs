using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExoGym.Controllers
{
    public class HealthController : Controller
    {
        // GET: Health
        public ActionResult Bmi()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Yoga()
        {
            return View();
        }

        public ActionResult Heart()
        {
            return View();
        }

        public ActionResult Maternity()
        {
            return View();
        }

        public ActionResult Old()
        {
            return View();
        }
        public ActionResult Young()
        {
            return View();
        }
    }
}