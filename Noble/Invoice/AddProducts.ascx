<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProducts.ascx.cs"
    Inherits="Noble.Invoice.AddProducts" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
<script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#<%=txtQty1.ClientID%>').bind("keyup", function () {
            var price = parseInt($('#<%=lblPrice1.ClientID%>').text());
            var qty = $('#<%=txtQty1.ClientID%>').val();
            var total = price * qty;
            $('#<%=lbltotal.ClientID%>').text(total);
        });
    });

</script>
<div style="border: 1px; border-color: Gray; height: 120px; width: 420px!important;">
    <table style="" cellpadding="2px" cellspacing="2px" class="dataTable2" width="420px">
        <tr>
            <td style="padding-left: 20px;">
                Product Category :
            </td>
            <td>
                <asp:DropDownList ID="ddlProductCat" CssClass="frmBox" runat="server" TabIndex="0"
                    AutoPostBack="True" OnSelectedIndexChanged="ddlProductCat_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px;">
                Product :
            </td>
            <td>
                <asp:DropDownList ID="ddlProd1" CssClass="frmBox" runat="server" TabIndex="1" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlProd1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfTitle" runat="server" ControlToValidate="ddlProd1"
                    CssClass="failureNotification" ErrorMessage="Product is required." ToolTip="Product is required."
                    InitialValue="-1">*</asp:RequiredFieldValidator>
                <asp:Label ID="lblProd1code" runat="server" Text="0" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px;">
                Unit Price:
            </td>
            <td>
                <asp:Label ID="lblPrice1" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px;">
                Quantity:
            </td>
            <td>
                <asp:TextBox ID="txtQty1" CssClass="frmBox" runat="server" Width="50px" TabIndex="2"
                    Text="0">
                </asp:TextBox>
                <asp:RangeValidator ID="rdCost" runat="server" ErrorMessage="Qty must be numeric."
                    Text="Qty must be numeric." ControlToValidate="txtQty1" MinimumValue="0" MaximumValue="1000"
                    Type="Integer" />
            </td>
        </tr>
        <tr>
            <td style="padding-left: 20px;">
                Total:
            </td>
            <td>
                <asp:Label ID="lbltotal" runat="server" Text="0"></asp:Label>
            </td>
        </tr>
        <tr style="padding: 10px 30px 0 50px;">
            <td align="right">
                <asp:Button ID="btnInsert" Text="Insert" runat="server" CssClass="frmButton" CommandName="Cancel"
                    Visible='<%# DataItem is Telerik.Web.UI.GridInsertionObject %>' OnClick="btnInsert_Click">
                </asp:Button>
            </td>
            <td colspan="2">
                <asp:Button ID="btnUpdate" Text="Update" runat="server" CssClass="frmButton" CommandName="Update"
                    Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>' OnClick="btnUpdate_Click">
                </asp:Button>&nbsp;
                <asp:Button ID="btnCancel" Text="Cancel" CssClass="frmButton" runat="server" CausesValidation="False"
                    CommandName="Cancel" OnClick="btnCancel_Click"></asp:Button>
            </td>
        </tr>
    </table>
</div>
