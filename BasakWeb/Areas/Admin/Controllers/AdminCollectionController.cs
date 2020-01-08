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
using PagedList;

namespace BasakWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminCollectionController : Controller
    {
        ICollectionService _collectionService;
        public AdminCollectionController(ICollectionService collectionService)
        {
             _collectionService = collectionService;
        }
        BasakWebContext db = new BasakWebContext();
        // GET: Admin/AdminCollection
        public ActionResult Index(int? SayfaNo)
        {
            CollectionVM prvm = new CollectionVM();
            int _sayfaNo = SayfaNo ?? 1;
            prvm.CollectionList = _collectionService.GetAll().OrderByDescending(x => x.CollectionName).ToPagedList(_sayfaNo, 10);
            return View(prvm);
        }

        // GET: Admin/AdminCollection/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Collection collection = db.Collections.Find(id);
            //if (collection == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: Admin/AdminCollection/Create
        public ActionResult Create()
        {
            var model = new CollectionVM();
            return View(model);
        }

        // POST: Admin/AdminCollection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CollectionName,Description,Picture")] CollectionVM collectionVM)
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
                Collection clc = new Collection
                {

                    CollectionName = collectionVM.CollectionName,
                    Description = collectionVM.Description,
                    Picture = uploadFolder + fileName,
                   
                };
                _collectionService.Add(clc);
                //db.ProductVMs.Add(productVM);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //return View(productVM);
            return RedirectToAction("Index");
        }

        // GET: Admin/AdminCollection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Collection clc = _collectionService.GetById((int)id);
            if (clc == null)
            {
                return HttpNotFound();
            }
            CollectionVM productVM = new CollectionVM
            {
                CollectionName = clc.CollectionName,
                Description = clc.Description,
                Picture = clc.Picture,
               
            };
            
            return View(productVM);
        }

        // POST: Admin/AdminCollection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CollectionName,Description,Picture")] CollectionVM collectionVM)
        {
            var upload = HttpContext.Request.Files[0];
            var clocut = _collectionService.GetById(collectionVM.ID);
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
                clocut.CollectionName = collectionVM.CollectionName;
                clocut.Description = collectionVM.Description;
                clocut.Picture = fileName == "" ? clocut.Picture : uploadFolder + fileName;
                
                _collectionService.Update(clocut);
                //db.ProductVMs.Add(productVM);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //return View(productVM);
            return RedirectToAction("Index");
        }

        // GET: Admin/AdminCollection/Delete/5
        public ActionResult Delete(int? id)
        {
            _collectionService.Delete((int)id);
            return RedirectToAction("Index");
        }

        // POST: Admin/AdminCollection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Collection collection = db.Collections.Find(id);
            //db.Collections.Remove(collection);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
