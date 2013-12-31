<%@ Page Title="" Language="C#" MasterPageFile="~/Employer.Master" AutoEventWireup="true"
    CodeBehind="EmpLandingPage.aspx.cs" Inherits="Noble.Employer.EmpLandingPage" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr align="left">
            <td>
                <br />
                <telerik:RadGrid ID="radgvFiles" runat="server" Width="100%" AutoGenerateColumns="False"
                    ShowStatusBar="true" AllowPaging="true" PageSize="10" Skin="WebBlue" AllowFilteringByColumn="true"
                    OnDataBound="radgvFiles_DataBound" OnNeedDataSource="radgvFiles_NeedDataSource"
                    OnInit="radgvFiles_Init" OnItemCommand="radgvFiles_ItemCommand">
                    <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                    <MasterTableView DataKeyNames="EmployerId,File_Path,File_Name,File_Type">
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="Member" HeaderText="Member" DataField="Member_Name"
                                FilterControlWidth="100px">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="FileName" HeaderText="FileName" DataField="File_Name">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="Status" HeaderText="Status" DataField="Status">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn CommandName="Select" HeaderText="View" Text="Select" UniqueName="SelectColumn"
                                ButtonType="ImageButton" ImageUrl="~/images/FileUpload/OneNote.png">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <%--<telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
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
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
