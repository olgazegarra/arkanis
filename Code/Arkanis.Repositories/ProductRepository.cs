using System;
using System.Collections.Generic;
using Arkanis.Core.Entities;
using Arkanis.Services.Repositories;

namespace Arkanis.Repositories
{
    public class ProductRepository : IProductRepository
    {
		public int Create(ProductEntity model)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public ProductEntity Get(string code, string name)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ProductEntity> GetAll()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<ProductEntity> Search(string name)
		{
			throw new NotImplementedException();
		}
    }
}
