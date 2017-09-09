using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arkanis.WebSite.Models
{
    public class ProductModel
    {
        [Display(Name = "Product ID")]
        public int id { get; set; }
        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "Code field is required")]
        public string code { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title field is required")]
        public string title { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        [Display(Name = "Unit Price")]
        public decimal unitPrice { get; set; }
        [Display(Name = "Units In Stock")]
        public int unitsInStock { get; set; }
        [Display(Name = "Units Ordered")]
        public int unitsOrdered { get; set; }
        [Display(Name = "Status")]
        public int status { get; set; }
        [Display(Name = "Discount")]
        public decimal discount { get; set; }
        [Display(Name = "Created On")]
        public DateTime createdOn { get; set; }
        [Display(Name = "Created By")]
        [Required(ErrorMessage = "Created By field is required")]
        public string createdBy { get; set; }
        public IEnumerable<CategoryModel> categories { get; set; }
    }
}
