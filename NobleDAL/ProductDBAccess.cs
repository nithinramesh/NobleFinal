using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
    public class ProductDBAccess
    {

        public DataTable GetProductPrice(string code)
        {
           
            SqlParameter[] parameters = new SqlParameter[]
		    {   
                 new SqlParameter("@Code", code),
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("[USP_GetProductPrice]", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    
                    return table;

                }
            }
            return null;
        }

        public DataTable GetProductDetailsINV_QUOT()
        {
            DataTable listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			   // new SqlParameter("@QuotNo", QuotNo)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetProductDetails", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    return table;

                }
            }

            return listMember;
        }
        public DataTable GetProductDetailsByID(Int32 QuotNo)
        {
            DataTable listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@QuotNo", QuotNo)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NLTR_GetProductDetailsByID", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    return table;

                }
            }

            return listMember;
        }

        public DataTable GetProductbyCatID(Int32 ProdCatID)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {      
                 new SqlParameter("@ProdCatID", ProdCatID),
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("[USP_Product_ByCatID]", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {

                    return table;

                }
            }
            return null;
        }

    }


}
