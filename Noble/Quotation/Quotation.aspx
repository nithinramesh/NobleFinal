<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Quotation.aspx.cs" Inherits="Noble.Quotation.Quotation" EnableEventValidation="false" %>

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
    <%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvQuot">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvQuot" LoadingPanelID="RadAjaxLoadingPanel1">
                    </telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div style="width: 100%; margin-left: 20%;">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
    </div>--%>
    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    <table id="tblGrid" runat="server" visible="true">
        <tr>
            <td>
                <telerik:RadGrid ID="gvQuot" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" ShowStatusBar="true" OnPreRender="gvQuot_PreRender"
                    OnNeedDataSource="gvQuot_NeedDataSource" OnUpdateCommand="gvQuot_UpdateCommand"
                    OnInsertCommand="gvQuot_InsertCommand" OnDeleteCommand="gvQuot_DeleteCommand"
                    OnItemCommand="gvQuot_ItemCommand" Skin="WebBlue" PageSize="10" AllowFilteringByColumn="true"
                    OnDataBound="gvQuot_DataBound">
                    <GroupingSettings CaseSensitive="false" />
                    <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                    <MasterTableView Width="100%" EditMode="EditForms" CommandItemDisplay="Top" DataKeyNames="QuotNo,FilePath">
                        <EditFormSettings>
                            <PopUpSettings Width="500px" Height="475px" Modal="true" />
                        </EditFormSettings>
                        <Columns>
                            <%-- <telerik:GridEditCommandColumn UniqueName="EditCommandColumn">
                </telerik:GridEditCommandColumn>--%>
                            <telerik:GridBoundColumn UniqueName="QuotNo" HeaderText="QuotNo" DataField="QuotNo"
                                ItemStyle-Width="10px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Date" HeaderText="Date" DataField="Date">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Valid Untill" HeaderText="Valid Untill" DataField="Validtill">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Title" HeaderText="Title" DataField="title"
                                Visible="false" DataFormatString="{0:d}">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Firstname" HeaderText="First Name" DataField="Firstname">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Lastname" HeaderText="Lastname" DataField="Lastname">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Address" HeaderText="Address" DataField="Address">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="HST" HeaderText="HST" DataField="HST" Visible="false"
                                ItemStyle-Width="20px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Total" HeaderText="Total" DataField="Total"
                                ItemStyle-Width="20px">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn HeaderText="View" CommandName="Select" Text="Select" UniqueName="SelectColumn"
                                ButtonType="ImageButton" ImageUrl="~/images/FileUpload/OneNote.png">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="Edit" HeaderText="Edit" UniqueName="EditColumn"
                                ButtonType="ImageButton" ImageUrl="~/Images/edit-button.png" ItemStyle-Width="5%">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn UniqueName="DeleteColumn" HeaderText="Delete" ConfirmText="Do you want to Delete ?"
                                ConfirmDialogType="RadWindow" Text="Delete" CommandName="Delete" ButtonType="ImageButton"
                                ImageUrl="~/Images/delete-button.png">
                            </telerik:GridButtonColumn>
                        </Columns>
                        <EditFormSettings UserControlName="QuotationEdit.ascx" EditFormType="WebUserControl">
                            <EditColumn UniqueName="EditCommandColumn1">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table style="margin-left: 50%" id="tblNewQuot3" runat="server" visible="false">
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="btnInsert_Parent" Text="Insert" runat="server" OnClick="btnInsert_Click">
                </asp:Button>
                &nbsp;
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False"
                    CommandName="Cancel" OnClick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
