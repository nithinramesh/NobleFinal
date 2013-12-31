using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class UserEntity : BaseEntity
    {
        public string Last_name { get; set; }
        public string First_name { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public int User_role { get; set; }
        public string Email_id { get; set; }
        public bool Is_deleted { get; set; }
        public bool Is_disabled { get; set; }
        public string Full_name { get; set; }
    }
}
