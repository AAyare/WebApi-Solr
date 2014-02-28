using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Evoke.Rnd.Solr.Api.Models
{
    public class SalesContext : DbContext
    {
        public DbSet<ModelRepository.Customer> Customers { get; set; }
        public DbSet<ModelRepository.Order> Orders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //primary key for customerid
            modelBuilder.Entity<ModelRepository.Customer>().HasKey(c => c.CustomerId);

            //identity key for customerid
            modelBuilder.Entity<ModelRepository.Customer>()
                        .Property(c => c.CustomerId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            //maxlenght(similar to varchar )
            modelBuilder.Entity<ModelRepository.Customer>().Property(c =>
                                                                     c.CustomerName).HasMaxLength(80);
            modelBuilder.Entity<ModelRepository.Customer>().Property(c =>
                                                                     c.Address).HasMaxLength(100);
            modelBuilder.Entity<ModelRepository.Customer>().Property(c =>
                                                                     c.MobileNo).HasMaxLength(14);
            modelBuilder.Entity<ModelRepository.Customer>().Property(c =>
                                                                     c.PhoneNo).HasMaxLength(20);
            modelBuilder.Entity<ModelRepository.Customer>().Property(c => c.City).HasMaxLength(40);
            modelBuilder.Entity<ModelRepository.Customer>().Property(c =>
                                                                     c.District).HasMaxLength(40);
            modelBuilder.Entity<ModelRepository.Customer>().Property(c => c.State).HasMaxLength(20);

            //primary key for order table
            modelBuilder.Entity<ModelRepository.Order>().HasKey(o => o.OrderId);
          
            //identity key for order id 
            modelBuilder.Entity<ModelRepository.Order>().Property(o =>
                                                                  o.OrderId)
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<ModelRepository.Order>().Property(o =>
                                                                  o.OrderedItem).HasMaxLength(50);
           
            modelBuilder.Entity<ModelRepository.Order>().HasRequired(c => c.Customer)
                        .WithMany(o => o.Orders).HasForeignKey(o => o.CustomerId);
           
            modelBuilder.Entity<ModelRepository.Order>()
                        .HasRequired(c => c.Customer)
                        .WithMany(o => o.Orders)
                        .HasForeignKey(o => o.CustomerId)
                        .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}


