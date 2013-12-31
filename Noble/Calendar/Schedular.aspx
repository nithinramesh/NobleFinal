<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedular.aspx.cs" Inherits="Noble.Calendar.WebForm1" %>
<%@ Register src="CalendarSchedular.ascx" tagname="CalendarSchedular" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:CalendarSchedular ID="CalendarSchedular1" runat="server" />
</asp:Content>
