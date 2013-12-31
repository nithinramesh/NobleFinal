using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleDAL;
using NobleEntity;

namespace NobleBLL
{
  public  class MemberPopupController
    {
        MemberPopupDAL mpopupAccessObj = null;

        public MemberPopupController()
        {
            mpopupAccessObj = new MemberPopupDAL();
        }

        public List<MemberPopupEntity> GetAllMembers(bool IsJobCategory,string SQLquery)
        {
            return mpopupAccessObj.GetAllMembers(IsJobCategory,SQLquery);
        }
        public List<MemberPopupEntity> GetAllMembersJobCategory(MemberPopupEntity objMemberPopupEntity)
        {
            return mpopupAccessObj.GetAllMembersJobCategory(objMemberPopupEntity);
        }
        public List<SumbissionsEntity> GetSubmissions()
        {
            return mpopupAccessObj.GetSubmissions();
        }
        public List<SumbissionsEntity> GetSubmissionsById(int SubmissionID)
        {
            return mpopupAccessObj.GetSubmissionsById(SubmissionID);
        }
    }
}
