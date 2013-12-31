using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleDAL;
using NobleEntity;


namespace NobleBLL
{
    public class GeneralController
    {

        GeneralDBAccess genObj = null;

        public GeneralController()
        {
            genObj = new GeneralDBAccess();
        }

        public Dictionary<string, string> GetExperience()
        {
            return genObj.GetExperience();
        }

        public Dictionary<string, string> GetGender()
        {
            return genObj.GetGender();
        }

        public Dictionary<string, string> GetJobCategory()
        {
            return genObj.GetJobCategory();
        }

        public Dictionary<string, string> GetTitle()
        {
            return genObj.GetTitle();
        }

        public Dictionary<string, string> GetCountry()
        {
            return genObj.GetCountry();
        }
        public Dictionary<string, string> GetNoteStatus()
        {
            return genObj.GetNoteStatus();
        }
        public Dictionary<string, string> GetWebForms()
        {
            return genObj.GetWebForms();
        }
        public Dictionary<string, string> GetEmployers()
        {
            return genObj.GetEmployers();
        }
        public Dictionary<string, string> GetEmployerFileStatus()
        {
            return genObj.GetEmployerFileStatus();
        }

    }
}
