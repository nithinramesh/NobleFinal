using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data;

namespace NobleDAL
{
    public class GeneralDBAccess
    {

        public Dictionary<string, string> GetExperience()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_GEN_GetExperience", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add( Convert.ToString(row["Experience"]), Convert.ToString(row["Experience"]) );
                    }
                }
            }

            return dicCombo;
        }

        public Dictionary<string, string> GetGender()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_GEN_GetGender", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add(Convert.ToString(row["Gender"]), Convert.ToString(row["Gender"]));
                    }
                }
            }

            return dicCombo;
        }

        public Dictionary<string, string> GetJobCategory()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_GEN_GetJobCategory", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add(Convert.ToString(row["JobcatId"]), Convert.ToString(row["JobCategorydescription"]));
                    }
                }
            }

            return dicCombo;
        }

        public Dictionary<string, string> GetTitle()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_GEN_GetTitle", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add(Convert.ToString(row["Title"]), Convert.ToString(row["Title"]));
                    }
                }
            }

            return dicCombo;
        }

        public Dictionary<string, string> GetCountry()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_GEN_GetCountry", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add(Convert.ToString(row["CountryCode"]), Convert.ToString(row["CountryName"]));
                    }
                }
            }

            return dicCombo;
        }

        public Dictionary<string, string> GetNoteStatus()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_GEN_GetNoteStatus", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add(Convert.ToString(row["Status_code"]), Convert.ToString(row["Status_desc"]));
                    }
                }
            }

            return dicCombo;
        }
        public Dictionary<string, string> GetWebForms()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_GEN_GetWebForms", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add(Convert.ToString(row["NodeID"]), Convert.ToString(row["NodeTitle"]));
                    }
                }
            }

            return dicCombo;
        }
        public Dictionary<string, string> GetEmployers()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_GEN_GetEmployers", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add(Convert.ToString(row["EmployerID"]), Convert.ToString(row["EmployerName"]));
                    }
                }
            }

            return dicCombo;
        }
        public Dictionary<string, string> GetEmployerFileStatus()
        {
            Dictionary<string, string> dicCombo = new Dictionary<string, string>();

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_EMPFL_GetEmployerFileStatus", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        dicCombo.Add(Convert.ToString(row["StatusId"]), Convert.ToString(row["StatusName"]));
                    }
                }
            }

            return dicCombo;
        }

    }
}
