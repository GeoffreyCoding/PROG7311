<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFarmerProducts.aspx.cs" Inherits="PROG7311.Layouts.ViewFarmerProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="../Styles/ViewFarmerProducts.css">
    <div class="container">
        <h1>View Farmer Products</h1>
        <div class="filter-section">
            <div class="form-group">
                <label for="txtFarmers">Select Farmer:</label>
                <asp:TextBox runat="server" ID="txtFarmers" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtStartDate">Start Date:</label>
                <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control" type="date" Text="2023-01-01"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtEndDate">End Date:</label>
                <asp:TextBox runat="server" ID="txtEndDate" CssClass="form-control" type="date" Text="2023-12-31"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtProductType">Product Type:</label>
                <asp:TextBox runat="server" ID="txtProductType" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="btnClear" CssClass="btn btn-primary" Text="Clear" OnClick="btnClear_Click" />
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="btnFilter" CssClass="btn btn-primary" Text="Filter" OnClick="btnFilter_Click" />
            </div>
        </div>
    </div>

    <div class="product-list">
        <asp:GridView runat="server" ID="gvProducts" CssClass="table">
            <Columns>
                <asp:BoundField DataField="Fullname" HeaderText="Farmer Full Name" />
                <asp:BoundField DataField="pType" HeaderText="Product Type" />
                <asp:BoundField DataField="pDateAdded" HeaderText="Date Added" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="fLocation" HeaderText="Farmer Location" />
                <asp:BoundField DataField="fEmail" HeaderText="Farmer Email" />
                <asp:BoundField DataField="fPhoneNumber" HeaderText="Farmer Phone Number" />
            </Columns>
        </asp:GridView>
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
                    <p>Data Filtered!</p>
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
                    <p>Error occurred while filtering product data farmer.</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
