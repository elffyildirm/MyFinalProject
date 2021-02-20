using Core.Entities;
using Microsoft.EntityFrameworkCore;   //DbContext EntityFrameworkCore dan gelir
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDısposable pattern implementation of c#  
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);// veri kaynagı ile ilişkilendir
                addedEntity.State = EntityState.Added;  // bu eklenecek nesne
                context.SaveChanges();                  //bu ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);// veri kaynagı ile ilişkilendir
                deletedEntity.State = EntityState.Deleted;  // bu silinecek nesne
                context.SaveChanges();                  //bu sil
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);  // bu ürünler tablosudur context.Set<Product>() product ta product custo
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                // product tablosuna yerleş veritabanındaki tüm tabloyu listeye çevir ve bana ver filtre null sa tümünü getir 
                // null değilse isteneni getir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);// veri kaynagı ile ilişkilendir
                updatedEntity.State = EntityState.Modified;  // bu güncellenecek nesne
                context.SaveChanges();                  //bunu güncelle
            }
        }
    }
}
