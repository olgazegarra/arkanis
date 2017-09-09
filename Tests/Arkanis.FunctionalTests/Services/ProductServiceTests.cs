using System;
using System.Configuration;
using Arkanis.Core.Entities;
using Arkanis.Repositories;
using Arkanis.Services;
using NUnit.Framework;

namespace Arkanis.FunctionalTests.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]
        public void CreateProduct_DefaultApp()
        {
            var code = "P002";
            var nameTitle = "PMI Kids World";
            var price = 3.99m;
            var description = "Silly description";
            var unitsInStock = 30;
            var unitsOrdered = 0;
            var user = "Momotaro test";
            var discount = .25m;

            IProductService service = new ProductService(new DataStoreFactory(string.Empty));
            	
			service.Create(code, nameTitle, description, price, unitsInStock, discount, unitsOrdered, user);
			var prod = service.Get<ProductEntity>(code, nameTitle, p => p);
			Assert.AreEqual(prod.title, nameTitle);

        }

        [Test]
        public void CreateProduct_Memory()
        {
            var code = "P0022";
            var nameTitle = "MEMORY - PMI Kids World";
            var price = 3.99m;
            var description = "Silly description";
            var unitsInStock = 30;
            var unitsOrdered = 0;
            var user = "Momotaro test";
            var discount = .25m;

            IProductService service = new ProductService(new DataStoreFactory("memory"));

            service.Create(code, nameTitle, description, price, unitsInStock, discount, unitsOrdered, user);
            var prod = service.Get<ProductEntity>(code, nameTitle, p => p);
            Assert.AreEqual(prod.title, nameTitle);

        }

        [Test]
        public void CreateProduct_DataBase()
        {
            var code = "P4587";
            var nameTitle = "DataBase - PMI Kids World";
            var price = 2.99m;
            var description = "Silly description";
            var unitsInStock = 30;
            var unitsOrdered = 0;
            var user = "Momotaro test";
            var discount = .25m;

            IProductService service = new ProductService(new DataStoreFactory("database"));

            service.Create(code, nameTitle, description, price, unitsInStock, discount, unitsOrdered, user);
            var prod = service.Get<ProductEntity>(code, nameTitle, p => p);
            Assert.AreEqual(prod.title, nameTitle);

        }

    }
}
