using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arkanis.WebSite.Models
{
    public class ProductModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Code field is required")]
        public string code { get; set; }
        [Required(ErrorMessage = "Title field is required")]
        public string title { get; set; }
        public string description { get; set; }
        public decimal unitPrice { get; set; }
        public int unitsInStock { get; set; }
        public int unitsOrdered { get; set; }
        public int status { get; set; }
        public decimal discount { get; set; }
        public DateTime createdOn { get; set; }
        [Required(ErrorMessage = "Created By field is required")]
        public string createdBy { get; set; }
        public IEnumerable<CategoryModel> categories { get; set; }
    }
}
