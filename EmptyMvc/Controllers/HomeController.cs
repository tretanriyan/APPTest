using EmptyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewLyubomir()
        {
            return PartialView("_Lyubomir");
        }
        [HttpPost]
        public ActionResult Lyubomir()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadAction(AnyModel model, List<HttpPostedFileBase> fileUpload)
        {
            // Your Code - / Save Model Details to DB

            // Handling Attachments - 
            foreach (HttpPostedFileBase item in fileUpload)
            {
                if (item != null && Array.Exists(model.FilesToBeUploaded.Split(','), s => s.Equals(item.FileName)))
                {
                    item.SaveAs(HttpContext.Server.MapPath("~/assets/") + item.FileName);
                    // Console.WriteLine(item.filename);
                }
            }
            return View("Index");
        }
	}
}