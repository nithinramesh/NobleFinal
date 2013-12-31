<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MemberPopup.ascx.cs"
    Inherits="Noble.MemberPopup.MemberPopup" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<meta http-equiv="X-UA-Compatible" content="IE=8" />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">


    <script type="text/javascript">
          //<![CDATA[

        function openRadWin() {
            // Handler for .ready() called.
            var oRadWindowManager = $find("<%= RadWindowManager1.ClientID %>");
            var oWnd = oRadWindowManager.GetWindowByName("RadWindow1");
            oWnd.SetUrl("../MemberPopup/SelectMember.aspx");
            oWnd.Show();
        };
    
    
          
    </script>

<link href="script-css/homestyle.css" rel="stylesheet" type="text/css" />
<link href="script-css/innerstyle.css" rel="stylesheet" type="text/css" />
<body>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Overlay="false" ReloadOnShow="false"
        Behavior="Close, Move" Modal="True" Skin="WebBlue" VisibleStatusbar="false">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Width="1050px" Height="680px" Title="Select Member"
                NavigateUrl="~/MemberPopup/SelectMember.aspx" Animation="Fade" />
        </Windows>
    </telerik:RadWindowManager>
    <table border="0" cellpadding="2px" cellspacing="2px" style="width:400px;">
    <tr>
    <td align="right">
        <asp:Label ID="lblSelectedMember" runat="Server">
  </asp:Label>
        </td>
        <td><asp:LinkButton
        ID="lbnSelectMember" SkinID="selectmember" Text="Select Member" runat="server"
        OnClientClick="openRadWin(); return false;"></asp:LinkButton>
        </td>
        </tr>
        </table>
    <%--   <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server"  Skin="WebBlue"  ShowContentDuringLoad="false" Width="700px"
                Height="660px" Title="Select Member"  NavigateUrl="~/MemberPopup/SelectMember.aspx" Behaviors="Default" Animation="Fade" >
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>--%>
    <input type="hidden" id="selected_member" name="selected_member" value="" />
      <input type="hidden" id="selected_Quotation" name="selected_Quotation" value="" />
</body>
</html>
