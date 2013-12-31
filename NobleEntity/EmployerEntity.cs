using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class EmployerEntity : BaseEntity
    {

        public string Name { get; set; }

        public string User_name { get; set; }
        public string Password { get; set; }

        public string Email_id { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }

        public bool Is_deleted { get; set; }
        public bool Is_disabled { get; set; }
    }
}
