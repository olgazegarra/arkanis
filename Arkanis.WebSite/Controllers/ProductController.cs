using Arkanis.Repositories;
using Arkanis.Services;
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
        public ActionResult Index()
        {
            var products = service.GetAll(translator.Translate);
            var res = new { data = products };
            return View();
        }
    }
}