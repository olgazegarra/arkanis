using System;
using System.Collections.Generic;
using System.Linq;
using Arkanis.Core.Entities;
using Arkanis.Services.Repositories;
using Arkanis.Repositories.DataModel;

namespace Arkanis.Repositories
{
    public class ProductRepository : IProductRepository
    {
		public int Create(ProductEntity model)
		{
			using (var context = new ArkanisDBContext())
			{
				var prod = new Product();
				prod.code = model.code;
                prod.name = model.title;
				prod.description = model.description;

                prod.unitPrice = model.unitPrice;
                prod.unitsInStock = model.unitsInStock;
                prod.unitsOrdered = model.unitsOrdered;

                prod.status = model.status;
                prod.discount = model.discount;

                prod.createdBy = prod.createdBy;
                prod.createdOn = prod.createdOn;
				
				context.Product.Add(prod);
				context.SaveChanges();
				return prod.id;
			}
		}

		public void Delete(int id)
		{
			using (var context = new ArkanisDBContext())
			{
				var prodFound = context.Product.Find(id);
				context.Product.Remove(prodFound);
				context.SaveChanges();
			}
		}

		public ProductEntity Get(string code, string name)
		{
            ProductEntity response = null;
			using (var context = new ArkanisDBContext())
			{
                var prodFound = context.Product
                                       .Where(p => p.code == code && p.name == name)
                                       .FirstOrDefault();
				if (prodFound != null)
				{
					response = prodFound.ConvertToEntity();
				}
			}
            return response;
		}

		public IEnumerable<ProductEntity> GetAll()
		{
            var result = new List<ProductEntity>();
			using (var context = new ArkanisDBContext())
			{
				var products = context.Product.Include("categories").ToList();
				foreach (var item in products)
				{
					var prod = item.ConvertToEntity();

					if (item.categories!= null && item.categories.Count()> 0)
					{
                        prod.categories = item.categories.Select(c => c.ConvertToEntity()).ToList();
					}

					result.Add(prod);
				}
				return result;
			}
		}

		public IEnumerable<ProductEntity> Search(string name)
		{
			var result = new List<ProductEntity>();
			using (var context = new ArkanisDBContext())
			{
				var products = context.Product.Include("categories")
                                      .Where(p => p.name.Equals(name)).ToList();
				foreach (var item in products)
				{
					var prod = item.ConvertToEntity();
					if (item.categories != null && item.categories.Count() > 0)
					{
						prod.categories = item.categories.Select(c => c.ConvertToEntity()).ToList();
					}
					result.Add(prod);
				}
            }
			return result;
		}
    }
}
