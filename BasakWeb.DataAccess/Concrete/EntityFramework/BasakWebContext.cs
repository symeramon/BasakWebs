
using BasakWeb.Entities.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace BasakWeb.DataAccess.Concrete.EntityFramework
{
    public class BasakWebContext : DbContext
    {
        public BasakWebContext()
          : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static BasakWebContext Create()
        {
            return new BasakWebContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartLine> CartLines { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Collection> Collections { get; set; }

    }
}
