using BikeStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeStore.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["UserMembership"] = null;
            Response.Redirect(ResolveUrl("~/Modules/Login/Login.aspx"));
        }
    }
}