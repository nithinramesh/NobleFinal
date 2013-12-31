using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using NobleEntity;

namespace Noble
{
    public partial class EmployerMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployerEntity objUE = null;

            try
            {
                if (Session["EMPLOYER"] != null)
                {

                    objUE = (EmployerEntity)Session["EMPLOYER"];
                    if (Session["LOGINEMPLOYERID"] == null)
                    {
                        Session["LOGINEMPLOYERID"] = objUE.ID;
                    }
                    ApplyMenuStyle(this.Menu);
                    lblUserName.Text = objUE.Name ;
                }
                else
                {
                    Logout();
                }
            }
            finally
            {
                objUE = null;
            }

        }

        private void ApplyMenuStyle(Menu name)
        {
            string path = Request.AppRelativeCurrentExecutionFilePath;
            foreach (MenuItem item in name.Items)
            {
                if (item.NavigateUrl.Equals(path, StringComparison.InvariantCultureIgnoreCase))
                {
                    item.Selected = true;
                    break;
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/EmployerLogin.aspx", true);
        }

    }
}