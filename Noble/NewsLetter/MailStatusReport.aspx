<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MailStatusReport.aspx.cs"
    Inherits="Noble.NewsLetter.MailStatusReport" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
        <p style="padding-bottom: 10px;">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="false" Font-Bold="true"
                Text="NewsLetters has been sending internally. please visit the report page after some time to see the stauts."></asp:Label></p>
        <telerik:RadGrid ID="radgvMailStatus" runat="server" Width="100%" AutoGenerateColumns="False"
            ShowStatusBar="true" AllowPaging="true" PageSize="10" Skin="WebBlue" OnItemCommand="radgvMailStatus_ItemCommand">
            <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn UniqueName="TemplateName" HeaderText="TemplateName" DataField="TemplateName"
                        FilterControlWidth="100px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="SuccessCount" HeaderText="SuccessCount" DataField="SuccessCount">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="FailedCount" HeaderText="FailedCount" DataField="FailedCount">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="StartDate" HeaderText="StartDate" DataField="StartDate">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="EndDate" HeaderText="EndDate" DataField="EndDate">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="radgvMailStatus">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="radgvMailStatus" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
    </div>
</asp:Content>
