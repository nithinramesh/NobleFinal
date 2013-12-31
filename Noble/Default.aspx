<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/SiteLogin.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Noble._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="content">
        <div class="contentContainer">
            <span class=" txtAdj"></span>
            <div class="tableContainer">
                <div class="contentAligner">
                    <div class="headerImg">
                        <div class="imgAligner">
                            <img src="images/img-one.jpg" width="243" height="222" /></div>
                    </div>
                </div>
                <br />
                <div class="frmBoxContainer">
                    <div class="frmTxtCol style3">
                        Login</div>
                </div>
                <div class="frmBoxContainer">
                    <div class="frmTxtCol">
                        Username:</div>
                    <asp:TextBox ID="UserName" runat="server" CssClass="frmBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                        CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <div class="frmBoxContainer">
                    <div class="frmTxtCol">
                        Password:</div>
                    <asp:TextBox ID="Password" runat="server" CssClass="frmBox" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <div class="frmBoxContainer">
                    <asp:Button ID="LoginButton" runat="server" CssClass="frmButton" Text="Log In"
                        ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click" /></div>
                <asp:Label ID="lblMessage" runat="server" class="failureNotification"></asp:Label>
                <div class="clearFloat">
                </div>
            </div>
        </div>
        <div class="breaker">
        </div>
    </div>
    <%--<asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
        <LayoutTemplate>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="LoginUserValidationGroup" />
            <fieldset class="login">
             
                <div class="breaker">
                </div>
                <br />
                <div class="loginTxtColLeft">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></div>
                <label>
                    <asp:TextBox ID="Password" runat="server" CssClass="frmBoxCol" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                </label>
                <div class="breaker">
                </div>
                <br />
            </fieldset>
            <div class="loginButtonAligner">
                <asp:Button ID="LoginButton" runat="server" CssClass="loginOrangeButton" Text="Log In"
                    ValidationGroup="LoginUserValidationGroup" OnClick="LoginButton_Click" />
                <br />
            </div>
        </LayoutTemplate>
    </asp:Login>--%>
</asp:Content>
