using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExoGym.Controllers
{
    
    public class ImageController : Controller
    {
        ImageService imageService = new ImageService();
       // GET: Image  
         public ActionResult Upload()
            {
               return View();
            }
    }
}