<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" Inherits="NewsLetter.TemplateList"
    CodeBehind="TemplateList.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
        <table width="100%" class="dataTable2">
            <tr align="right">
                <td align="right">
                    <asp:Button ID="btnContacts" Text="Contact Lists" runat="server" CssClass="frmButton"
                        OnClick="btnContacts_Click" />
                    <asp:Button ID="btnCreateTemplate" runat="server" CssClass="frmButton" Text="Create New"
                        OnClick="btnCreateTemplate_Click" />
                    <asp:Button ID="btnReports" runat="server" CssClass="frmButton" Text="Reports"
                        OnClick="btnReports_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataList DataKeyField="TemplateID" ID="dlTemplates" RepeatColumns="3" runat="server"
                        OnItemCommand="dlTemplates_ItemCommand" OnItemDataBound="dlTemplates_ItemDataBound">
                        <ItemTemplate>
                            <table class="dataTable2">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ibnTemplate" runat="server" AlternateText='<%# DataBinder.Eval(Container.DataItem, "TemplateName")%>'
                                            CommandName="Redirect" Width="200px" Height="300px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblTemplateName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TemplateName")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr align="right">
                                    <td>
                                        <asp:Button ID="btnDelete" CssClass="frmButton" runat="server" Text="Delete"
                                            CommandName="Delete" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
        <table border="0" width="410">
            <tr>
                <td>
                    <asp:LinkButton ID="lbtnPrev" runat="server" OnClick="lbtnPrev_Click">Prev</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="lbtnNext" runat="server" OnClick="lbtnNext_Click">Next</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
