using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
   public class EmployerFileEntity:BaseEntity
    {
        public int EmployerId { get; set; }
        public int FileId { get; set; }
		public string Member_Name { get; set; }
        public string File_Name { get; set; }
        public string File_Type { get; set; }
        public string File_Path { get; set; }
        public string Status { get; set; }
        public int FileStatusID { get; set; }
        public bool IsInsert { get; set; }
        
    }

   
}
