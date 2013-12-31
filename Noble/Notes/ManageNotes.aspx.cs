using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleEntity;
using Noble.Common;
using System.Configuration;
using Telerik.Web.UI;

namespace Noble.Notes
{
    public partial class ManageNotes : System.Web.UI.Page
    {

        GeneralController genAccessObj = null;
        NotesController objNC = null;
        UserController objUC = null;
        static string noteID = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //((Label)Master.FindControl("lblPageHeading")).Text = "Manage ";
                ((Label)Master.FindControl("lblFirstHeader")).Text = "Manage";
                ((Label)Master.FindControl("lblSecondHeader")).Text = "Notes";
                //BindDropDown();
                //BindGrid();
                if (Session["SelectedMember"] != null)
                {
                    ViewState["MemberName"] = string.Concat(Session["SelectedMember"].ToString().Split(';')[2].ToString(), ",", Session["SelectedMember"].ToString().Split(';')[1].ToString());
                }
            }
        }

        private void BindGrid()
        {
            objNC = new NotesController();

            try
            {
                if (Session["SelectedMember"] != null)
                {
                    gvNotes.DataSource = objNC.GetMemberNotesList(Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]));
                }
            }
            finally
            {
                objNC = null;
            }
        }

        private void BindGridonSave()
        {
            objNC = new NotesController();

            try
            {
                if (Session["SelectedMember"] != null)
                {
                    gvNotes.DataSource = objNC.GetMemberNotesList(Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]));
                    gvNotes.DataBind();
                }
            }
            finally
            {
                objNC = null;
            }
        }

       

        //protected void btnAddNotes_Click(object sender, EventArgs e)
        //{
        //    tblAdd.Visible = true;
        //    tblNotes.Visible = false;

        //    redNotes.Text = string.Empty;
        //    lblMessage.Text = string.Empty;
        //    ddlStatus.SelectedIndex = 0;
        //    ddlUser.SelectedIndex = 0;
        //}

        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    tblAdd.Visible = false;
        //    tblNotes.Visible = true;

        //    redNotes.Text = string.Empty;
        //    lblMessage.Text = string.Empty;

        //    ddlStatus.SelectedIndex =0;
        //    ddlUser.SelectedIndex =0;
        //    ddlUser.Visible = false;
        //    rfUser.Visible = false;

        //    BindGridonSave();
        //}

        //protected void btnSaveNotes_Click(object sender, EventArgs e)
        //{
        
        //    }
        //}

        

        protected void gvNotes_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            BindGrid();
        }

        protected void gvNotes_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            //if (e.CommandName.Equals("Edit"))
            //{
            //    GridDataItem item = (GridDataItem)e.Item;
            //    string id = item.GetDataKeyValue("ID").ToString();
            //    Response.Redirect("EditNotes.aspx?id=" + id);
            //}

            if (e.CommandName == RadGrid.EditCommandName)
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;

                noteID = editedItem.GetDataKeyValue("ID").ToString();

                //noteID = Convert.ToInt32(editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["QuotNo"].ToString());
            }
        }



        /*protected void gvNotes_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)// to access a row 
            {
                GridDataItem item = (GridDataItem)e.Item;
                object objTemp = item.GetDataKeyValue("Status_code").ToString();
                if (objTemp != null && objTemp.ToString().Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    ImageButton ibEdit = ((ImageButton)item["EditColumn"].Controls[0]);
                    if (ibEdit != null)
                    {
                        ibEdit.Enabled = false;
                        ibEdit.ToolTip = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "4002");
                    }
                }

                //object objTemp = gvNotes.DataKeys[e.Row.RowIndex].Values["Status_code"] as object;
                //        if (objTemp != null && objTemp.ToString().Equals("C",StringComparison.InvariantCultureIgnoreCase))
                //        {
                //            ImageButton ibEdit = ((ImageButton)e.Row.FindControl("btnEdit"));
                //            if (ibEdit != null)
                //            {
                //                ibEdit.Enabled = false;
                //                ibEdit.ToolTip = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "4002");
                //            }
                //        }
            }
        }*/

        protected void gvNotes_DeleteCommand(object source, GridCommandEventArgs e)
        {

        }

        protected void gvNotes_InsertCommand(object source, GridCommandEventArgs e)
        {
            objNC = new NotesController();
            objUC = new UserController();

            UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);

            if (Page.IsValid)
            {
                NotesEntity meObj = null;
                try
                {
                    meObj = new NotesEntity();

                    if (Session["SelectedMember"] != null && Session["LOGINUSERID"] != null)
                    {
                        meObj.Member_id = Convert.ToInt32(Session["SelectedMember"].ToString().Split(';')[0]);
                        //meObj.Note_text = redNotes.Text.Trim();
                        meObj.Note_text = (userControl.FindControl("redNotes") as RadEditor).Content;
                        //meObj.Status_code = ddlStatus.SelectedItem.Value;
                        meObj.Status_code = (userControl.FindControl("ddlStatus") as DropDownList).SelectedItem.Value;
                        meObj.Created_by = Convert.ToInt32(Session["LOGINUSERID"]);
                        //if (ddlStatus.SelectedItem.Value.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                        if (meObj.Status_code.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                        {
                            //meObj.Assigned_toId = Convert.ToInt32(ddlUser.SelectedItem.Value);
                             meObj.Assigned_toId  = Convert.ToInt32((userControl.FindControl("ddlUser") as DropDownList).SelectedItem.Value);
                        }


                        if (objNC.AddMemberNotes(meObj))
                        {
                            lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");

                            // sent mail functionality
                            //if (ddlStatus.SelectedItem.Value.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                            if (meObj.Status_code.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                            {
                                List<MemberEntity> onjEmailId = objUC.GetAdminEmailId(Convert.ToInt32((userControl.FindControl("ddlUser") as DropDownList).SelectedItem.Value));

                                MailEntity objMailEntity = new MailEntity();
                                objMailEntity.Subject = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "4000");
                                string body = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "4001");
                                objMailEntity.Body = body.Replace("[YYY]", ViewState["MemberName"].ToString());
                                objMailEntity.FromAddress = ConfigurationManager.AppSettings["FromAddress"];

                                MailUtility objMU = new MailUtility();
                                objMU.OrgarnizeEmailAsync(onjEmailId, objMailEntity, false);
                            }

                            //BindGrid();
                        }
                        else
                        {
                            lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
                        }
                    }

                }
                finally
                {
                    meObj = null;
                }
            }
        }

        protected void gvNotes_UpdateCommand(object source, GridCommandEventArgs e)
        {
            if (Page.IsValid)
            {
                objNC = new NotesController();
                objUC = new UserController();
                UserControl userControl = (UserControl)e.Item.FindControl(GridEditFormItem.EditFormUserControlID);
                NotesEntity objEntity = null;
                try
                {
                    if (Session["LOGINUSERID"] != null || Session["USER"] != null)
                    {
                        objEntity = new NotesEntity();


                        objEntity.ID = Convert.ToInt32(noteID);


                        objEntity.Note_text = (userControl.FindControl("redNotes") as RadEditor).Content;
                        objEntity.Status_code = (userControl.FindControl("ddlStatus") as DropDownList).SelectedItem.Value;
                        objEntity.Updated_by = Convert.ToInt32(Session["LOGINUSERID"]);

                        if (objEntity.Status_code.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                        {
                            objEntity.Assigned_toId = Convert.ToInt32((userControl.FindControl("ddlUser") as DropDownList).SelectedItem.Value);
                        }

                        //UserEntity uObj = (UserEntity)Session["USER"];
                        //string adminName = uObj.Last_name + " , " + uObj.First_name;

                        bool status = objNC.UpdateMemberNotes(objEntity);
                        if (status)
                        {
                            lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");

                            // sent mail functionality
                            if (objEntity.Status_code.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                            {
                                List<MemberEntity> onjEmailId = objUC.GetAdminEmailId(Convert.ToInt32((userControl.FindControl("ddlUser") as DropDownList).SelectedItem.Value));

                                MailEntity objMailEntity = new MailEntity();
                                objMailEntity.Subject = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "4000");
                                string body = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "4001");
                                objMailEntity.Body = body.Replace("[YYY]", ViewState["MemberName"].ToString());
                                objMailEntity.FromAddress = ConfigurationManager.AppSettings["FromAddress"];

                                MailUtility objMU = new MailUtility();
                                objMU.OrgarnizeEmailAsync(onjEmailId, objMailEntity, false);
                            }

                        }
                        else
                        {
                            lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2002");
                        }
                    }
                }
                finally
                {
                    objEntity = null;
                    objNC = null;
                }
            }
        }

        protected void gvNotes_PreRender(object sender, EventArgs e)
        {

        }

       
    }
}