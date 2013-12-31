<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCategoryCS.ascx.cs" Inherits="Noble.ProductCategory.ProductCategoryCS" %>
<div class="contentContainer">
<table width="50%">
    <tr>
        <td>
            <br/>
        </td>
    </tr>
    <tr>
        <td>Product Category
        </td>
        <td>
            <asp:TextBox runat="Server" CssClass="frmBox" Width="90%" ID="btnProductCategoryName" Text='<%# DataBinder.Eval(Container, "DataItem.ProductCategory_name") %>' ></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfPCat" runat="server" ControlToValidate="btnProductCategoryName"
                    CssClass="failureNotification" ErrorMessage="Product Category is required."
                   >Product Category is required</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="right">
            <asp:Button ID="btnUpdate" CssClass="frmButton" Text="Update" runat="server" CommandName="Update" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>'></asp:Button>
            <asp:Button ID="btnInsert" CssClass="frmButton" Text="Insert" runat="server" CommandName="PerformInsert" Visible='<%# (DataItem is Telerik.Web.UI.GridInsertionObject) %>'></asp:Button>
       
            <asp:Button ID="btnCancel" CssClass="frmButton" runat="server" Text = "Cancel" CommandName="Cancel" 
                        onclick="btnCancel_Click" />
        </td>
    </tr>
</table>
</div>