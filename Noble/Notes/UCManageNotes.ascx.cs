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
    public partial class UCManageNotes : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        GeneralController genAccessObj = null;
        NotesController objNC = null;
        UserController objUC = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///          Required method for Designer support - do not modify
        ///          the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataBinding += new System.EventHandler(this.Product_Binding);

        }
        #endregion
        public object DataItem
        {
            get
            {
                return this._dataItem;
            }
            set
            {
                this._dataItem = value;
            }
        }

        protected void Product_Binding(object sender, System.EventArgs e)
        {
            object tocValue = DataBinder.Eval(DataItem, "Status_text");

            object index = DataBinder.Eval(DataItem, "Status_code");

            object noteEditor = DataBinder.Eval(DataItem, "Note_text");
            redNotes.Content = noteEditor.ToString();

            //if (tocValue == DBNull.Value)
            //{
            //    tocValue = "Mrs.";
            //}

            BindDropDown();

            if (tocValue != DBNull.Value)
            {
                //ddlStatus.SelectedItem.Text = tocValue.ToString();
                ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByValue(Convert.ToString(index)));
              //  ddlStatus.SelectedIndex = Convert.ToInt16(index.ToString());
            }
            ddlStatus.DataSource = null;

           

        }

        private void BindDropDown()
        {
            genAccessObj = new GeneralController();
            objUC = new UserController();

            ddlStatus.DataSource = genAccessObj.GetNoteStatus();
            ddlStatus.DataValueField = "Key";
            ddlStatus.DataTextField = "Value";
            ddlStatus.DataBind();
            ddlStatus.Items.Insert(0, new ListItem("Select", "-1"));


            ddlUser.DataSource = objUC.GetActiveSuperAdminandAdmin();
            ddlUser.DataValueField = "ID";
            ddlUser.DataTextField = "Full_name";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("Select", "-1"));
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

        protected void btnSaveNotes_Click(object sender, EventArgs e)
        {
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
      

    }
}