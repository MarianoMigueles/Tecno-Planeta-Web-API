using Entities.Elements;
using Entities.Elements.Invoice;
using Entities.Elements.InvoiceFolder;
using Entities.Elements.ProductFolder;
using Entities.Extra;
using Entities.Services;
using Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Repair>()
            //    .HasOne(r => r.Customer)
            //    .WithMany(c => c.Repairs)
            //    .HasForeignKey(r => r.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        //--------------------------------- USERS 
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<User> User { get; set; }

        //--------------------------------- SERVICES 
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        //--------------------------------- INVOICE 
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItem { get; set; }
        public virtual DbSet<InvoiceType> InvoiceType { get; set; }

        //--------------------------------- PRODUCT 
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }

        //--------------------------------- DEVICE 
        public virtual DbSet<Device> Device { get; set; }

        //--------------------------------- EXTRA 
        public virtual DbSet<StockMovement> StockMovement { get; set; }
        public virtual DbSet<StockMovementItem> StockMovementItem { get; set; }
    }
}
