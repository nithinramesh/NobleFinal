<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DeleteAdmin.aspx.cs" Inherits="Noble.DeleteAdmin" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <div class="tableContainer">
                <table class="dataTable2" id="tblAdd" runat="server" visible="true">
                    <tr>
                        <td>
                            <%--  <b>Delete Admin</b>--%>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            First_name
                        </td>
                        <td>
                            <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last_name
                        </td>
                        <td>
                            <asp:Label ID="lblLastName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email
                        </td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:Button ID="btnDeleteAdmin0" runat="server" OnClick="btnDeleteAdmin_Click" OnClientClick="return confirmbox();"
                                Text="Delete Admin" SkinID="Button1" ValidationGroup="AdminSave" />
                        </td>
                        <td>
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Button1"
                                Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function confirmbox() {
            var con = confirm("Are you sure want to delete?"); if (con == true)
            { return true; } else { return false; }
        }
    </script>
</asp:Content>
