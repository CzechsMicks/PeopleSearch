<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewdetail.aspx.cs" Inherits="EmployeeDirectory.viewdetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
	<style type="text/css" media="screen"> 
	@import "style.css"; 
	</style> 
    <asp:PlaceHolder ID="phViewDetail" runat="server" Visible="true"> 
	<dl> 
	<dt>First name:</dt> 
	<dd><asp:Label ID="lblFName" runat="server" /></dd> 
	<dt>Last name:</dt> 
	<dd><asp:Label ID="lblLName" runat="server" /></dd> 
	<dt>Address:</dt> 
	<dd><asp:Label ID="lblAddress" runat="server" /></dd> 
    <dt>Age:</dt> 
	<dd><asp:Label ID="lblAge" runat="server" /></dd>
    <dt>Interests:</dt> 
	<dd><asp:Label ID="lblInterests" runat="server" /></dd>
    <dt>Picture:</dt> 
	<dd><asp:Label ID="lblPicture" runat="server" /></dd>
	<dt></dt> 
	<dd><a href="Default.aspx">Back to employee directory</a></dd> 
	</dl> 
	</asp:PlaceHolder> 
	<asp:PlaceHolder ID="phNoViewDetail" runat="server" Visible="false"> 
	<p>No employee selected.</p> 
	</asp:PlaceHolder> 
</asp:Content>
