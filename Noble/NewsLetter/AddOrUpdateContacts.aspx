<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOrUpdateContacts.aspx.cs"
    MasterPageFile="~/Site.Master" Inherits="Noble.NewsLetter.AddOrUpdateContacts" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
        <table class="dataTable2">
            <tr>
                <td>
                    First name
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="searchfrmBoxCol" MaxLength="100"
                        SkinID="TextBox1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Last name
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="searchfrmBoxCol" MaxLength="100"
                        SkinID="TextBox1"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="frmButton" MaxLength="100"
                        SkinID="TextBox1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfEMAIL" runat="server" ControlToValidate="txtEmail"
                        CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                        ValidationGroup="EmailContact">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\s*\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*"
                        ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ValidationGroup="EmailContact"
                        CssClass="failureNotification"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessge" runat="server" CssClass="failureNotification"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="frmButton"
                        Text="Save Admin" SkinID="Button1" ValidationGroup="EmailContact" />
                </td>
                <td>
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="frmButton" OnClick="btnCancel_Click"
                        Text="Cancel" SkinID="Button1" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
