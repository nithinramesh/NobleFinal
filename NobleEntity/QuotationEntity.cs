using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
   public class QuotationEntity
    {
        public Int32 QuotNo { get; set; }
        public string Date { get; set; }
        public string Validtill { get; set; }
        public string title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public double HST { get; set; }
        public double Total { get; set; }
        public string FilePath { get; set; }
    }
}
