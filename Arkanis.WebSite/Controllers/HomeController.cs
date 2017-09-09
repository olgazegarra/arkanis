using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arkanis.WebSite.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStorage()
        {
            if (Request != null)
                System.Web.HttpContext.Current.Session["store"] = Request.Form["ddlStorage"].ToString();
            return RedirectToAction("Index", "Product");
        }
    }
}