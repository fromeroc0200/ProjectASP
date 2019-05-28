using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Data.Model
{
    public class ProductModel
    {
        public int product_id { get; set; }
        
        public string product_name { get; set; }
        
        public int brand_id { get; set; }
        
        public int category_id { get; set; }
        public int model_year { get; set; }
        public decimal list_price { get; set; }
        public BrandModel brands { get; set; }
        public CategoryModel categories { get; set; }
    }
}