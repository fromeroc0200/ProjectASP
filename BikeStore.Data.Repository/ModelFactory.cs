using BikeStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Data.Repository
{
    public class ModelFactory
    {
        public ModelFactory()
        {

        }

        public UserModel Create(UserModel usr)
        {
            UserModel model = null;

            return model;
        }

        public List<UserModel> CreateLst(IEnumerable<UserModel> usr)
        {
            List<UserModel> model = null;

            return model;
        }
    }
}