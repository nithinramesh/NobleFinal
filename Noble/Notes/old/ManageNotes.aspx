<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ManageNotes.aspx.cs" EnableEventValidation="false" Inherits="Noble.Notes.ManageNotes" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%--   <div>
<asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline" UpdateMode="Conditional">
            <ContentTemplate>--%>
    <div class="content">
        <div class="contentContainer">
            <span class="txtAdj">Manage Notes</span>
            <div class="tableContainer">
                <table runat="server" id="tblNotes" width="100%">
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%-- <b>Manage Notes</b>--%>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <%--<asp:GridView ID="gvNotes" runat="server" DataKeyNames="ID,Status_code" AutoGenerateColumns="False"
                                AllowPaging="true" OnPageIndexChanging="gvNotes_PageIndexChanging" CssClass="inner"
                                EmptyDataText="No record found." Width="100%" 
                                onrowdatabound="gvNotes_RowDataBound">
                                <Columns>
                                    <asp:BoundField HeaderText="Notes" DataField="Note_text" ItemStyle-Width="35%" />
                                    <asp:BoundField HeaderText="Status" DataField="Status_text" ItemStyle-Width="15%" />
                                    <asp:BoundField HeaderText="Assigned_To" DataField="Assigned_toName" ItemStyle-Width="15%" />
                                    <asp:BoundField HeaderText="Updated_By" DataField="Added_username" ItemStyle-Width="15%" />
                                    <asp:BoundField HeaderText="Updated_On" DataField="Updated_on" ItemStyle-Width="25%" />
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/edit-button.png"
                                                OnClick="btnEdit_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>--%>
                            <telerik:RadGrid ID="gvNotes" runat="server" Width="100%" AutoGenerateColumns="False"
                                ShowStatusBar="true" AllowPaging="true" PageSize="10" Skin="WebBlue" OnItemCommand="gvNotes_ItemCommand"
                                OnNeedDataSource="gvNotes_NeedDataSource" OnItemDataBound="gvNotes_ItemDataBound">
                                <PagerStyle AlwaysVisible="True" Position="Bottom" Mode="NumericPages" />
                                <MasterTableView DataKeyNames="ID,Status_code" AutoGenerateColumns="false" NoMasterRecordsText="No data available.">
                                    <Columns>
                                        <telerik:GridBoundColumn UniqueName="Notes" HeaderText="Notes" DataField="Note_text"
                                            ItemStyle-Width="35%">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Status" HeaderText="Status" DataField="Status_text"
                                            ItemStyle-Width="15%">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Assigned_To" HeaderText="Assigned_To" DataField="Assigned_toName"
                                            ItemStyle-Width="15%">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="Updated_On" HeaderText="Updated_On" DataField="Updated_On"
                                            ItemStyle-Width="15%">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn CommandName="Edit" HeaderText="Edit" UniqueName="EditColumn"
                                            ButtonType="ImageButton" ImageUrl="~/Images/edit-button.png" ItemStyle-Width="5%">
                                        </telerik:GridButtonColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnAddNotes" runat="server" Text="Add Notes" OnClick="btnAddNotes_Click"
                                SkinID="Button1" />
                        </td>
                    </tr>
                </table>
                <%--   </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAddNotes" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>--%>
                <%--       <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline">
            <ContentTemplate>--%>
                <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="gvNotes">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="btnAddNotes" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="btnAddNotes">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="tblNotes" />
                                <telerik:AjaxUpdatedControl ControlID="tblAdd" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="btnCancel">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="tblNotes" />
                                <telerik:AjaxUpdatedControl ControlID="tblAdd" />
                                <telerik:AjaxUpdatedControl ControlID="gvNotes" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <table class="dataTable2" id="tblAdd" runat="server" visible="false" width="85%">
                    <tr>
                        <td valign="top">
                            Note
                        </td>
                        <td>
                            <asp:TextBox ID="txtNotes" runat="server" MaxLength="2000" TextMode="MultiLine" Height="100px"
                                Width="100%" SkinID="TextBox1"></asp:TextBox>
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
                            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfStatus" runat="server" ControlToValidate="ddlStatus"
                                CssClass="failureNotification" ErrorMessage="Status is required." ToolTip="Status is required."
                                ValidationGroup="NoteSave" InitialValue="-1">*</asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlUser" runat="server" Visible="false">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfUser" runat="server" ControlToValidate="ddlUser"
                                CssClass="failureNotification" ErrorMessage="User is required." ToolTip="User is required."
                                ValidationGroup="NoteSave" InitialValue="-1" Visible="false">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                            <asp:Label ID="lblMessage" runat="server" CssClass="failureNotification"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                            <asp:Button ID="btnSaveNotes" runat="server" Text="Save Notes" ValidationGroup="NoteSave"
                                SkinID="Button1" OnClick="btnSaveNotes_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                SkinID="Button1" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAddNotes" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>--%>
</asp:Content>
