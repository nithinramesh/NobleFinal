<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditMember.aspx.cs" Inherits="Noble.EditMember" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <div class="content">
                <div class="contentContainer">
                    <span class="txtAdj">Manage Member - Edit</span>
                    <div class="tableContainer">
                        <table class="dataTable2" id="tblAdd" runat="server" visible="true">
                            <tr>
                                <td>
                                    <%--<b>Edit Member</b>--%>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Title
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTitle" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    First name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="100" SkinID="TextBox1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfFN" runat="server" ControlToValidate="txtFirstName"
                                        CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                                        ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Middle name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="100" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last name
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="100" SkinID="TextBox1"></asp:TextBox>
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
                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" SkinID="TextBox1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfEMAIL" runat="server" ControlToValidate="txtEmail"
                                        CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                                        ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address 1
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddress1" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address 2
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAddress2" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    City
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCity" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Province
                                </td>
                                <td>
                                    <asp:TextBox ID="txtProvince" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Postal Code
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPostalCode" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" SkinID="TextBox1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhone"
                                        CssClass="failureNotification" ErrorMessage="Phone is required." ToolTip="Phone is required."
                                        ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Home Phone
                                </td>
                                <td>
                                    <asp:TextBox ID="txtHomePhone" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Work Phone
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWorkPhone" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Frame
                                </td>
                                <td>
                                    <asp:TextBox ID="txtJobTitle" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    Position Looking
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPosition" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    Country(Residence)
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCountry" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    Country(Origin)
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOriginCountry" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    Experience
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlExperience" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gender
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlGender" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Other
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOther" runat="server" SkinID="TextBox1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td valign="top">
                                    Job Category(s)
                                </td>
                                <td>
                                    <asp:Label ID="lblJobCategory" runat="server"></asp:Label>
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
                                    <asp:Button ID="btnSaveAdmin" runat="server" OnClick="btnSaveAdmin_Click" Text="Save Member"
                                        SkinID="Button1" ValidationGroup="AdminSave" />
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                        SkinID="Button1" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
