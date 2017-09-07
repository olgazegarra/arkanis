using System;
using System.Collections.Generic;
using Arkanis.Core.Entities;

namespace Arkanis.Services.Repositories
{
    public interface IProductRepository
    {
		int Create(ProductEntity model);
		void Delete(int id);
		ProductEntity Get(string code, string name);
		IEnumerable<ProductEntity> GetAll();
		IEnumerable<ProductEntity> Search(string name);
    }
}
