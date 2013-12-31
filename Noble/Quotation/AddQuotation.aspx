<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddQuotation.aspx.cs" Inherits="Noble.Quotation.AddQuotation" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="Table2" cellspacing="2" cellpadding="1" width="100%" border="1" rules="none"
        style="border-collapse: collapse">
        <tr class="EditFormHeader">
            <td colspan="2">
                <b>Quotation Form</b>
            </td>
        </tr>
        <tr>
            <td>
                <table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="0">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Date:
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtDate" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Date"  ) %>'>
                        </asp:TextBox>--%>
                            <telerik:RadDatePicker ID="rdDate" runat="server" MinDate="1/1/1900" DbSelectedDate='<%# DataBinder.Eval( Container, "DataItem.Date") %>'
                                TabIndex="4">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Valid Untill:
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtValidDate" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.validtill"  ) %>'>
                        </asp:TextBox>--%>
                            <telerik:RadDatePicker ID="rdValidDate" runat="server" MinDate="1/1/1900" DbSelectedDate='<%# DataBinder.Eval( Container, "DataItem.Date") %>'
                                TabIndex="4">
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Title
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTitle" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfTitle" runat="server" ControlToValidate="ddlTitle"
                                CssClass="failureNotification" ErrorMessage="Title is required." ToolTip="Title is required."
                                InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            First Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstname" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Firstname") %>'
                                TabIndex="1">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfFN" runat="server" ControlToValidate="txtFirstName"
                                CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last Name:
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastname" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Lastname") %>'
                                TabIndex="2">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfLN" runat="server" ControlToValidate="txtLastname"
                                CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address:
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Address") %>'
                                TabIndex="2">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfAdd" runat="server" ControlToValidate="txtAddress"
                                CssClass="failureNotification" ErrorMessage="Address is required." ToolTip="Address is required.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            HST:
                        </td>
                        <td>
                            <asp:TextBox ID="txtHST" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.HST") %>'
                                TabIndex="2">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
  
    <table style="margin-left: 50%">
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="btnUpdate" Text="Update" runat="server" CommandName="Update" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>'>
                </asp:Button>
                <asp:Button ID="btnInsert" Text="Insert" runat="server" CommandName="PerformInsert"
                    Visible='<%# DataItem is Telerik.Web.UI.GridInsertionObject %>' OnClick="btnInsert_Click">
                </asp:Button>
                &nbsp;
                <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False"
                    CommandName="Cancel"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
