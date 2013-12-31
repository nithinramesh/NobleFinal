<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditAdmin.aspx.cs" Inherits="Noble.EditAdmin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <div class="tableContainer">
                <table class="dataTable2" id="tblAdd" runat="server" visible="true">
                    <tr>
                        <td>
                            <%--<b>Edit Admin</b>--%>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            First name
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfFN" runat="server" ControlToValidate="txtFirstName"
                                CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                                ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last name
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastName" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfLN" runat="server" ControlToValidate="txtLastName"
                                CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required."
                                ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" MaxLength="75" SkinID="TextBox1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfEMAIL" runat="server" ControlToValidate="txtEmail"
                                CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                                ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Password
                        </td>
                        <td>
                            <asp:TextBox ID="txtPass" runat="server" MaxLength="75" SkinID="TextBox1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfPwd" runat="server" ControlToValidate="txtPass"
                                CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                                ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="valPassword" runat="server" ControlToValidate="txtPass"
                                ErrorMessage="Minimum password length is 8" ValidationExpression=".{8}.*" ValidationGroup="AdminSave" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Disabled
                        </td>
                        <td>
                            <asp:CheckBox ID="cbDisable" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:Button ID="btnSaveAdmin" runat="server" OnClick="btnSaveAdmin_Click" Text="Save Admin"
                                ValidationGroup="AdminSave" SkinID="Button1" />
                        </td>
                        <td>
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                SkinID="Button1" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
