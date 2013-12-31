using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace NobleDAL
{
    public class NotesDBAccess
    {
        public bool AddMemberNotes(NotesEntity notes)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@Member_id", notes.Member_id),
                new SqlParameter("@Note_text", notes.Note_text),
                new SqlParameter("@Status", notes.Status_code),
                new SqlParameter("@Created_by", notes.Created_by),
                new SqlParameter("@Assigned_to", notes.Assigned_toId)
		    };

            return SqlDBHelper.ExecuteNonQuery("USP_NTS_Notes_Insert", CommandType.StoredProcedure, parameters);
        }

        public List<NotesEntity> GetMemberNotesList(int member_id)
        {
            List<NotesEntity> listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
            {      
                new SqlParameter("@Member_id", member_id),
            };
            //Lets get the list of all notes for a member
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NTS_Notes_SelectAllByMember", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<NotesEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        NotesEntity memObj = new NotesEntity();
                        memObj.ID = Convert.ToInt32(row["Note_id"]);
                        memObj.Member_id = Convert.ToInt32(row["Member_id"]);
                        memObj.Member_name = Convert.ToString(row["MemberName"]);
                        memObj.Note_text = Convert.ToString(row["Note_text"]);
                        memObj.Status_code = Convert.ToString(row["Status"]);
                        memObj.Status_text = Convert.ToString(row["Status_desc"]);
                        memObj.Updated_by = Convert.ToInt32(row["Updated_by"]);
                        memObj.Updated_on = Convert.ToDateTime(row["Updated_on"]);
                        memObj.Added_username = Convert.ToString(row["UpdatedByName"]);
                        memObj.Assigned_toId =Convert.ToInt32(row["Assigned_to"]);
                        memObj.Assigned_toName = Convert.ToString(row["AssignedName"]);

                        listMember.Add(memObj);
                    }
                }
            }

            return listMember;
        }

        public bool UpdateMemberNotes(NotesEntity notes)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Note_id", notes.ID),
                new SqlParameter("@Note_text", notes.Note_text),
                new SqlParameter("@Status", notes.Status_code),
                new SqlParameter("@Updated_by", notes.Updated_by),
                new SqlParameter("@Assigned_to", notes.Assigned_toId)
            };

            return SqlDBHelper.ExecuteNonQuery("USP_NTS_Notes_UpdateById", CommandType.StoredProcedure, parameters);
        }

        public NotesEntity GetNotesDetails(int note_id)
        {
            NotesEntity notObj = null;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Note_id", note_id)
            };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_NTS_Notes_SelectById", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    notObj = new NotesEntity();

                    notObj.ID = Convert.ToInt32(row["Note_id"]);
                    notObj.Member_id = Convert.ToInt32(row["Member_id"]);
                    notObj.Member_name = Convert.ToString(row["MemberName"]);
                    notObj.Note_text = Convert.ToString(row["Note_text"]);
                    notObj.Status_code = Convert.ToString(row["Status"]);
                    notObj.Status_text = Convert.ToString(row["Status_desc"]);
                    notObj.Updated_by = Convert.ToInt32(row["Updated_by"]);
                    notObj.Updated_on = Convert.ToDateTime(row["Updated_on"]);
                    notObj.Added_username = Convert.ToString(row["UpdatedByName"]);
                    notObj.Assigned_toId = Convert.ToInt32(row["Assigned_to"]);
                    
                }
            }

            return notObj;
        }


    }
}
