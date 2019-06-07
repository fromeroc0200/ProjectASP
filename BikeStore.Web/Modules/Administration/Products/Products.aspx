<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="BikeStore.Web.Modules.Administration.Products.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table table tbody tr td a,
        .table table tbody tr td span {
            position: relative;
            float: left;
            padding: 6px 12px;
            margin-left: -1px;
            line-height: 1.42857143;
            color: #337ab7;
            text-decoration: none;
            background-color: #fff;
            border: 1px solid #ddd;
        }

        .table table > tbody > tr > td > span {
            z-index: 3;
            color: #fff;
            cursor: default;
            background-color: #337ab7;
            border-color: #337ab7;
        }

        .table table > tbody > tr > td:first-child > a,
        .table table > tbody > tr > td:first-child > span {
            margin-left: 0;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
        }

        .table table > tbody > tr > td:last-child > a,
        .table table > tbody > tr > td:last-child > span {
            border-top-right-radius: 4px;
            border-bottom-right-radius: 4px;
        }

        .table table > tbody > tr > td > a:hover,
        .table table > tbody > tr > td > span:hover,
        .table table > tbody > tr > td > a:focus,
        .table table > tbody > tr > td > span:focus {
            z-index: 2;
            color: #23527c;
            background-color: #eee;
            border-color: #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <h1>Product List</h1>
        </div>
    </div>
    <div class="cotainer">
        <div class="row justify-content-center">

            <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="false" PageSize="20" AllowPaging="true" AllowSorting="true"
                CssClass="table table-striped table-bordered table-hover"
                DataKeyNames="product_id"
                OnPageIndexChanging="grdProducts_PageIndexChanging"
                OnSorting="grdProducts_Sorting"
                OnRowEditing="grdProducts_RowEditing"
                OnRowCancelingEdit="grdProducts_RowCancelingEdit"
                OnRowDeleting="grdProducts_RowDeleting"
                OnRowUpdating="grdProducts_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="S.No." ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee Name">
                        <ItemTemplate>
                            <%#Eval("product_name")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtProduct_name" runat="server" Text='<%#Eval("product_name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <%#Eval("list_price")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtListPrice" runat="server" Text='<%#Eval("list_price") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Model Year">
                        <ItemTemplate>
                            <%#Eval("model_year")%>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModelYear" runat="server" Text='<%#Eval("model_year") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" ButtonType="Image" EditImageUrl="~/Assets/Content/images/Edit.ico" UpdateImageUrl="~/Assets/Content/images/Save.ico" CancelImageUrl="~/Assets/Content/images/Cancel.ico" HeaderText="Edit" ControlStyle-Width="24px" ControlStyle-Height="24px" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Delete" ShowHeader="False" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <span onclick="return confirm('Are you sure to Delete?')">
                                <asp:ImageButton ImageUrl="~/Assets/Content/images/Delete.ico" ID="btnDelete" runat="server" CausesValidation="False" ControlStyle-Width="24px" ControlStyle-Height="24px"
                                    CommandName="Delete" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/Assets/Content/images/Delete.ico" HeaderText="Delete" ControlStyle-Width="24px" ControlStyle-Height="24px" ItemStyle-HorizontalAlign="Center" OnClientClick="return confirm('Are you sure?');"/>--%>
                </Columns>
                <EditRowStyle BackColor="#ccccff" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>

        </div>
    </div>
</asp:Content>
