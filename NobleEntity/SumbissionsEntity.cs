using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
   public class SumbissionsEntity : BaseEntity
    {
        public int SubmissionID { get; set; }
        public int NodeID { get; set; }
        public string NodeTitle { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime SubmittedOn { get; set; }
        public int ComponentID { get; set; }
        public string ComponentName { get; set; }
        public string ComponentFormKey { get; set; }
        public string ComponentData { get; set; }
    }
}
