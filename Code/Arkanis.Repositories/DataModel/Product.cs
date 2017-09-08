using Arkanis.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arkanis.Repositories.DataModel
{
    public class Product
    {
		[Key]
		public int id { get; set; }
		public string code { get; set; }
		public string name { get; set; }
		public string description { get; set; }
        public decimal unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOrdered { get; set; }
        public decimal discount { get; set; }
		public int status { get; set; }

		public DateTime createdOn { get; set; }
		public string createdBy { get; set; }

		public DateTime updatedOn { get; set; }
		public string updatedBy { get; set; }

        public virtual ICollection<Category> categories { get; set; }

		public ProductEntity ConvertToEntity()
		{
            var entity = new ProductEntity(this.code, this.name)
            {
                id = id,
                description = description,
                unitPrice = unitPrice,
                unitsInStock = unitsInStock,
                unitsOrdered = unitsOrdered,
                discount = discount,
                createdBy = createdBy,
                createdOn = createdOn,
                updatedBy = updatedBy,
                updatedOn = updatedOn
            };

			return entity;
		}

		public Product() { }
    }
}
