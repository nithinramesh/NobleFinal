using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class NotesEntity : BaseEntity
    {
        public int Member_id { get; set; }
        public string  Member_name { get; set; }
        public string Note_text { get; set; }
        public string Status_code { get; set; }
        public string Status_text { get; set; }

        public string Added_username { get; set; }

        public int Assigned_toId { get; set; }
        public string Assigned_toName { get; set; }
    }
}
