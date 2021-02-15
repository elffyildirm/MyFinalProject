using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {    //SOLID
         //Open Closed Principle 
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());  // beni new leyebilmen için hangi veriyöntemiyle çalıştıgımı söylermen lazım diyor. Interface inmemory referansı tutabildiği için 

            //in memory ile çözümledik şimdi inmemory ile calısacagız

            foreach (var product in productManager.GetAll()) 
            {
                Console.WriteLine(product.ProductName);
            }
        }

    }
}
