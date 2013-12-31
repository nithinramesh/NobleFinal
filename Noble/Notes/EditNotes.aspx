<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditNotes.aspx.cs" Inherits="Noble.Notes.EditNotes" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <div class="tableContainer">
                <table class="dataTable2" id="tblAdd" runat="server" visible="true" width="75%">
                    <tr>
                        <td>
                            <%-- <b>Edit Notes</b>--%>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Notes
                        </td>
                        <td>
                            <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" SkinID="TextBox1"
                                MaxLength="2000" Height="100px" Width="100%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfFN" runat="server" ControlToValidate="txtNotes"
                                CssClass="failureNotification" ErrorMessage="Note is required." ToolTip="Note is required."
                                ValidationGroup="NoteSave">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfStatus" runat="server" ControlToValidate="ddlStatus"
                                CssClass="failureNotification" ErrorMessage="Status is required." ToolTip="Status is required."
                                ValidationGroup="NoteSave" InitialValue="-1">*</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlUser" runat="server" Visible="false">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfUser" runat="server" ControlToValidate="ddlUser"
                                CssClass="failureNotification" ErrorMessage="User is required." ToolTip="User is required."
                                ValidationGroup="NoteSave" InitialValue="-1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            &nbsp;
                            <asp:Button ID="btnSaveNotes" runat="server" Text="Save Notes" SkinID="Button1" ValidationGroup="NoteSave"
                                OnClick="btnSaveNotes_Click" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                SkinID="Button1" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
