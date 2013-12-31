<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EmailCategoryList.aspx.cs"
    Inherits="Noble.NewsLetter.EmailCategoryList" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
        <table class="dataTable2" width="100%">
            <tr>
                <td class="dataTable2" width="60%">
                    <table>
                        <tr>
                            <%-- <td>
                                Create New Category
                            </td>--%>
                            <td>
                                <asp:TextBox ID="txtCategoryName" CssClass="searchfrmBoxCol" runat="Server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfCN" runat="server" ControlToValidate="txtCategoryName"
                                    CssClass="failureNotification" ErrorMessage="Category Name is required." ValidationGroup="EmailCategory"
                                    ToolTip="Category Name is required.">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" Text="Save" ValidationGroup="EmailCategory" CssClass="frmButton"
                                    runat="server" OnClick="btnSave_Click" />
                                &nbsp;
                                <asp:Button ID="btnCancel" Text="Cancel" CssClass="frmButton" runat="server"
                                    OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <telerik:RadGrid ID="rgContactCategories" Visible="true" runat="server" Width="100%"
                        AutoGenerateColumns="False" ShowStatusBar="true" AllowPaging="true" PageSize="15"
                        AllowMultiRowSelection="true" Skin="WebBlue" OnNeedDataSource="rgContactCategories_NeedDataSource"
                        OnItemCommand="rgContactCategories_ItemCommand" OnDataBound="rgContactCategories_DataBound">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NextPrevAndNumeric" />
                        <ClientSettings EnableRowHoverStyle="true">
                            <Scrolling UseStaticHeaders="True" ScrollHeight="" SaveScrollPosition="False"></Scrolling>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="CategoryId" Name="Parent" ClientDataKeyNames="CategoryId,CategoryName">
                            <Columns>
                                <telerik:GridHyperLinkColumn UniqueName="CategoryName" HeaderText="Category Name"
                                    Text="CategoryName" FilterControlWidth="100px">
                                </telerik:GridHyperLinkColumn>
                                <telerik:GridBoundColumn UniqueName="ContactsCount" HeaderText="Contacts Count" DataField="ContactsCount"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Delete" HeaderText="Delete" UniqueName="DeleteColumn"
                                    ButtonType="ImageButton" ImageUrl="~/Images/delete-button.png" ItemStyle-Width="5%">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
