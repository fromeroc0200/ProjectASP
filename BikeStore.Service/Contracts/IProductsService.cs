using System.Collections.Generic;
using BikeStore.Data.Model;
using BikeStore.Data.Repository;

namespace BikeStore.Service.Contracts
{
    public interface IProductsService 
    {
        ProcessResult<List<ProductModel>> Get();
    }
}