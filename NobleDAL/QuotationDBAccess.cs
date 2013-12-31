using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;


namespace NobleDAL
{
   public class QuotationDBAccess
    {
       public List<QuotationEntity> GetQuotationLists()
        {
            List<QuotationEntity> listMember = null;
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("[USP_Quotation_SelectAll]", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<QuotationEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        

                        QuotationEntity Obj = new QuotationEntity();
                        Obj.QuotNo = Convert.ToInt32(row["QuotNo"]);
                        Obj.Date = Convert.ToString(row["Date"]);
                        Obj.Validtill = Convert.ToString(row["Validtill"]);
                        Obj.title = Convert.ToString(row["title"]);
                        Obj.Firstname = Convert.ToString(row["Firstname"]);
                        Obj.Lastname = Convert.ToString(row["Lastname"]);
                        Obj.Address = Convert.ToString(row["Address"]);
                        Obj.HST = Convert.ToDouble(row["HST"]);
                        Obj.Total=Convert.ToDouble(row["Total"]);
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

       public bool AddNewQuotation(QuotationEntity quot)
       {
           SqlParameter[] parameters = new SqlParameter[]
		    {      
                //new SqlParameter("@QuotNo", quot.QuotNo),
                new SqlParameter("@QuotDate", Convert.ToDateTime(quot.Date)),
                new SqlParameter("@Validtill", Convert.ToDateTime(quot.Validtill)),
                new SqlParameter("@title", quot.title),
                new SqlParameter("@Firstname", quot.Firstname),
                new SqlParameter("@Lastname", quot.Lastname),
                new SqlParameter("@Address", quot.Address),
                new SqlParameter("@HST", quot.HST)  
		    };

           return SqlDBHelper.ExecuteNonQuery("USP_NLTR_InsertQuotation", CommandType.StoredProcedure, parameters);
       }

       public bool UpdateQuotationFilePath(Int32 QuotNo,string path)
       {
           SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@QuotNo", QuotNo),               
                new SqlParameter("@FilePath", path),
                  
		    };

           return SqlDBHelper.ExecuteNonQuery("USP_NLTR_UpdateQuotationFilePath", CommandType.StoredProcedure, parameters);
       }

       public bool AddNewQuotationDetails(QuotationDetailsEntity quot)
       {
           SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@QuotNo", quot.QuotNo),
                new SqlParameter("@Code", quot.Code),
                new SqlParameter("@Qty", quot.Qty)                
		    };

           return SqlDBHelper.ExecuteNonQuery("USP_NLTR_InsertQuotationDetails", CommandType.StoredProcedure, parameters);
       }

       public bool DeleteQuotationDetails(QuotationDetailsEntity quot)
       {
           SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@QuotNo", quot.QuotNo)           
		    };

           return SqlDBHelper.ExecuteNonQuery("USP_NLTR_DeleteQuotationDetails", CommandType.StoredProcedure, parameters);
       }

       public bool DeleteQuotationHr(QuotationEntity quot)
       {
           SqlParameter[] parameters = new SqlParameter[]
	        {
		        new SqlParameter("@QuotNo", quot.QuotNo)    
	        };

           return SqlDBHelper.ExecuteNonQuery("USP_NLTR_DeleteQuotationHr", CommandType.StoredProcedure, parameters);
       }

       public bool UpdateQuotation(QuotationEntity quot)
       {
           SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@QuotNo", quot.QuotNo),
                new SqlParameter("@QuotDate", Convert.ToDateTime(quot.Date)),
                new SqlParameter("@Validtill", Convert.ToDateTime(quot.Validtill)),
                new SqlParameter("@title", quot.title),
                new SqlParameter("@Firstname", quot.Firstname),
                new SqlParameter("@Lastname", quot.Lastname),
                new SqlParameter("@Address", quot.Address),
                new SqlParameter("@HST", quot.HST),                
		    };

           return SqlDBHelper.ExecuteNonQuery("USP_NLTR_UpdateQuotation", CommandType.StoredProcedure, parameters);
       }

       public Int32 getMaxQuotNo()
       {

           Int32 Quotno = 0;
           using (DataTable table = SqlDBHelper.ExecuteSelectCommand("[USP_MS_GetMaxQuotNo]", CommandType.StoredProcedure))
           {
               
               if (table.Rows.Count > 0)
               {                   
                   Quotno = Convert.ToInt32(table.Rows[0]["QuotNo"].ToString());
               }
           }

           return Quotno;
       }

       public DataTable GetQuotationDetailsByID(Int32 QuotNo)
       {
           DataTable listMember = null;

           SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@QuotNo", QuotNo)
		    };

           using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetQuotationDetails", CommandType.StoredProcedure, parameters))
           {
               if (table.Rows.Count > 0)
               {
                   return table;
                   
               }
           }

           return listMember;
       }
       public DataTable GetQuotationHrByID(Int32 QuotNo)
       {
           DataTable listMember = null;

           SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@QuotNo", QuotNo)
		    };

           using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetQuotationHr", CommandType.StoredProcedure, parameters))
           {
               if (table.Rows.Count > 0)
               {
                   return table;

               }
           }

           return listMember;
       }

       public DataTable GetQuotationRatesID(Int32 QuotNo)
       {
           DataTable listMember = null;

           SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@QuotNo", QuotNo)
		    };

           using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetQuotationRates", CommandType.StoredProcedure, parameters))
           {
               if (table.Rows.Count > 0)
               {
                   return table;

               }
           }

           return listMember;
       }
       
    }
}
