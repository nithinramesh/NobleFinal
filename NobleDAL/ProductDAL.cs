using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
    public class ProductDAL
    {
        public bool InserProduct(string ProductCode, string ProductDescription, double ProductPrice,int productCategoryId)
        {
            var parameters = new SqlParameter[]
		    {     
                new SqlParameter("@ProductCode",ProductCode),
                new SqlParameter("@ProductDescription",ProductDescription),
                new SqlParameter("@ProductPrice",ProductPrice),
                new SqlParameter("@productCategoryId",productCategoryId),
                new SqlParameter("@out_message", SqlDbType.VarChar,5)
                { 
                    Direction = ParameterDirection.Output 
                }
                
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_PRD_Product_Insert", CommandType.StoredProcedure, parameters);
        }


        public bool UpdateProduct(ProductEntity objProduct)
        {
            var parameters = new SqlParameter[]
		    {     
               new SqlParameter("@ProductId",objProduct.ProductID),
               new SqlParameter("@ProductCode",objProduct.ProductCode),
               new SqlParameter("@ProductDescription",objProduct.ProductDescription),
               new SqlParameter("@productPrice",objProduct.ProductPrice),
               new SqlParameter("@out_message", SqlDbType.VarChar,5)
                { 
                    Direction = ParameterDirection.Output 
                }
                		    
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_PRD_ProductsUpdateById", CommandType.StoredProcedure, parameters);
        }

        public List<ProductEntity> GetAllProducts()
        {
            List<ProductEntity> listMember = null;


            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_PRD_Products_SelectAll", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<ProductEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        var catObj = new ProductEntity();
                        catObj.ID = Convert.ToInt32(row["ProductId"]);
                        catObj.ProductID = Convert.ToInt32(row["ProductId"]);
                        catObj.ProductCode = Convert.ToString(row["Productcode"]);
                        catObj.ProductDescription = Convert.ToString(row["ProductDescription"]);
                        catObj.ProductPrice = Convert.ToDouble(row["ProductPrice"]);
                        listMember.Add(catObj);
                    }
                }
            }

            return listMember;
        }

        public ProductEntity GetProductByID(int ProductID)
        {
            ProductEntity prdObj = null;

            var parameters = new SqlParameter[]
		    {
			    new SqlParameter("@ProductId", ProductID)
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_PRD_Product_SelectByID", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    prdObj = new ProductEntity();

                    prdObj.ProductCode = Convert.ToString(row["ProductCode"]);
                    prdObj.ProductDescription = Convert.ToString(row["ProductDescription"]);
                    prdObj.ProductPrice = Convert.ToDouble(row["ProductPrice"]);


                }
            }

            return prdObj;
        }

        public List<ProductEntity> GetProductByCategoryID(int categoryid)
        {
            var prdObj = new ProductEntity();
            List<ProductEntity> listMember = null;
           
            var parameters = new SqlParameter[]
		    {
			    new SqlParameter("@CategoryId", categoryid)
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_PRD_Product_SelectByCategoryID", CommandType.StoredProcedure, parameters))
            {


                if (table.Rows.Count > 0)
                {
                    listMember = new List<ProductEntity>();
                    foreach (DataRow row in table.Rows)
                    {

                        prdObj.ProductCode = Convert.ToString(row["ProductCode"]);
                        prdObj.ProductDescription = Convert.ToString(row["ProductDescription"]);
                        prdObj.ProductPrice = Convert.ToDouble(row["ProductPrice"]);
                        prdObj.ID = Convert.ToInt32(row["ProductId"]);
                        listMember.Add(prdObj);
                    }
                }

               
            }

            return listMember;
        }

        public bool DeleteProductById(int ProductId)
        {

            var parameters = new SqlParameter[]
		    {
                new SqlParameter("@ProductId", ProductId)
			  
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_PRD_Products_DeleteById", CommandType.StoredProcedure, parameters);


        }

    }
}
