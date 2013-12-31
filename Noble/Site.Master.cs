using System;
using System.Web.Security;
using System.Web.UI;
using NobleDAL;
using NobleEntity;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Noble
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserEntity objUE = null;

            try
            {
                if (Session["USER"] != null)
                {

                    objUE = (UserEntity)Session["USER"];
                    if (Session["LOGINUSERID"] == null)
                    {
                        Session["LOGINUSERID"] = objUE.ID;
                    }

                    HideMenu(objUE);

                    //if (!Page.IsPostBack)
                    //{

                    //    objUE = (UserEntity)Session["USER"];
                    //    Session["LOGINUSERID"] = objUE.ID;
                    //    HideMenu(objUE);
                    //}
                    //else
                    //{

                    //    objUE = (UserEntity)Session["USER"];
                    //    HideMenu(objUE);
                    //}
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
            Regex regex = new Regex("/", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(path);
            int count = matches.Count;
            if (count == 1)
            {
                foreach (MenuItem item in name.Items)
                {
                    if (item.NavigateUrl.Equals(path, StringComparison.InvariantCultureIgnoreCase))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                string starting = path.Substring(0, (path.LastIndexOf("/") + 1));

                foreach (MenuItem item in name.Items)
                {
                    if (item.NavigateUrl.StartsWith(starting, StringComparison.InvariantCultureIgnoreCase))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        private void HideMenu(UserEntity objUE)
        {
            if (objUE != null)
            {
                if (objUE.User_role == 1)
                {
                    // superadmin
                    NavigationAdminMenu.Visible = false;
                    NavigationSuperAdminMenu.Visible = true;

                    ApplyMenuStyle(NavigationSuperAdminMenu);
                }
                else if (objUE.User_role == 2)
                {
                    // admin
                    NavigationAdminMenu.Visible = true;
                    NavigationSuperAdminMenu.Visible = false;
                    ApplyMenuStyle(NavigationAdminMenu);
                    //MenuItemCollection menuItems = NavigationSuperAdminMenu.Items;
                    //MenuItem adminItem = new MenuItem();
                    //foreach (MenuItem menuItem in menuItems)
                    //{
                    //    if (menuItem.Value.Equals("ADMIN", StringComparison.InvariantCultureIgnoreCase))
                    //    {
                    //        adminItem = menuItem;
                    //        break;
                    //    }
                    //}
                    //menuItems.Remove(adminItem);
                }

                lblUserName.Text = objUE.Last_name + " , " + objUE.First_name;
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
            Response.Redirect("~/Default.aspx", true);
        }
    }
}
