using Arkanis.Services.Factories;
using Arkanis.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanis.Repositories
{
    public class DataStoreFactory : IDataStoreFactory
    {
        private string _Key;
        public DataStoreFactory(string Key = "app")
        {
            this._Key = Key;
        }
        public IProductRepository CreateProductStore()
        {
            switch (this._Key)
            {
                case "memory":                    
                    return new ProductMemoryRepository();
                case "database":
                    return new ProductRepository();
                case "app":
                default:
                    return new ProductApplicationRepository();                    
            }
        }
    }
}
