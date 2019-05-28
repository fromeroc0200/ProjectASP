using BikeStore.Data.Model;
using BikeStore.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeStore.Web.Modules.Administration.Products
{
    public partial class Products : System.Web.UI.Page
    {

        protected override void OnInit(EventArgs e)
        {
            // In OnInit(), set unique ID for Button/ImageButton 
            foreach (GridViewRow grdRw in grdProducts.Rows)
            {
                Button editButton = (Button)grdRw.Cells[2].Controls[1];
                editButton.ID = "btnEdit_" + grdRw.RowIndex.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessResult<List<ProductModel>> result = new ProcessResult<List<ProductModel>>();
            ProductsService productsService = new ProductsService();

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

            //--Generating list of products
            result = productsService.Get();
            if(result.HasError)
            {
                Response.Write(@"<script language='javascript'>alert('Message: \n The products could not be obtained .');</script>");
                return;
            }
            List<ProductModel> products = result.Content;

            grdProducts.DataSource = products;
            grdProducts.DataBind();

        }

        protected void btnDelProduct_Click(object sender, EventArgs e)
        {
            //int userId = Convert.ToInt16((sender as LinkButton).CommandArgument);
            int userId = Convert.ToInt16((sender as Button).CommandArgument);
            Response.Write(@"<script language='javascript'>alert('Message: \n" + "product id = " + userId + " .');</script>");
        }
    }
}