using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using System.Text;


namespace Noble.MemberPopup
{
    public partial class MemberPopup : System.Web.UI.UserControl
    {

        protected void Page_Init(object sender, EventArgs e)
        {

            string selectedCustomer = (string)Request.Form["selected_member"];
            string selected_Quotation = (string)Request.Form["selected_Quotation"];
            if (!string.IsNullOrEmpty(selectedCustomer))
            {
                Session["SelectedMember"] = selectedCustomer;
                Session["selected_Quotation"] = null;
                lblSelectedMember.Text = string.Concat(Session["SelectedMember"].ToString().Split(';')[1].ToString(), " ", Session["SelectedMember"].ToString().Split(';')[2].ToString());
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else if (!string.IsNullOrEmpty(selected_Quotation))
            {
                Session["selected_Quotation"] = selected_Quotation;
                Session["SelectedMember"] = null;
                lblSelectedMember.Text = string.Concat(Session["selected_Quotation"].ToString().Split(';')[1].ToString(), " ", Session["selected_Quotation"].ToString().Split(';')[2].ToString());
                Response.Redirect(Request.Url.AbsoluteUri);

            }
            else if (Session["SelectedMember"] != null && !string.IsNullOrEmpty(Session["SelectedMember"].ToString()))
            {
                lblSelectedMember.Text = string.Concat(Session["SelectedMember"].ToString().Split(';')[1].ToString(), " ", Session["SelectedMember"].ToString().Split(';')[2].ToString());
            }
            else if (Session["selected_Quotation"] != null && !string.IsNullOrEmpty(Session["selected_Quotation"].ToString()))
            {
                lblSelectedMember.Text = string.Concat(Session["selected_Quotation"].ToString().Split(';')[1].ToString(), " ", Session["selected_Quotation"].ToString().Split(';')[2].ToString());
            }
            else
            {
                var lScriptString = string.Format("<script>function pageLoad() {{ var oRadWindowManager = $find(\"{0}\"); var oWnd = oRadWindowManager.GetWindowByName('RadWindow1');oWnd.SetUrl('../MemberPopup/SelectMember.aspx');oWnd.Show();}} </script>",  RadWindowManager1.ClientID);

                //Now we register a script to run when page loads
                Page.ClientScript.RegisterClientScriptBlock(typeof(string), "popupScript", lScriptString);

            }




        }

        
        protected void Page_Load(object sender, EventArgs e)
        {

            //string selectedCustomer = (string)Request.Form["selected_member"];
            //if (!string.IsNullOrEmpty(selectedCustomer))
            //{
            //    Session["SelectedMember"] = selectedCustomer;
            //    lblSelectedMember.Text = string.Concat(Session["SelectedMember"].ToString().Split(';')[1].ToString(), " ", Session["SelectedMember"].ToString().Split(';')[2].ToString());
            //}
            //else if (Session["SelectedMember"] != null && !string.IsNullOrEmpty(Session["SelectedMember"].ToString()))
            //{
            //    lblSelectedMember.Text = string.Concat(Session["SelectedMember"].ToString().Split(';')[1].ToString(), " ", Session["SelectedMember"].ToString().Split(';')[2].ToString());
            //}

          


        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
           

        }
    

    
      
      
     
        protected void lbnSelectMember_Click(object sender, EventArgs e)
        {
           // MPEMemberSearch.Show();
           // FillMemberDetails(PageNumber);
           // FillJobCategory();
        }

        //protected void btnSearch_Click(object sender, EventArgs e)
        //{
        //    FillMemberDetails(PageNumber);
        //}
        //private void FillJobCategory()
        //{
        //    Dictionary<string, string> dicCombo = new Dictionary<string, string>();
        //    dicCombo = genAccessObj.GetJobCategory();
        //    cblJobCategory.DataSource = dicCombo;
        //    cblJobCategory.DataValueField = "Key";
        //    cblJobCategory.DataTextField = "Value";
        //    cblJobCategory.DataBind();

        //}

        //protected void btnClearAll_Click(object sender, EventArgs e)
        //{
        //    //txtFirstName.Text = string.Empty;
        //    //txtLastName.Text = string.Empty;
        //    //txtPhone.Text = string.Empty;
        //    //foreach (ListItem item in cblJobCategory.Items)
        //    //{
        //    //    //check anything out here
        //    //    if (item.Selected)
        //    //        item.Selected = false;
        //    //}
        //}
       
      
    }
}