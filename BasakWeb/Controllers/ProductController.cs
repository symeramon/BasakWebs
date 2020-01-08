using BasakWeb.Business.Abstract;
using BasakWeb.Entities.Concrete;
using BasakWeb.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasakWeb.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Product
        public ActionResult Index(int? SayfaNo)
        {
            ProductVM pvm = new ProductVM();
            int _sayfaNo = SayfaNo ?? 1;
            pvm.ProductList = _productService.GetAll().Where(z => z.Silindi == false).OrderByDescending(x => x.DateAdded).ToPagedList(_sayfaNo, 10);
            return View(pvm);
        }

        public JsonResult BenzerGetir(int productid)
        {
            IEnumerable<Product> prlist = _productService.GetSimilars(productid);
            return Json(prlist, JsonRequestBehavior.AllowGet);
        }
    }
}