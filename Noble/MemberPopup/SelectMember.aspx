<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SelectMember.aspx.cs" Inherits="Noble.MemberPopup.SelectMember" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
    <div style="width: 100%">
        <asp:RadioButtonList ID="RbtnSearchOptions" AutoPostBack="true" RepeatDirection="Horizontal"
            CellSpacing="10" runat="server" OnSelectedIndexChanged="RbtnSearchOptions_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="list">Member</asp:ListItem>
            <asp:ListItem Value="all">Quotation</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <div>
        <table width="100%">
            <tr>
                <td>
                    <telerik:RadGrid ID="radgvMembers" Visible="true" runat="server" Width="100%" AutoGenerateColumns="False"
                        ShowStatusBar="true" AllowPaging="true" AllowFilteringByColumn="true" PageSize="20"
                        Skin="WebBlue" OnItemCreated="radgvMembers_ItemCreated" OnInit="radgvMembers_Init"
                        OnNeedDataSource="radgvMembers_NeedDataSource">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NextPrevAndNumeric" />
                        <ClientSettings EnableRowHoverStyle="true">
                            <Scrolling UseStaticHeaders="True" ScrollHeight="" SaveScrollPosition="False"></Scrolling>
                            <Selecting AllowRowSelect="True" />
                            <ClientEvents OnRowClick="MemberSelected" />
                        </ClientSettings>
                        <MasterTableView DataKeyNames="Member_ID" ClientDataKeyNames="Member_ID,First_name,Last_name">
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="Firstname" HeaderText="Firstname" DataField="First_name"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Lastname" HeaderText="Lastname" DataField="Last_name"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Phone" HeaderText="Phone" DataField="Phone"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="JobKeyWords" HeaderText="House Address" DataField="JobKeyWords"
                                    FilterControlWidth="200px">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <telerik:RadGrid ID="gvQuot" runat="server" AllowPaging="True" AllowSorting="True"
                        Visible="false" AutoGenerateColumns="False" ShowStatusBar="true" OnNeedDataSource="gvQuot_NeedDataSource"
                        OnInit="gvQuot_Init" Skin="WebBlue" OnItemCommand="gvQuot_ItemCommand" PageSize="20"
                        AllowFilteringByColumn="true">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                        <ClientSettings EnableRowHoverStyle="true">
                            <Scrolling UseStaticHeaders="True" ScrollHeight="" SaveScrollPosition="False"></Scrolling>
                            <Selecting AllowRowSelect="True" />
                            <ClientEvents OnRowClick="QuotationSelected" />
                        </ClientSettings>
                        <MasterTableView Width="100%" DataKeyNames="QuotNo" ClientDataKeyNames="QuotNo,Firstname,Lastname">
                            
                            <Columns>
                                <%-- <telerik:GridEditCommandColumn UniqueName="EditCommandColumn">
                </telerik:GridEditCommandColumn>--%>
                                <telerik:GridBoundColumn UniqueName="QuotNo" HeaderText="QuotNo" DataField="QuotNo">
                                    <HeaderStyle Width="60px"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Date" HeaderText="Date" DataField="Date">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Valid Untill" HeaderText="Valid Untill" DataField="Validtill">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Title" HeaderText="Title" DataField="title"
                                    DataFormatString="{0:d}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Firstname" HeaderText="First Name" DataField="Firstname">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Lastname" HeaderText="Lastname" DataField="Lastname">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Address" HeaderText="Address" DataField="Address">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="HST" HeaderText="HST" DataField="HST">
                                </telerik:GridBoundColumn>
                                
                                
                            </Columns>
                         
                        </MasterTableView>
                        
                    </telerik:RadGrid>
                    
                    <%-- <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="radgvMembers" >
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="radgvMembers" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>--%>
                    <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="radgvMembers">
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="RadComboBoxCity">
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table width="100%">
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
<%--<script type="text/javascript">
    function MyRowMouseOver(sender, eventArgs) {
        $get(eventArgs.get_id()).className += " MyRowMouseOver";
    }

    function MyRowMouseOut(sender, eventArgs) {
        var row = $get(eventArgs.get_id());
        row.className = row.className.replace("MyRowMouseOver", "MyRowMouseOut");
    }
</script>--%>
<script type="text/javascript">


    var selected_member = "";
    var selected_Quotation = "";
    var oWnd = GetRadWindow();

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)

        return oWindow;
    }


    function MemberSelected(sender, eventArgs) {


        var DataItem = $find("<%=radgvMembers.ClientID %>").get_masterTableView().get_dataItems()[eventArgs.get_itemIndexHierarchical()];
        selected_member = DataItem.getDataKeyValue("Member_ID") + ";" + DataItem.getDataKeyValue("First_name") + ";" + DataItem.getDataKeyValue("Last_name") + ";";
        oWnd.BrowserWindow.document.forms[0].selected_member.value = selected_member;
        oWnd.BrowserWindow.document.forms[0].submit();
        oWnd.Close();
    }

    function QuotationSelected(sender, eventArgs) {


        var DataItem = $find("<%=gvQuot.ClientID %>").get_masterTableView().get_dataItems()[eventArgs.get_itemIndexHierarchical()];
        selected_Quotation = DataItem.getDataKeyValue("QuotNo") + ";" + DataItem.getDataKeyValue("Firstname") + ";" + DataItem.getDataKeyValue("Lastname") + ";";
        oWnd.BrowserWindow.document.forms[0].selected_Quotation.value = selected_Quotation;
        oWnd.BrowserWindow.document.forms[0].submit();
        oWnd.Close();
    }






</script>
</html>
