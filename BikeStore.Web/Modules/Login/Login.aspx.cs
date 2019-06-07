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
        IUnitOfWork _unitOfWork;
        public Login(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ProcessResult<UserModel> result = new ProcessResult<UserModel>();
            UserModel user = new UserModel();
            user.Name = txtUserName.Text;
            user.Password = txtPassword.Text;
            result = _unitOfWork.Security.ValidateUser(user);
            if (!result.HasError)
            {
                user = result.Content;
                HttpContext.Current.Session["UserMembership"] = user;
                Response.Redirect(ResolveUrl("~/Modules/Dashboard/Dashboard.aspx"));
            }
            lblMessage.Text = "Users or Password are invalid!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
            //Response.Write(@"<script language='javascript'>alert('Message: \n" + "Users or Password are invalid!" + " .');</script>");
        }

    }
}