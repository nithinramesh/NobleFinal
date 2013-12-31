<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" MasterPageFile="~/Site.Master"
    EnableEventValidation="false" ClientIDMode="AutoID" Inherits="Noble.FileUpload.FileUpload" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<%@ Register Src="~/MemberPopup/MemberPopup.ascx" TagName="memberPopup" TagPrefix="ABR" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="SelectMemberContent" runat="server">
    <ABR:memberPopup runat="server" ID="MemberPopupfile" />
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="tableContainer">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr align="left">
                <td>
                    <table width="500px">
                        <tr align="left">
                            <td>
                                <p id="upload-area">
                                    <input id="File1" type="file" class="FilebrowseButton" dir="rtl" runat="server" size="267" />
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    <input id="AddFile" class="frmButton" type="button" value="+ Add file" onclick="addFileUploadBox()" />
                                </p>
                            </td>
                        </tr>
                        <tr align="right">
                            <td>
                                <p>
                                    <asp:Label ID="lblMessage" ForeColor="Red" runat="Server"></asp:Label>
                                </p>
                            </td>
                        </tr>
                        <tr align="right">
                            <td>
                                <p>
                                    <asp:DropDownList ID="ddlSubfolders" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:Button ID="btnSubmit" runat="server" class="frmButton" Text="Upload" OnClick="btnSubmit_Click" />&nbsp;
                                    <%--  <asp:Button ID="btnCancel" runat="server" class="frmButton" Text="cancel"  />--%>
                                    <input type="button" id="btnCancel" value="Redirect" class="frmButton" style="display: none"
                                        onclick="Javascript: callMsgBox('The Upload has been cancelled.');" />
                                </p>
                                <span id="Span1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="right">
                <td>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr align="right">
                <td>
                </td>
            </tr>
            <tr align="left">
                <td>
                    <br />
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
                                <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn"
                                    ButtonType="ImageButton" ImageUrl="~/images/delete-button.png">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <%--       <telerik:RadAjaxManager runat="server" ID="RadAjaxManager1">
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
    </div>
    <script type="text/javascript">
        function addFileUploadBox() {


            if (!document.getElementById || !document.createElement)
                return false;

            var uploadArea = document.getElementById("upload-area");

            if (!uploadArea)
                return;

            var newLine = document.createElement("br");
            uploadArea.appendChild(newLine);

            var newUploadBox = document.createElement("input");

            // Set up the new input for file uploads
            newUploadBox.type = "file";
            newUploadBox.size = "267";

            // The new box needs a name and an ID
            if (!addFileUploadBox.lastAssignedId)
                addFileUploadBox.lastAssignedId = 100;

            newUploadBox.setAttribute("id", "dynamic" + addFileUploadBox.lastAssignedId);
            newUploadBox.setAttribute("name", "dynamic:" + addFileUploadBox.lastAssignedId);
            newUploadBox.setAttribute("dir", "rtl");
            newUploadBox.setAttribute("class", "FilebrowseButton");
            uploadArea.appendChild(newUploadBox);
            addFileUploadBox.lastAssignedId++;
        }

        function callMsgBox(strMsg) {
            //                alert(strMsg);
            window.location = "FileNotFound.aspx";
        }


    </script>
</asp:Content>
