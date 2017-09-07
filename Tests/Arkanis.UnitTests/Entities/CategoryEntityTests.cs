using NUnit.Framework;
using System;
using Arkanis.Core.Entities;

namespace Arkanis.UnitTests.Entities
{
    [TestFixture]
    public class CategoryEntityTests
    {
		[Test]
		public void CreateDefaultCategory()
		{
			var entity = new CategoryEntity();
            entity.Create();

            Assert.AreEqual("Others", entity.name);
		}

		[Test]
        public void CreateCategory_Empty()
		{
            var name = string.Empty;
			var entity = new CategoryEntity(name);
			
            Assert.Throws(typeof(ApplicationException), () => {
                entity.Create();
            }, "Category name is required");
		}

		[Test]
		public void CreateCategory_OK()
		{
			var name = "Toys";
			var entity = new CategoryEntity(name);

			Assert.AreEqual(name, entity.name);
		}
    }
}
