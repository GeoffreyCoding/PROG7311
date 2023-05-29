<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PROG7311._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <head>
        <meta charset="UTF-8">
        <title>Login Page</title>
        <!-- Page title -->
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" integrity="sha512-i2/GNz6S5BhtakMfZcZyzvH1+Qic/6/TJwLm8Qn/CO6eB+1rK5UvS8r2LnZUxLtbIIfSsC2o4fB6VHwH+1PLKw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.0/css/bootstrap.min.css" integrity="sha512-/gPrYqicnW+WaFVs7Tmv2sSY/YS1A4W0eXb+nz4Nz3hXLE1lH/7T4dUZYUet6AgFqckzqT5OnN2Gt4evKSiTjA==" crossorigin="anonymous" referrerpolicy="no-referrer" />
        <link rel="stylesheet" href="../Styles/Login.css" />
        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
        <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    </head>
    <!--GUI COMPONENTS-->
    <body>
        <div class="login-form">
            <h2 text-center="mb4">Login</h2>
            <form action="" method="post">
                <div class="mb-4">
                    <!--Email label-->
                    <label for="email" class="form-label">Email address</label>
                    <div class="form-group">
                            <!--Email icon image-->
                            <div class="input-group-prepend" style="width: 42px;">
                                <span class="input-group-text" style="width: 42px;">
                                    <img src="../Images/envelope-solid.svg" alt="Email" width="25" height="25" id="imgEmailIcon" />
                                </span>
                            </div>
                         <!--Email input text box-->
                        <asp:TextBox inputtype="email" class="form-control" ID="txtEmail" name="email" runat="server" Style="width: 220px;" required></asp:TextBox>                               
                    </div>
                    <!--Invalid Email Label-->
                    <asp:Label ID="lblInvalidEmail" runat="server" Text=" " ForeColor="Red" Visible="false"></asp:Label>
                    <!--Password label-->
                    <div>
                        <label for="password" class="form-label">Password</label>
                    </div>
                    <div class="form-group">
                            <!--Password icon-->
                            <div class="input-group-prepend" style="width: 42px;">
                                <span class="input-group-text">
                                    <img src="../Images/lock-solid.svg" alt="Password" width="25" height="25" id="imgPasswordIcon" /> 
                                </span>
                            </div>
                            <!--Password input text box-->
                            <asp:TextBox inputtype="Password" TextMode="Password" PasswordChar="*" class="form-control" ID="txtPassword" name="password" runat="server" Style="width:220px;" required></asp:TextBox>
                    </div>
                    <!--Invalid Password Label-->
                    <asp:Label ID="lblInvalidPassword" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                    <asp:Button class="form-group">
                        <!--Login Button-->
                        <asp:Button type="submit" text="Login" class="btn btn-primary btn-sm w-100" id="btnLogin" OnClick="btnLogin_Click" runat="server"></asp:Button>
                    </asp:Button>
                </div>
            </form>
        </div>
        <!------------------------------------------------------------------------------END-OF-FILE----------------------------------------------------------------------->
</asp:Content>
