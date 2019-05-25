using BikeStore.Data.Model;
using BikeStore.Data.Repository;
using BikeStore.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Service.Services
{
    public class UsersService : BaseRepository<UserModel>, IUsersService
    {
        public UsersService(Uri uri) : base (uri)
        {

        }

        public ProcessResult<IEnumerable<UserModel>> Update(UserModel user)
        {

            ProcessResult<IEnumerable<UserModel>> result = new ProcessResult<IEnumerable<UserModel>>();

            return result;
        }
    }
}