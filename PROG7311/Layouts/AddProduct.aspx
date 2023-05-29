<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="PROG7311.Layouts.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Styles/AddProduct.css" />
    <div class="container">
        <div class="mb-4">
            <div class="secondShadowBorder">
                <div class="shadowBorder">
                    <div class="form-group">
                        <h1>Add Product</h1>
                        <label for="txtProductName">
                            Product Name:
                        </label>
                        <asp:TextBox runat="server" ID="txtProductName" CssClass="form-control" placeholder="Enter product name" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revProductName" runat="server" ControlToValidate="txtProductName" ErrorMessage="Firstname can only contain letters!"
                            ValidationExpression="^[A-Za-z\s]*$" CssClass="error-label" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtProductType">
                            Product Type:
                        </label>
                        <asp:TextBox runat="server" ID="txtProductType" CssClass="form-control" placeholder="Enter product Type" required></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revProductType" runat="server" ControlToValidate="txtProductType" ErrorMessage="Firstname can only contain letters!"
                            ValidationExpression="^[A-Za-z\s]*$" CssClass="error-label" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtProductQty">
                            Product Quantity:
                        </label>
                        <asp:TextBox runat="server" ID="txtProductQty" CssClass="form-control" placeholder="Enter product quantity" required></asp:TextBox>
                        <asp:Label ID="lblProductQtyError" runat="server" CssClass="error-label" Visible="false"></asp:Label>
                    </div>
                    <asp:Button runat="server" ID="btnAddProduct" CssClass="btn btn-primary btn-login" OnClick="btnAddProduct_Click" Text="Add Product" />
                        <div class="alert alert-dismissible alert-danger" id="validEmail" runat="server">
                        <button type="button" class="btn-close" data-bs-dismiss="alert" fdprocessedid="d2m2i"></button>
                        <strong>Oh snap!</strong> <a class="alert-link">Invalid Product Type</a>The Product type must be unique
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
