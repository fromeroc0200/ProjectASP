using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeStore.Web.Modules.Administration.Categories
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserMembership"] == null)
            {
                Response.Redirect(ResolveUrl("~/Modules/Login/Login.aspx"));
            }
            else
            {
                var link = Master.FindControl("lnkProduct");
                link.Visible = true;
                link = Master.FindControl("lnkCategories");
                link.Visible = true;
                link = Master.FindControl("lnkLogout");
                link.Visible = true;
                link = Master.FindControl("lnkLogin");
                link.Visible = false;
                link = Master.FindControl("lnkRegister");
                link.Visible = false;
            }
        }
    }
}