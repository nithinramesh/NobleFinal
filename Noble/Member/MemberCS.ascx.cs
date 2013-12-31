using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using NobleBLL;
using NobleDAL;
using NobleEntity;
using Noble.Common;
using Telerik.Web.UI;

namespace Noble.Member
{
    public partial class MemberCS : System.Web.UI.UserControl
    {
        private object _dataItem = null;
        private MemberController memobj = null;
        private MemberEntity EntObj = null;
        
        private MemberController _memberController = new MemberController();
        private ProductCategoryController _categoryController=new ProductCategoryController();

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

            this.DataBinding += new EventHandler(ProductCS_DataBinding);

        }

        void ProductCS_DataBinding(object sender, EventArgs e)
        {
            //List<MemberEntity> lstbank = null;
            //lstbank = _memberController.GetAllBank();
            //radcmbBankName.DataSource = lstbank;
            //radcmbBankName.DataTextField = "BankName";
            //radcmbBankName.DataValueField = "BankId";
            //radcmbBankName.DataBind();


            //MemberEntity _objMemberEntity=new MemberEntity();
            //object objBank = DataBinder.Eval(DataItem, "BankId");
            
            //int bankId=0;
            //if(objBank != null)
            //    bankId = Convert.ToInt32(objBank);

            //radcmbBankName.SelectedIndex =
            //  radcmbBankName.Items.IndexOf(radcmbBankName.Items.FindItemByValue(bankId.ToString()));
            

        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
        
       

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            
            {
                if (ViewState["PostBack"] == null)
                {
                    List<MemberEntity> memberEntities = null;
                    List<ProductCategoryEntity> prdList = null;
                    List<MemberEntity> lstbank = null;
                    memberEntities = _memberController.GetAllZones();
                    radlstZones.DataSource = memberEntities;
                    radlstZones.DataTextField = "ZoneName";
                    radlstZones.DataValueField = "ZoneId";
                    radlstZones.DataBind();

                    prdList = _categoryController.GetProductCategoryDetails();
                    radlstProductCategory.DataSource = prdList;
                    radlstProductCategory.DataTextField = "ProductCategory_name";
                    radlstProductCategory.DataValueField = "ProductCategory_id";
                    radlstProductCategory.DataBind();

                    lstbank = _memberController.GetAllBank();
                    radcmbBankName.DataSource = lstbank;
                    radcmbBankName.DataTextField = "BankName";
                    radcmbBankName.DataValueField = "BankId";
                    radcmbBankName.DataBind();

                    radlstProductCategory.Style.Add("Scroll", "Yes");
                    radlstZones.Style.Add("Scroll", "Yes");
                    ViewState["PostBack"] = "PostBack";
                }
            }
       

        }



        protected void radcmbBankName_SelectedIndexChanged1(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            EntObj = new MemberEntity();
            EntObj.BankId = Convert.ToInt32(radcmbBankName.SelectedValue);
            memobj = new MemberController();
            txtbankno.Text = memobj.GetBankNo(EntObj.BankId);
           
        }

        

    }
}