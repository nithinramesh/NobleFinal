using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleEntity;
using NobleBLL;
using System.Text;
using Telerik.Web.UI;

namespace Noble.MemberPopup
{
    public partial class SelectMember : System.Web.UI.Page
    {
        MemberPopupEntity objMemberPopupEntity = new MemberPopupEntity();
        MemberPopupController objMemberSearchController = new MemberPopupController();
        GeneralController genAccessObj = new GeneralController();
        private int RecordsPerPage = 10;
        private int PageNumber = 1;
        protected string selected_member = "";
        protected string selected_Quotation = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                FillMemberDetails(PageNumber);
                BindQuotationGrid();
               
            }
           

        }
        private void FillMemberDetails(int PageNumber)
        {
            string f = "";
            bool IsJobCategory = false;
            string fFirstName = GetFilter(radgvMembers.Columns[0], "FirstName");
            string fLastName = GetFilter(radgvMembers.Columns[1], "LastName");
            string fPhone = GetFilter(radgvMembers.Columns[2], "HousePhone");
            string fJobKeywords = GetFilter(radgvMembers.Columns[3], "HouseAddress");
            //string fJobCatdesc = GetFilter(radgvMembers.Columns[4], "JobCategoryDescription");


            if (fFirstName != "") f = f + " AND " + fFirstName;
            if (fLastName != "") f = f + " AND " + fLastName;
            if (fPhone != "") f = f + " AND " + fPhone;
            if (fJobKeywords != "") f = f + " AND " + fJobKeywords;
            //if (fJobCatdesc != "")
            //{
            //    f = f + " AND " + fJobCatdesc;
            //    IsJobCategory = true;
            //}

            List<MemberPopupEntity> lstMemberInfo;

            lstMemberInfo = objMemberSearchController.GetAllMembers(IsJobCategory, f);

            radgvMembers.DataSource = lstMemberInfo;
            // radgvMembers.DataBind();

            int RecordCount = 0;
            if (lstMemberInfo != null && lstMemberInfo.Count > 0)
                RecordCount = lstMemberInfo[0].RecordCount;

        }

        private void BindQuotationGrid()
        {
            QuotationController quotAccessObj = new QuotationController();
            gvQuot.DataSource = quotAccessObj.GetQuotationLists();
            gvQuot.DataBind();
                

        }

        protected void gvQuot_ItemCommand(object source, GridCommandEventArgs e)
        {
            BindQuotationGrid();
        }

        protected void gvQuot_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindQuotationGrid();
        }




        protected void lbnSelectMember_Click(object sender, EventArgs e)
        {
            // MPEMemberSearch.Show();
            FillMemberDetails(PageNumber);
            // FillJobCategory();
        }



        protected void radgvMembers_ItemCreated(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridFilteringItem)
            //{
            //    if (e.Item.FindControl("RadComboBoxJC") != null)
            //    {
            //        Dictionary<string, string> dicCombo = new Dictionary<string, string>();
            //        dicCombo = genAccessObj.GetJobCategory();

            //        RadComboBox ComboForStatus = (RadComboBox)e.Item.FindControl("RadComboBoxJC");

            //        ComboForStatus.DataSource = dicCombo;
            //        ComboForStatus.DataTextField = "Value";
            //        ComboForStatus.DataValueField = "Value";

            //    }
            //    if (e.Item.FindControl("RadComboBoxCountry") != null)
            //    {
            //        Dictionary<string, string> dicCountryCombo = new Dictionary<string, string>();
            //        dicCountryCombo = genAccessObj.GetCountry();

            //        RadComboBox ComboForStatus = (RadComboBox)e.Item.FindControl("RadComboBoxCountry");

            //        ComboForStatus.DataSource = dicCountryCombo;
            //        ComboForStatus.DataTextField = "Value";
            //        ComboForStatus.DataValueField = "Value";

            //    }
            //}
        }

      

        protected void radgvMembers_Init(object sender, EventArgs e)
        {
            GridFilterMenu menu = radgvMembers.FilterMenu;
            int i = 0;
            while (i < menu.Items.Count)
            {
                if (menu.Items[i].Text == "NoFilter" || menu.Items[i].Text == "Contains" || menu.Items[i].Text == "EqualTo"
                    || menu.Items[i].Text == "NotEqualTo" || menu.Items[i].Text == "StartsWith")
                {
                    i++;
                }
                else
                {
                    menu.Items.RemoveAt(i);
                }
            }
        }

        protected void gvQuot_Init(object sender, EventArgs e)
        {
            GridFilterMenu menu = gvQuot.FilterMenu;
            int i = 0;
            while (i < menu.Items.Count)
            {
                if (menu.Items[i].Text == "NoFilter" || menu.Items[i].Text == "Contains" || menu.Items[i].Text == "EqualTo"
                    || menu.Items[i].Text == "NotEqualTo" || menu.Items[i].Text == "StartsWith")
                {
                    i++;
                }
                else
                {
                    menu.Items.RemoveAt(i);
                }
            }
        }
        
        



        protected void radgvMembers_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            FillMemberDetails(1);
        }
        private string GetFilter(Telerik.Web.UI.GridColumn c, string cName)
        {
            //if (c.CurrentFilterValue == "") return "";

            string fv = c.CurrentFilterValue; // filter value
            string f = "";

            //Escape any single quotes in the search string
            if (!string.IsNullOrEmpty(fv))
                fv = fv.Replace("'", "''");

            switch (c.CurrentFilterFunction)
            {
                case GridKnownFunction.Between:
                    f = "";
                    break;
                case GridKnownFunction.Contains:
                    f = cName + " like '%" + fv + "%'";
                    break;
                case GridKnownFunction.Custom:
                    f = ""; // ???
                    break;
                case GridKnownFunction.DoesNotContain:
                    f = cName + " not like '%" + fv + "%'";
                    break;
                case GridKnownFunction.EndsWith:
                    f = cName + " like '%" + fv + "'";
                    break;
                case GridKnownFunction.EqualTo:
                    f = cName + " = '" + fv + "'";
                    break;
                case GridKnownFunction.GreaterThan:
                    f = cName + " > '" + fv + "'";
                    break;
                case GridKnownFunction.GreaterThanOrEqualTo:
                    f = cName + " >= '" + fv + "'";
                    break;
                case GridKnownFunction.IsEmpty:
                    f = cName + " = ''";
                    break;
                case GridKnownFunction.IsNull:
                    f = cName + " is null";
                    break;
                case GridKnownFunction.LessThan:
                    f = cName + " < '" + fv + "'";
                    break;
                case GridKnownFunction.LessThanOrEqualTo:
                    f = cName + " <= '%" + fv + "%'";
                    break;
                case GridKnownFunction.NoFilter:
                    f = "";
                    break;
                case GridKnownFunction.NotBetween:
                    f = ""; // ???
                    break;
                case GridKnownFunction.NotEqualTo:
                    f = cName + " <> '" + fv + "'";
                    break;
                case GridKnownFunction.NotIsEmpty:
                    f = cName + " <> ''";
                    break;
                case GridKnownFunction.NotIsNull:
                    f = cName + " is not null";
                    break;
                case GridKnownFunction.StartsWith:
                    f = cName + " like '" + fv + "%'";
                    break;
            };

            return f;
        }


        protected void RbtnSearchOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtnSearchOptions.SelectedIndex == 0)
            {

                radgvMembers.Visible = true;
                gvQuot.Visible = false;
            }
            else
            {
                gvQuot.Visible = true;
                radgvMembers.Visible = false;
                

            }
        }


    }
}