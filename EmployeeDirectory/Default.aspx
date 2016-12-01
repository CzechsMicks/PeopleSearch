<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EmployeeDirectory._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Employee Search</h2> 
	<p>Search an employee by typing a last name.</p> 
	<asp:TextBox ID="txtName" runat="server"/> 
	<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" /> 
	<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Search cannot be empty!" Display="Dynamic" /> 
	<asp:RegularExpressionValidator ID="revName" runat="server" ControlToValidate="txtName" ValidationExpression="^\s*[a-zA-Z,\s]+\s*$" ErrorMessage="Search can only contain letters!" Display="Dynamic" /> 
	<asp:PlaceHolder ID="phEmployeeSearch" runat="server" Visible="false">    
	<asp:Repeater ID="rpEmployeeSearchView" runat="server"> 
	<ItemTemplate> 
	    <p><asp:HyperLink ID="hlLink" runat="server" NavigateUrl='<%#Eval("guid", "viewdetail.aspx?guid={0}")%>' Text='<%#Eval("Name")%>' /></p> 
	</ItemTemplate> 
	</asp:Repeater> 
	</asp:PlaceHolder> 
	<asp:PlaceHolder ID="phNoEmployeeFound" runat="server" Visible="false"> 
	<p>No Employee exists.</p> 
	</asp:PlaceHolder> 

</asp:Content>
