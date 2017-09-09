using Arkanis.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanis.Services.Factories
{
    public interface IDataStoreFactory
    {
        IProductRepository CreateProductStore();
    }
}
