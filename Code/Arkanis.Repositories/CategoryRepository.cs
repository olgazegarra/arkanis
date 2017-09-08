using System;
using System.Collections.Generic;
using System.Linq;
using Arkanis.Core.Entities;
using Arkanis.Services.Repositories;
using Arkanis.Repositories.DataModel;

namespace Arkanis.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
		public int Create(CategoryEntity model)
		{
			using (var context = new ArkanisDBContext())
			{
                var catg = new Category()
                {
                    name = model.name,
                    description = model.description,
                    createdBy = model.createdBy,
                    createdOn = model.createdOn,
                    status = model.status
                };
				
				context.Category.Add(catg);
				context.SaveChanges();
				return catg.id;
			}
		}

		public void Delete(int id)
		{
			using (var context = new ArkanisDBContext())
			{
				var catgFound = context.Category.Find(id);
				context.Category.Remove(catgFound);
				context.SaveChanges();
			}
		}

		public CategoryEntity Get(string name)
		{
            CategoryEntity response = null;
			using (var context = new ArkanisDBContext())
			{
                var catgFound = context.Category
                                       .Where(p => p.name.Equals(name))
                                       .FirstOrDefault();
				if (catgFound != null)
				{
					response = catgFound.ConvertToEntity();
				}
			}
            return response;
		}

    }
}
