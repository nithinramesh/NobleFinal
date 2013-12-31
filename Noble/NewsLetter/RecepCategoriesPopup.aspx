<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecepCategoriesPopup.aspx.cs"
    Inherits="Noble.NewsLetter.RecepCategoriesPopup" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">


        var EmailWnd = GetEmailRadWindow();

        function GetEmailRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)

            return oWindow;
        }


        function CloseEmailWindow() {
            EmailWnd.BrowserWindow.document.forms[0].submit();
            EmailWnd.Close();
        }






    </script>
    <link href="../script-css/homestyle.css" rel="stylesheet" type="text/css" />
    <link href="../script-css/innerstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <div>
        <table class="dataTable2" width="100%">
            <tr>
                <td>
                    <table width="80%">
                        <tr>
                            <td>
                                Create New List:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCategoryName" CssClass="searchfrmBoxCol" Width="200px" runat="Server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfCN" runat="server" ControlToValidate="txtCategoryName"
                                    CssClass="failureNotification" ErrorMessage="Category Name is required." ValidationGroup="EmailCategory"
                                    ToolTip="Category Name is required.">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" Text="Save" CssClass="frmButton" ValidationGroup="EmailCategory"
                                    runat="server" OnClick="btnSave_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="rgContactCategories" Visible="true" runat="server" Width="100%"
                        AutoGenerateColumns="False" ShowStatusBar="true" AllowPaging="true" PageSize="10"
                        AllowMultiRowSelection="true" Skin="WebBlue" OnNeedDataSource="rgContactCategories_NeedDataSource"
                        OnItemCommand="rgContactCategories_ItemCommand" OnDataBound="rgContactCategories_DataBound"
                        OnColumnCreated="rgContactCategories_ColumnCreated" OnItemDataBound="rgContactCategories_ItemDataBound">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NextPrevAndNumeric" />
                        <ClientSettings EnableRowHoverStyle="true">
                            <Scrolling UseStaticHeaders="True" ScrollHeight="" SaveScrollPosition="False"></Scrolling>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="CategoryId" ExpandCollapseColumn-CollapseImageUrl="../images/min.png"
                            ExpandCollapseColumn-ExpandImageUrl="../images/plus.png" Name="Parent" ClientDataKeyNames="CategoryId">
                            <DetailTables>
                                <telerik:GridTableView HierarchyLoadMode="Client" AllowPaging="false" Name="Child">
                                    <ParentTableRelation>
                                        <telerik:GridRelationFields DetailKeyField="CategoryId" MasterKeyField="CategoryId">
                                        </telerik:GridRelationFields>
                                    </ParentTableRelation>
                                    <Columns>
                                        <telerik:GridTemplateColumn>
                                            <ItemTemplate>
                                                <table width="100%" class="dataTable2">
                                                    <tr style="border: none;">
                                                        <td style="border: none;">
                                                            <telerik:RadTextBox ID="rdEmails" TextMode="MultiLine" Width="100%" EmptyMessage="email@email.com"
                                                                runat="server">
                                                            </telerik:RadTextBox>
                                                            <asp:RequiredFieldValidator ID="rfEMAIL" runat="server" ControlToValidate="rdEmails"
                                                                CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                                                                ValidationGroup="EmailSave">*</asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="border: none;">
                                                            <asp:Button ID="btnAdd" CommandName="AddEmail" ValidationGroup="EmailSave" CssClass="frmButton"
                                                                runat="server" Text="Add Email" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblMessage" CssClass="failureNotification" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="CategoryName" HeaderText="Category Name" DataField="CategoryName"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="ContactsCount" HeaderText="Contacts Count" DataField="ContactsCount"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn">
                                </telerik:GridClientSelectColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button ID="btnSelect" CssClass="frmButton" runat="server" Text="Select"
                        OnClick="btnSelect_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
