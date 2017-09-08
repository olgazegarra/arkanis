using System;
using Arkanis.Core.Entities;
using Arkanis.WebSite.Models;

namespace Arkanis.WebSite.Translators
{
    public class CategoryTranslator
    {
        public static CategoryModel Translate(CategoryEntity entity)
        {
            return new CategoryModel()
            {
                id = entity.id,
                name = entity.name,
                description = entity.description,
                status = entity.status
            };

        }
    }
}
