﻿using ExoGym.Models;
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
        
        // GET: Details List
        public ActionResult Index()
        {
            var x = dm.details.ToList();
            ViewBag.details = x;
            return View();
        }

        // SHOW DETAILS OF LOGGED IN USER:
        public ActionResult Details(int? MembersId)
        {
            if (Session["id"] != null)
            {
                MembersId = Convert.ToInt32(Session["id"]);
            }

            if (MembersId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = dm.details.Where(x => x.MembersId == MembersId).ToList();
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {                
                ViewBag.Userdetails = user;
                return View();

            }
           

        }

        [HttpGet]
         public new ActionResult Profile()
        { 
            return View();
        }

        // ADD DETAILS TO LOGGED IN USER
        [HttpPost]
        public new ActionResult Profile(detail details)
        {
            if (ModelState.IsValid)
            {
                details.MembersId = Convert.ToInt32(Session["id"].ToString());
                dm.details.Add(details);
                dm.SaveChanges();
                return RedirectToAction("Home", "Health");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
    }
