using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class FileDetailsEntity : BaseEntity
    {
        public int File_ID { get; set; }
        public int Member_ID { get; set; }
        public string Member_Name { get; set; }
        public string File_Name { get; set; }
        public string File_Type { get; set; }
        public string File_Path { get; set; }
        public string File_Category { get; set; }
        public string CreatedAdmin { get; set; }

    }
    public class SubFolderEntity : BaseEntity
    {
        public int SubFolder_ID { get; set; }
        public string SubFolder_Name { get; set; }
    }
}
