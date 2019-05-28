using BikeStore.Data.Model;
using BikeStore.Data.Repository;
using BikeStore.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Service.Services
{
    public class ProductsService : IProductsService
    {
        public ProcessResult<List<ProductModel>> Get()
        {
            ProcessResult<List<ProductModel>> result = new ProcessResult<List<ProductModel>>();

            result.Content = BuildProductsObj();

            return result;
        }

        private List<ProductModel> BuildProductsObj()
        {
            List<ProductModel> products = new List<ProductModel>();

            products.Add(new ProductModel() { product_id = 1, product_name = "bike 2000", list_price = 10, model_year = 1990, brand_id = 1, category_id = 1 });
            products.Add(new ProductModel() { product_id = 2, product_name = "bike 20", list_price = 100, model_year = 1991, brand_id = 1, category_id = 1 });
            products.Add(new ProductModel() { product_id = 3, product_name = "bike 1800", list_price = 50, model_year = 1998, brand_id = 1, category_id = 1 });
            products.Add(new ProductModel() { product_id = 4, product_name = "bike V2", list_price = 80, model_year = 2000, brand_id = 1, category_id = 1 });
            products.Add(new ProductModel() { product_id = 5, product_name = "bike M400", list_price = 120, model_year = 1990, brand_id = 1, category_id = 1 });
            products.Add(new ProductModel() { product_id = 6, product_name = "bike F100", list_price = 8, model_year = 2019, brand_id = 1, category_id = 1 });


            return products;
        }

    }
}