<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFarmerProducts.aspx.cs" Inherits="PROG7311.Layouts.ViewFarmerProducts"%> 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <link rel="stylesheet" href="../Styles/ViewFarmerProducts.css">
  <div class="container">
    <h1>View Farmer Products</h1>
    <div class="filter-section">
      <div class="form-group">
        <label for="ddlFarmers">Select Farmer:</label>
        <asp:DropDownList runat="server" ID="ddlFarmers" CssClass="form-control"></asp:DropDownList>
      </div>

      <div class="form-group">
        <label for="txtStartDate">Start Date:</label>
        <asp:TextBox runat="server" ID="txtStartDate" CssClass="form-control" type="date"></asp:TextBox>
      </div>

      <div class="form-group">
        <label for="txtEndDate">End Date:</label>
        <asp:TextBox runat="server" ID="txtEndDate" CssClass="form-control" type="date"></asp:TextBox>
      </div>
      <div class="form-group">
        <label for="ddlProductType">Product Type:</label>
        <asp:DropDownList runat="server" ID="ddlProductType" CssClass="form-control"></asp:DropDownList>
      </div>
      <div class="form-group">
        <asp:Button runat="server" ID="btnFilter" CssClass="btn btn-primary" Text="Filter" OnClick="btnFilter_Click" />
      </div>
    </div>
  </div>
  <div class="product-list">
    <asp:GridView runat="server" ID="gvProducts" CssClass="table">
      <Columns>
        <asp:BoundField DataField="fFullname" HeaderText="Farmer Name" />
        <asp:BoundField DataField="pType" HeaderText="Product Type" />
        <asp:BoundField DataField="pDateAdded" HeaderText="Date Added" DataFormatString="{0:dd/MM/yyyy}" />
      </Columns>
    </asp:GridView>
  </div>
</asp:Content>
