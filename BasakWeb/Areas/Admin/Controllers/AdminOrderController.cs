using BasakWeb.Areas.Admin.Models;
using BasakWeb.Business.Abstract;
using BasakWeb.Entities.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BasakWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminOrderController : Controller
    {
        IOrderService _orderService;
        public AdminOrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: Admin/Order
        public ActionResult Index(int? SayfaNo)
        {
            OrderVM prvm = new OrderVM();
            int _sayfaNo = SayfaNo ?? 1;
            prvm.OrderList = _orderService.GetAllwithDetails().Where(s=> s.Silindi == false).OrderByDescending(x => x.OrderDate).ToPagedList(_sayfaNo, 10);
            return View(prvm);
        }
        public ActionResult Details(int? OrderID)
        {
            if (OrderID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order Ordr = _orderService.GetById((int)OrderID);
            if (Ordr == null)
            {
                return HttpNotFound();
            }
            return View(Ordr);
        }
        public ActionResult SiparisveUrunSil(int orderid)
        {
            _orderService.SiparisSil(orderid);
            return RedirectToAction("Index");
        }
        public ActionResult SatildiKaldir(int orderid)
        {
            _orderService.SatildiKaldir(orderid);
            return RedirectToAction("Index");
        }
        public ActionResult SiparisSil(int orderid)
        {
            _orderService.SadeSiparisSil(orderid);
            return RedirectToAction("Index");
        }
    }
}