<%@ Page Title="" Language="C#" AutoEventWireup="True" MasterPageFile="~/Site.Master"
         EnableEventValidation="false" ClientIDMode="AutoID" CodeBehind="LandingPage.aspx.cs"
         Inherits="Noble.LandingPage" %>
<%--<%@ Register Src="~/MemberPopup/MemberPopup.ascx" TagName="memberPopup" TagPrefix="ABR" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="SelectMemberContent" runat="server">
    <ABR:memberPopup runat="server" ID="MemberPopupfile" />
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--  <asp:Panel ID="pnlMemberDetails" runat="server">--%>
    <div class="content">
        <div class="contentContainer">
            <span class="txtAdj">Personal Details</span>
            <div class="tableContainer">
                <table class="dataTable2" id="tblAdd" runat="server" visible="true">
                    <tr>
                        <td colspan="4">
                            <b>Personal Details</b>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 25%">
                            Title:
                        </td>
                        <td style="width: 25%">
                            <asp:Label ID="lblTitle" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px; widh: 25%;">
                            Address1:
                        </td>
                        <td style="width: 25%">
                            <asp:Label ID="lblAddressLine1" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            First name:
                        </td>
                        <td>
                            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px;">
                            Address2:
                        </td>
                        <td>
                            <asp:Label ID="lblAddressLine2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Middle name:
                        </td>
                        <td>
                            <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px;">
                            City:
                        </td>
                        <td>
                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last name:
                        </td>
                        <td>
                            <asp:Label ID="lblLastName" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px;">
                            Province:
                        </td>
                        <td>
                            <asp:Label ID="lblProvince" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email:
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px;">
                            Postal Code:
                        </td>
                        <td>
                            <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone:
                        </td>
                        <td>
                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px;">
                            Home Phone:
                        </td>
                        <td>
                            <asp:Label ID="lblHomePhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Work Phone:
                        </td>
                        <td>
                            <asp:Label ID="lblWorkPhone" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px;">
                            Frame:
                        </td>
                        <td>
                            <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td>
                            Country:
                        </td>
                        <td>
                            <asp:Label ID="lblCountry" runat="server"></asp:Label>
                        </td>
                        <td>
                            Experience:
                        </td>
                        <td>
                            <asp:Label ID="lblExperience" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Gender:
                        </td>
                        <td>
                            <asp:Label ID="lblGender" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px;">
                            Other:
                        </td>
                        <td>
                            <asp:Label ID="lblOther" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td valign="top">
                            Job Category(s):
                        </td>
                        <td>
                            <asp:Label ID="lblJobCategory" runat="server"></asp:Label>
                        </td>
                        <td valign="top" style="padding-left: 50px;">
                            Position Looking:
                        </td>
                        <td>
                            <asp:Label ID="lblPosition" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <br />
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <b>Notes</b>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadGrid ID="gvNotes" runat="server" Width="100%" AutoGenerateColumns="False"
                                             ShowStatusBar="true" AllowPaging="true" Skin="WebBlue" PageSize="10" OnItemCommand="gvNotes_ItemCommand">
                                <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                                <MasterTableView DataKeyNames="ID,Status_code" AutoGenerateColumns="false" NoMasterRecordsText="No data available.">
                                    <Columns>
                                        <telerik:GridBoundColumn UniqueName="Notes" HeaderText="Notes" DataField="Note_text"
                                                                 ItemStyle-Width="35%">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Status" HeaderText="Status" DataField="Status_text"
                                                                 ItemStyle-Width="15%">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Assigned_To" HeaderText="Assigned_To" DataField="Assigned_toName"
                                                                 ItemStyle-Width="15%">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Updated_On" HeaderText="Updated_On" DataField="Updated_On"
                                                                 ItemStyle-Width="15%">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td>
                            <b>Files</b>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadGrid ID="radgvFiles" runat="server" Width="100%" AutoGenerateColumns="False"
                                             ShowStatusBar="true" AllowPaging="true" PageSize="10" Skin="WebBlue" OnDataBound="radgvFiles_DataBound"
                                             OnItemCommand="radgvFiles_ItemCommand">
                                <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                                <MasterTableView DataKeyNames="File_ID,File_Path,File_Name,File_Type">
                                    <Columns>
                                        <telerik:GridBoundColumn UniqueName="Member" HeaderText="Member" DataField="Member_Name"
                                                                 FilterControlWidth="100px">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="File_Name" HeaderText="File_Name" DataField="File_Name">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="File_Type" HeaderText="File_Type" DataField="File_Type">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="File_Category" HeaderText="File_Category" DataField="File_Category">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="CreatedAdmin" HeaderText="CreatedAdmin" DataField="CreatedAdmin">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Created_on" HeaderText="Created_on" DataField="Created_on">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn HeaderText="View" CommandName="Select" Text="Select" UniqueName="SelectColumn"
                                                                  ButtonType="ImageButton" ImageUrl="~/images/FileUpload/OneNote.png">
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                            <%-- <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="radgvFiles">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="radgvFiles" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>--%>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%--  </asp:Panel>--%>
    
</asp:Content>