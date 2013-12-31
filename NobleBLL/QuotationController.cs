using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using NobleDAL;
using System.Data;

namespace NobleBLL
{
    public class QuotationController
    {
        QuotationDBAccess quotObj = null;

        public static Int32 QuotNo = 0; 

        public QuotationController()
        {
            quotObj = new QuotationDBAccess();
        }

        public List<QuotationEntity> GetQuotationLists()
        {

            return quotObj.GetQuotationLists();
        }
        public DataTable GetProductDatatable()
        {

            return quotObj.GetProductDatatable();
        }

        public DataTable GetQuotationDetailsByID(Int32 QuotNo)
        {

            return quotObj.GetQuotationDetailsByID(QuotNo);
        }

        public bool AddNewQuotation(QuotationEntity quot)
        {

            return quotObj.AddNewQuotation(quot);
        }

        public bool DeleteQuotationDetails(QuotationDetailsEntity quot)
        {

            return quotObj.DeleteQuotationDetails(quot);
        }

        public bool DeleteQuotationHr(QuotationEntity quot)
        {

            return quotObj.DeleteQuotationHr(quot);
        }

        public bool AddNewQuotationDetails(QuotationDetailsEntity quot)
        {

            return quotObj.AddNewQuotationDetails(quot);
        }

        public bool UpdateQuotation(QuotationEntity quot)
        {

            return quotObj.UpdateQuotation(quot);
        }

        public Int32 getMaxQuotNo()
        {

            return quotObj.getMaxQuotNo();
        }

        public DataTable GetQuotationHrByID(Int32 QuotNo)
        {
            return quotObj.GetQuotationHrByID(QuotNo);
        }
        public DataTable GetQuotationRatesID(Int32 QuotNo)
        {
            return quotObj.GetQuotationRatesID(QuotNo);
        }

        public bool UpdateQuotationFilePath(Int32 QuotNo,string FilePath)
        {
            return quotObj.UpdateQuotationFilePath(QuotNo, FilePath);
        }
    }
}
