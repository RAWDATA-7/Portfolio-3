using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataServiceLib.Domain;

namespace DataServiceLib
{
    class IMDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<KnownForTitles> KnownForTitles { get; set; }
        public DbSet<Principals> Principals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string path = System.IO.File.ReadAllText(@"Portfoilo2/path");
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql(path);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>().ToTable("names");
            modelBuilder.Entity<Actor>().Property(x => x.Id).HasColumnName("nameID");
            modelBuilder.Entity<Actor>().Property(x => x.Name).HasColumnName("primaryname");
            modelBuilder.Entity<Actor>().Property(x => x.BirthYear).HasColumnName("birthYear");
            modelBuilder.Entity<Actor>().Property(x => x.DeathYear).HasColumnName("deathYear");
            modelBuilder.Entity<Actor>().Property(x => x.Rating).HasColumnName("actorrating");
   
            modelBuilder.Entity<Profession>().ToTable("professions");
            modelBuilder.Entity<Profession>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Profession>().Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Profession>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Profession>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Profession>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");

/*
                                    modelBuilder.Entity<OrderDetails>().ToTable("orderdetails").HasKey(pk => new {pk.ProductId, pk.OrderId});
                                    modelBuilder.Entity<OrderDetails>().Property(x => x.ProductId).HasColumnName("productid");
                                    modelBuilder.Entity<OrderDetails>().Property(x => x.OrderId).HasColumnName("orderid");
                                    modelBuilder.Entity<OrderDetails>().Property(x => x.UnitPrice).HasColumnName("unitprice");
                                    modelBuilder.Entity<OrderDetails>().Property(x => x.Quantity).HasColumnName("quantity");
                                    modelBuilder.Entity<OrderDetails>().Property(x => x.Discount).HasColumnName("discount");
                                    
            modelBuilder.Entity<Order>().ToTable("orders");
                                    modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
                                    modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("orderdate");
                                    modelBuilder.Entity<Order>().Property(x => x.Required).HasColumnName("requireddate");
                                    modelBuilder.Entity<Order>().Property(x => x.Shipped).HasColumnName("shippeddate");
                                    modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
                                    modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname"); 
                                    modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");
                        */
        }
    }
}



    }
}
