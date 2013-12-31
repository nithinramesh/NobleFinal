<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployerFileAssign.aspx.cs"
    MasterPageFile="~/Site.Master" EnableEventValidation="false" ClientIDMode="AutoID"
    Inherits="Noble.EmployerFiles.EmployerFileAssign" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr align="left">
                <td style="width: 10%" align="left">
                    <asp:Label ID="lblEmployer" runat="server" Text="Employer: "></asp:Label>
                </td>
                <td align="left">
                    <telerik:RadComboBox ID="ddlEmployers" runat="server" OnSelectedIndexChanged="ddlEmployers_SelectedIndexChanged"
                        AutoPostBack="true" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr align="left">
                <td colspan="2">
                    <br />
                    <table width="100%" id="tblGrid" runat="server">
                        <tr>
                            <td>
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
                                            <telerik:GridButtonColumn CommandName="Select" HeaderText="View" Text="Select" UniqueName="SelectColumn"
                                                ButtonType="ImageButton" ImageUrl="~/images/FileUpload/OneNote.png">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridTemplateColumn HeaderText="Status">
                                                <ItemTemplate>
                                                    <telerik:RadComboBox ID="ddlEmployerFileStaus" runat="server" Skin="WebBlue">
                                                    </telerik:RadComboBox>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="Assigned">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAssigned" Text="" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <%-- <telerik:RadAjaxManager runat="server" ID="RadAjaxManager2">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="radgvFiles">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="radgvFiles" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="btnSubmit">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="ddlEmployers">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="tblGrid" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>--%>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
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
                <td align="right" style="padding-right: 50px;">
                    <asp:Button ID="btnSubmit" class="frmButton" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
