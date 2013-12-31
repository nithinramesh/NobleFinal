using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using Telerik.Web.UI;

namespace Noble
{
    public partial class ManageMember : System.Web.UI.Page
    {
        MemberController _memberAccessObj = null;
        private MemberEntity _objMemberEntity = null;
        private List<MemberEntity> listMember = null;
        private List<ProductCategoryEntity> ListCat = null; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // ((Label)Master.FindControl("lblPageHeading")).Text = " ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Member";
                BindGrid();
            }
        }

       

        private void BindGrid()
        {
            _memberAccessObj = new MemberController();
            try
            {


                //gvMember.DataSource = memberAccessObj.GetMemberSearchList(txtLN.Text.Trim(), txtFN.Text.Trim(),
                //    txtMN.Text.Trim(), txtSearchPhone.Text.Trim());
                //gvMember.DataBind();

                if (Session["SelectedMember"] != null)
                {
                    gvMember.DataSource = _memberAccessObj.GetMemberDetails_search(Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]));
                }
                else
                {
                    gvMember.DataSource = _memberAccessObj.GetMemberSearchList();
                }
            }
            finally
            {
                _memberAccessObj = null;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        //protected void gvMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvMember.PageIndex = e.NewPageIndex;
        //    BindGrid();
        //}

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            tblAdd.Visible = true;
            //tblSearch.Visible = false;
            tblGrid.Visible = false;
            //gvMember.Visible = false;

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            tblAdd.Visible = false;
            //tblSearch.Visible = true;
            tblGrid.Visible = true;
            //gvMember.Visible = true;

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }

       protected void gvMember_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindGrid();
        }

        protected void gvMember_Init(object sender, System.EventArgs e)
        {
            GridFilterMenu menu = gvMember.FilterMenu;
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

        protected void gvMember_Itemcreated(object source, Telerik.Web.UI.GridInsertedEventArgs e)
        {
            
        }

        protected void gvMember_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName.Equals("InitInsert"))
            {
                //GridEditableItem editedItem = e.Item as GridEditableItem;
               
                //UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
                //RadListBox radlstZones = userControl.FindControl("radlstZones") as RadListBox;
                //if (radlstZones != null) radlstZones.ClearChecked();
                gvMember.MasterTableView.ClearEditItems();
                ViewState["MemberId"] = null;
            }

            if (e.CommandName.Equals("Delete"))
            {
                GridDataItem item = (GridDataItem)e.Item;
                string id = item.GetDataKeyValue("ID").ToString();
                ViewState["MemberId"] = Convert.ToInt32(item.GetDataKeyValue("ID"));
            }
            if (e.CommandName.Equals("Edit"))
            {
                GridDataItem item = (GridDataItem)e.Item;
                string id = item.GetDataKeyValue("ID").ToString();
                ViewState["MemberId"] = Convert.ToInt32(item.GetDataKeyValue("ID"));
            }
        }

        protected void gvMember_PreRender(object sender, EventArgs e)
        {
            UserEntity objUE = null;
            if (Session["USER"] != null)
            {
                objUE = (UserEntity)Session["USER"];
                if (objUE.User_role == 2)
                {
                    // admin
                    gvMember.MasterTableView.GetColumn("DeleteColumn").Display = false;
                }
            }
        }

       

        protected void gvMember_UpdateCommand(object source, GridCommandEventArgs e)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            _objMemberEntity = new MemberEntity();
            MemberController _memberAccessObj = null;
            ProductCategoryEntity EntCat = null;

            MemberEntity prObj = null;
            try
            {
                _objMemberEntity.ID = Convert.ToInt32(ViewState["MemberId"]);
                _objMemberEntity.InstallType = (userControl.FindControl("txtInstallType") as TextBox).Text;
                _objMemberEntity.Firstname = (userControl.FindControl("txtFirstName") as TextBox).Text;
                _objMemberEntity.AlarmAccountNo = ((userControl.FindControl("txtAlarmAccountNo") as TextBox).Text);
                _objMemberEntity.PreviousAccountNo = ((userControl.FindControl("txtPreviousAccountNo") as TextBox).Text);
                _objMemberEntity.DateOfInstall = Convert.ToDateTime((userControl.FindControl("Rddate") as RadDatePicker).SelectedDate);
                _objMemberEntity.CancelationDate = Convert.ToDateTime((userControl.FindControl("RdCanceldate") as RadDatePicker).DbSelectedDate);
                _objMemberEntity.InstallerName = (userControl.FindControl("txtInstallerName") as TextBox).Text;
                _objMemberEntity.Lastname = (userControl.FindControl("txtLastName") as TextBox).Text;
                _objMemberEntity.Companyname = (userControl.FindControl("txtCompanyName") as TextBox).Text;
                _objMemberEntity.HouseAddress = (userControl.FindControl("txtHouseAddress") as TextBox).Text;
                _objMemberEntity.HouseCity = (userControl.FindControl("txtHouseCity") as TextBox).Text;
                _objMemberEntity.HouseProvince = (userControl.FindControl("txtprovince") as TextBox).Text;
                _objMemberEntity.HousePostelCode = Convert.ToString((userControl.FindControl("txtPostelCode") as TextBox).Text);
                _objMemberEntity.BusinessAddress = (userControl.FindControl("txtBusinessAddress") as TextBox).Text;
                _objMemberEntity.BusinessCity = (userControl.FindControl("txtBusinessCity") as TextBox).Text;
                _objMemberEntity.BusinessProvince = (userControl.FindControl("txtBusinessProvince") as TextBox).Text;
                _objMemberEntity.BusinessPostelCode = Convert.ToString((userControl.FindControl("txtBPostelCode") as TextBox).Text);
                _objMemberEntity.HousePhone = ((userControl.FindControl("txtHousePhone") as TextBox).Text);
                _objMemberEntity.CellPhone = ((userControl.FindControl("txtCellPhone") as TextBox).Text);
                _objMemberEntity.BusinessPhone = ((userControl.FindControl("txtBusinessPhone") as TextBox).Text);
                _objMemberEntity.Fax = (userControl.FindControl("txtfax") as TextBox).Text;
                _objMemberEntity.Email = (userControl.FindControl("txtemail") as TextBox).Text;
                _objMemberEntity.EmgContactName = (userControl.FindControl("txtemgname") as TextBox).Text;
                _objMemberEntity.EmgContactName1 = (userControl.FindControl("txtemgname1") as TextBox).Text;
                _objMemberEntity.EmgContactName2 = (userControl.FindControl("txtemgname1") as TextBox).Text;
                _objMemberEntity.EmgPhone = ((userControl.FindControl("txtemgPhone") as TextBox).Text);
                _objMemberEntity.EmgPhone1 = ((userControl.FindControl("txtemgPhone1") as TextBox).Text);
                _objMemberEntity.EmgPhone2 = ((userControl.FindControl("txtemgPhone2") as TextBox).Text);
                _objMemberEntity.EmgCellNo = ((userControl.FindControl("txtemgcell") as TextBox).Text);
                _objMemberEntity.EmgCellNo1 = ((userControl.FindControl("txtemgcell1") as TextBox).Text);
                _objMemberEntity.EmgCellNo2 = ((userControl.FindControl("txtemgcell2") as TextBox).Text);
                _objMemberEntity.Password = (userControl.FindControl("txtpass") as TextBox).Text;
                _objMemberEntity.Password1 = (userControl.FindControl("txtpass1") as TextBox).Text;
                _objMemberEntity.Password2 = (userControl.FindControl("txtpass2") as TextBox).Text;
                _objMemberEntity.SecurityLevel = (userControl.FindControl("txtsecurity") as TextBox).Text;
                _objMemberEntity.MonthlyAlamPayment = Convert.ToInt32((userControl.FindControl("txtmonthlyPayment") as TextBox).Text);
                _objMemberEntity.BankId = Convert.ToInt32((userControl.FindControl("radcmbBankName") as RadComboBox).SelectedValue);
                _objMemberEntity.BankAccountHoldername = (userControl.FindControl("txtAccHolderName") as TextBox).Text;
                _objMemberEntity.AccountNo = ((userControl.FindControl("txtAccNo") as TextBox).Text);
                _objMemberEntity.BankTransit = (userControl.FindControl("txtbankTransit") as TextBox).Text;
                _objMemberEntity.BankNo = ((userControl.FindControl("txtBankNo") as TextBox).Text);
                _objMemberEntity.AlarmPanelMakeModel = (userControl.FindControl("txtalarmpanel") as TextBox).Text;
                _objMemberEntity.Version = Convert.ToInt32((userControl.FindControl("txtVersion") as TextBox).Text);
                _objMemberEntity.SignalFormat = (userControl.FindControl("txtsignalformat") as TextBox).Text;
                _objMemberEntity.AlarmProduct = (userControl.FindControl("txtalarmProduct") as TextBox).Text;
                _objMemberEntity.Note = (userControl.FindControl("txtnote") as TextBox).Text;

                _memberAccessObj=new MemberController();
                listMember = new List<MemberEntity>();
                ListCat = new List<ProductCategoryEntity>();
                _memberAccessObj = new MemberController();
               


                RadListBox radlstZones = userControl.FindControl("radlstZones") as RadListBox;
                MemberEntity memberEntity;
                for (int i = 0; i < radlstZones.Items.Count; i++)
                {
                    if (radlstZones.Items[i].Checked)
                    {
                        memberEntity=new MemberEntity();
                        memberEntity.ZoneId = Convert.ToInt32(radlstZones.Items[i].Value);
                        listMember.Add(memberEntity);
                    }
                }

                RadListBox radlstProductCategory = userControl.FindControl("radlstProductCategory") as RadListBox;

                for (int i = 0; i < radlstProductCategory.Items.Count; i++)
                {
                    if (radlstProductCategory.Items[i].Checked)
                    {
                        EntCat = new ProductCategoryEntity();
                        EntCat.ProductCategory_id = Convert.ToInt32(radlstProductCategory.Items[i].Value);
                        ListCat.Add(EntCat);
                    }
                }
                if (_memberAccessObj.UpdateMember(_objMemberEntity,listMember,ListCat))
                {
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                    radlstZones.ClearSelection();
                    ViewState["MemberId"] = null;
                }
                else
                {
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "3000");
                }


                //tblAdd.Visible = false;
                //tblSearch.Visible = true;
            }
            finally
            {
                prObj = null;
            }
        }

        protected void gvMember_InsertCommand(object source, GridCommandEventArgs e)
        {
             GridEditableItem editedItem = e.Item as GridEditableItem;
            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            _objMemberEntity = new MemberEntity();

           MemberEntity prObj = null;
            ProductCategoryEntity EntCat = null;

          

            listMember = new List<MemberEntity>();
           //IList<RadListBoxItem> collection = radlstZones.SelectedItems;
           //foreach (RadListBoxItem item in collection)
           //{
           //    _objMemberEntity.ZoneId = Convert.ToInt32(item.Value);
           //    listMember.Add(_objMemberEntity);
           //}
          

 
            //try
            //{
                _objMemberEntity.ID = Convert.ToInt32(ViewState["MemberId"]);
                _objMemberEntity.InstallType = (userControl.FindControl("txtInstallType") as TextBox).Text;
                _objMemberEntity.Firstname = (userControl.FindControl("txtFirstName") as TextBox).Text;
                _objMemberEntity.AlarmAccountNo =((userControl.FindControl("txtAlarmAccountNo") as TextBox).Text);
                _objMemberEntity.PreviousAccountNo =((userControl.FindControl("txtPreviousAccountNo") as TextBox).Text);
                _objMemberEntity.DateOfInstall = Convert.ToDateTime((userControl.FindControl("Rddate") as RadDatePicker).SelectedDate);
                _objMemberEntity.CancelationDate = Convert.ToDateTime((userControl.FindControl("RdCanceldate") as RadDatePicker).SelectedDate);
                _objMemberEntity.InstallerName = (userControl.FindControl("txtInstallerName") as TextBox).Text;
                _objMemberEntity.Lastname = (userControl.FindControl("txtLastName") as TextBox).Text;
                _objMemberEntity.Companyname = (userControl.FindControl("txtCompanyName") as TextBox).Text;
                _objMemberEntity.HouseAddress = (userControl.FindControl("txtHouseAddress") as TextBox).Text;
                _objMemberEntity.HouseCity = (userControl.FindControl("txtHouseCity") as TextBox).Text;
                _objMemberEntity.HouseProvince = (userControl.FindControl("txtprovince") as TextBox).Text;
                _objMemberEntity.HousePostelCode =Convert.ToString((userControl.FindControl("txtPostelCode") as TextBox).Text);
                _objMemberEntity.BusinessAddress = (userControl.FindControl("txtBusinessAddress") as TextBox).Text;
                _objMemberEntity.BusinessCity = (userControl.FindControl("txtBusinessCity") as TextBox).Text;
                _objMemberEntity.BusinessProvince = (userControl.FindControl("txtBusinessProvince") as TextBox).Text;
                _objMemberEntity.BusinessPostelCode =Convert.ToString((userControl.FindControl("txtBPostelCode") as TextBox).Text);
                _objMemberEntity.HousePhone = ((userControl.FindControl("txtHousePhone") as TextBox).Text);
                _objMemberEntity.CellPhone = ((userControl.FindControl("txtCellPhone") as TextBox).Text);
                _objMemberEntity.BusinessPhone =((userControl.FindControl("txtBusinessPhone") as TextBox).Text);
                _objMemberEntity.Fax = (userControl.FindControl("txtfax") as TextBox).Text;
                _objMemberEntity.Email = (userControl.FindControl("txtemail") as TextBox).Text;
                _objMemberEntity.EmgContactName = (userControl.FindControl("txtemgname") as TextBox).Text;
                _objMemberEntity.EmgContactName1 = (userControl.FindControl("txtemgname1") as TextBox).Text;
                _objMemberEntity.EmgContactName2 = (userControl.FindControl("txtemgname1") as TextBox).Text;
                _objMemberEntity.EmgPhone = ((userControl.FindControl("txtemgPhone") as TextBox).Text);
                _objMemberEntity.EmgPhone1 = ((userControl.FindControl("txtemgPhone1") as TextBox).Text);
                _objMemberEntity.EmgPhone2 = ((userControl.FindControl("txtemgPhone2") as TextBox).Text);
                _objMemberEntity.EmgCellNo = ((userControl.FindControl("txtemgcell") as TextBox).Text);
                _objMemberEntity.EmgCellNo1 = ((userControl.FindControl("txtemgcell1") as TextBox).Text);
                _objMemberEntity.EmgCellNo2 = ((userControl.FindControl("txtemgcell2") as TextBox).Text);
                _objMemberEntity.Password = (userControl.FindControl("txtpass") as TextBox).Text;
                _objMemberEntity.Password1 = (userControl.FindControl("txtpass1") as TextBox).Text;
                _objMemberEntity.Password2 = (userControl.FindControl("txtpass2") as TextBox).Text;
                _objMemberEntity.SecurityLevel = (userControl.FindControl("txtsecurity") as TextBox).Text;
                _objMemberEntity.MonthlyAlamPayment =Convert.ToInt32((userControl.FindControl("txtmonthlyPayment") as TextBox).Text);
                _objMemberEntity.BankId = Convert.ToInt32((userControl.FindControl("radcmbBankName") as RadComboBox).SelectedValue);
                _objMemberEntity.BankAccountHoldername = (userControl.FindControl("txtAccHolderName") as TextBox).Text;
                _objMemberEntity.AccountNo = ((userControl.FindControl("txtAccNo") as TextBox).Text);
                _objMemberEntity.BankTransit = (userControl.FindControl("txtbankTransit") as TextBox).Text;
                _objMemberEntity.BankNo = ((userControl.FindControl("txtBankNo") as TextBox).Text);
                _objMemberEntity.AlarmPanelMakeModel = (userControl.FindControl("txtalarmpanel") as TextBox).Text;
                _objMemberEntity.Version = Convert.ToInt32((userControl.FindControl("txtVersion") as TextBox).Text);
                _objMemberEntity.SignalFormat = (userControl.FindControl("txtsignalformat") as TextBox).Text;
                _objMemberEntity.AlarmProduct = (userControl.FindControl("txtalarmProduct") as TextBox).Text;
                _objMemberEntity.Note = (userControl.FindControl("txtnote") as TextBox).Text;
                RadListBox combo = (userControl.FindControl("radlstZones") as RadListBox);

                listMember = new List<MemberEntity>();
                ListCat=new List<ProductCategoryEntity>();
                _memberAccessObj=new MemberController();
                EntCat=new ProductCategoryEntity();
               

                RadListBox radlstZones = userControl.FindControl("radlstZones") as RadListBox;
                MemberEntity memberEntity;
                for (int i = 0; i < radlstZones.Items.Count; i++)
                {
                    if (radlstZones.Items[i].Checked)
                    {
                        memberEntity = new MemberEntity();
                        memberEntity.ZoneId = Convert.ToInt32(radlstZones.Items[i].Value);
                        listMember.Add(memberEntity);
                    }
                }

                RadListBox radlstProductCategory = userControl.FindControl("radlstProductCategory") as RadListBox;

                for (int i = 0; i < radlstProductCategory.Items.Count; i++)
                {
                    if (radlstProductCategory.Items[i].Checked)
                    {
                        EntCat.ProductCategory_id = Convert.ToInt32(radlstProductCategory.Items[i].Value);
                        ListCat.Add(EntCat);
                    }
                }


            string result = _memberAccessObj.AddNewMember(_objMemberEntity, listMember, ListCat);
            if(result=="2000")
                {
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");
                   
                }
                else
                {
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "3000");
                }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        protected void gvMember_DeleteCommand(object source, GridCommandEventArgs e)
        {
            _memberAccessObj=new MemberController();
            try
            {
                bool status = _memberAccessObj.DeleteMember(Convert.ToInt32(ViewState["MemberId"]));
                if (status)
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2001");
                else
                    lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
            }
            finally
            {
                _memberAccessObj = null;
            }
        }

        protected void gvMember_ItemBound(object sender, GridItemEventArgs e)
        {
            List<MemberEntity> memberEntities = null;
            MemberController _memberController = new MemberController();
            List<ProductCategoryEntity> prdList = null;
            List<MemberEntity> lstbank = null;
           
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                var item = e.Item as GridEditFormItem;
                GridEditableItem editedItem = e.Item as GridEditableItem;
                UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

                RadListBox lstZones = (userControl.FindControl("radlstZones") as RadListBox);
                RadListBox lstProdCat = (userControl.FindControl("radlstProductCategory") as RadListBox);
                memberEntities = _memberController.GetZonesByMemberID(Convert.ToInt32(ViewState["MemberId"]));


                if (memberEntities != null)
                    foreach (var memberEntity in memberEntities)
                    {
                        for (int i = 0; i < lstZones.Items.Count; i++)
                        {
                            if (Convert.ToInt32(lstZones.Items[i].Value) == memberEntity.ZoneId)
                            {
                                lstZones.Items[i].Checked = true;
                                break;
                            }
                        }
                    }


                memberEntities = _memberController.GetProductCategoryByMemberID(Convert.ToInt32(ViewState["MemberId"]));

                if (memberEntities != null)
                    foreach (var memberEntity in memberEntities)
                    {
                        for (int i = 0; i < lstProdCat.Items.Count; i++)
                        {
                            if (Convert.ToInt32(lstProdCat.Items[i].Value) == memberEntity.CategoryId)
                            {
                                lstProdCat.Items[i].Checked = true;
                                break;
                            }
                        }
                    }

                List<MemberEntity> _objMemberEntity=new List<MemberEntity>();
                _objMemberEntity = _memberController.GetMemberDetails_search(Convert.ToInt32(ViewState["MemberId"]));

                string bankname = null;
                string BankNo = null;
                foreach (MemberEntity memberEntity in _objMemberEntity)
                {
                    bankname = memberEntity.BankName;
                    BankNo = memberEntity.BankNo;
                }
                RadComboBox rdComboBox = (userControl.FindControl("radcmbBankName") as RadComboBox);
                rdComboBox.SelectedItem.Text = bankname;

                (userControl.FindControl("txtBankNo") as TextBox).Text = BankNo;


            }
        }

        
    }
}