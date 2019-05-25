using System.Collections.Generic;
using BikeStore.Data.Model;

namespace BikeStore.Service.Contracts
{
    public interface ISecurityService
    {
        ProcessResult<IEnumerable<UserModel>> ValidateUser(UserModel user);
    }
}