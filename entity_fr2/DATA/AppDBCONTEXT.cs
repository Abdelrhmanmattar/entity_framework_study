using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using entity_fr2.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_fr2.DATA
{
    public class AppDBCONTEXT: DbContext
    {

        public DbSet<Product> products { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }

        public DbSet<OrderWithDetailsView> orderWithDetailsViews { get; set; }

        public DbSet<OrderBill> orderBills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var constr = configuration.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable("Products", "Inventory")
                .HasKey(p => p.Id);

            modelBuilder.Entity<Orders>()
                .ToTable("Orders", "Sales")
                .HasKey(o => o.Id);
            modelBuilder.Entity<OrderDetails>()
                .ToTable("OrderDetails", "Sales")
                .HasKey(od => od.Id);

            modelBuilder.Entity<OrderWithDetailsView>()
                .ToView("OrderWithDetailsView")
                .HasNoKey();
            modelBuilder.Entity<OrderBill>()
                .HasNoKey()
                .ToFunction("GetOrderBill");

            //modelBuilder.HasDefaultSchema("Sales");

            /*
             * here we will ignore snapshoot from mapped to the database
             */
            //modelBuilder.Ignore<SnapShot>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
