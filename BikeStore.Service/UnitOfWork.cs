using BikeStore.Data.Repository;
using BikeStore.Service.Contracts;
using BikeStore.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        Uri uri = new Uri("http://localhost:9200");
       public UnitOfWork()
        {
            Users = new UsersService(uri);
            Security = new SecurityService(uri);
        }

        public IUsersService Users { get; set; }
        public ISecurityService Security { get; set; }
    }
}