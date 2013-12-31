<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageMember.aspx.cs" Inherits="Noble.ManageMember" EnableEventValidation="false" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" id="tblGrid" runat="server">
        <tr >
            <td >
                <telerik:RadGrid ID="gvMember" runat="server" Width="100%" AutoGenerateColumns="False"
                    ShowStatusBar="true" AllowPaging="true" PageSize="10" AllowFilteringByColumn="true"
                    OnItemCommand="gvMember_ItemCommand" Skin="WebBlue" OnNeedDataSource="gvMember_NeedDataSource"
                    OnUpdateCommand="gvMember_UpdateCommand" 
                    OnInsertCommand="gvMember_InsertCommand"
                    OnDeleteCommand="gvMember_DeleteCommand"
                    OnItemDataBound="gvMember_ItemBound" 
                    OnInit="gvMember_Init" OnPreRender="gvMember_PreRender">
                    <GroupingSettings CaseSensitive="false" />
                    <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                    <MasterTableView EditMode="EditForms" CommandItemDisplay="Top" DataKeyNames="ID" AutoGenerateColumns="false">
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="Firstname" HeaderText="Firstname" DataField="Firstname"
                                ItemStyle-Width="11%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Lastname" HeaderText="Lastname" DataField="Lastname"
                                ItemStyle-Width="11%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="AlarmAccountNo" HeaderText="AlarmAccountNo" DataField="AlarmAccountNo"
                                ItemStyle-Width="3%"  FilterControlWidth="30px">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn UniqueName="PreviousAccountNo" HeaderText="PreviousAccountNo" DataField="PreviousAccountNo"
                                ItemStyle-Width="7%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="HousePhone" HeaderText="HousePhone" DataField="HousePhone" 
                                ItemStyle-Width="9%">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CellPhone" Visible="False"  HeaderText="CellPhone" DataField="CellPhone"
                                ItemStyle-Width="3%" FilterControlWidth="40px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BusinessPhone" Visible="False" HeaderText="BusinessPhone" DataField="BusinessPhone"
                                ItemStyle-Width="3%" FilterControlWidth="40px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="CompanyName" HeaderText="CompanyName" DataField="CompanyName"
                                ItemStyle-Width="3%" FilterControlWidth="40px">
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="BusinessAddress" HeaderText="BusinessAddress" DataField="BusinessAddress"
                                ItemStyle-Width="3%" FilterControlWidth="40px">
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn UniqueName="CompanyName" ItemStyle-Width="14%" FilterControlWidth="100px"  HeaderText="CompanyName" DataField="CompanyName">
                                <FilterTemplate>
                                    <telerik:RadComboBox ID="RadComboBoxCountry" AppendDataBoundItems="true" SelectedValue='<%# ((GridItem)Container).OwnerTableView.GetColumn("Country").CurrentFilterValue %>'
                                        runat="server" OnClientSelectedIndexChanged="CountryIndexChanged">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="All" />
                                        </Items>
                                    </telerik:RadComboBox>
                                    <telerik:RadScriptBlock ID="RadScriptBlockCountryName" runat="server">
                                        <script type="text/javascript">
                                            function CountryIndexChanged(sender, args) {
                                                var tableView = $find("<%# ((GridItem)Container).OwnerTableView.ClientID %>");
                                                tableView.filter("Country", args.get_item().get_value(), "EqualTo");
                                            }
                                        </script>
                                    </telerik:RadScriptBlock>
                                </FilterTemplate>
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridButtonColumn CommandName="Edit" HeaderText="Edit" UniqueName="EditColumn"
                                ButtonType="ImageButton" ImageUrl="~/Images/edit-button.png" ItemStyle-Width="5%">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn CommandName="Delete" HeaderText="Delete" UniqueName="DeleteColumn"
                                ButtonType="ImageButton" ImageUrl="~/Images/delete-button.png" ItemStyle-Width="5%">
                            </telerik:GridButtonColumn>
                        </Columns>
                         <EditFormSettings UserControlName="MemberCS.ascx" EditFormType="WebUserControl">
                        <EditColumn UniqueName="EditCommandColumn1">
                        </EditColumn>
                </EditFormSettings>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
        <tr>
            <td>
            </td>
           
        </tr>
    </table>
   <%-- <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gvMember">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvMember" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddMember">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                    <telerik:AjaxUpdatedControl ControlID="tblAdd" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                    <telerik:AjaxUpdatedControl ControlID="tblAdd" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%-- <telerik:AjaxSetting AjaxControlID="btnShowAll">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gvMember" />
                    <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>--%>
    <table class="dataTable2" id="tblAdd" runat="server" visible="false" width="100%">
        <tr>
            <td>
                Title
            </td>
            <td>
                <asp:DropDownList ID="ddlTitle" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfTitle" runat="server" ControlToValidate="ddlTitle"
                    CssClass="failureNotification" ErrorMessage="Title is required." ToolTip="Title is required."
                    ValidationGroup="MemberSave" InitialValue="-1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                First Name
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="100" SkinID="TextBox1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfFN" runat="server" ControlToValidate="txtFirstName"
                    CssClass="failureNotification" ErrorMessage="First Name is required." ToolTip="First Name is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Middle Name
            </td>
            <td>
                <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="100" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Last Name
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="100" SkinID="TextBox1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfLN" runat="server" ControlToValidate="txtLastName"
                    CssClass="failureNotification" ErrorMessage="Last Name is required." ToolTip="Last Name is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" SkinID="TextBox1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfEMAIL" runat="server" ControlToValidate="txtEmail"
                    CssClass="failureNotification" ErrorMessage="Email is required." ToolTip="Email is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ValidationGroup="MemberSave"
                    CssClass="failureNotification"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Address 1
            </td>
            <td>
                <asp:TextBox ID="txtAddress1" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Address 2
            </td>
            <td>
                <asp:TextBox ID="txtAddress2" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                City
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Province
            </td>
            <td>
                <asp:TextBox ID="txtProvince" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Postal Code
            </td>
            <td>
                <asp:TextBox ID="txtPostalCode" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Phone
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" MaxLength="20" SkinID="TextBox1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhone"
                    CssClass="failureNotification" ErrorMessage="Phone No is required." ToolTip="Phone No is required."
                    ValidationGroup="MemberSave">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="mNoValidator" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage="Phone No must be Numerals" ValidationExpression="\d+" ValidationGroup="MemberSave"
                    CssClass="failureNotification">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                Home Phone
            </td>
            <td>
                <asp:TextBox ID="txtHomePhone" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Work Phone
            </td>
            <td>
                <asp:TextBox ID="txtWorkPhone" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Frame
            </td>
            <td>
                <asp:TextBox ID="txtJobTitle" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td>
                Position Looking
            </td>
            <td>
                <asp:TextBox ID="txtPosition" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td>
                Country(Residence)
            </td>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server">
                </asp:DropDownList>
                <%--<asp:RequiredFieldValidator ID="rfCountry" runat="server" ControlToValidate="ddlCountry"
                    CssClass="failureNotification" ErrorMessage="Country is required." ToolTip="Country is required."
                    ValidationGroup="MemberSave" InitialValue="-1">*</asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr style="display:none">
            <td>
                Country(Origin)
            </td>
            <td>
                <asp:DropDownList ID="ddlOriginCountry" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="display:none">
            <td>
                Experience
            </td>
            <td>
                <asp:DropDownList ID="ddlExperience" runat="server">
                </asp:DropDownList><%--
                <asp:RequiredFieldValidator ID="rfExperience" runat="server" ControlToValidate="ddlExperience"
                    CssClass="failureNotification" ErrorMessage="Experience is required." ToolTip="Experience is required."
                    ValidationGroup="MemberSave" InitialValue="-1">*</asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                Gender
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfGender" runat="server" ControlToValidate="ddlGender"
                    CssClass="failureNotification" ErrorMessage="Gender is required." ToolTip="Gender is required."
                    ValidationGroup="MemberSave" InitialValue="-1">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr style="display:none">
            <td valign="top">
                Job Category(s)
            </td>
            <td>
                <asp:CheckBoxList ID="cblJobCategory" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                </asp:CheckBoxList><%--
                <asp:CustomValidator ID="cbJob" runat="server" ErrorMessage="Job category is required"
                    ToolTip="Job category is required" ClientValidationFunction="CheckBoxListValidator"
                    ValidationGroup="MemberSave" CssClass="failureNotification">*</asp:CustomValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                Other
            </td>
            <td>
                <asp:TextBox ID="txtOther" runat="server" SkinID="TextBox1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;
                
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                    SkinID="Button1" />
            </td>
        </tr>
    </table>
    <%-- <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
   function CheckBoxListValidator(source, arguments) {
    var Control;
    Control = document.getElementById("<%=cblJobCategory.ClientID %>").getElementsByTagName("input");
    var check = false;
    if (eval(Control)) {
        for (var i = 0; i < Control.length; i++) {
            if (Control[i].tagName == 'INPUT') {

                if (Control[i].checked) {
                    check = true;
                }
            }
        }
        if (!check)
            arguments.IsValid = false;
        else
            arguments.IsValid = true;
    }
}

function category(sender, args) {
    alert('hi');
    var result = false;
    var rcbCategory = $find("<%=cblJobCategory.ClientID %>");
    var rcbCategoryIndex = rcbCategory.get_selectedIndex();

    if (rcbCategoryIndex > 0)
        result = true;

    args.IsValid = result;
}

    </telerik:RadScriptBlock>--%>
   
</asp:Content>
