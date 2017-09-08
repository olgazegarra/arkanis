using System;
using System.Collections.Generic;
using Arkanis.Core.Entities;

namespace Arkanis.Services.Repositories
{
    public interface ICategoryRepository
    {
		int Create(CategoryEntity model);
		void Delete(int id);
		CategoryEntity Get(string name);
    }
}
