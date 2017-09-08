using System;
using Arkanis.Core.Entities;
using Arkanis.Services.Repositories;

namespace Arkanis.Services
{
    public class CategoryService : ICategoryService
    {
		readonly ICategoryRepository _repository;

		public CategoryService(ICategoryRepository repository)
		{
			this._repository = repository;
		}

        public int Create(string name, string description, string user){
			var model = new CategoryEntity(name)
			{
				description = description,
                createdBy = user
			};
			model.Create();
			return this._repository.Create(model);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

		public T Get<T>(string name, Func<CategoryEntity, T> mapper)
        {
			T result = default(T);
			var category = this._repository.Get(name);
			if (category != null)
				result = mapper(category);
			return result;
        }

    }
}
