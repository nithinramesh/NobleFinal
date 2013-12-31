using System;

namespace Noble.ProductCategory
{
    public partial class ProductCategoryCS : System.Web.UI.UserControl
    {
        private object _dataItem = null;
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
            
            this.DataBinding += new EventHandler(ProductCategoryCS_DataBinding);

        }

        void ProductCategoryCS_DataBinding(object sender, EventArgs e)
        {
            
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}