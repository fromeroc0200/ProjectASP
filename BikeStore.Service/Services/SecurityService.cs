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


        public ProcessResult<UserModel> ValidateUser(UserModel user)
        {
            ModelFactory modelFactory = new ModelFactory();
            ProcessResult<UserModel> result = new ProcessResult<UserModel>();

            result.Content = client.Search<UserModel>(s => s.Index("users")
                   .Query(q => q
                          .Term(t1 => t1.Name, user.Name)
                          && q.Term(t2 => t2.Password, user.Password)
                           )
                  ).Documents.SingleOrDefault();


            if (result.Content == null )
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