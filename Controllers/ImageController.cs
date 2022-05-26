using ExoGym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlobStorageDemo.Controllers
{
    public class ImageController : Controller
    {
        ImageService imageService = new ImageService();
        profilepicEntities pc = new profilepicEntities();

        // GET: Image  
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase photo,profilepic profilepic)
        {
            if (ModelState.IsValid)
            {
                var imageUrl = await imageService.UploadImageAsync(photo);
                Session["link"] = imageUrl.ToString();
                profilepic.linkpic = imageUrl.ToString();
                profilepic.MembersId = Convert.ToInt32(Session["id"].ToString());
                pc.profilepics.Add(profilepic);
                pc.SaveChanges();
                if (Session["link"] != null)
                {
                    //ViewBag.pics = Convert.ToString(Session["link"]);
                    return RedirectToAction("Home", "Health");
                }

                
            }
             return View();
        }


        
    }
}