<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCS.ascx.cs" Inherits="Noble.ProductCategory.ProductCS" %>
<style>
    .tableStyle {

        padding-left: 15px;
        width: 115px;
    }
</style>
<br/>
<br/>
<div class="contentContainer" width="100%" >
<table>
    <tr>
        <td class="tableStyle">
            Product Code
        </td>
        <td  >
            <asp:TextBox runat="server" CssClass="frmBox" ID="txtProductCode" Text='<%# DataBinder.Eval(Container, "DataItem.ProductCode") %>' ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFProductCode" runat="server" ControlToValidate="txtProductCode"
                    CssClass="failureNotification" ErrorMessage="Product Code is required."
                   >Product Code is required</asp:RequiredFieldValidator>
        </td>
        <td class="tableStyle">
            Product Description
        </td>
        <td  >
            <asp:TextBox runat="server" CssClass="frmBox" ID="txtProductDescription" Text='<%# DataBinder.Eval(Container, "DataItem.ProductDescription") %>' ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFValidatorName" runat="server" ControlToValidate="txtProductDescription"
                    CssClass="failureNotification" ErrorMessage="Product Description is required."
                   >Product Description is required</asp:RequiredFieldValidator>    
        </td>
        <td class="tableStyle">
            Product Price
        </td>
        <td  >
            <asp:TextBox runat="server" CssClass="frmBox" ID="txtProductPrice" Text='<%# DataBinder.Eval(Container, "DataItem.ProductPrice") %>' ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFValidatorPrice" runat="server" ControlToValidate="txtProductPrice"
                    CssClass="failureNotification" ErrorMessage="Product Price is required."
                   >Product Price is required</asp:RequiredFieldValidator>
        </td>
        <td>
            <br/>
     
        </td>
    </tr>
    <tr>
        <td colspan=6 align="right">
            <br/>
            <asp:Button runat="server" CssClass="frmButton"  ID="btnUpdate" CommandName="Update" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' Text="Update"  />
            <asp:Button runat="server" CssClass="frmButton"  ID="btnInsert" CommandName="PerformInsert" Visible='<%# (DataItem is Telerik.Web.UI.GridInsertionObject) %>' Text="Insert"  />
            <asp:Button runat="server" CssClass="frmButton" ID="btnCancel" CommandName="Cancel" Text="Cancel" 
                        onclick="btnCancel_Click"  />
        </td>
    </tr>
</table>
