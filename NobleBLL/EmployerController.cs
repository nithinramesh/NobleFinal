using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using NobleDAL;

namespace NobleBLL
{
    public class EmployerController
    {
        EmployerDBAccess empAccessObj = null;

        public EmployerController()
        {
            empAccessObj = new EmployerDBAccess();
        }

        public string AddNewEmployer(EmployerEntity ueObj)
        {
           return empAccessObj.AddNewEmployer(ueObj);
        }

        public List<EmployerEntity> GetEmployerSearchList()
        {
            return empAccessObj.GetEmployerSearchList();
        }

        public EmployerEntity GetEmployerDetails(int Id)
        {
            return empAccessObj.GetEmployerDetails(Id);
        }

        public bool UpdateEmployer(EmployerEntity emp)
        {
            return empAccessObj.UpdateEmployer(emp);
        }

        public bool DeleteEmployer(int Id)
        {
            return empAccessObj.DeleteEmployer(Id);
        }

        public EmployerEntity GetUserDetails(string username, string password)
        {
            return empAccessObj.GetUserDetails(username, password);
        }
    }
}
