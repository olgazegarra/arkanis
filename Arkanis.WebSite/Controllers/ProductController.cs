using Arkanis.Repositories;
using Arkanis.Services;
using Arkanis.WebSite.Models;
using Arkanis.WebSite.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Arkanis.WebSite.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService service;
        readonly ProductTranslator translator;

        public ProductController()
        {
            var key = (string)System.Web.HttpContext.Current.Session["store"];
            this.service = new ProductService(new DataStoreFactory(key));
            this.translator = new ProductTranslator();

            var selectedStorage = new SelectListItem[]{
                new SelectListItem() { Text = "Application", Value = "app"},
                new SelectListItem() { Text = "Memory", Value = "memory"},
                new SelectListItem() { Text = "MySql", Value = "database"}};
            if (!string.IsNullOrWhiteSpace(key))
                selectedStorage.Where(i => i.Value.Equals(key)).FirstOrDefault().Selected = true;
            ViewBag.selectedStorage = selectedStorage;
        }

        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            var products = service.GetAll(translator.Translate);
            return View(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int id = service.Create(model.code, model.title, model.description, model.unitPrice, model.unitsInStock, model.discount, model.unitsOrdered, model.createdBy);
            model.id = id;
            return RedirectToAction("Index");
        }
    }
}