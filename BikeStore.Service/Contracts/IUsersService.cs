using BikeStore.Data.Model;
using BikeStore.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Service.Contracts
{
    public interface IUsersService: IBaseRepository<IEnumerable<UserModel>>
    {
        ProcessResult<IEnumerable<UserModel>> Update(UserModel user);
    }
}
