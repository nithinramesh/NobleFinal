<%@ Page Title="" Language="C#" AutoEventWireup="True" MasterPageFile="~/Site.Master"
    EnableEventValidation="false" ClientIDMode="AutoID" CodeBehind="LandingPage.aspx.cs"
    Inherits="Noble.LandingPage" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<%@ Register Src="~/MemberPopup/MemberPopup.ascx" TagName="memberPopup" TagPrefix="ABR" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="SelectMemberContent" runat="server">
    <ABR:memberPopup runat="server" ID="MemberPopupfile" />
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlMemberDetails" runat="server">
        <table class="tableContainer" id="tblAdd" runat="server" visible="true">
            <tr>
                <td colspan="4">
                    <b>Personal Details</b>
                </td>
            </tr>
            <tr>
            <td colspan="4">
                    &nbsp;
                </td>
            </tr>

            <tr align="center">
                <td colspan="4" align="center">
                    <telerik:RadGrid ID="rgMemberDetails" runat="server" Width="90%" AutoGenerateColumns="False"
                        ShowStatusBar="true" AllowPaging="true" Skin="WebBlue" PageSize="50">
                        <MasterTableView AutoGenerateColumns="false" NoMasterRecordsText="No data available.">
                            <Columns>
                                <telerik:GridBoundColumn ItemStyle-Width="20%" ItemStyle-Height="20px" UniqueName="Title1"
                                    HeaderText="" DataField="Title1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn ItemStyle-Width="30%" ItemStyle-Height="20px" UniqueName="Value1"
                                    HeaderText="" DataField="Value1">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn ItemStyle-Width="20%" ItemStyle-Height="20px" UniqueName="Title2"
                                    HeaderText="" DataField="Title2">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn ItemStyle-Width="30%" ItemStyle-Height="20px" UniqueName="Value2"
                                    HeaderText="" DataField="Value2">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <br />
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <b>Notes</b>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="gvNotes" runat="server" Width="100%" AutoGenerateColumns="False"
                        ShowStatusBar="true" AllowPaging="true" PageSize="10" Skin="WebBlue" OnItemCommand="gvNotes_ItemCommand"
                        OnNeedDataSource="gvNotes_NeedDataSource" OnPreRender="gvNotes_PreRender">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                        <MasterTableView DataKeyNames="ID,Status_code" EditMode="EditForms" CommandItemDisplay="Top"
                            NoMasterRecordsText="No data available.">
                            <EditFormSettings>
                                <PopUpSettings Width="500px" Height="475px" Modal="true" />
                            </EditFormSettings>
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="Notes" HeaderText="Notes" DataField="Note_text"
                                    Visible="false" ItemStyle-Width="35%">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn CommandName="Edit" HeaderText="View" UniqueName="EditColumn"
                                    ButtonType="ImageButton" ImageUrl="~/Images/search_button.png" ItemStyle-Width="5%">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn UniqueName="Status" HeaderText="Status" DataField="Status_text"
                                    ItemStyle-Width="15%">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Assigned_To" HeaderText="Assigned_To" DataField="Assigned_toName"
                                    ItemStyle-Width="15%">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Updated_On" HeaderText="Updated_On" DataField="Updated_On"
                                    ItemStyle-Width="15%">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings UserControlName="NotesEdit.ascx" EditFormType="WebUserControl">
                                <EditColumn UniqueName="EditCommandColumn1">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <b>Files</b>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="radgvFiles" runat="server" Width="100%" AutoGenerateColumns="False"
                        ShowStatusBar="true" AllowPaging="true" PageSize="10" Skin="WebBlue" OnDataBound="radgvFiles_DataBound"
                        OnItemCommand="radgvFiles_ItemCommand">
                        <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                        <MasterTableView DataKeyNames="File_ID,File_Path,File_Name,File_Type">
                            <Columns>
                                <telerik:GridBoundColumn UniqueName="Member" HeaderText="Member" DataField="Member_Name"
                                    FilterControlWidth="100px">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="File_Name" HeaderText="File_Name" DataField="File_Name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="File_Type" HeaderText="File_Type" DataField="File_Type">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="File_Category" HeaderText="File_Category" DataField="File_Category">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="CreatedAdmin" HeaderText="CreatedAdmin" DataField="CreatedAdmin">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="Created_on" HeaderText="Created_on" DataField="Created_on">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn HeaderText="View" CommandName="Select" Text="Select" UniqueName="SelectColumn"
                                    ButtonType="ImageButton" ImageUrl="~/images/FileUpload/OneNote.png">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <%-- <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="radgvFiles">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="radgvFiles" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>--%>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlSubmissionDetails" runat="server">
        <%--
        <table>
            <tr>
                <td>
                    <br>
                    </br> <b>Quotation No</b>
                    <asp:Label ID="lblgQuotNo" runat="server"></asp:Label>
                    <br></br> <b>First Name</b>
                    <asp:Label ID="lblfname" runat="Server"></asp:Label>
                    <br></br> <b>Last Name</b>
                    <asp:Label ID="lblLname" runat="Server"></asp:Label>
                </td>
            </tr>
        </table>--%>
        <telerik:RadGrid ID="gvQuot" runat="server" AllowPaging="True" AllowSorting="True"
            Visible="true" AutoGenerateColumns="False" ShowStatusBar="true" OnNeedDataSource="gvQuot_NeedDataSource"
            Skin="WebBlue" PageSize="20">
            <MasterTableView Width="100%" DataKeyNames="QuotNo" ClientDataKeyNames="QuotNo,Firstname,Lastname">
                <Columns>
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
        <br />
        <br />
        <br />
        <telerik:RadGrid ID="gvQuotDetails" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" ShowStatusBar="true" OnNeedDataSource="gvQuotDetails_NeedDataSource"
            Skin="WebBlue">
            <MasterTableView Width="800px" DataKeyNames="ID">
                <Columns>
                    <telerik:GridBoundColumn UniqueName="ID" HeaderText="ID" DataField="ID" ItemStyle-Width="3%"
                        FilterControlWidth="30px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="Code" HeaderText="Code" DataField="Code" ItemStyle-Width="11%">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="ProductName" HeaderText="Product" DataField="ProductName"
                        ItemStyle-Width="3%" FilterControlWidth="30px">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="Price" HeaderText="Price" DataField="Price"
                        ItemStyle-Width="11%">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="Qty" HeaderText="Qty" DataField="Qty" ItemStyle-Width="9%">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="Total" HeaderText="Total" DataField="Total"
                        ItemStyle-Width="9%">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <%-- <asp:Repeater ID="RepSubmissions" runat="server">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--<asp:Label ID="lblComment" runat="server" Text='<%#Eval("Comment") %>' />--%>
        <%-- </td>
                </tr>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblComponent" runat="server" Font-Bold="true" Text='<%#Eval("ComponentName") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblComponentData" runat="server" Text='<%#Eval("ComponentData") %>' />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>--%>
    </asp:Panel>
</asp:Content>
