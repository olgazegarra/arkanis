using System;
using System.Collections.Generic;
using Arkanis.Core.Entities;
using Arkanis.Services.Repositories;
using Arkanis.Services.Factories;

namespace Arkanis.Services
{
	public class ProductService : IProductService
	{
		readonly IProductRepository _productRepository;

		public ProductService(IDataStoreFactory factory)
		{
			this._productRepository = factory.CreateProductStore();
		}

		public int Create(string code, string name, string description,
						  decimal unitPrice, int unitsInStock, decimal discount,
						  int unitsOrdered, string user)
		{
			var model = new ProductEntity(code, name)
			{
				description = description,
				unitPrice = unitPrice,
				unitsInStock = unitsInStock,
				unitsOrdered = unitsOrdered,
                discount = discount,
                createdBy = user
			};
            model.Create();
			return this._productRepository.Create(model);
		}

		public void Delete(int id)
		{
			this._productRepository.Delete(id);
		}

		public T Get<T>(string code, string name, Func<ProductEntity, T> mapper)
		{
			T result = default(T);
			var product = this._productRepository.Get(code, name);
			if (product != null)
				result = mapper(product);
			return result;
		}

		public IEnumerable<T> GetAll<T>(Func<IEnumerable<ProductEntity>, IEnumerable<T>> mapper)
		{
			var products = this._productRepository.GetAll();
			return mapper(products);
		}

		public IEnumerable<T> Search<T>(string name, Func<IEnumerable<ProductEntity>, IEnumerable<T>> mapper)
		{
			var products = this._productRepository.Search(name);
			return mapper(products);
		}


	}
}
