using EmptyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMvc.Controllers
{
    public class CheckboxController : Controller
    {
        //
        // GET: /Checkbox/
        public ActionResult Index()
        {
            List<FilterBaseModel> ls = new List<FilterBaseModel>() { 
                new FilterBaseModel{
                    JenisSewa="KD"
                },
                new FilterBaseModel{
                    JenisSewa="KD"
                },new FilterBaseModel{
                    JenisSewa="KK"
                }
            };
            
            List<string> LS2= ls.Select(x => x.JenisSewa).Distinct().ToList();

            ViewBag.jns = LS2;
            var ft=FilterExtension.ParsingQueryURL(Request.QueryString);
            ViewBag.Filter = ft;
            return View();
        }
	}
}