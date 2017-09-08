using Arkanis.Core.Infrastructure;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arkanis.Core.Entities
{
    public class ProductEntity : AuditingBaseEntity
    {
        public ProductEntity() : base() { }
		public ProductEntity(string code, string title) : base()
		{
			this.code = code;
			this.title = title;
		}

		public int id { get; set; }
        [Required]
		public string code { get; protected set; }
		[Required]
        public string title { get; protected set; }
        [StringLength(250)]
		public string description { get; set; }
		[Required] 
        public decimal unitPrice { get; set; }
		public int unitsInStock { get; set; }
		public int unitsOrdered { get; set; }
        public decimal discount { get; set; }
        public int status { get; set; }

        public ICollection<CategoryEntity> categories { get; set; }

        public void Create() {
            Validate();
            if (categories == null){
                var defaultCategory = new CategoryEntity();
                categories = new List<CategoryEntity>() { defaultCategory };
            }
            if (status == default(int)) {
                status = 1;
            }
        }

		public void Validate()
		{
            if (string.IsNullOrWhiteSpace(this.code))
				throw new ApplicationException("Product code is necessary");
            
            if (string.IsNullOrWhiteSpace(this.title))
                throw new ApplicationException("Product title is required");
	
            if (unitPrice <= 0)
                throw new ApplicationException("Price should greater than zero");

            var validator = ValidationFactory.CreateValidator<ProductEntity>();
			var results = validator.Validate(this);
			if (!results.IsValid)
			{
				throw results.ToException();
			}

		}
    }
}
