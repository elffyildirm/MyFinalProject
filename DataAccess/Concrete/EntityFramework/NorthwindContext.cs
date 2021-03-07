using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak  
  public class NorthwindContext:DbContext    //yukarıda yazan entity framework ile alakalı bir şeydir db context 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");  // @koyma sebebimiz \ işaretini yazı olarak algılaması içindir.    
        }
        public DbSet<Product> Products { get; set; }   // benim products nesnemi veri tabanındaki products ile bağla
        public DbSet <Category> Categories { get; set; }
        public DbSet <Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}

