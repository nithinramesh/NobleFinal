<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" MasterPageFile="~/Site.Master"
    Inherits="Noble.NewsLetter.ContactList" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
        <table class="dataTable2" width="100%">
            <tr align="right">
                <td align="right">
                    <asp:Button ID="btnAdd" Text="Create" CssClass="frmButton" runat="server" OnClick="btnAdd_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" Text="Cancel" CssClass="frmButton" runat="server"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadGrid ID="rgContacts" Visible="true" runat="server" Width="100%" AutoGenerateColumns="False"
                        ShowStatusBar="true" AllowPaging="true" PageSize="15" AllowFilteringByColumn="true"
                        AllowMultiRowSelection="true" Skin="WebBlue" OnNeedDataSource="rgContacts_NeedDataSource"
                        OnItemCommand="rgContacts_ItemCommand" OnDataBound="rgContacts_DataBound" OnInit="rgContacts_Init">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NextPrevAndNumeric" />
                        <ClientSettings EnableRowHoverStyle="true">
                            <Scrolling UseStaticHeaders="True" ScrollHeight="" SaveScrollPosition="False"></Scrolling>
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="EmailId" Name="Parent" ClientDataKeyNames="EmailId,EmailAddress">
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="EmailAddress" HeaderText="EmailAddress" DataField="EmailAddress"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="FirstName" HeaderText="FirstName" DataField="FirstName"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="LastName" HeaderText="LastName" DataField="LastName"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="CreatedOn" HeaderText="Created On" DataField="Created_on"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="CreatedAdmin" HeaderText="Created Admin" DataField="CreatedAdmin"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Edit" HeaderText="Edit" UniqueName="EditColumn"
                                    ButtonType="ImageButton" ImageUrl="~/Images/edit-button.png" ItemStyle-Width="5%">
                                </telerik:GridButtonColumn>
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
