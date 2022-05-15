﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExoGym.Models;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using System.Web.Security;
using System.Web.UI.WebControls;

 namespace ExoGym.Controllers
{
    public class LoginController : Controller
    {
        membersEntities db = new membersEntities();

        SqlConnection con = new SqlConnection(@"data source = (localdb)\ProjectModels; Integrated Security = SSPI");
        SqlCommand cmd = new SqlCommand();

        // GET: Login/Create
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(membersdata membersdata)
        {
            var user = db.membersdatas.Where(x => x.username == membersdata.username && x.password == membersdata.password).FirstOrDefault();
            if (user != null)
            {
                Session["Name"] = user.Name.ToString();
                string Id = user.Id.ToString();
                
                return View("Home");
            }
            else
            {
                ViewBag.Error = "Login Failed";
                return View();
            };
        }
        
       
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

       
    }

}
