<%@ Page Title="Homepage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Layouts/HomePage.aspx.cs" Inherits="PROG7311.HomePage" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>My Farm App - Dashboard</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
        <link rel="stylesheet" href="styles.css">
    </head>
    <body>
      <div class="container mt-5">
            <div class="row">
                <div class="col-md-6">
                    <h2>Welcome to My Farm App</h2>
                    <p>Manage your farm products and farmers with ease.</p>
                    <a runat="server" id="btnBackToLogin" onclick="BtnBackToLogin_Click()" class="btn btn-primary mt-3">Get Started</a>
                </div>
                <div class="col-md-6">
                    <img src="../Images/homepage_Farmers_Image.png" alt="Farm App" class="img-fluid">
                </div>
            </div>
        </div>
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.10.2/dist/umd/popper.min.js"
                integrity="sha384-eQf+jU/tOcv/jxQdS89MvLpdLw+aQ3E6oKEDf3rnJ4L61YkT/Sf6ppjlqO5RNMmk"
                crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </body>
    </html>
</asp:Content>
