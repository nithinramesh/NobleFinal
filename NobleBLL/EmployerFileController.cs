using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using NobleDAL;
namespace NobleBLL
{
    public class EmployerFileController
    {
        EmployerFilesDAL objefdal = new EmployerFilesDAL();

        public bool UpdateEmployerFileDetails(EmployerFileEntity objef)
        {
            return objefdal.UpdateEmployerFileDetails(objef);
        }
        public EmployerFileEntity IsEmployerFile(EmployerFileEntity objef)
        {
            return objefdal.IsEmployerFile(objef);
        }

        public List<EmployerFileEntity> GetEmployerFiles(int EmployerID)
        {
            return objefdal.GetEmployerFiles(EmployerID);
        }
    }
}
