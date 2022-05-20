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
        membersEntities db = new membersEntities();


        public ActionResult Home()
        {
            return View();
        }

        // GET: Login/Create
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST LOGIN
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(membersdata membersdata)
        {
            var user = db.membersdatas.Where(x => x.username == membersdata.username && x.password == membersdata.password).FirstOrDefault();
            if (user != null)
            {
                Session["Name"] = user.Name.ToString();
                Session["id"] = user.Id.ToString();
                return View("Home");  
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
            return RedirectToAction("Home");
        }

       
    }

}
