using System;
using System.Web;
using System.Web.Security;
using Noble.Common;
using NobleBLL;
using NobleEntity;

namespace Noble
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (ValidateUser(UserName.Text.Trim(), Password.Text.Trim()))
            {
                //FormsAuthenticationTicket tkt;
                //string cookiestr = string.Empty;
                //HttpCookie ck;

                //tkt = new FormsAuthenticationTicket(1, LoginUser.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), LoginUser.RememberMeSet, "your custom data");
                //cookiestr = FormsAuthentication.Encrypt(tkt);
                //ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                //if (LoginUser.RememberMeSet)
                //    ck.Expires = tkt.Expiration;
                //ck.Path = FormsAuthentication.FormsCookiePath;
                //Response.Cookies.Add(ck);

                string strRedirect = string.Empty;
                UserEntity uObj = GetUserDetails(UserName.Text.Trim(), Password.Text.Trim());
                if (uObj != null)
                {
                    Session["USER"] = uObj;

                    strRedirect = Request["ReturnUrl"];
                    if (strRedirect == null)
                    {
                        strRedirect = "LandingPage.aspx";
                    }
                    Response.Redirect(strRedirect, true);
                }
                else
                {
                  
                }
            }
            else
            {
                lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "1000");
            }
        }

        private bool ValidateUser(string userName, string passWord)
        {
            UserController uc = new UserController();
            if (uc.ValidateUser(userName, EncryptionUtility.EncryptData(passWord)))
            {
                return true;
            }
            return false;

            # region old code
            //SqlConnection conn;
            //SqlCommand cmd;
            //string lookupPassword = null;

            //// Check for invalid userName.
            //// userName must not be null and must be between 1 and 15 characters.
            //if ((null == userName) || (0 == userName.Length) || (userName.Length > 15))
            //{
            //    System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.");
            //    return false;
            //}

            //// Check for invalid passWord.
            //// passWord must not be null and must be between 1 and 25 characters.
            //if ((null == passWord) || (0 == passWord.Length) || (passWord.Length > 25))
            //{
            //    System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
            //    return false;
            //}

            //try
            //{
            //    // Consult with your SQL Server administrator for an appropriate connection
            //    // string to use to connect to your local SQL Server.
            //    //conn = new SqlConnection("server=localhost;Integrated Security=SSPI;database=pubs");
            //    conn = new SqlConnection("Server=localhost;Database=Noble;Trusted_Connection=Yes;");
            //    conn.Open();

            //    // Create SqlCommand to select pwd field from users table given supplied userName.
            //    cmd = new SqlCommand("Select pwd from users where uname=@userName", conn);
            //    cmd.Parameters.Add("@userName", SqlDbType.VarChar, 25);
            //    cmd.Parameters["@userName"].Value = userName;

            //    // Execute command and fetch pwd field into lookupPassword string.
            //    lookupPassword = (string)cmd.ExecuteScalar();

            //    // Cleanup command and connection objects.
            //    cmd.Dispose();
            //    conn.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    // Add error handling here for debugging.
            //    // This error message should not be sent back to the caller.
            //    System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            //}

            //// If no password found, return false.
            //if (null == lookupPassword)
            //{
            //    // You could write failed login attempts here to event log for additional security.
            //    return false;
            //}

            //// Compare lookupPassword and input passWord, using a case-sensitive comparison.
            //return (0 == string.Compare(lookupPassword, passWord, false));
            # endregion
        }

        private UserEntity GetUserDetails(string userName, string passWord)
        {
             UserController uc = new UserController();
             return uc.GetUserDetails(userName, EncryptionUtility.EncryptData(passWord));
        }
    }
}
