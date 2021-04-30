using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechShop.Models.Repositories;

namespace TechShop.Data
{
    public class TechShopDB: IdentityDbContext<ApplicationUser>
    {
        public TechShopDB(DbContextOptions<TechShopDB> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CategoryBrand>()
                .HasKey(cb => new { cb.CategoryId, cb.BrandId });

            builder.Entity<CategoryBrand>()
                .HasOne(cb => cb.Category)
                .WithMany(c => c.CategoryBrands)
                .HasForeignKey(cb => cb.CategoryId);

            builder.Entity<CategoryBrand>()
                .HasOne(cb => cb.Brand)
                .WithMany(b => b.CategoryBrands)
                .HasForeignKey(cb => cb.BrandId);

            //--------------------------------------------------------

            builder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            builder.Entity<Brand>()
                .HasKey(b => b.BrandId);


            builder.Entity<Product>()
                .HasKey(p => p.ProductId);

            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(fk => fk.CategoryId);

            builder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(c => c.Products)
                .HasForeignKey(fk => fk.BrandId);

            //-----------------------------------------------------

            builder.Entity<BillDetail>()
                .HasKey(b => new { b.BillId,b.ProductId});

            builder.Entity<BillDetail>()
                .HasOne(b => b.Bill)
                .WithMany(b => b.BillDetails)
                .HasForeignKey(b => b.BillId);

            builder.Entity<BillDetail>()
                .HasOne(b => b.Product)
                .WithMany(p => p.BillDetails)
                .HasForeignKey(b => b.ProductId);
            //------------------------------------------------------

            builder.Entity<Bill>()
                .HasKey(b => b.BillId);

            //builder.Entity<Bill>()
            //    .HasOne(b => b.ApplicationUser)
            //    .WithMany(a => a.Bills)
            //    .HasForeignKey(fk => fk.Id);

            builder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.Bills)
                .WithOne(p=>p.User)
                .HasForeignKey(ac => ac.UserId)
                .IsRequired();
            });
            //----------------------------------------------------------

        }




        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CategoryBrand> CategoryBrands { get; set; }



        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }



    }
}
