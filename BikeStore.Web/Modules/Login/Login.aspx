<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BikeStore.Web.Modules.Login.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="login-form">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-xs-12">
              <div class="alert alert-danger" style="display:none">
                <p id="lblError">Invalid User Name/Password.</p>
              </div>
            </div>
          </div>
        <div class="row justify-content-center">
            <div class="col-md-8">
                  <div class="card">
                    <div class="card-header">Login

                    </div>
                      <div class="card-body">
                          <form action="" method="">
                              <div class="form-group row">
                                  <label for="userName" class="col-md-4 col-form-label text-md-right">User Name</label>
                                  <div class="col-md-6">
                                      <input type="text" id="userName" class="form-control" name="userName" required autofocus >
                                  </div>
                              </div>

                              <div class="form-group row">
                                  <label for="password" class="col-md-4 col-form-label text-md-right">Password</label>
                                  <div class="col-md-6">
                                      <input type="password" id="password" class="form-control" name="password" >
                                  </div>
                              </div>

                              <div class="form-group row">
                                  <div class="col-md-6 offset-md-4">
                                      <div class="checkbox">
                                          <label>
                                              <input type="checkbox" name="remember"> Remember Me
                                          </label>
                                      </div>
                                  </div>
                              </div>

                              <div class="col-md-6 offset-md-4">
                                  <button type="button" class="btn btn-primary" onclick="login()">
                                      Login
                                  </button>
                                  <a href="#" class="btn btn-link">
                                      Forgot Your Password?
                                  </a>
                              </div>

                          </form>
                      </div>

                  </div>
            </div>
        </div>
    </div>
</main>


<script type="text/javascript">
    function login() {
        /*Getting data*/
        var usr = $('#userName').val();
        var pass = $('#password').val();
        if (usr === '' && pass === '') {
            $('#lblError').text("Username and password must not be empty");
            $(".alert").show();
            return;
        } else if(usr === '') {
            $('#lblError').text("The username must not be empty");
            $(".alert").show();
            return;
        } else if(pass === '') {
            $('#lblError').text("The password must not be empty");
            $(".alert").show();
            return;
        }



        var url = "<%= ResolveClientUrl("~/Modules/Login/Login.aspx/LoginUser") %>";
        $.ajax({
            type: "POST",
            url: url,
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ userName: usr, password: pass }),
            async: true,
            success: function (result) {
                if (result.d.HasError) {
                    $('#lblError').text("Invalid User Name/Password.");
                    $(".alert").show();
                    
                } else {
                    $(".alert").hide();
                    window.location = '<%=ResolveUrl("~/Modules/Dashboard/Dashboard.aspx")%>';
                }
                
                    
                
            },
            error: function (result) {
                alert('error occured: ' + result.responseText);
                /*alert(result.responseText);
                window.location.href = "FrmError.aspx?Exception=" + result.responseText;*/
            },
        
        });
    }
</script>
</asp:Content>
