<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Layouts/AddFarmer.aspx.cs" Inherits="PROG7311.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <title>Add Farmer</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
        <link rel="stylesheet" href="../Styles/AddFarmer.css">
    </head>
    <div class="navbar-container">
    </div>
    <div class="container">
        <div class="mb-4">
            <div class="secondShadowBorder">
                <div class="shadowBorder">
                    <h1>Add Farmer</h1>
                    <div class="mb-4">
                        <div class="form-group">
                            <label for="txtFirstName">
                                <img src="full-name-image.jpg" alt="First Name" class="input-image">
                                First Name:
                            </label>
                            <%--  --%>
                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" placeholder="Enter first name" required></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Firstname can only contain letters!"
                                ValidationExpression="^[A-Za-z\s]*$" CssClass="error-label" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtSurname">
                                <img src="../Images/lock-solid.svg" alt="txtSurname" class="input-image">
                                Surname:
                            </label>
                            <asp:TextBox runat="server" ID="txtSurname" CssClass="form-control" placeholder="Enter Surname" required></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revSurname" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname can only contain letters!"
                                ValidationExpression="^[A-Za-z\s]*$" CssClass="error-label" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtEmail">
                                <img src="../Images/envelope-solid.svg" alt="Email" class="input-image">
                                Email:
                            </label>
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Enter email" required></asp:TextBox>
                            <asp:Label runat="server" ID="lblInvalidEmail" Visible="false" CssClass="error-label">Invalid Email: An account with that email already exists!</asp:Label>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Must be a valid email"
                                ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" CssClass="error-label" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtLocation">
                                <img src="location-image.jpg" alt="Location" class="input-image">
                                Location:
                            </label>
                            <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control" placeholder="Enter location" required></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revLocation" runat="server" ControlToValidate="txtLocation" ErrorMessage="Location can only contain letters and numbers!"
                                ValidationExpression="^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$" CssClass="error-label" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtPhoneNumber">
                                <img src="../Images/envelope-solid.svg" alt="PhoneNumber" class="input-image">
                                Phone Number:
                            </label>
                            <asp:TextBox runat="server" ID="txtPhoneNumber" CssClass="form-control" placeholder="Enter Phone Number" required></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLocation" ErrorMessage="Location can only contain letters and numbers!"
                                ValidationExpression="^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$" CssClass="error-label" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtPassword">
                                <img src="../Images/lock-solid.svg" alt="Password" class="input-image">
                                Password:
                            </label>
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password" PasswordChar="*" placeholder="Enter password" required></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password must be at least 10 chars long!"
                                ValidationExpression="^.{8,}$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                        <div class="form-group">
                            <label for="txtConfirmPassword">
                                <img src="../Images/lock-solid.svg" alt="ConfirmPassword" class="input-image">
                                Confirm Password:
                            </label>
                            <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control" TextMode="Password" PasswordChar="*" placeholder="Confirm your password" required></asp:TextBox>
                            <asp:CompareValidator ID="cvPasswordMatch" CssClass="error-label" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match" Display="Dynamic"></asp:CompareValidator>
                        </div>
                        <asp:Button runat="server" ID="btnAddFarmer" CssClass="btn btn-primary btn-login" Text="Add Farmer" Width="278px" OnClick="btnAddFarmer_Click" CausesValidation="true" />
                        <div class="alert alert-dismissible alert-danger" id="invalidEmail" runat="server">
                            <button type="button" class="btn-close" data-bs-dismiss="alert" fdprocessedid="d2m2i"></button>
                            <strong>Oh snap!</strong> <a class="alert-link">Invalid Email!</a>The email must be unique
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <div id="successModal" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Success</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Farmer added successfully!</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>
    <div id="errorModal" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Error</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Error occurred while adding farmer.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

