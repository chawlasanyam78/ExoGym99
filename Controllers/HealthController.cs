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
    }
}