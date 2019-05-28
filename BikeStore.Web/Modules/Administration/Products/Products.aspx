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
    <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" >
        <Columns>
            <asp:BoundField DataField="product_name" HeaderText="Name"/>
            <asp:BoundField DataField="list_price" HeaderText="Password"/>
            <asp:BoundField DataField="model_year" HeaderText="CreateDate"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button Text="Edit" runat = "server" CommandArgument='<%# Eval("product_id") %>' OnClick="btnDelProduct_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </div>
        </div>
</asp:Content>
