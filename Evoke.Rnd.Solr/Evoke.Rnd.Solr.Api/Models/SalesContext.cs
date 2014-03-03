using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using Evoke.Rnd.Solr.Api.Models.ModelRepository;

namespace Evoke.Rnd.Solr.Api.Models
{
    public class SalesContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public SalesContext()
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>().ToTable("Order");
;
            modelBuilder.Entity<Customer>().ToTable("Customer");
            
            //primary key for customerid
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);

            //identity key for customerid
            modelBuilder.Entity<Customer>()
                        .Property(c => c.CustomerId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //maxlenght(similar to varchar )
            modelBuilder.Entity<Customer>().Property(c =>
                                                                     c.CustomerName).HasMaxLength(80);
            modelBuilder.Entity<Customer>().Property(c =>
                                                                     c.Address).HasMaxLength(100);
            modelBuilder.Entity<Customer>().Property(c =>
                                                                     c.MobileNo).HasMaxLength(14);
            modelBuilder.Entity<Customer>().Property(c =>
                                                                     c.PhoneNo).HasMaxLength(20);
            modelBuilder.Entity<Customer>().Property(c => c.City).HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(c =>
                                                                     c.District).HasMaxLength(40);
            modelBuilder.Entity<Customer>().Property(c => c.State).HasMaxLength(20);

            //primary key for order table
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
          
            //identity key for order id 
            modelBuilder.Entity<Order>().Property(o =>
                                                                  o.OrderId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Order>().Property(o =>
                                                                  o.OrderedItem).HasMaxLength(50);

            modelBuilder.Entity<Order>().HasRequired(c => c.Customer)
                        .WithMany(o => o.Orders ?? null).HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                        .HasRequired(c => c.Customer)
                        .WithMany(o => o.Orders ?? null)
                        .HasForeignKey(o => o.CustomerId)
                        .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}


