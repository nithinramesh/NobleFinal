<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NotesEdit.ascx.cs" Inherits="Noble.NotesEdit" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div style="border: 1px; border-style: solid; min-width: 300px; min-height: 300px;">
    <div style="background-color: Gray; min-width: 300px">
        <b>Detail View</b></div>
    <div style="padding: 20px;">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
            CausesValidation="False" CommandName="Cancel" SkinID="Button1" />
    </div>
</div>
