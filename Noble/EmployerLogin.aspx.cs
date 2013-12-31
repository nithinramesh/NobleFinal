using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleEntity;
using NobleBLL;
using Noble.Common;

namespace Noble
{
    public partial class EmployerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string strRedirect = string.Empty;
            EmployerEntity uObj = GetUserDetails(LoginUser.UserName.Trim(), LoginUser.Password.Trim());
            if (uObj != null)
            {
                Session["EMPLOYER"] = uObj;

                strRedirect = Request["ReturnUrl"];
                if (strRedirect == null)
                {
                    strRedirect = "~/Employer/EmpLandingPage.aspx";
                }
                Response.Redirect(strRedirect, true);
            }
            else
            {
                lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "1000");
            }
        }

        private EmployerEntity GetUserDetails(string userName, string passWord)
        {
            EmployerController uc = new EmployerController();
            return uc.GetUserDetails(userName, EncryptionUtility.EncryptData(passWord));
        }
    }
}