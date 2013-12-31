using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using NobleDAL;
using System.Data;

namespace NobleBLL
{
    public class InvoiceController
    {
        InvoiceDBAccess invObj = null;
        public static DataTable myDataTable = new DataTable();
        public static DataTable editmyDataTable = new DataTable();
        public static string flag=null;
        public static Int32 InvNo = 0; 

        public InvoiceController()
        {
            invObj = new InvoiceDBAccess();
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
        public List<InvoiceEntity> GetInvoiceLists(Int32 Member_ID)
        {

            return invObj.GetInvoiceLists(Member_ID);
        }
        public DataTable GetProductDatatable()
        {

            return invObj.GetProductDatatable();
        }

       

        public DataTable GetInvoiceDetailsByID(Int32 QuotNo)
        {

            return invObj.GetInvoiceDetailsByID(QuotNo);
        }

        public bool AddNewInvoice(InvoiceEntity quot)
        {

            return invObj.AddNewInvoice(quot);
        }

        public bool DeleteInvoiceDetails(InvoiceDetailsEntity quot)
        {

            return invObj.DeleteInvoiceDetails(quot);
        }

        public bool DeleteInvoiceHr(InvoiceEntity quot)
        {

            return invObj.DeleteInvoiceHr(quot);
        }

        public bool AddNewInvoiceDetails(InvoiceDetailsEntity quot)
        {

            return invObj.AddNewInvoiceDetails(quot);
        }

        public bool UpdateInvoice(InvoiceEntity quot)
        {

            return invObj.UpdateInvoice(quot);
        }

        public Int32 getMaxInvNo()
        {

            return invObj.getMaxInvNo();
        }

        public DataTable GetInvoiceProductDetailsByID(Int32 InvNo,Int32 Member_ID)
        {
            return invObj.GetInvoiceProductDetailsByID(InvNo, Member_ID);
        }

        public DataTable GetInvoicenHrByID(Int32 InvNo)
        {
            return invObj.GetInvoicenHrByID(InvNo);
        }
        public DataTable GetInvoiceRatesID(Int32 InvNo)
        {
            return invObj.GetInvoiceRatesID(InvNo);
        }
        public bool UpdateInvoiceFilePath(Int32 InvNo, string FilePath)
        {
            return invObj.UpdateInvoiceFilePath(InvNo, FilePath);
        }
    }
}
