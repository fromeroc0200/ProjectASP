using System.Collections.Generic;
using BikeStore.Data.Model;

namespace BikeStore.Service.Contracts
{
    public interface ISecurityService
    {
        ProcessResult<UserModel> ValidateUser(UserModel user);
    }
}