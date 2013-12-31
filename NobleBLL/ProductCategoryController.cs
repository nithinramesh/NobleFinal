using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleDAL;
using NobleEntity;
using System.Data;

namespace NobleBLL
{
    
    public class ProductCategoryController
    {
        ProductCategoryDAL objProductCategory=null;
        
        public ProductCategoryController()
        {
            objProductCategory = new ProductCategoryDAL();
        }

        public bool InsertNewProductCategory(string ProductCategoryname)
        {
            return objProductCategory.InserProductCategory(ProductCategoryname);
        }

        public bool DeleteProductCategory(int Id)
        {
            return objProductCategory.DeleteProductCategoryById(Id);
        }
        public bool UpdateCategory(ProductCategoryEntity objcat)
        {
            return objProductCategory.UpdateProductCategory(objcat);
        }
        public List<ProductCategoryEntity> GetProductCategoryDetails()
        {
            return objProductCategory.GetAllProductCategory();
        }
        public ProductCategoryEntity GetProductCategoryByID(int Id)
        {
            return objProductCategory.GetProductCategoryByID(Id);
        }

      

    }
}
