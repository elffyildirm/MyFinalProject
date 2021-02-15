using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    //entity microsoftun bir ürünüdür linq destekli çalışır. Amaç şu veritabanındaki tabloyu sanki classmış gibi onunla ilişkilendirip sql leri linq ile yaptıgımız bir ortam. yani kodları veritabanı ile ilişkilendirme
    // NuGet kodların ortak koyulduğu yer 
    // entity framework paket adıdır
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {    
            //IDısposable pattern implementation of c#  
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);// veri kaynagı ile ilişkilendir
                addedEntity.State = EntityState.Added;  // bu eklenecek nesne
                context.SaveChanges();                  //bu ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);// veri kaynagı ile ilişkilendir
                deletedEntity.State = EntityState.Deleted;  // bu silinecek nesne
                context.SaveChanges();                  //bu sil
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);  // bu ürünler tablosudur context.Set<Product>() product ta product custo
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter==null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();  
                // product tablosuna yerleş veritabanındaki tüm tabloyu listeye çevir ve bana ver filtre null sa tümünü getir 
                  // null değilse isteneni getir
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);// veri kaynagı ile ilişkilendir
                updatedEntity.State = EntityState.Modified;  // bu güncellenecek nesne
                context.SaveChanges();                  //bunu güncelle
            }
        }
    }
}
