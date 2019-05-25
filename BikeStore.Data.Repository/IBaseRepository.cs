using BikeStore.Data.Model;
using Nest;

namespace BikeStore.Data.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        ProcessResult<TEntity> Get();
       
    }
}