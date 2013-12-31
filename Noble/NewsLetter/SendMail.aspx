<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" ClientIDMode="AutoID"
    EnableEventValidation="false" Inherits="NewsLetter.SendMail" CodeBehind="SendMail.aspx.cs" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
          //<![CDATA[

    function openEmailRadWin() {
        // Handler for .ready() called.
        var oRadWindowManager = $find("<%= RadMgrSendLists.ClientID %>");
        var oWnd = oRadWindowManager.GetWindowByName("RadWindowSendLists");
        oWnd.SetUrl("RecepCategoriesPopup.aspx");
        oWnd.Show();
    };
    
    
          
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <telerik:RadWindowManager ID="RadMgrSendLists" runat="server" Overlay="false" ReloadOnShow="false"
        Behavior="Close, Move" Modal="True" Skin="WebBlue" VisibleStatusbar="false">
        <Windows>
            <telerik:RadWindow ID="RadWindowSendLists" runat="server" Width="600px" Height="450px"
                Title="Select Emails" NavigateUrl="RecepCategoriesPopup.aspx" Animation="Fade" />
        </Windows>
    </telerik:RadWindowManager>
    <div>
        <div>
            <table class="tableContainer">
                <tr>
                    <td>
                        <asp:Label ID="lblTemplateName" Text="Name" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTemplateNameValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSubject" Text="Subject" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblSubjectValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div style="width: 700px; height: 600px; overflow: scroll;">
                            <asp:Label ID="lblBodyValue" Style="width: 600px; height: 400px;" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFromAddress" Text="From Address" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblFromAddressValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDisplayName" Text="DisplayName" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDisplayNameValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblReplyAddress" Text="Reply Address" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblReplyAddressValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <%--<asp:UpdatePanel ID="UPmembermode" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:RadioButtonList ID="rbtnPrimaryOptions" AutoPostBack="true" RepeatLayout="Table"
                                    CellSpacing="10" runat="server" OnSelectedIndexChanged="rbtnPrimaryOptions_SelectedIndexChanged"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Members" Selected="True">Members</asp:ListItem>
                                    <asp:ListItem Value="Submissions">Submissions</asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:Panel runat="server" ID="pnlMembers">
                                    <asp:RadioButtonList ID="RbtnRecepOptions" AutoPostBack="true" RepeatLayout="Table"
                                        CellSpacing="10" runat="server" OnSelectedIndexChanged="RbtnRecepOptions_SelectedIndexChanged">
                                        <asp:ListItem Value="list">Select List of Members</asp:ListItem>
                                        <asp:ListItem Value="all">select All the Members</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <div id="divList" runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ListBox Width="200px" ID="lbxAvilableMembers" SelectionMode="Multiple" runat="server">
                                                    </asp:ListBox>
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Button CssClass="frmButton" runat="server" Text=">>" ID="btnMoveRight"
                                                                    OnClick="btnMoveRight_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button CssClass="frmButton" runat="server" Text="<<" ID="btnMoveleft" OnClick="btnMoveleft_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <asp:ListBox Width="200px" ID="lbxSelectedMembers" SelectionMode="Multiple" runat="server">
                                                    </asp:ListBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlSubmissions" runat="server" Visible="false">
                                    <table>
                                        <tr>
                                            <td>
                                                WebForms:
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlWebForms" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <div>
                                    <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RbtnRecepOptions" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>--%>
                          <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        <asp:Label ID="lblAtnlEmail" runat="server" Text="Additional Email"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdditionalEmail" CssClass="searchfrmBoxCol" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexAdditionalEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtAdditionalEmail" ErrorMessage="Invalid Email Format" ToolTip="Invalid Email Format"></asp:RegularExpressionValidator>
                    </td>
                </tr>
               --%> <tr>
                    <td>
                        <asp:Label ID="lblSendtoLists" runat="server" Text="Sent To Lists"></asp:Label>&nbsp;<asp:LinkButton
                            ID="lbnAddEditLists" runat="server" OnClientClick="openEmailRadWin(); return false;" Text="Add/Edit"></asp:LinkButton>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSendLists" CssClass="searchfrmBoxCol" ReadOnly="true" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSend" CssClass="frmButton" Text="Send Mail" runat="server"
                            OnClick="btnSend_Click"></asp:Button>
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" CssClass="frmButton" Text="Cancel" runat="server"
                            OnClick="btnCancel_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
