<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageProductcategory.aspx.cs"
    Inherits="Noble.ProductCategory.ManageProductcategory" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
    <table width="100%" id="tblGrid" runat="server">
        <tr>
            <td>
                <telerik:RadGrid ID="gvPRDCategory" runat="server" Width="100%" AutoGenerateColumns="False"
                                 ShowStatusBar="true" AllowPaging="true" PageSize="10" 
                                 Skin="WebBlue" OnItemCommand="gvPRDCategory_ItemCommand"
                                 OnNeedDataSource="gvPRDCategory_NeedDataSource " 
                                 OnUpdateCommand="gvPRDCategory_UpdateCommand" 
                                 OnInsertCommand="gvPRDCategory_InsertCommand"
                                 OnDeleteCommand="gvPRDCategory_DeleteCommand"
                                 OnCancelCommand="gvPRDCategory_CancelCommand"
                                 OnInit="gvPRDCategory_Init" AllowFilteringByColumn="True" >
                    <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                    <MasterTableView EditMode="EditForms" CommandItemDisplay="Top"  DataKeyNames="ID" AutoGenerateColumns="false" NoMasterRecordsText="No data available."  >
                        <Columns>
                               
                            <telerik:GridBoundColumn UniqueName="ProductCategory_name" HeaderText="ProductcategoryName" DataField="ProductCategory_name"
                                                     ItemStyle-Width="15%">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="Edit" HeaderText="Edit" UniqueName="EditColumn"
                                                      ButtonType="ImageButton" ImageUrl="~/Images/edit-button.png" ItemStyle-Width="2%" >
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="Delete" HeaderText="Delete" UniqueName="DeleteColumn"
                                                      ButtonType="ImageButton" ImageUrl="~/Images/delete-button.png" ItemStyle-Width="2%">
                            </telerik:GridButtonColumn>

                        </Columns>

                        <EditFormSettings UserControlName="ProductCategoryCS.ascx" EditFormType="WebUserControl">
                            <EditColumn UniqueName="EditCommandColumn1">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>

        </tr>
        
    </table>


    <table class="dataTable2" id="tblAdd" runat="server" visible="false">
        <tr>
            <td>
                ProductCategory Name
            </td>
            <td>
                <asp:TextBox ID="txtcategory" runat="server" MaxLength="50" SkinID="TextBox1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfUN" runat="server" ControlToValidate="txtcategory"
                                            CssClass="failureNotification" ErrorMessage="Category Name is required." ToolTip="Category Name is required."
                                            ValidationGroup="CategorySave">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
                
            <td>
                &nbsp;
                <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
            </td>
            <td>
                &nbsp;
                    
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            SkinID="Button1" />
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
