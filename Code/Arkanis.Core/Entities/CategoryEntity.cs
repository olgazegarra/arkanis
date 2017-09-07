using Arkanis.Core.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Practices.EnterpriseLibrary.Validation;

namespace Arkanis.Core.Entities
{
    public class CategoryEntity : AuditingBaseEntity
    {
		public int id { get; set; }
        [Required]
		public string name { get; set; }
		public string description { get; set; }
		public int status { get; set; }
		
        public CategoryEntity() : base() {
            this.name = "Others";
        }
        public CategoryEntity(string name) {
            this.name = name;
        }

        public void Create(){
            this.Validate();
        }

        public void Validate() {
			if (string.IsNullOrWhiteSpace(this.name))
				throw new ApplicationException("Category name is required");

			var validator = ValidationFactory.CreateValidator<CategoryEntity>();
			var results = validator.Validate(this);
			if (!results.IsValid)
			{
				throw results.ToException();
			}
        }
    }
}
