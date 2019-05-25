using BikeStore.Data.Model;
using BikeStore.Data.Repository;
using BikeStore.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Service.Services
{
    public class SecurityService : BaseRepository<UserModel>, ISecurityService
    {

        public SecurityService(Uri uri): base(uri) { }


        public ProcessResult<IEnumerable<UserModel>> ValidateUser(UserModel user)
        {

            ProcessResult<IEnumerable<UserModel>> result = new ProcessResult<IEnumerable<UserModel>>();

            result.Content = client.Search<UserModel>(s => s.Index("users")
                   .Query(q => q
                          .Term(t1 => t1.Name, user.Name)
                          && q.Term(t2 => t2.Password, user.Password)
                           )
                  ).Documents.ToList();

            if(result.Content.Count() !=1 )
            {
                result.HasError = true;
                result.Description = "User not found";
            }
            else
            {
                result.Description = "User found";
            }

            return result;
        }
    }
}