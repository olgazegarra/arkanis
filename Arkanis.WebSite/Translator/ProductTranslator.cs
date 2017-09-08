using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arkanis.Core.Entities;
using Arkanis.WebSite.Models;

namespace Arkanis.WebSite.Translators
{
    public class ProductTranslator
    {
        public ProductModel Translate(ProductEntity entity)
        {
            return new ProductModel()
            {
                id = entity.id,
                code = entity.code,
                title = entity.title,
                description = entity.description,
                unitPrice = entity.unitPrice,
                unitsInStock = entity.unitsInStock,
                unitsOrdered = entity.unitsOrdered,
                status = entity.status,
                discount = entity.discount,
                createdOn = entity.createdOn,
                createdBy = entity.createdBy,
                categories = entity.categories.Select(c => CategoryTranslator.Translate(c))
            };

        }



        public IEnumerable<ProductModel> Translate(IEnumerable<ProductEntity> entityList)
        {
            return entityList.Select(e => Translate(e));
        }
    }
}
