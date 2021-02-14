using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal  //memory bellek demek ürünle ilgili veri erişim kodlarının yazılacağı yer
    {
        List<Product> _products;  // class içinde ama methodların içinde değil global değişken böyle ismini alt tire baslatarak veririz

        public InMemoryProductDal()
        {
            _products = new List<Product> {
            
                // ürünleri burada olustururuz hayali bir ürün olusturalım
                // Oracle, Sql Server, Postges, MongoDb den geliyormuş gibi simüle ediyoruz
     
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15,UnitInStock = 15 },
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500,UnitInStock = 3 },
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500,UnitInStock = 2 },                
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150,UnitInStock = 65 },
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85,UnitInStock = 1 },

            };
        }
        public void Add(Product product)   // burada ürünü veri kaynagına ekleyeceğiz yukarıdaki listeye ekleme yapacagız
        {
            _products.Add(product);
        }

        public void delete(Product product)
        {
            // _ products.Remove(product); , ile normalde silme yapılır ancak burası referans tiptir ve böyle silinmez 
            // yapmamız gereken Id kullanıp eşleştirmek
            //LINQ - Language Integrated Query
            // p=> isaretine Lambda deniyor
            Product productToDelete= _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //foreach (var p in _products)
            //{
            //    if(product.ProductId == p.ProductId)  //benim gönderdiğim product ın product ıd si esitse o anki product Id ye
            //    {                                     // tek tek dolasıyosun her dolastıgındaki p o elemana karsılık geliyor

            //        productToDelete = p;              // foreach kısmına gerek yok tek satır kod isi yapabiliyor

            //    }

            //}
            //singleOrDefault bir methodtur
            // yukarıdaki döngü yerine linq ile yazalım
            //productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);   //parantez için kuraldır her p parametre ile gönderilen ürün id sine esitse onun referansını buna esitle
            // singleordefault products ı tek tek dolasmaya yarar p tek tek dolasırken verilen takma isimdir. foreach li kodun hepsini bu satır karsılar
            // p tek tek dolasırken verdiğimiz takma isimdir
            // single or yerine firstor ya da first de yazılabilirdi
            //yukarıda usingsystem.linq olmazsa bu gelmez 
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()  //veri tabanındaki datayı businessa vermemiz lazım isterssen yukarıda da void değil return kullanabilirdin ama burada 
        {                              // business listesini istiyorum diyor return vermek zorundasın
            return _products;          //veritabanını oldugu gibi döndürür
        }

        public void Update(Product product)
        {    
            //Gönderdiğim ürün id sine sahip olan listedeki ürünü bul demek
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
        public List <Product> GetAllByCategory (int categoryId)
        {
            // where kosulu içindeki şarta uyan tüm elemanları yeni bir liste haline getirir ve onu döndürür
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
