using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleDAL;
using NobleEntity;

namespace NobleBLL
{
    public class ProductController
    {
        ProductDAL objProduct=null;
        
        public ProductController()
        {
            objProduct = new ProductDAL();
        }

        public bool InsertNewProduct(string ProductCode, string ProductDescription, double ProductPrice,int productCategoryId)
        {
            return objProduct.InserProduct(ProductCode, ProductDescription, ProductPrice,productCategoryId);
        }

        public bool DeleteProduct(int Id)
        {
            return objProduct.DeleteProductById(Id);
        }
        public bool UpdateProduct(ProductEntity objcat)
        {
            return objProduct.UpdateProduct(objcat);
        }
        public List<ProductEntity> GetProductDetails()
        {
            return objProduct.GetAllProducts();
        }
        public ProductEntity GetProductByID(int Id)
        {
            return objProduct.GetProductByID(Id);
        }

        public List<ProductEntity> GetProductDetailsByCatId(int CategoryID)
        {
            return objProduct.GetProductByCategoryID(CategoryID);
        }

    }
}
