<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DeleteMember.aspx.cs" Inherits="Noble.DeleteMember" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
        <ContentTemplate>
            <div class="content">
                <div class="contentContainer">
                    <span class="txtAdj">Manage Member - Delete</span>
                    <div class="tableContainer">
                        <table class="dataTable2" id="tblAdd" runat="server" visible="true">
                            <tr>
                                <td>
                                    <%--<b>Delete Member</b>--%>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Title
                                </td>
                                <td>
                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    First name
                                </td>
                                <td>
                                    <asp:Label ID="lblFirstName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Middle name
                                </td>
                                <td>
                                    <asp:Label ID="lblMiddleName" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last name
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
                                <td>
                                    Address 1
                                </td>
                                <td>
                                    <asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Address 2
                                </td>
                                <td>
                                    <asp:Label ID="lblAddress2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    City
                                </td>
                                <td>
                                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Province
                                </td>
                                <td>
                                    <asp:Label ID="lblProvince" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Postal Code
                                </td>
                                <td>
                                    <asp:Label ID="lblPostalCode" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone
                                </td>
                                <td>
                                    <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Home Phone
                                </td>
                                <td>
                                    <asp:Label ID="lblHomePhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Work Phone
                                </td>
                                <td>
                                    <asp:Label ID="lblWorkPhone" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Job Keyword
                                </td>
                                <td>
                                    <asp:Label ID="lblJobTitle" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Position Looking
                                </td>
                                <td>
                                    <asp:Label ID="lblPosition" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Country(Residence)
                                </td>
                                <td>
                                    <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Country(Origin)
                                </td>
                                <td>
                                    <asp:Label ID="lblOriginCountry" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Experience
                                </td>
                                <td>
                                    <asp:Label ID="lblExperience" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gender
                                </td>
                                <td>
                                    <asp:Label ID="lblGender" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Other
                                </td>
                                <td>
                                    <asp:Label ID="lblOther" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    Job Category(s)
                                </td>
                                <td>
                                    <asp:Label ID="lblJobCategory" runat="server"></asp:Label>
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
                                    <asp:Button ID="btnDeleteMember" runat="server" OnClientClick="return confirmbox();"
                                        SkinID="Button1" Text="Delete" OnClick="btnDeleteMember_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel"
                                        SkinID="Button1" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
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
