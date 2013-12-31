using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
    public class InvoiceDBAccess
    {
        public List<InvoiceEntity> GetInvoiceLists(Int32 Member_ID)
        {
            List<InvoiceEntity> listMember = null;
            SqlParameter[] parameters = new SqlParameter[]
		    {      
               new SqlParameter("@Member_ID",Member_ID) 
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("[USP_Invoice_SelectAll]", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<InvoiceEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        InvoiceEntity Obj = new InvoiceEntity();
                        Obj.InvNo = Convert.ToInt32(row["InvNo"]);
                        Obj.Member_ID = Convert.ToInt32(row["Member_ID"]);
                        Obj.Date = Convert.ToString(row["Date"]);
                        Obj.DueDate = Convert.ToString(row["DueDate"]);
                        Obj.title = Convert.ToString(row["title"]);
                        Obj.Firstname = Convert.ToString(row["Firstname"]);
                        Obj.Lastname = Convert.ToString(row["Lastname"]);
                        Obj.Address = Convert.ToString(row["Address"]);
                        Obj.HST = Convert.ToDouble(row["HST"]);
                        Obj.Total = Convert.ToDouble(row["Total"]);
                        Obj.FilePath = Convert.ToString(row["FilePath"]);
                        listMember.Add(Obj);
                    }
                }
            }
            return listMember;
        }

        public DataTable GetProductDatatable()
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {      
                
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("[USP_Product_SelectAll]", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {

                    return table;

                }
            }
            return null;
        }

       

        public bool AddNewInvoice(InvoiceEntity Inv)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                //new SqlParameter("@InvNo", Inv.InvNo),                
                new SqlParameter("@Member_ID",Inv.Member_ID),
                new SqlParameter("@InvDate", Convert.ToDateTime(Inv.Date)),
                new SqlParameter("@DueDate", Convert.ToDateTime(Inv.DueDate)),
                new SqlParameter("@title", Inv.title),
                new SqlParameter("@Firstname", Inv.Firstname),
                new SqlParameter("@Lastname", Inv.Lastname),
                new SqlParameter("@Address", Inv.Address),
                new SqlParameter("@HST", Inv.HST),
		    };

            return SqlDBHelper.ExecuteNonQuery("[USP_NLTR_InsertInvoice]", CommandType.StoredProcedure, parameters);
        }

        public bool AddNewInvoiceDetails(InvoiceDetailsEntity Inv)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@InvNo", Inv.InvNo),
                new SqlParameter("@Code", Inv.Code),
                new SqlParameter("@Qty", Inv.Qty), 
                new SqlParameter("@Regular", Inv.Regular) 
               
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_InsertInvoiceDetails", CommandType.StoredProcedure, parameters);
        }

        public bool DeleteInvoiceDetails(InvoiceDetailsEntity Inv)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@InvNo", Inv.InvNo)           
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_DeleteInvoiceDetails", CommandType.StoredProcedure, parameters);
        }

        public bool DeleteInvoiceHr(InvoiceEntity Inv)
        {
            SqlParameter[] parameters = new SqlParameter[]
	        {
		        new SqlParameter("@InvNo", Inv.InvNo)    
	        };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_DeleteInvoiceHr", CommandType.StoredProcedure, parameters);
        }

        public bool UpdateInvoice(InvoiceEntity Inv)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@InvNo", Inv.InvNo),
                //new SqlParameter("@Member_ID",Inv.Member_ID),
                new SqlParameter("@QuotDate", Convert.ToDateTime(Inv.Date)),
                new SqlParameter("@DueDate", Convert.ToDateTime(Inv.DueDate)),
                new SqlParameter("@title", Inv.title),
                new SqlParameter("@Firstname", Inv.Firstname),
                new SqlParameter("@Lastname", Inv.Lastname),
                new SqlParameter("@Address", Inv.Address),
                new SqlParameter("@HST", Inv.HST)
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_UpdateInvoice", CommandType.StoredProcedure, parameters);
        }

        public Int32 getMaxInvNo()
        {

            Int32 InvNo = 0;
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("[USP_MS_GetMaxInvNo]", CommandType.StoredProcedure))
            {

                if (table.Rows.Count > 0)
                {
                    InvNo = Convert.ToInt32(table.Rows[0]["InvNo"].ToString());
                }
            }

            return InvNo;
        }

        public DataTable GetInvoiceDetailsByID(Int32 InvNo)
        {
            DataTable listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@InvNo", InvNo)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetInvoiceDetails", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    return table;

                }
            }

            return listMember;
        }

        public DataTable GetInvoiceProductDetailsByID(Int32 InvNo, Int32 Member_ID)
        {
            DataTable listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@InvNo", InvNo),
                new SqlParameter("@Member_ID", Member_ID)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetInvoiceProductDetailsByID", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    return table;

                }
            }

            return listMember;
        }

        public DataTable GetInvoicenHrByID(Int32 InvNo)
        {
            DataTable listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@InvNo", InvNo)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetInvoiceHr", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    return table;

                }
            }

            return listMember;
        }

        public DataTable GetInvoiceRatesID(Int32 InvNo)
        {
            DataTable listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@InvNo", InvNo)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetInvoiceRates", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    return table;

                }
            }

            return listMember;
        }

        public bool UpdateInvoiceFilePath(Int32 InvNo, string path)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@InvNo", InvNo),               
                new SqlParameter("@FilePath", path),
                  
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NLTR_UpdateInvoiceFilePath", CommandType.StoredProcedure, parameters);
        }
    }
}
