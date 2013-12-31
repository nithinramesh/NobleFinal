using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class InvoiceEntity
    {
        public Int32 InvNo { get; set; }
        public Int32 Member_ID { get; set; }
        public string Date { get; set; }
        public string DueDate { get; set; }
        public string title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public double HST { get; set; }
        public double Total { get; set; }
        public string FilePath { get; set; }
    }
}
