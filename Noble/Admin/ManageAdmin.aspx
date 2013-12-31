<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageAdmin.aspx.cs" Inherits="Noble.ManageAdmin" EnableEventValidation="false" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--    <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <%--<table class="dataTable2" id="tblSearch" runat="server" visible="true">
        <tr>
            <td>--%>
    <%-- <b>Manage Admin</b>--%>
    <%--   </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                User name
            </td>
            <td>
                <asp:TextBox ID="txtUN" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                First name
            </td>
            <td>
                <asp:TextBox ID="txtFN" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Last name
            </td>
            <td>
                <asp:TextBox ID="txtLN" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                    SkinID="Button1" />
                &nbsp;<asp:Button ID="btnAddAdmin" runat="server" OnClick="btnAddAdmin_Click" Text="Add Admin"
                    SkinID="Button1" />
            </td>
        </tr>
    </table>--%>
    <div class="tableContainer">
        <table width="100%" id="tblGrid" runat="server">
            <tr align="center">
                <td colspan="2">
                    <%-- <asp:GridView ID="gvAdmin" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                            EnableSortingAndPagingCallbacks="True" AllowPaging="True" OnPageIndexChanging="gvAdmin_PageIndexChanging"
                            EmptyDataText="No record found." CssClass="inner" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="User_name" HeaderText="User_name" />
                                <asp:BoundField DataField="Last_name" HeaderText="Last_name" />
                                <asp:BoundField DataField="First_name" HeaderText="First_name" />
                                <asp:BoundField DataField="Email_id" HeaderText="Email_id" NullDisplayText="NA" />
                                <asp:BoundField DataField="Is_Disabled" HeaderText="Is_Disabled" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit-button.png"
                                            OnClick="btnEdit_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnDelete" runat="server" ImageUrl="~/Images/delete-button.png"
                                            OnClick="btnDelete_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>--%>
                    <telerik:RadGrid ID="gvAdmin" runat="server" Skin="WebBlue" Width="99%" AutoGenerateColumns="False"
                        ShowStatusBar="true" AllowPaging="true" PageSize="10" AllowFilteringByColumn="true"
                        OnItemCommand="gvAdmin_ItemCommand" OnNeedDataSource="gvAdmin_NeedDataSource"
                        OnInit="gvAdmin_Init">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                        <MasterTableView DataKeyNames="ID" AutoGenerateColumns="false" NoMasterRecordsText="No data available.">
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="User_name" HeaderText="User_name" DataField="User_name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Last_name" HeaderText="Last_name" DataField="Last_name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="First_name" HeaderText="First_name" DataField="First_name">
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
                    <%--  <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search"
                    SkinID="Button1" />--%>
                    &nbsp;<asp:Button ID="btnAddAdmin" runat="server" OnClick="btnAddAdmin_Click" Text="Add Admin"
                        SkinID="Button1" />
                </td>
            </tr>
        </table>
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="btnAddAdmin">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                        <telerik:AjaxUpdatedControl ControlID="gvAdmin" />
                        <telerik:AjaxUpdatedControl ControlID="tblAdd" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btnCancel">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                        <telerik:AjaxUpdatedControl ControlID="gvAdmin" />
                        <telerik:AjaxUpdatedControl ControlID="tblAdd" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="gvAdmin">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="gvAdmin" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <%--   </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAddAdmin" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
        <%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>--%>
        <table class="dataTable2" id="tblAdd" runat="server" visible="false">
            <tr>
                <td>
                    User name
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfUN" runat="server" ControlToValidate="txtUserName"
                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                        ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
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
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfPwd" runat="server" ControlToValidate="txtPwd"
                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                        ValidationGroup="AdminSave">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="valPassword" runat="server" ControlToValidate="txtPwd"
                        ErrorMessage="Minimum password length is 8" ValidationExpression=".{8}.*" ValidationGroup="AdminSave" />
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
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ValidationGroup="AdminSave"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                    <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
                </td>
                <td>
                    &nbsp;
                    <asp:Button ID="btnSaveAdmin" runat="server" OnClick="btnSaveAdmin_Click" Text="Save Admin"
                        SkinID="Button1" ValidationGroup="AdminSave" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                        SkinID="Button1" />
                </td>
            </tr>
        </table>
    </div>
    <%--  </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddAdmin" EventName="Click"></asp:AsyncPostBackTrigger>
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>
