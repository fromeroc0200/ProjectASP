using BikeStore.Data.Model;
using BikeStore.Service.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BikeStore.Web.Modules.Administration.Products
{
    public partial class Products : System.Web.UI.Page
    {

        //protected override void OnInit(EventArgs e)
        //{
        //    // In OnInit(), set unique ID for Button/ImageButton 
        //    foreach (GridViewRow grdRw in grdProducts.Rows)
        //    {
        //        Button editButton = (Button)grdRw.Cells[2].Controls[1];
        //        editButton.ID = "btnEdit_" + grdRw.RowIndex.ToString();
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                ValidateSeason();
                LoadAllProducts();
            }
        }

        private void ValidateSeason()
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

        private void LoadAllProducts()
        {
            ProcessResult<List<ProductModel>> result = new ProcessResult<List<ProductModel>>();
            ProductsService productsService = new ProductsService();
            //--Generating list of products
            result = productsService.Get();
            if (result.HasError || result.Content == null || result.Content.Count() < 0)
            {
                Response.Write(@"<script language='javascript'>alert('Message: \n The products could not be obtained .');</script>");
                return;
            }

            if(HttpContext.Current.Session["Products"] == null)
                HttpContext.Current.Session["Products"] = result.Content;

            LoadCurrentProducts();
        }

        private void LoadCurrentProducts()
        {
            grdProducts.DataSource = HttpContext.Current.Session["Products"];
            grdProducts.DataBind();
        }

        protected void btnDelProduct_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt16((sender as LinkButton).CommandArgument);
            //int userId = Convert.ToInt16((sender as Button).CommandArgument);
            Response.Write(@"<script language='javascript'>alert('Message: \n" + "product id = " + userId + " .');</script>");
        }

        protected void grdProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProductsService productsService = new ProductsService();
            grdProducts.PageIndex = e.NewPageIndex;
            ProcessResult<List<ProductModel>> result = productsService.Get();
            LoadCurrentProducts();
        }

        protected void grdProducts_Sorting(object sender, GridViewSortEventArgs e)
        {
            string Sortdir = GetSortDirection(e.SortExpression);
            string SortExp = e.SortExpression;
            var list = HttpContext.Current.Session["Products"] as List<ProductModel>;
            if (Sortdir == "ASC")
            {
                list = Sort<ProductModel>(list, SortExp, SortDirection.Ascending);
            }
            else
            {
                list = Sort<ProductModel>(list, SortExp, SortDirection.Descending);
            }
            this.grdProducts.DataSource = list;
            this.grdProducts.DataBind();
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";
            string sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }

        public List<ProductModel> Sort<TKey>(List<ProductModel> list, string sortBy, SortDirection direction)
        {
            PropertyInfo property = list.GetType().GetGenericArguments()[0].GetProperty(sortBy);
            if (direction == SortDirection.Ascending)
            {
                return list.OrderBy(e => property.GetValue(e, null)).ToList<ProductModel>();
            }
            else
            {
                return list.OrderByDescending(e => property.GetValue(e, null)).ToList<ProductModel>();
            }
        }

        protected void btnEditProduct_Click(object sender, EventArgs e)
        {

        }

        protected void grdProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProducts.EditIndex = e.NewEditIndex;
            LoadCurrentProducts();

        }

        protected void grdProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProducts.EditIndex = -1;
            LoadCurrentProducts();
        }

        protected void grdProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grdProducts.DataKeys[e.RowIndex].Value.ToString());

            List<ProductModel> products = HttpContext.Current.Session["Products"] as List<ProductModel>;
            ProductModel prod = products.Find(p => p.product_id == id);
            products.Remove(prod);
            HttpContext.Current.Session["Products"] = products;
            LoadCurrentProducts();
        }

        protected void grdProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grdProducts.DataKeys[e.RowIndex].Value.ToString());

            string product_name = ((TextBox)grdProducts.Rows[e.RowIndex].FindControl("txtProduct_name")).Text;
            decimal list_price = decimal.Parse(((TextBox)grdProducts.Rows[e.RowIndex].FindControl("txtListPrice")).Text);
            int model_year = Convert.ToInt32(((TextBox)grdProducts.Rows[e.RowIndex].FindControl("txtModelYear")).Text);

            List<ProductModel> products = HttpContext.Current.Session["Products"] as List<ProductModel>;


            
            var indexOf = products.IndexOf(products.Find(p => p.product_id == id));
            products[indexOf].product_name = product_name;
            products[indexOf].list_price = list_price;
            products[indexOf].model_year = model_year;

            HttpContext.Current.Session["Products"] = products;

            grdProducts.EditIndex = -1;
            LoadCurrentProducts();
        }

        
    }
}