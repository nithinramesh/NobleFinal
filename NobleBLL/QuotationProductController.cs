using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using NobleDAL;
using System.Data;

namespace NobleBLL
{
    public class QuotationProductController
    {
        ProductDBAccess prodObj = null;
        public static DataTable myDataTable = new DataTable();
        public static DataTable editmyDataTable = new DataTable();
        public static bool AddMode = true;
        public static int QuotNo;

        public DataTable GetProductPrice(string code)
        {
            prodObj = new ProductDBAccess();
            return prodObj.GetProductPrice(code);
        }

        public static void makeDatatable()
        {
            if (myDataTable.Columns.Contains("Code") == false)
                {
                    myDataTable.Columns.Add("ID");
                    myDataTable.Columns.Add("Code");
                    myDataTable.Columns.Add("ProductName");
                    myDataTable.Columns.Add("Price");
                    myDataTable.Columns.Add("Qty");
                    myDataTable.Columns.Add("Total");
                }
            
        }

        public DataTable GetProductDetails()
        {
          
            prodObj = new ProductDBAccess();
            return prodObj.GetProductDetailsINV_QUOT();
        }
        public DataTable GetProductDetailsByID(Int32 QuotNo)
        {
          
            prodObj = new ProductDBAccess();
            return prodObj.GetProductDetailsByID(QuotNo);
        }

        public DataTable GetProductbyCatID(int ProdCatID)
        {

            prodObj = new ProductDBAccess();
            return prodObj.GetProductbyCatID(ProdCatID);
        }
    }
    
}
