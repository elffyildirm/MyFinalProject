using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


//core evrensel katmanımızdır tüm dotnet projelerinde kullanabiliriz 
//Core katmanı diğer katmanları referans almaz

namespace Core.DataAccess

{    
    //generic constraint jenerik kısıtlama (T yazınca int bile yazsak sorun görmüyorbuna kısıtlama getireceğiz)
    //class : referans tip
    //IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new lenebilir olmalı IEntity newlenemez
    //şuan sistem sadece veri tabanı listeleriyle çalışabilir
    public interface IEntityRepository<T> where T:class,IEntity,new() // T class olabilir ve IEntity içindeki bir class olmalı orada olmayan class olmamalı  
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);        //filter=null filtre vermeyebilirsin de demek filtre vermemişse tüm datayı istiyor demektir  
                                                                     //Product la ilgili veritabanında yapılacak operasyonları içeren interface
        T Get(Expression<Func<T, bool>> filter);   // bu filter zorunludur  //bu hareketi yazılımda bir kez yaparsın daha da yapmazsın
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
        // bir classa IEntitty dersek veritabanı görevi görür
    }
}

namespace Core
{
    public interface IDto
    {
    }
}