using System;
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
        membersEntities1 db = new membersEntities1();

        public ActionResult Home()
        {
            return View();
        }

        // GET: Login/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        
        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(membersdata membersdata)
        {
            var user = db.membersdatas.Where(x => x.username == membersdata.username && x.password == membersdata.password).FirstOrDefault();
            if (user != null)
            {
                Session["username"] = user.username.ToString();
                Session["id"] = user.Id.ToString();
                return RedirectToAction("Home", "Health");
            }
            else
            {
                ViewBag.Error = "Login Failed";
                return View();
            };
        }

        // LOGOUT
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Home","Health");
        }

        //GET: Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register WITH USERNAME PASSWORD
        [HttpPost]
        public ActionResult Register(membersdata membersdata)
        {
            if(ModelState.IsValid)
            {
                db.membersdatas.Add(membersdata);
                db.SaveChanges();

                var user = db.membersdatas.Where(x => x.username == membersdata.username && x.password == membersdata.password).FirstOrDefault();
                if (user != null)
                {
                    Session["username"] = user.username.ToString();
                    Session["id"] = user.Id.ToString();
                }

                return RedirectToAction("Profile","Details");
            }
            return View("Home","Health");
        }
        
       
        public ActionResult Details(int? id)
        {
            if (Session["id"] !=null)
            {
                id =Convert.ToInt32(Session["id"]);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membersdata membersdata = db.membersdatas.Find(id);
            if(membersdata == null)
            {
                return HttpNotFound();
            }
            return View(membersdata);
        }

        //SHOW COMPLETE MEMBER LIST  
        public ActionResult Index()
        {
            var x = db.membersdatas.ToList();
            ViewBag.details = x;
            return View();
        }
           
    }

}