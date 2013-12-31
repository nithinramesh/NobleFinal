<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageEmployer.aspx.cs" Inherits="Noble.Employer.ManageEmployer" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" id="tblGrid" runat="server">
        <tr align="center">
            <td colspan="2">
                <telerik:RadGrid ID="gvEmployer" runat="server" Skin="WebBlue" Width="99%" AutoGenerateColumns="False"
                    ShowStatusBar="true" AllowPaging="true" PageSize="10" AllowFilteringByColumn="true"
                    OnItemCommand="gvEmployer_ItemCommand" OnNeedDataSource="gvEmployer_NeedDataSource"
                    OnInit="gvEmployer_Init">
                    <GroupingSettings CaseSensitive="false" />
                    <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                    <MasterTableView DataKeyNames="ID" AutoGenerateColumns="false" NoMasterRecordsText="No data available.">
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="Name" HeaderText="Name" DataField="Name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Addr1" HeaderText="Addr1" DataField="Addr1">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="City" HeaderText="City" DataField="City">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Email_id" HeaderText="Email_id" DataField="Email_id">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Is_Disabled" HeaderText="Is_Disabled" DataField="Is_Disabled">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="Edit" HeaderText="Edit" UniqueName="EditColumn"
                                ButtonType="ImageButton" ImageUrl="~/Images/edit-button.png">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="Delete" HeaderText="Delete" UniqueName="DeleteColumn"
                                ButtonType="ImageButton" ImageUrl="~/Images/delete-button.png">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;<asp:Button ID="btnAddEmployer" runat="server" OnClick="btnAddEmployer_Click"
                    Text="Add Employer" SkinID="Button1" />
                     &nbsp;<asp:Button ID="btnAssignFiles" runat="server" 
                    Text="Assign Files" SkinID="Button1" onclick="btnAssignFiles_Click" />
            </td>
        </tr>
    </table>
    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddEmployer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                    <telerik:AjaxUpdatedControl ControlID="gvEmployer" />
                    <telerik:AjaxUpdatedControl ControlID="tblAdd" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                    <telerik:AjaxUpdatedControl ControlID="gvEmployer" />
                    <telerik:AjaxUpdatedControl ControlID="tblAdd" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="gvEmployer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvEmployer" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <table class="dataTable2" id="tblAdd" runat="server" visible="false">
        <tr>
            <td>
                User name
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfUN" runat="server" ControlToValidate="txtUserName"
                    CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                    ValidationGroup="EmployerSave">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="txtPwd" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfPwd" runat="server" ControlToValidate="txtPwd"
                    CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                    ValidationGroup="EmployerSave">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valPassword" runat="server" ControlToValidate="txtPwd"
                    ErrorMessage="Minimum password length is 8" ValidationExpression=".{8}.*" ValidationGroup="EmployerSave" />
            </td>
        </tr>
        <tr>
            <td>
                Name
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfFN" runat="server" ControlToValidate="txtName"
                    CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                    ValidationGroup="EmployerSave">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Address 1
            </td>
            <td>
                <asp:TextBox ID="txtAddress1" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Address 2
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
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
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ValidationGroup="EmployerSave"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
                <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
            </td>
            <td>
                &nbsp;
                <asp:Button ID="btnSaveEmp" runat="server" Text="Save Employer" SkinID="Button1" OnClick="btnSaveEmp_Click"
                    ValidationGroup="EmployerSave" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                    SkinID="Button1" />
            </td>
        </tr>
    </table>
</asp:Content>
