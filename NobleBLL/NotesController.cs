using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleDAL;
using NobleEntity;

namespace NobleBLL
{
    public class NotesController
    {
        NotesDBAccess objDBAccess = null;
        public NotesController()
        {
            objDBAccess = new NotesDBAccess();
        }

        public bool AddMemberNotes(NotesEntity notes)
        {
            return objDBAccess.AddMemberNotes(notes);
        }

        public List<NotesEntity> GetMemberNotesList(int member_id)
        {
            return objDBAccess.GetMemberNotesList(member_id);
        }

        public bool UpdateMemberNotes(NotesEntity notes)
        {
            return objDBAccess.UpdateMemberNotes(notes);
        }

        public NotesEntity GetNotesDetails(int note_id)
        {
            return objDBAccess.GetNotesDetails(note_id);
        }
    }
}
