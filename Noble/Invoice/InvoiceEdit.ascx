<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InvoiceEdit.ascx.cs"
    Inherits="Noble.Invoice.InvoiceEdit" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
  <script type="text/javascript">
      var popUp;
      function PopUpShowing(sender, eventArgs) {
          popUp = eventArgs.get_popUp();
          var gridWidth = sender.get_element().offsetWidth;
          var gridHeight = sender.get_element().offsetHeight;
          var popUpWidth = popUp.style.width.substr(0, popUp.style.width.indexOf("px"));
          var popUpHeight = popUp.style.height.substr(0, popUp.style.height.indexOf("px"));
          popUp.style.left = 500 + "px";
          popUp.style.top = 300 + "px";
      } 
  </script>
</telerik:RadCodeBlock>
<table id="Table2" cellspacing="2" cellpadding="1" width="100%" border="1" class="dataTable2"
    rules="none" style="border-collapse: collapse; padding-bottom: 20px; background-color: #DAE2E8;">
    <tr class="EditFormHeader" height="30px">
        <td width="50px;">
        </td>
        <td colspan="2" valign="middle">
            <b>Invoice Form</b>
        </td>
    </tr>
    <tr>
        <td width="50px;">
        </td>
        <td>
            <table id="Table3" cellspacing="1" cellpadding="1" width="100%" border="0">
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInvNo" runat="server" ReadOnly="true" Visible="false" Text='<%# DataBinder.Eval( Container, "DataItem.InvNo"  ) %>'>
                        </asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        Date:
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdDate" runat="server" MinDate="1/1/1900" DbSelectedDate='<%# DataBinder.Eval( Container, "DataItem.Date") %>'
                            TabIndex="1">
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="rDate" runat="server" ControlToValidate="rdDate"
                            CssClass="failureNotification" ErrorMessage="Date is required." ToolTip="Date is required.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Due Date:
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdValidDate" runat="server" MinDate="1/1/1900" DbSelectedDate='<%# DataBinder.Eval( Container, "DataItem.DueDate") %>'
                            TabIndex="2">
                        </telerik:RadDatePicker>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rdValidDate"
                            CssClass="failureNotification" ErrorMessage="Valid till date is required." ToolTip="Valid till date is required.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Title
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTitle" CssClass="frmBox" runat="server" TabIndex="3">
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
                        <asp:TextBox ID="txtFirstname" CssClass="frmBox" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Firstname") %>'
                            TabIndex="4">
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
                        <asp:TextBox ID="txtLastname" CssClass="frmBox" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Lastname") %>'
                            TabIndex="5">
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
                        <asp:TextBox ID="txtAddress" CssClass="frmBox" TextMode="MultiLine" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.Address") %>'
                            TabIndex="6">
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
                        <asp:TextBox ID="txtHST" CssClass="frmBox" runat="server" Text='<%# DataBinder.Eval( Container, "DataItem.HST") %>'
                            TabIndex="7">
                        </asp:TextBox>
                        <asp:RangeValidator ID="rdCost" runat="server" ErrorMessage="HST must be numeric."
                                    Text="HST must be numeric." ControlToValidate="txtHST" MinimumValue="0" MaximumValue="1000"
                                    Type="Currency" />
                    </td>
                </tr>
                <tr height="20px;">
                    <td colspan="3">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table style="background-color: #DAE2E8;padding-left:100px!important;padding-top:10px;width:100%">
    <tr>
        <td>
        </td>
        <td>
            <b>Add Product Details</b><br />
            <telerik:RadGrid ID="gvInvDetails" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" ShowStatusBar="true" OnNeedDataSource="gvInvDetails_NeedDataSource"
                Skin="WebBlue" OnDeleteCommand="gvInvDetails_DeleteCommand" BackColor="#DAE2E8">
                <MasterTableView Width="700px" EditMode="PopUp" CommandItemDisplay="Top" DataKeyNames="ID">
                    <EditFormSettings>
                        <PopUpSettings Width="600px" Height="300px" Modal="true" />
                    </EditFormSettings>
                    <Columns>
                        <telerik:GridBoundColumn UniqueName="ID" HeaderText="ID" DataField="ID" ItemStyle-Width="3%"
                            FilterControlWidth="30px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Code" HeaderText="Code" DataField="Code" ItemStyle-Width="11%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="ProductName" HeaderText="Product" DataField="ProductName"
                            ItemStyle-Width="3%" FilterControlWidth="30px">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Price" HeaderText="Price" DataField="Price"
                            ItemStyle-Width="11%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Qty" HeaderText="Qty" DataField="Qty" ItemStyle-Width="9%">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="Total" HeaderText="Total" DataField="Total"
                            ItemStyle-Width="9%">
                        </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn UniqueName="DeleteColumn" ConfirmText="Do you want to Delete ?"
                            ConfirmDialogType="RadWindow" Text="Delete" CommandName="Delete" ButtonType="ImageButton"
                            ImageUrl="~/Images/delete-button.png">
                        </telerik:GridButtonColumn>
                    </Columns>
                    <EditFormSettings UserControlName="AddProducts.ascx" EditFormType="WebUserControl" 
                        CaptionFormatString="Add Products">
                       
                    </EditFormSettings>
                </MasterTableView>
                <ClientSettings>
                    <ClientEvents OnRowDblClick="RowDblClick"></ClientEvents>
                    <ClientEvents OnPopUpShowing="PopUpShowing" />
                </ClientSettings>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
<asp:Label ID="lblError" runat="server" Text="test" ForeColor="Red" Visible="false"></asp:Label>
<table style="padding-top: 30px; background-color: #fff;" width="100%" class="dataTable2">
    <tr>
        <td align="center" colspan="2">
            <asp:Button ID="btnUpdate" Text="Update" runat="server" CssClass="frmButton"
                CommandName="Update" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>'
                OnClick="btnUpdate_Click"></asp:Button>
            <asp:Button ID="btnInsert" Text="Insert" CssClass="frmButton" runat="server"
                CommandName="PerformInsert" Visible='<%# DataItem is Telerik.Web.UI.GridInsertionObject %>'
                OnClick="btnInsert_Click"></asp:Button>
            &nbsp;
            <asp:Button ID="btnCancel" Text="Cancel" runat="server" CssClass="frmButton"
                CausesValidation="False" CommandName="Cancel" OnClick="btnCancel_Click"></asp:Button>
        </td>
    </tr>
</table>
