using NUnit.Framework;
using System;
using Arkanis.Core.Entities;

namespace Arkanis.UnitTests
{
    [TestFixture]
    public class ProductEntityTests
    {
        [Test]
        public void CreateProd_NoCode()
        {
            var entity = new ProductEntity();

            Assert.Throws(typeof(ApplicationException), ()=> {
                entity.Create();
            }, "Product code is necessary");
        }

		[Test]
		public void CreateProd_NoTitle()
		{
            var code = "P001";
            var title = string.Empty;
			var entity = new ProductEntity(code, title);
			
            Assert.Throws(typeof(ApplicationException), () => {
				entity.Create();
			}, "Product title is required");
		}

		[Test]
		public void CreateProd_NoPrice()
		{
			var code = "P001";
			var title = "Imoji / ToyWorld";
			var entity = new ProductEntity(code, title);
			
            Assert.Throws(typeof(ApplicationException), () => {
				entity.Create();
			}, "Price should greater than zero");
		}

		[Test]
		public void CreateProd_LongDescription()
		{
			var code = "P001";
			var title = "Imoji / ToyWorld";
            decimal price = 2.99m;
			var entity = new ProductEntity(code, title);
            entity.unitPrice = price;
            entity.description = "This a very veeeeery long description, to validate that only 250 characters are allowed on description. And we are going to start writing now: 'Ein gutes Gewissen ist ein sanftes Ruhekissen', 'Einem geschenkten Gaul schaut man nicht ins Maul', 'Auch ein blindes Huhn findet mal ein Korn'";
			
            Assert.Throws(typeof(ApplicationException), () => {
				entity.Create();
			}, "Price should greater than zero");
		}

		[Test]
		public void CreateProd_OK()
		{
			var code = "P001";
			var title = "Imoji / ToyWorld";
            decimal price = 3.25m;
			var entity = new ProductEntity(code, title);
            entity.unitPrice = price;

			Assert.AreEqual(entity.code, code);
			Assert.AreEqual(entity.title, title);
            Assert.AreEqual(entity.unitPrice, price);
		}
    }
}
