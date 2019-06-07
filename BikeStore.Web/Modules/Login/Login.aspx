<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BikeStore.Web.Modules.Login.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="login-form">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-xs-12">
                    <div class="alert alert-danger" style="display: none">
                        <p id="lblError">Invalid User Name/Password.</p>
                    </div>
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <div class="card">
                        <div class="card-header">
                            Login

                        </div>
                        <div class="card-body">
                            <form>
                                <div class="form-group row">
                                    <label for="txtUserName" class="col-md-4 col-form-label text-md-right">User Name</label>
                                    <div class="col-md-6">
                                        <asp:TextBox id="txtUserName" placeholder="User Name" class="form-control" runat="server" required="required"/>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="txtPassword" class="col-md-4 col-form-label text-md-right">Password</label>
                                    <div class="col-md-6">
                                        <asp:TextBox id="txtPassword" placeholder="Password" TextMode="Password" class="form-control" runat="server" required="required" />
                                       
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <div class="col-md-6 offset-md-4">
                                        <div class="checkbox">
                                            <label>
                                                <input type="checkbox" name="remember">
                                                Remember Me
                                            </label>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-6 offset-md-4">
                                    <asp:Button ID="btnLogin" class="btn btn-primary" Text="Login" runat="server" OnClick="btnLogin_Click" OnClientClick="return Validation()" />
                                    <%--<button type="button" class="btn btn-primary" onclick="login()">
                                        Login
                                    </button>--%>
                                    <a href="#" class="btn btn-link">Forgot Your Password?
                                    </a>
                                </div>

                            </form>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </main>
  
    <!-- Modal -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Login</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>

                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMessage" runat="server" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>

        </div>
    </div>
    
    <script type="text/javascript">
        function showModal() {
            $("#myModal").modal('show');
        }

        $(function () {
            $("#btnShow").click(function () {
                showModal();
            });
        });
    </script>

    <script type="text/javascript">
        $("#txtUserName").on('keypress', function (e) {
            if (e.which == 13) {
                login();
            }
        });
        $("#txtPassword").on('keypress', function (e) {
            if (e.which == 13) {
                login();
            }
        });
    </script>
    

    <!--Validating Data-->
    <script type="text/javascript">

        function Validation() {
             /*Getting data*/
            var usr = $("#<%=txtUserName.ClientID%>").val();
            var pass = $("#<%=txtPassword.ClientID%>").val();
            var result = true;
            if (usr === '' && pass === '') {
                $('#lblError').text("Username and password must not be empty");
                $(".alert").show();
                result = false;
            } else if (usr === '') {
                $('#lblError').text("The username must not be empty");
                $(".alert").show();
                result = false;
            } else if (pass === '') {
                $('#lblError').text("The password must not be empty");
                $(".alert").show();
                result = false;
            }
            return result;
        }

    </script>
</asp:Content>
