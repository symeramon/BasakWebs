using BasakWeb.Business.Abstract;
using BasakWeb.DataAccess.Concrete.EntityFramework;
using BasakWeb.Entities;
using BasakWeb.Entities.Concrete;
using BasakWeb.Models;
using BasakWeb.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace BasakWeb.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        private ICartSessionService _cartSessionService;
        private IProductService _productService;
        private ICartService _cartService;
        private IOrderService _orderService;

        public CartController(ICartSessionService cartSessionService, IOrderService orderService, ICartService cartService, IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
            _orderService = orderService;
        }

        [HttpPost]
        public JsonResult AddToCart(int productid)
        {
            var productToBeAdded = _productService.GetbyId(productid);
            if (productToBeAdded.Sold == false)
            {
                var cart = _cartSessionService.GetCart();
                if (_cartService.AddToCart(cart, productToBeAdded) == true)
                {
                    _cartSessionService.SetCart(cart);
                    //TempData.Add("messager", String.Format("Your product {0} was successfully added to cart", productToBeAdded.ProductName));
                    //return RedirectToAction("Index", "Product");
                    return Json(new { success = true });
                }
                //cart nesnesini ekledikkten sonra tekrar sessiona atmamız gerekiyor kaybolmasın diye
               
            }
            return Json(new { success = false });
        }
        public ActionResult Remove(int productid)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productid);
            _cartSessionService.SetCart(cart);
            TempData.Add("messager", String.Format("Ürününüz sepetten çıkarıldı"));
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }
        public ActionResult Complete()
        {
            var cart = _cartSessionService.GetCart();
            var OrderVM = new OrderViewModel();
            OrderVM.Cart = cart;
            return View(OrderVM);//bu kısımda veritabanına kaydetme aşamalarını atladık sen yap
        }
        [HttpPost]
        public ActionResult Complete(OrderViewModel orderViewModel)
        {
            Order ord = new Order();
            Guid userid = Guid.NewGuid();
            var cart = _cartSessionService.GetCart();
            if (cart == null)
            {
                return RedirectToAction("Index","Home");
            }
            var user = new ApplicationUser { Id = userid.ToString(), UserName = orderViewModel.Email, FirstName = orderViewModel.FirstName, LastName = orderViewModel.LastName, Email = orderViewModel.Email, Address = orderViewModel.Address, Phone = orderViewModel.Phone };
            int id = 0;
            if (ModelState.IsValid)
            {

                

                using (var context = new BasakWebContext())
                {
                    var addedEntityUser = context.Entry(user);
                    addedEntityUser.State = EntityState.Added;
                    context.SaveChanges();

                    ord.CustomerID = userid.ToString();
                    ord.Sozlesme = orderViewModel.Sozlesme;
                    ord.OrderDate = DateTime.Now;
                    ord.ShipAddress = orderViewModel.Address;
                    ord.ShipCity = orderViewModel.ShipCity;


                    _orderService.Add(ord);
                    id = ord.OrderId; // Yes it's here

                    foreach (var item in cart.CartLines)
                    {
                        
                        OrderDetails orddetail = new OrderDetails();
                        orddetail.OrderId = id;
                        orddetail.ProductID = item.Product.ProductId;
                        orddetail.UnitPrice = (int)item.Product.UnitPrice;
                        _orderService.AddOrdDetails(orddetail);

                        var productToBeAdded = _productService.GetbyId(item.Product.ProductId);
                        productToBeAdded.Sold = true;
                        _productService.Update(productToBeAdded);
                    }
                    
                }

            }

            TempData.Add("messager", String.Format("Teşekkürler {0}, 24 saat içinde havale yapıldıktan sonra siparişiniz işleme koyulacak ", orderViewModel.FirstName));
            SmtpClient smtp = new SmtpClient();

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress("basgulcan@gmail.com"));
            msg.Subject = "Sipariş";
            msg.Body = "Birtanem yeni bir siparişin var!";
            msg.From = new MailAddress("basakweb001@gmail.com", "BasakWeb");
            msg.IsBodyHtml = true;

            MailMessage msg2 = new MailMessage();
            msg2.To.Add(new MailAddress(orderViewModel.Email));
            msg2.Subject = "Quubik Sipariş";
            msg2.Body = "Sipariş Kodunuz :"+ id+ " Lütfen 24 saat içinde havale işlemini gerçekleştiriniz.";
            msg2.From = new MailAddress("basakweb001@gmail.com", "BasakWeb");
            msg2.IsBodyHtml = true;

            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("basakweb001@gmail.com", "basakweb5745G");
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(msg);
            smtp.Send(msg2);

            msg.Dispose();
            Session.Clear();
            return RedirectToAction("List");
        }
    }
}