using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class ProductCategoryEntity : BaseEntity
    {
        public int ProductCategory_id { get; set; }
        public string ProductCategory_name { get; set; }
        public bool Is_deleted { get; set; }
     
    }
}
