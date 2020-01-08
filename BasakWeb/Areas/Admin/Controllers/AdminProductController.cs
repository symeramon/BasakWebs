using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BasakWeb.Areas.Admin.Models;
using BasakWeb.Business.Abstract;
using BasakWeb.DataAccess.Concrete.EntityFramework;
using BasakWeb.Entities.Concrete;
using BasakWeb.Helpers;
using PagedList;

namespace BasakWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminProductController : Controller
    {
        IProductService _productService;
        public AdminProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: Admin/Product
        public ActionResult Index(int? SayfaNo)
        {
            ProductVM prvm = new ProductVM();
            int _sayfaNo = SayfaNo ?? 1;
            prvm.ProductList = _productService.GetAll().Where(s => s.Silindi == false).OrderByDescending(x => x.DateAdded).ToPagedList(_sayfaNo, 10);
            return View(prvm);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ProductVM productVM = _productService.GetbyId(id);
            //if (productVM == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(productVM);
            return View();

        }
        SharedSelectListMethods _selectList = new SharedSelectListMethods();

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            var model = new ProductVM();
            model.CollectionList = _selectList.GetCollectionList();
            return View(model);
        }
       
        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ProductName,UnitPrice,UnitPriceOld,Picture,ProductDescription,Discount,CollectionId,Sold")] ProductVM productVM)
        {
            var upload = HttpContext.Request.Files[0];
            if (upload.ContentLength <= 0)
                return null;

            // here logic to upload image
            // and get file path of the image

            //const string uploadFolder = "Resimler";
            string uploadFolder = "/assets/images/product/";

            var fileName = Path.GetFileName(upload.FileName);
            var path = Path.Combine(Server.MapPath(string.Format("~/{0}", uploadFolder)), fileName);
            upload.SaveAs(path);
            if (ModelState.IsValid)
            {
                Product prd = new Product
                {
                    Collection_Id = productVM.CollectionId,
                    DateAdded = DateTime.Now,
                    Discount = productVM.Discount,
                    ProductDescription = productVM.ProductDescription,
                    Picture = uploadFolder + fileName,
                    ProductName = productVM.ProductName,
                    Sold = productVM.Sold,
                    UnitPrice = productVM.UnitPrice,
                    UnitPriceOld = productVM.UnitPriceOld
                };
                _productService.Add(prd);
                //db.ProductVMs.Add(productVM);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //return View(productVM);
            return RedirectToAction("Index");

        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product prd = _productService.GetById((int)id);
            if (prd == null)
            {
                return HttpNotFound();
            }
            ProductVM productVM = new ProductVM {
                ProductId = prd.ProductId,
                Discount = prd.Discount,
                Picture = prd.Picture,
                ProductDescription = prd.ProductDescription,
                ProductName = prd.ProductName,
                Sold = prd.Sold,
                UnitPrice = prd.UnitPrice,
                UnitPriceOld = prd.UnitPriceOld,
                CollectionId = prd.Collection_Id,
                CollectionList = _selectList.GetCollectionList()
        };
           
            return View(productVM);

        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,UnitPrice,UnitPriceOld,Picture,ProductDescription,CollectionId,Discount,Sold")] ProductVM productVM)
        {
            var upload = HttpContext.Request.Files[0];
            var prdocut = _productService.GetById(productVM.ProductId);
            string uploadFolder = "/assets/images/product/";
            var fileName = "";
            if (upload.ContentLength > 0)
            {
                // here logic to upload image
                // and get file path of the image

                //const string uploadFolder = "Resimler";

                //string fullPath = Request.MapPath(prdocut.Picture);
                //if (System.IO.File.Exists(fullPath))
                //{
                //    System.IO.File.Delete(fullPath);
                //}

                 fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath(string.Format("~/{0}", uploadFolder)), fileName);
                upload.SaveAs(path);
            }

            if (ModelState.IsValid)
            {
                prdocut.Collection_Id = productVM.CollectionId;
                    prdocut.DateAdded = DateTime.Now;
                prdocut.Discount = productVM.Discount;
                prdocut.ProductDescription = productVM.ProductDescription;
                prdocut.Picture = fileName == ""? prdocut.Picture: uploadFolder + fileName;
                prdocut.ProductName = productVM.ProductName;
                prdocut.Sold = productVM.Sold;
                prdocut.UnitPrice = productVM.UnitPrice;
                prdocut.UnitPriceOld = productVM.UnitPriceOld;
                _productService.Update(prdocut);
                //db.ProductVMs.Add(productVM);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //return View(productVM);
            return RedirectToAction("Index");

        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product prd = _productService.GetById(id);
            prd.Silindi = true;
            _productService.Update(prd);
            return RedirectToAction("Index");

        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //ProductVM productVM = db.ProductVMs.Find(id);
            //db.ProductVMs.Remove(productVM);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
