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
        public void CreateProduct_DataBase()
        {
            var code = "P002";
            var nameTitle = "PMI Kids World";
            var price = 3.99m;
            var description = "Silly description";
            var unitsInStock = 30;
            var unitsOrdered = 0;
            var user = "Momotaro test";

            IProductService service = new ProductService(new ProductRepository());
            	
			service.Create(code, nameTitle, description, price, unitsInStock, unitsOrdered, user);
			var prod = service.Get<ProductEntity>(code, nameTitle, p => p);
			Assert.AreEqual(prod.title, nameTitle);

        }

    }
}
