using Arkanis.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arkanis.Core.Entities;
using System.Web;

namespace Arkanis.Repositories
{
    public class ProductApplicationRepository : IProductRepository
    {
        protected ICollection<ProductEntity> _products
        {
            get
            {
                var appProds = HttpContext.Current.Application["Message"];
                if (appProds == null)
                {
                    HttpContext.Current.Application["Message"] = new List<ProductEntity>();
                }
                return (ICollection<ProductEntity>)HttpContext.Current.Application["Message"];                
            }
            set
            {
                HttpContext.Current.Application["Message"] = value;
            }
        } 

        public int Create(ProductEntity model)
        {
            int count = _products.Count;
            model.id = count++;
            _products.Add(model);
            return model.id;
        }

        public void Delete(int id)
        {
            var item = _products.Where(p => p.id == id).FirstOrDefault();
            if (item != null)
                _products.Remove(item);
        }

        public ProductEntity Get(string code, string name)
        {
            return _products.Where(p => p.code.Equals(code) && p.title.Equals(name)).FirstOrDefault();
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _products;
        }

        public IEnumerable<ProductEntity> Search(string name)
        {
            return _products.Where(p => p.title.Equals(name));
        }
    }
}
