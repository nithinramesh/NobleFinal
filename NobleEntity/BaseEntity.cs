using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime Created_on { get; set; }
        public int Created_by { get; set; }
        public DateTime Updated_on { get; set; }
        public int Updated_by { get; set; }
    }
}
