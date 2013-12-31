using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class MemberPopupEntity : BaseEntity
    {
        public int Member_ID { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JobCategory { get; set; }
        public int PageNumber { get; set; }
        public int RecordsPerPage { get; set; }
        public int RecordCount { get; set; }
        public string JobCatIDs { get; set; }
        public string JobKeyWords { get; set; }
        public string Country { get; set; }
        
            
    }
}
