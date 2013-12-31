<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddQuotationDetails.ascx.cs"
    Inherits="Noble.Quotation.AddQuotationDetails" %>
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
<div style="border: 1px; border-color: Gray; height: 150px;">
    <table style="" cellpadding="2px" cellspacing="2px" class="dataTable2" width="300px">
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
                <%-- <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>--%>
                <asp:DropDownList ID="ddlProd1" CssClass="frmBox" runat="server" TabIndex="7" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlProd1_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="lblProd1code" runat="server" Text="0" Visible="false"></asp:Label>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
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
        <tr style="padding: 20px 30px 0 50px;">
            <td align="right">
                <asp:Button ID="btnInsert" Text="Insert" runat="server" CssClass="frmButton" CommandName="PerformInsert"
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
