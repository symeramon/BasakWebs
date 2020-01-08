using BasakWeb.Business.Abstract;
using BasakWeb.Business.Concrete;
using BasakWeb.Controllers;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.DataAccess.Concrete.EntityFramework;
using BasakWeb.Entities;
using BasakWeb.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;

namespace BasakWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IProductService, ProductManager>();
            container.RegisterType<IProductDAL, EfProductDAL>();
            container.RegisterType<IOrderService, OrderManager>();
            container.RegisterType<IOrderDAL, EFOrderDAL>();
            container.RegisterType<ICollectionService, CollectionManager>();
            container.RegisterType<ICollectionDAL, EFCollectionDAL>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<ICartSessionService, CartSessionService>();
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<DbContext, BasakWebContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IAuthenticationManager>(
    new InjectionFactory(
        o => System.Web.HttpContext.Current.GetOwinContext().Authentication
    )
);

        }
    }
}