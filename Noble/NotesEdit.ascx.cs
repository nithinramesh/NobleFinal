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

namespace Noble
{
    public partial class NotesEdit : System.Web.UI.UserControl
    {
        private object _dataItem = null;
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

            object tocValue = DataBinder.Eval(DataItem, "Note_text");

            //redNotes.Content = tocValue.ToString();
            Label1.Text = tocValue.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveNotes_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

    }
}