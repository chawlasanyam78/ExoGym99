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
using MySqlX.XDevAPI;

namespace ExoGym.Controllers
{
    public class membersdatasController : Controller
    {
        membersEntities db = new membersEntities();
       
        // GET: membersdatas
        public async Task<ActionResult> Index()
        {
            return View(await db.membersdatas.ToListAsync());
        } 

        // GET: membersdatas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membersdata membersdata = await db.membersdatas.FindAsync(id);
            if (membersdata == null)
            {
                return HttpNotFound();
            }
            return View(membersdata);
        }

        // GET: membersdatas/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: membersdatas/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Include = "Id,username,password,Name,Mobile,Address")] membersdata membersdata)
        {
            if (ModelState.IsValid)
            {
                db.membersdatas.Add(membersdata);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(membersdata);
        }

        // GET: EDIT
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membersdata membersdata = await db.membersdatas.FindAsync(id);
            if (membersdata == null)
            {
                return HttpNotFound();
            }
            return View(membersdata);
        }

        // POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,username,password,Name,Mobile,Address")] membersdata membersdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membersdata).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(membersdata);
        }

        // GET: membersdatas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membersdata membersdata = await db.membersdatas.FindAsync(id);
            if (membersdata == null)
            {
                return HttpNotFound();
            }
            return View(membersdata);
        }

        // POST: membersdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            membersdata membersdata = await db.membersdatas.FindAsync(id);
            db.membersdatas.Remove(membersdata);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public async Task<ActionResult> Test(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            membersdata membersdata = await db.membersdatas.FindAsync(id);
            if (membersdata == null)
            {
                return HttpNotFound();
            }
            return View(membersdata);
           
        }
      
    }
    }
