<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="BikeStore.Web.Modules.Administration.Categories.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-xs-12">
            <h1>Categories</h1>
        </div>
    </div>
    <div class="row">
  <div class="col-xs-12">
      <div class="form-group">
          <label for="category_name">Category Name</label>
          <asp:TextBox ID="txtCategoryName" class="form-control" runat="server" />
        </div>
      <asp:Button ID="btnAddCategory" class="btn btn-primary" Text="Add New Category" runat="server" />
  </div>
</div>
<br/>
<div>
    <asp:GridView runat="server">

    </asp:GridView>
</div>

    <div class="container">
    <div class="btn-group">
        <asp:Button ID="btnSubmit" class="btn btn-primary" runat="server" Text="Submit"          
        OnClick="btnSubmit_Click"></asp:Button>
    </div>
</div>


<!-- Bootstrap Modal Dialog -->
<div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
</asp:Content>
