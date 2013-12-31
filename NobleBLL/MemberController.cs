using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using NobleDAL;

namespace NobleBLL
{
    public class MemberController
    {

        MemberDBAccess userMemberObj = null;

        public MemberController()
        {
            userMemberObj = new MemberDBAccess();
        }

        public List<MemberEntity> GetMemberSearchList()
        {
            return userMemberObj.GetMemberSearchList();
        }

        public List<MemberEntity> GetAllZones()
        {
            return userMemberObj.GetZones();
        }

        public List<MemberEntity> GetZonesByMemberID(int MemberId)
        {
            return userMemberObj.GetZonesByMemberId(MemberId);
        }

        public List<MemberEntity> GetProductCategoryByMemberID(int MemberId)
        {
            return userMemberObj.GetProductCategoryByMemberId(MemberId);
        }

        public List<MemberEntity> GetAllBank()
        {
            return userMemberObj.GetBank();
        }

        public bool DeleteMember(int Id)
        {
            return userMemberObj.DeleteMember(Id);
        }

        public string GetBankNo( int BankId)
        {
            return userMemberObj.GetBankNo(BankId);
        }

        public string AddNewMember(MemberEntity member,List<MemberEntity> ListMember,List<ProductCategoryEntity> Lstcat )
        {
            return userMemberObj.AddNewMember(member,ListMember,Lstcat);
        }

        public MemberEntity GetMemberDetails(int Id)
        {
            return userMemberObj.GetMemberDetails(Id);
        }

        public List<MemberEntity> GetMemberDetails_search(int Id)
        {
            return userMemberObj.GetMemberDetails_search(Id);
        }

        public bool UpdateMember(MemberEntity member,List<MemberEntity> LstMember,List<ProductCategoryEntity>LstCat  )
        {
            return userMemberObj.UpdateMember(member,LstMember,LstCat);
        }
        public List<MemberHomeEntity> GetMemberDetailsHome(int Id)
        {
            return userMemberObj.GetMemberDetailsHome(Id);
        }
    }
}
