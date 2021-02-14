using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());  // beni new leyebilmen için hangi veriyöntemiyle çalıştıgımı söylermen lazım diyor. Interface inmemory referansı tutabildiği için 

            //in memory ile çözümledik şimdi inmemory ile calısacagız

            foreach (var product in productManager.GetAll()) 
            {
                Console.WriteLine(product.ProductName);
            }
        }

    }
}
