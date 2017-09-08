using Arkanis.Repositories;
using Arkanis.Services;
using Arkanis.WebSite.Models;
using Arkanis.WebSite.Translators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Arkanis.WebSite.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService service;
        readonly ProductTranslator translator;

        public ProductController()
        {
            this.service = new ProductService(new ProductRepository());
            this.translator = new ProductTranslator();
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