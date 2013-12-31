using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
    public class ProductCategoryDAL
    {
        public bool InserProductCategory(string ProductCategoryname)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {     
                new SqlParameter("@ProductCategoryName",ProductCategoryname),
                new SqlParameter("@out_message", SqlDbType.VarChar,5)
                { 
                    Direction = ParameterDirection.Output 
                }
                
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_PRD_ProductCategory_Insert", CommandType.StoredProcedure, parameters);
        }
        public bool UpdateProductCategory(ProductCategoryEntity objProductCategory)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {     
               new SqlParameter("@ProductCategoryId",objProductCategory.ID),
               new SqlParameter("@ProductCategoryName",objProductCategory.ProductCategory_name),
               new SqlParameter("@out_message", SqlDbType.VarChar,5)
                { 
                    Direction = ParameterDirection.Output 
                }
                		    
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_PRD_ProductCategoryUpdateById", CommandType.StoredProcedure, parameters);
        }
        public List<ProductCategoryEntity> GetAllProductCategory()
        {
            List<ProductCategoryEntity> listMember = null;

          
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_PRD_ProductCategory_SelectAll", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<ProductCategoryEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        ProductCategoryEntity catObj = new ProductCategoryEntity();
                        catObj.ID = Convert.ToInt32(row["ProductCategoryId"]);
                        catObj.ProductCategory_id = Convert.ToInt32(row["ProductCategoryId"]);
                        catObj.ProductCategory_name = Convert.ToString(row["ProductCategoryName"]);
                        listMember.Add(catObj);
                    }
                }
            }

            return listMember;
        }
        public ProductCategoryEntity GetProductCategoryByID( int ProductCategoryID)
        {
            ProductCategoryEntity prdObj = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@ProductCategoryId", ProductCategoryID)
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_PRD_ProductCategory_SelectByID", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    prdObj = new ProductCategoryEntity();

                    prdObj.ProductCategory_name = Convert.ToString(row["ProductCategoryName"]);
                   
                }
            }

            return prdObj;
        }

        public bool DeleteProductCategoryById(int ProductcategoryId)
        {

            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@ProductCategoryId", ProductcategoryId)
			  
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_PRD_ProductCategory_DeleteById", CommandType.StoredProcedure, parameters);


        }
    }
}
