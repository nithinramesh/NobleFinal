<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageNotes.aspx.cs" EnableEventValidation="false" Inherits="Noble.Notes.ManageNotes" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvQuot">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvQuot" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <table runat="server" id="tblNotes" width="100%">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr align="center">
            <td>
                <telerik:RadGrid ID="gvNotes" runat="server" Width="100%" AutoGenerateColumns="False"
                    ShowStatusBar="true" AllowPaging="true" PageSize="10" Skin="WebBlue" OnItemCommand="gvNotes_ItemCommand"
                    OnNeedDataSource="gvNotes_NeedDataSource" OnDeleteCommand="gvNotes_DeleteCommand"
                    OnInsertCommand="gvNotes_InsertCommand" OnUpdateCommand="gvNotes_UpdateCommand"
                    OnPreRender="gvNotes_PreRender">
                    <%--onitemdatabound="gvNotes_ItemDataBound"--%>
                    <GroupingSettings CaseSensitive="false" />
                    <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                    <MasterTableView DataKeyNames="ID,Status_code" EditMode="EditForms" CommandItemDisplay="Top"
                        NoMasterRecordsText="No data available.">
                        <EditFormSettings>
                            <PopUpSettings Width="500px" Height="475px" Modal="true" />
                        </EditFormSettings>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="Notes" HeaderText="Notes" DataField="Note_text"
                                ItemStyle-Width="35%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Status" HeaderText="Status" DataField="Status_text"
                                ItemStyle-Width="15%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Assigned_To" HeaderText="Assigned_To" DataField="Assigned_toName"
                                ItemStyle-Width="15%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Updated_On" HeaderText="Updated_On" DataField="Updated_On"
                                ItemStyle-Width="15%">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="Edit" HeaderText="Edit" UniqueName="EditColumn"
                                ButtonType="ImageButton" ImageUrl="~/Images/edit-button.png" ItemStyle-Width="5%">
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings UserControlName="UCManageNotes.ascx" EditFormType="WebUserControl">
                            <EditColumn UniqueName="EditCommandColumn1">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%--  <asp:Button ID="btnAddNotes" runat="server" Text="Add Notes" OnClick="btnAddNotes_Click"
                    SkinID="Button1" />--%>
            </td>
        </tr>
    </table>
</asp:Content>
