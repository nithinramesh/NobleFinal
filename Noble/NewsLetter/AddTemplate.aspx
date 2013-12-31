<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Site.Master" Inherits="NewsLetter.AddTemplate"
    CodeBehind="AddTemplate.aspx.cs" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
        <table class="dataTable2">
            <tr>
                <td style="width: 15%">
                    <asp:Label ID="lblTemplateName" Text="Name" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="searchfrmBoxCol" ID="txtTemplateName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfTN" runat="server" ControlToValidate="txtTemplateName"
                        CssClass="failureNotification" ErrorMessage="Template Name is required." ToolTip="Template Name is required."
                        ValidationGroup="AddTemplate">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSubject" Text="Subject" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="searchfrmBoxCol" ID="txtSubject" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="txtSubject"
                        CssClass="failureNotification" ErrorMessage="Subject is required." ToolTip="Subject is required."
                        ValidationGroup="AddTemplate">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBody" Text="Body" runat="server"></asp:Label>
                </td>
                <td>
                    <telerik:RadEditor ID="EdtBody" runat="server" Width="740px" Height="270px">
                        <Modules>
                            <telerik:EditorModule Name="fakeModule"></telerik:EditorModule>
                        </Modules>
                    </telerik:RadEditor>
                    <asp:RequiredFieldValidator ID="rfvBody" runat="server" ControlToValidate="EdtBody"
                        CssClass="failureNotification" ErrorMessage="Body is required." ToolTip="Body is required."
                        ValidationGroup="AddTemplate">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblFromAddress" Text="From Address" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="searchfrmBoxCol" ID="txtFromAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFromAddress" runat="server" ControlToValidate="txtFromAddress"
                        CssClass="failureNotification" ErrorMessage="From Address is required." ToolTip="From Address is required."
                        ValidationGroup="AddTemplate">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="regexFromAddress" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtFromAddress" ErrorMessage="Invalid Email Format" ToolTip="Invalid Email Format"
                        ValidationGroup="AddTemplate"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDisplayName" Text="DisplayName" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="searchfrmBoxCol" ID="txtDisplayName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtDisplayName" runat="server" ControlToValidate="txtDisplayName"
                        CssClass="failureNotification" ErrorMessage="Display Name is required." ToolTip="Display Name is required."
                        ValidationGroup="AddTemplate">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblReplyAddress" Text="Reply Address" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox CssClass="searchfrmBoxCol" ID="txtReplyAddress" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvReplyAddress" runat="server" ControlToValidate="txtReplyAddress"
                        CssClass="failureNotification" ErrorMessage="Reply Address is required." ToolTip="Reply Address is required."
                        ValidationGroup="AddTemplate">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revtxtReplyAddress" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtReplyAddress" ErrorMessage="Invalid Email Format" ToolTip="Invalid Email Format"
                        ValidationGroup="AddTemplate"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAdd" CssClass="frmButton" Text="Add" runat="server" ValidationGroup="AddTemplate"
                        OnClick="btnAdd_Click"></asp:Button>&nbsp;
                    <asp:Button ID="btnCancel" CssClass="frmButton" Text="Cancel" runat="server"
                        OnClick="btnCancel_Click"></asp:Button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
