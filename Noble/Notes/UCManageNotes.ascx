<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCManageNotes.ascx.cs"
    Inherits="Noble.Notes.UCManageNotes" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>--%>
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
            <%--<asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" SkinID="TextBox1"
                Text='<%# DataBinder.Eval( Container, "DataItem.Note_text") %>' MaxLength="2000"
                Height="100px" Width="100%"></asp:TextBox>--%>
            <telerik:RadEditor ID="redNotes" runat="server" Width="740px" Height="270px" >
                <Modules>
                    <telerik:EditorModule Name="fakeModule"></telerik:EditorModule>
                </Modules>
            </telerik:RadEditor>
            <asp:RequiredFieldValidator ID="rfFN" runat="server" ControlToValidate="redNotes"
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
            <asp:Button ID="btnUpdate" Text="Update" runat="server" SkinID="Button1" ValidationGroup="NoteSave"
                CommandName="Update" Visible='<%# !(DataItem is Telerik.Web.UI.GridInsertionObject) %>'
                OnClick="btnUpdate_Click"></asp:Button>
            <asp:Button ID="btnSaveNotes" runat="server" Text="Save Notes" SkinID="Button1" ValidationGroup="NoteSave"
                CommandName="PerformInsert" Visible='<%# DataItem is Telerik.Web.UI.GridInsertionObject %>'
                OnClick="btnSaveNotes_Click" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                CausesValidation="False" CommandName="Cancel" SkinID="Button1" />
        </td>
    </tr>
</table>
