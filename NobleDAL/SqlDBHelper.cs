using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace NobleDAL
{
    class SqlDBHelper
    {
        //const string CONNECTION_STRING = @"Server=localhost;Database=Noble;Trusted_Connection=Yes;";
        internal static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;

        // This function will be used to execute R(CRUD) operation of parameterless commands
        internal static DataTable ExecuteSelectCommand(string CommandName, CommandType cmdType)
        {
            
            DataTable table = null;
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            table = new DataTable();
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }                   
                }
            }

            return table;
        }

        // This function will be used to execute R(CRUD) operation of parameterized commands
        internal static DataTable ExecuteParamerizedSelectCommand(string CommandName, CommandType cmdType, SqlParameter[] param)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                    catch
                    {
                        throw;
                    }                    
                }
            }

            return table;
        }

        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        internal static bool ExecuteNonQuery(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);                    

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }
    
                        result = cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        throw;
                    }                   
                }
            }

            return (result > 0);        
        }

        internal static string ExecuteNonQuerywithOutput(string CommandName, CommandType cmdType, SqlParameter[] pars)
        {
            string result = string.Empty;

            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = CommandName;
                    cmd.Parameters.AddRange(pars);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        cmd.ExecuteNonQuery();

                        result = cmd.Parameters["@out_message"].Value.ToString();
                    }
                    catch
                    {
                        throw;
                    }
                }
            }

            return result;
        }   
    }
}
