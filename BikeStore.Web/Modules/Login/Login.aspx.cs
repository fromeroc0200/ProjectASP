using BikeStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;
using Nest;
using Elasticsearch.Net;
using BikeStore.Service;
using Microsoft.Practices.ServiceLocation;

namespace BikeStore.Web.Modules.Login
{
    public partial class Login : System.Web.UI.Page
    {
    
        IUnitOfWork _unitOfWork { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // UnitOfWork unitOfWork = new UnitOfWork();
            //UserModel usr = new UserModel()
            // {
            //     Name = "fer",
            //     Password = "admin"};
            // //var result =  unitOfWork.Users.Get();
            //Response.Write(@"<script language='javascript'>alert('Message: \n" + "OK Process!" + " .');</script>");

        }

        public static Uri node;

        //Nest Functions
        public static ConnectionSettings settings;
        public static ElasticClient client;
        
        [WebMethod]
        public static ProcessResult<IEnumerable<UserModel>> LoginUser(string user, string password)
        {
            ProcessResult<IEnumerable<UserModel>> result = new ProcessResult<IEnumerable<UserModel>>();
            UnitOfWork unitOfWork = new UnitOfWork();

            UserModel usr = new UserModel() { Name = user, Password = password };
            result = unitOfWork.Security.ValidateUser(usr);
            

            return result;
        }
    }
}