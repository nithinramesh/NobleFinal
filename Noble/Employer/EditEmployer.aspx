<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditEmployer.aspx.cs" Inherits="Noble.Employer.EditEmployer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>
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
                        Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfFN" runat="server" ControlToValidate="txtName"
                            CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="Name is required."
                            ValidationGroup="EmployerSave">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address 1
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddr1" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address 2
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddr2" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        City
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province
                    </td>
                    <td>
                        <asp:TextBox ID="txtProvince" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Postal Code
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostalCode" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Phone
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
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
                            ValidationGroup="EmployerSave">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        UserName
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" MaxLength="75" SkinID="TextBox1" Enabled="false"></asp:TextBox>
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
                            ValidationGroup="EmployerSave">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="valPassword" runat="server" ControlToValidate="txtPass"
                            ErrorMessage="Minimum password length is 8" ValidationExpression=".{8}.*" ValidationGroup="EmployerSave" />
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
                        <asp:Button ID="btnSaveEmployer" runat="server" Text="Save Employer" ValidationGroup="EmployerSave"
                            SkinID="Button1" OnClick="btnSaveEmployer_Click" />
                    </td>
                    <td>
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                            SkinID="Button1" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
