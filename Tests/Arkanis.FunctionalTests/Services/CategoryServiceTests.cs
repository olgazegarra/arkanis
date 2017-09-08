using System;
using System.Configuration;
using Arkanis.Core.Entities;
using Arkanis.Repositories;
using Arkanis.Services;
using NUnit.Framework;

namespace Arkanis.FunctionalTests.Services
{
    [TestFixture]
    public class CategoryServiceTests
    {
        [Test]
		public void CreateProduct_DataBase()
		{
			var name = "Toys";
			var description = "Toys to play with";
			var user = "Momotaro Category test";

			ICategoryService service = new CategoryService(new CategoryRepository());

			service.Create(name, description, user);
			var category = service.Get<CategoryEntity>(name, p => p);
			Assert.AreEqual(category.name, name);

		}
    }
}
