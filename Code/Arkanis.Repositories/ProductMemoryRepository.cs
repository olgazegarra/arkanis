using Arkanis.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkanis.Core.Entities;

namespace Arkanis.Repositories
{
    public class ProductMemoryRepository : IProductRepository
    {
        public static readonly List<ProductEntity> _memoryProducts = new List<ProductEntity>();
        public int Create(ProductEntity model)
        {
            int count = _memoryProducts.Count;
            model.id = count++;
            _memoryProducts.Add(model);
            return model.id;
        }

        public void Delete(int id)
        {
            var item = _memoryProducts.Where(p => p.id == id).FirstOrDefault();
            if (item != null)
                _memoryProducts.Remove(item);
        }

        public ProductEntity Get(string code, string name)
        {
            return _memoryProducts.Where(p => p.code.Equals(code) && p.title.Equals(name)).FirstOrDefault();
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _memoryProducts;
        }

        public IEnumerable<ProductEntity> Search(string name)
        {
            return _memoryProducts.Where(p => p.title.Equals(name));
        }
    }
}
