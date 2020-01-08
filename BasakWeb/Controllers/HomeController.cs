using BasakWeb.Business.Abstract;
using BasakWeb.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasakWeb.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;
        ICollectionService _collectionService;
        public ICartSessionService _cartSessionService;
        
        public HomeController(ICartSessionService cartSessionService,IProductService productService, ICollectionService collectionService)
        {
            _productService = productService;
            _cartSessionService = cartSessionService;
            _collectionService = collectionService;
        }
       
        // GET: Product
        public ActionResult Index()

        {
            //ProductVM pvm = new ProductVM();
            //GetUserIdAndAccessToken();
            //pvm.ProductList = _productService.GetAll();
            GirisPageVM gpv = new GirisPageVM();
            gpv.LatestProducts = _productService.GetLatest();
            gpv.Collections = _collectionService.GetAll();
            gpv.ProductList = _productService.GetAll().Where(s => s.Silindi == false).OrderByDescending(x => x.DateAdded);
            return View(gpv);
        }
        public void GetUserIdAndAccessToken()
        {
            //NameValueCollection parameters = new NameValueCollection();
            //parameters.Add("client_id", "ea68a85350ab4fb0b4f935fb50db6910");
            //parameters.Add("client_secret", " db32c4c6f9c14de18c1d309827605228 ");
            //parameters.Add("grant_type", "authorization_code");
            //parameters.Add("redirect_uri", "http://localhost:54085/Home/Index");
            //parameters.Add("code", 400);

            //WebClient client = new WebClient();
            //var result = client.UploadValues("https://api.instagram.com/oauth/access_token", "POST", parameters);
            //var response = System.Text.Encoding.Default.GetString(result);

            //var returnContent = (JObject)JsonConvert.DeserializeObject(response);
            //string accessToken = (string)returnContent["access_token"];
            //string id = returnContent["user"]["id"].ToString();

            //var script = string.Format("<script>var userId = \"{0}\"; var accessToken = \"{1}\";</script>",
            //    id,
            //    accessToken
            //    );
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "GetToken", script);
        }
        public ActionResult CartReturn()
        {
            var model = new CartSummaryViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return PartialView(@"~\Views\PartialViews\CartSummary.cshtml", model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Collection(int? SayfaNo,int? id)
        {
            ProductVM pvm = new ProductVM();
            int _sayfaNo = SayfaNo ?? 1;
            pvm.ProductList = _productService.GetByCollection(id).Where(s => s.Silindi == false).ToPagedList(_sayfaNo, 10);

            return View(pvm);
        }
    }
}