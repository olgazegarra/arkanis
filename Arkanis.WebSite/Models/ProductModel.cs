using System;
using System.Collections;
using System.Collections.Generic;

namespace Arkanis.WebSite.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public decimal unitPrice { get; set; }
        public decimal unitsInStock { get; set; }
        public decimal unitsOrdered { get; set; }
        public int status { get; set; }
        public decimal discount { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public IEnumerable<CategoryModel> categories { get; set; }
    }
}
