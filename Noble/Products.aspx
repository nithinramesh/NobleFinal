<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs"
    Inherits="Noble.ProductCategory.Products" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #tblGrid
        {
            width: 92%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
        <table>
            <tr>
                <td style="width: 135px">
                    Product Category
                </td>
            <td>
                <telerik:RadComboBox runat="server" ID="radCmbPCategories" 
                                     onselectedindexchanged="radCmbPCategories_SelectedIndexChanged"></telerik:RadComboBox>
            </td>
            </tr>
        </table>
        <br />
        <br />
        <table id="tblGrid" runat="server">
            <tr>
                <td>
                <telerik:RadGrid ID="gvproduct" runat="server" Width="100%" AutoGenerateColumns="False"
                                 ShowStatusBar="true" AllowPaging="true" PageSize="10" 
                                 Skin="WebBlue" OnItemCommand="gvproduct_ItemCommand"
                                 OnNeedDataSource="gvproduct_NeedDataSource" 
                                 OnUpdateCommand="gvproduct_UpdateCommand1"
                                 OnInsertCommand="gvproduct_InsertCommand"
                                 OnDeleteCommand="gvproduct_DeleteCommand"
                                 OnInit="gvproduct_Init" AllowFilteringByColumn="True"  >
                    <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                    <MasterTableView EditMode="EditForms" CommandItemDisplay="Top"  DataKeyNames="ID" AutoGenerateColumns="false" NoMasterRecordsText="No data available."  >
                        <Columns>
                              
                            <telerik:GridBoundColumn UniqueName="ProductCode" HeaderText="ProductCode" DataField="ProductCode"
                                                     ItemStyle-Width="15%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="ProductDescription" HeaderText="ProductDescription" DataField="ProductDescription"
                                                     ItemStyle-Width="15%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="ProductPrice" HeaderText="ProductPrice" DataField="ProductPrice"
                                                     ItemStyle-Width="15%">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="Edit" HeaderText="Edit" UniqueName="EditColumn"
                                                      ButtonType="ImageButton" ImageUrl="~/Images/edit-button.png" ItemStyle-Width="2%" >
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="Delete" HeaderText="Delete" UniqueName="DeleteColumn"
                                                      ButtonType="ImageButton" ImageUrl="~/Images/delete-button.png" ItemStyle-Width="2%">
                            </telerik:GridButtonColumn>

                        </Columns>

                        <EditFormSettings UserControlName="ProductCS.ascx" EditFormType="WebUserControl">
                            <EditColumn UniqueName="EditCommandColumn1">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
                </td>
            </tr>
        </table>
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="gvproduct">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="gvproduct" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
    </div>
</asp:Content>
