using Arkanis.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Arkanis.Repositories.DataModel
{
    public class Category
    {
		[Key]
		public int id { get; set; }
		public string name { get; set; }
		public string description { get; set; }
        public int status { get; set; }

        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }

		public DateTime updatedOn { get; set; }
		public string updatedBy { get; set; }

		public CategoryEntity ConvertToEntity()
		{
			var entity = new CategoryEntity(this.name);
            entity.id = this.id;
            entity.description = this.description;
            entity.createdBy = this.createdBy;
            entity.createdOn = this.createdOn;
            entity.updatedBy = this.updatedBy;
            entity.updatedOn = this.updatedOn;

			return entity;
		}

		public Category() { }
    }
}
