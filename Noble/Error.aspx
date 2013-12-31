<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Noble.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h3 class="subHeadBlue">
        Error</h3>
    <asp:Label ID="lblMessage1" runat="server" class="failureNotification" Text ="Unfortunately an error has occured. Please " ></asp:Label>
    <a href="Default.aspx">login</a> <asp:Label ID="lblMessage2" runat="server" class="failureNotification" Text =" to continue." ></asp:Label>
</asp:Content>
