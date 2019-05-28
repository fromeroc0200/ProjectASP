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
            for (int i = 1; i <= 1000; i++)
            {
                products.Add(new ProductModel() { product_id = i, product_name = $"bike {i}", list_price = i, model_year = i, brand_id = i, category_id = 1 });
            }



            return products;
        }

    }
}