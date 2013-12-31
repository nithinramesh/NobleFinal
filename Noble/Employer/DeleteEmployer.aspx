<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DeleteEmployer.aspx.cs" Inherits="Noble.Employer.DeleteEmployer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>
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
                        Name
                    </td>
                    <td>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address 1
                    </td>
                    <td>
                        <asp:Label ID="lblAddr1" runat="server"  ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Address 2
                    </td>
                    <td>
                        <asp:Label ID="lblAddr2" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        City
                    </td>
                    <td>
                        <asp:Label ID="lblCity" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Province
                    </td>
                    <td>
                        <asp:Label ID="lblProvince" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Postal Code
                    </td>
                    <td>
                        <asp:Label ID="lblPostalCode" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Phone
                    </td>
                    <td>
                        <asp:Label ID="lblPhone" runat="server" ></asp:Label>
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
                        <asp:Button ID="btnDeleteEmp" runat="server" OnClientClick="return confirmbox();"
                            Text="Delete" SkinID="Button1" ValidationGroup="AdminSave" onclick="btnDeleteEmp_Click" 
                            />
                    </td>
                    <td>
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" SkinID="Button1"
                            Text="Cancel" />
                    </td>
                </tr>
            </table>
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
