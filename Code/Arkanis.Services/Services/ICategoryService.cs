using System;
using Arkanis.Core.Entities;

namespace Arkanis.Services
{
    public interface ICategoryService
    {
		int Create(string name, string description, string user);
        
		void Delete(int id);
		
        T Get<T>(string name, Func<CategoryEntity, T> mapper);
    }
}
