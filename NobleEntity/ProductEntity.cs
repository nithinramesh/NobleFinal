using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class ProductEntity : BaseEntity
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductDescription { get; set; }
        public double ProductPrice { get; set; }
    }
}
