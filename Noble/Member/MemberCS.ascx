<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberCS.ascx.cs" Inherits="Noble.Member.MemberCS" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2009.2.701.20, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<style type="text/css">


.failureNotification
{
    font-size: 1.2em;
    color: Red;
}</style>
<div class="contentContainer">
    <table>
        <tr align="center">
            <td colspan="4">
                <table align="center"  width="100%">
                    <tr align="center">
                        <td>
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please enter all the mandatory fields *"
                                ShowMessageBox="false" DisplayMode="BulletList" ShowSummary="true" ValidationGroup="MemberSave"
                                CssClass="failureNotification" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                Install Type
            </td>
            <td >
                
                <asp:TextBox Width="220" CssClass="frmBox"  runat="server" ID="txtInstallType" Text='<%# DataBinder.Eval(Container, "DataItem.Installtype") %>'></asp:TextBox>
            </td>
            <td>
                EmergencyContactName1
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgname1" Text='<%# DataBinder.Eval(Container, "DataItem.EmgContactName1") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                AlarmAccountNo
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtAlarmAccountNo" Text='<%# DataBinder.Eval(Container, "DataItem.AlarmAccountNo") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFAlarm" runat="server" ControlToValidate="txtAlarmAccountNo"
                    CssClass="failureNotification" ErrorMessage="Alarm Account Number is required."
                    ToolTip="Alarm Account Number is required." ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>   
            </td>
            <td>
                EmergencyPhoneNo1
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgPhone1" Text='<%# DataBinder.Eval(Container, "DataItem.EmgPhone1") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                PreviousAccountNo
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtPreviousAccountNo" Text='<%# DataBinder.Eval(Container, "DataItem.PreviousAccountNo") %>'></asp:TextBox>
            </td>
            <td>
                EmergencyCellNo1
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgcell1" Text='<%# DataBinder.Eval(Container, "DataItem.EmgCellNo1") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Date Of Install
            </td>
            <td>
                <telerik:RadDatePicker Width="220" CssClass="frmBox" runat="server" ID="Rddate" DbSelectedDate='<%# DataBinder.Eval(Container, "DataItem.DateOfInstall") %>'>
                </telerik:RadDatePicker>
                      <asp:RequiredFieldValidator ID="rfvDateOfInstall" runat="server" ControlToValidate="Rddate"
                    CssClass="failureNotification" ErrorMessage="Date Of Install is required." ToolTip="Date Of Install is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
            </td>
            <td>
                Password1
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtpass1" Text='<%# DataBinder.Eval(Container, "DataItem.password1") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                CancelationDate
            </td>
            <td>
                <telerik:RadDatePicker CssClass="frmBox" Width="220" runat="server" ID="RdCanceldate" DbSelectedDate='<%# DataBinder.Eval(Container, "DataItem.CancelationDate") %>'>
                </telerik:RadDatePicker>
                <asp:RequiredFieldValidator ID="rfvCancelationDate" runat="server" ControlToValidate="RdCanceldate"
                    CssClass="failureNotification" ErrorMessage="CancelationDate is required." ToolTip="CancelationDate is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
            </td>
            <td>
                EmergencyContactName2
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgname2" Text='<%# DataBinder.Eval(Container, "DataItem.EmgContactName2") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Installer Name
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtInstallerName" Text='<%# DataBinder.Eval(Container, "DataItem.InstallerName") %>'></asp:TextBox>
            </td>
            <td>
                EmergencyPhoneNo2
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgphone2" Text='<%# DataBinder.Eval(Container, "DataItem.EmgPhone2") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                FirstName
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtFirstName" Text='<%# DataBinder.Eval(Container, "DataItem.FirstName") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFFirstName" runat="server" ControlToValidate="txtFirstName"
                    CssClass="failureNotification" ErrorMessage="First Name is required."
                    ToolTip="FirstName is required." ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>    
            </td>
            <td>
                EmergencyCellNo2
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgcell2" Text='<%# DataBinder.Eval(Container, "DataItem.EmgCellNo2") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                LastName
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtLastName" Text='<%# DataBinder.Eval(Container, "DataItem.LastName") %>'></asp:TextBox>
            </td>
            <td>
                Password2
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtpass2" Text='<%# DataBinder.Eval(Container, "DataItem.password2") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                CompanyName
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtCompanyName" Text='<%# DataBinder.Eval(Container, "DataItem.LastName") %>'></asp:TextBox>
            </td>
            <td>
                SecurityLevel
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtsecurity" Text='<%# DataBinder.Eval(Container, "DataItem.SecurityLevel") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                HouseAddress
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtHouseAddress" Text='<%# DataBinder.Eval(Container, "DataItem.HouseAddress") %>'></asp:TextBox>
            </td>
            <td>
                MonthlyAlarmPayment
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtmonthlyPayment" Text='<%# DataBinder.Eval(Container, "DataItem.MonthlyAlamPayment") %>'></asp:TextBox>
                <asp:RegularExpressionValidator ID="revmonthly" runat="server" ValidationExpression="^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$"
                    ControlToValidate="txtmonthlyPayment" ErrorMessage="Invalid MonthlyAlarmPayment"
                    ToolTip="Invalid MonthlyAlarmPayment" ValidationGroup="MemberSave" CssClass="failureNotification">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvmonthlyPayment" runat="server" ControlToValidate="txtmonthlyPayment"
                    CssClass="failureNotification" ErrorMessage="MonthlyAlarmPayment is required."
                    ToolTip="Phone is required." ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                HouseCity
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtHouseCity" Text='<%# DataBinder.Eval(Container, "DataItem.HouseCity") %>'></asp:TextBox>
            </td>
            <td>
                Bank Name
            </td>
            <td>
                <telerik:RadComboBox ID="radcmbBankName"  runat="server" AutoPostBack="True" Width="220"
                    OnSelectedIndexChanged="radcmbBankName_SelectedIndexChanged1" 
                    >
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                HouseProvince
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtprovince" Text='<%# DataBinder.Eval(Container, "DataItem.HouseProvince") %>'></asp:TextBox>
            </td>
            <td>
                Bank Number
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" Enabled="False" runat="server" ID="txtbankno" Text='<%# DataBinder.Eval(Container, "DataItem.BankNo") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                HousePostelCode
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtPostelCode" Text='<%# DataBinder.Eval(Container, "DataItem.HousePostelCode") %>'></asp:TextBox>
            </td>
            <td>
                AccountNo
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtAccNo" Text='<%# DataBinder.Eval(Container, "DataItem.AccountNo") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                BusinessAddress
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtBusinessAddress" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessAddress") %>'></asp:TextBox>
            </td>
            <td>
                BankTransit
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtBankTransit" Text='<%# DataBinder.Eval(Container, "DataItem.BankTransit") %>'></asp:TextBox>
                <asp:RegularExpressionValidator ID="revBankTransit" runat="server" ValidationExpression="^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$"
                    ControlToValidate="txtBankTransit" ErrorMessage="Invalid BankTransit MonthlyAlarmPayment"
                    ToolTip="Invalid BankTransit MonthlyAlarmPayment" ValidationGroup="MemberSave" CssClass="failureNotification">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvBankTransit" runat="server" ControlToValidate="txtBankTransit"
                    CssClass="failureNotification" ErrorMessage="BankTransit is required." ToolTip="Phone is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Business City
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtBusinessCity" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessCity") %>'></asp:TextBox>
            </td>
            <td>
                BankAccountHolderName
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtAccHolderName" Text='<%# DataBinder.Eval(Container, "DataItem.BankAccountHoldername") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Business Province
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtBusinessProvince" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessProvince") %>'></asp:TextBox>
            </td>
            <td>
                AlarmPanelMakeModal
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtalarmpanel" Text='<%# DataBinder.Eval(Container, "DataItem.AlarmPanelMakeModel") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Business PostelCode
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtBPostelCode" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessPostelCode") %>'></asp:TextBox>
            </td>
            <td>
                Version
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtversion" Text='<%# DataBinder.Eval(Container, "DataItem.Version") %>'></asp:TextBox>
                <asp:RegularExpressionValidator ID="regexversion" runat="server" ValidationExpression="^[1-9]\d{0,2}(\.\d{3})*(,\d+)?$"
                    ControlToValidate="txtversion" ErrorMessage="Invalid Version" ToolTip="Invalid Version"
                    ValidationGroup="MemberSave" CssClass="failureNotification">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtversion"
                    CssClass="failureNotification" ErrorMessage="Version is required." ToolTip="Phone is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                House Phone
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtHousePhone" Text='<%# DataBinder.Eval(Container, "DataItem.HousePhone") %>'></asp:TextBox>
            </td>
            <td>
                SignalFormat
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtsignalformat" Text='<%# DataBinder.Eval(Container, "DataItem.signalFormat") %>'></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Cell Phone
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtcellphone" Text='<%# DataBinder.Eval(Container, "DataItem.CellPhone") %>'></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Business Phone
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtBusinessPhone" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessPhone") %>'></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                FAX
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtfax" Text='<%# DataBinder.Eval(Container, "DataItem.Fax") %>'></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                EmergencyContactName
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgname" Text='<%# DataBinder.Eval(Container, "DataItem.EmgContactName") %>'></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Emergency Phone No
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgPhone" Text='<%# DataBinder.Eval(Container, "DataItem.EmgPhone") %>'></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Emergency Cell No
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtemgcell" Text='<%# DataBinder.Eval(Container, "DataItem.EmgCellNo") %>'></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtpass" Text='<%# DataBinder.Eval(Container, "DataItem.password") %>'></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox Width="220" CssClass="frmBox" runat="server" ID="txtEmail" Text='<%# DataBinder.Eval(Container, "DataItem.Email") %>'></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" 
                CssClass="failureNotification" ErrorMessage="Valid email address required" ValidationGroup="MemberSave"  
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                 <asp:RequiredFieldValidator ID="RFValidator1" runat="server" ControlToValidate="txtEmail"
                    CssClass="failureNotification" ErrorMessage="Email is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>            
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Alarm Product
            </td>
            <td colspan="3">
                <asp:TextBox CssClass="frmBox" TextMode="MultiLine" Width="700px" runat="server" ID="txtAlarmProduct"
                    Text='<%# DataBinder.Eval(Container, "DataItem.AlarmProduct") %>' Height="59px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Note
            </td>
            <td colspan="3">
                <asp:TextBox CssClass="frmBox" TextMode="MultiLine" Width="700px" runat="server" ID="txtnote" Text='<%# DataBinder.Eval(Container, "DataItem.Note") %>'
                    Height="62px"></asp:TextBox>
            </td>
        </tr>
        `<tr>
            <td>
                Zones
            </td>
            <td colspan="3">
                <telerik:RadListBox ID="radlstZones" runat="server" SelectionMode="Multiple" CheckBoxes="True"
                    Height="250px" Width="300px">
                </telerik:RadListBox>
            </td>
        </tr>
        <tr>
            <td>
                Product Category
            </td>
            <td colspan="3">
                <br />
                <telerik:RadListBox runat="server" ID="radlstProductCategory" CheckBoxes="True" SelectionMode="Multiple"
                    Height="250px" Width="300px">
                </telerik:RadListBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <br />
                <asp:Button ID="btnUpdate" CssClass="frmButton" Text="Update" runat="server" CommandName="Update"
                    Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>'></asp:Button>
                <asp:Button ID="btnInsert" CausesValidation="true" CssClass="frmButton" Text="Insert"
                    ValidationGroup="MemberSave" runat="server" CommandName="PerformInsert" Visible='<%# (DataItem is Telerik.Web.UI.GridInsertionObject) %>'>
                </asp:Button>
                <asp:Button ID="btnCancel" CssClass="frmButton" runat="server" Text="Cancel" CommandName="Cancel"
                    OnClick="btnCancel_Click" />
                <br />
            </td>
            <td>
                
                <asp:Label ID="lblMessage" runat="server" class="failureNotification"></asp:Label>
                
            </td>
        </tr>
    </table>
</div>
