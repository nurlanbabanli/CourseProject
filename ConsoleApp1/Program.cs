using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleApp1
{
    class Program
    {

        private static IContainer Container()
        {
            var containerbuilder = new ContainerBuilder();
            containerbuilder.RegisterModule(new AutofacBusinessModule());
            containerbuilder.RegisterType<MyApplication>();
            return containerbuilder.Build();
        }
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //PrductDetails();

            Container().Resolve<MyApplication>().Run();
        }

        private static void PrductDetails()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.ProductName + "/" + item.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (Category item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (Product item in productManager.GetAll().Data)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }

    class MyApplication
    {
        IProductService _productService;

        public MyApplication(IProductService productService)
        {
            _productService = productService;
        }

        public void Run()
        {
            
            Product product = new Product { CategoryId = 1, ProductName = "Bardak20", UnitPrice = 5, UnitsInStock = 15 };
            var result = _productService.Add(product);
        }


    }

}
