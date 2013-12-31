<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployerLogin.aspx.cs"
    Inherits="Noble.EmployerLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Employer Login</title>
    <link href="script-css/Loginstyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <div class="wrapper">
        <div class="headerWrapper">
            <div class="bannerArea">
                <div class="logoAlignner">
                </div>
            </div>
            <div class="clearFloat">
            </div>
        </div>
        <div class="innerContentWrapper">
            <div class="loginTopAlign">
            </div>
            <div class="innerContentContainer">
                <div class="innerContentArea">
                    <div class="logContainer">
                        <div class="loginCol">
                            <img src="images/flash-img.jpg" /><br />
                            <img src="images/shadow.png" />
                            <br />
                        </div>
                        <div class="loginArea">
                            <h3 class="subHeadBlue">
                                Employer Login</h3>
                            <asp:Label ID="lblMessage" runat="server" class="failureNotification"></asp:Label>
                            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
                                <LayoutTemplate>
                                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                                        ValidationGroup="LoginUserValidationGroup" />
                                    <fieldset class="login">
                                        <div class="loginTxtColLeft">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label></div>
                                        <label>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="frmBoxCol"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
                                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </label>
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
                                        <%--<input name="" type="button" class="loginOrangeButton" value="Reset" />--%>
                                        <br />
                                    </div>
                                </LayoutTemplate>
                            </asp:Login>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clearFloat">
    </div>
    </div>
    <div class="footerWrapper">
        <div class="footerContainer">
            <img src="images/content-bttom-img.png" /><br />
            <div class="footerLeft">
                <a href="#" class="lnkGrey">
                    <%--Suite 205-14, 4117 Lawrence Avenue East, Toronto, Ontario,
                    M1E 2S2, Canada. Tel: 647 477 2197 Fax: 647 477 5983<br />--%>
                    Toronto office:<br />
                    4117 Lawrence Avenue E, Suite 205-14,Toronto, ONT, M1E 2S2, Canada<br />
                    Edmonton office:<br />
                    4935 – 55 Avenue NW, Suite 213, Edmonton, Alberta T6B 3S3, Canada.<br />
                    Tel: (647) 477 2197 or 780 628 7040
                    <br />
                    Toll Free: 1-877-612-1222
                    <br />
                    Fax: (647) 477 5983<br />
                    Email: info@Noble.com<br />
                    Web: www.Noble.com</a></div>
            <div class="footerRight">
                <a href="#" class="lnkGreyRight">© ANN ARBOUR GROUP All Rights Reserved.<br />
                    Canadian Immigration Consultant.</a>
                <div class="imageAligner">
                    <img src="images/iccrc-image-2.jpg" /></div>
                <br />
                <a href="#" class="lnkGreyRight">Sharmila Perera ACIS, RCIC<br />
                    Certified Member of the Immigration Consultants of Canada Regulatory Council<br />
                    Member of the Canadian Association of Professional Immigration Consultants</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
