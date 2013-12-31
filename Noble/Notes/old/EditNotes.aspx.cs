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

namespace Noble.Notes
{
    public partial class EditNotes : System.Web.UI.Page
    {
        GeneralController genAccessObj = null;
        NotesController objNC = null;
        UserController obUc = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();

                if (Request.QueryString["id"] != null)
                {
                    ViewState["NoteId"] = Request.QueryString["id"];
                }

                ((Label)Master.FindControl("lblPageHeading")).Text = "Manage Notes";
                GetNoteDetails();
            }
        }

        private void GetNoteDetails()
        {
            objNC = new NotesController();
            NotesEntity objEntity = null;

            try
            {
                objEntity = objNC.GetNotesDetails(Convert.ToInt32(ViewState["NoteId"]));
                if (objEntity != null)
                {
                    txtNotes.Text = objEntity.Note_text.Trim();
                    ViewState["MemberName"] = objEntity.Member_name.Trim();
                    if (ddlStatus.Items.FindByValue(objEntity.Status_code) != null)
                    {
                        ddlStatus.SelectedValue = objEntity.Status_code;
                    }

                    if (ddlStatus.SelectedItem.Value.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (ddlUser.Items.FindByValue(objEntity.Assigned_toId.ToString()) != null)
                        {
                            ddlUser.SelectedValue = objEntity.Assigned_toId.ToString();
                            ddlUser.Visible = true;
                        }
                    }
                    else
                    {
                        ddlUser.Visible = false;
                    }
                }
            }
            finally
            {
                objEntity = null;
                objNC = null;
            }
        }

        private void BindDropDown()
        {
            genAccessObj = new GeneralController();
            obUc = new UserController();

            ddlStatus.DataSource = genAccessObj.GetNoteStatus();
            ddlStatus.DataValueField = "Key";
            ddlStatus.DataTextField = "Value";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("Select", "-1"));

            ddlUser.DataSource = obUc.GetActiveSuperAdminandAdmin();
            ddlUser.DataValueField = "ID";
            ddlUser.DataTextField = "Full_name";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("Select", "-1"));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageNotes.aspx", true);
        }

        protected void btnSaveNotes_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                objNC = new NotesController();
                obUc = new UserController();

                NotesEntity objEntity = null;
                try
                {
                    if (Session["LOGINUSERID"] != null || Session["USER"] != null)
                    {
                        objEntity = new NotesEntity();
                        objEntity.ID = Convert.ToInt32(ViewState["NoteId"]);
                        objEntity.Note_text = txtNotes.Text.Trim();
                        objEntity.Status_code = ddlStatus.SelectedItem.Value;
                        objEntity.Updated_by = Convert.ToInt32(Session["LOGINUSERID"]);

                        if (ddlStatus.SelectedItem.Value.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                        {
                            objEntity.Assigned_toId = Convert.ToInt32(ddlUser.SelectedItem.Value);
                        }

                        //UserEntity uObj = (UserEntity)Session["USER"];
                        //string adminName = uObj.Last_name + " , " + uObj.First_name;

                        bool status = objNC.UpdateMemberNotes(objEntity);
                        if (status)
                        {
                            lblMessage.Text = XMLParser.ReadKeyValue(Server.MapPath("~/Messages.xml"), "2000");

                            // sent mail functionality
                            if (ddlStatus.SelectedItem.Value.Equals("T", StringComparison.InvariantCultureIgnoreCase))
                            {
                                List<MemberEntity> onjEmailId = obUc.GetAdminEmailId(Convert.ToInt32(ddlUser.SelectedItem.Value));

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

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedItem.Value.Equals("T", StringComparison.InvariantCultureIgnoreCase))
            {
                ddlUser.Visible = true;
                rfUser.Visible = true;
            }
            else
            {
                ddlUser.Visible = false;
                rfUser.Visible = false;
            }
        }
    }
}