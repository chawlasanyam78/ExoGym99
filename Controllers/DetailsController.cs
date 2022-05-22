using ExoGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ExoGym.Controllers
{
    public class DetailsController : Controller
         
    {
        detailsEntities dm = new detailsEntities();
        // GET: Details

        public ActionResult Index()
        {
            var x = dm.details.ToList();
            ViewBag.details = x;
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (Session["id"] != null)
            {
                id = Convert.ToInt32(Session["id"]);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detail details = dm.details.Find(id);
            if (details == null)
            {
                return HttpNotFound();
            }
            return View(details);
        }
        [HttpGet]
         public ActionResult Profile()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Profile(detail details)
        {
            if (ModelState.IsValid)
            {
                details.MembersId = Convert.ToInt32(Session["id"].ToString());
                dm.details.Add(details);
                dm.SaveChanges();
                return View("Index");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
    }
