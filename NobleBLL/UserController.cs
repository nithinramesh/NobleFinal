using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleDAL;
using NobleEntity;

namespace NobleBLL
{
    public class UserController
    {
        UserDBAccess userAccessObj = null;

        public UserController()
        {
            userAccessObj = new UserDBAccess();
        }

        public bool ValidateUser(string username, string password)
        {
            return userAccessObj.ValidateUser(username, password);
        }

        public UserEntity GetUserDetails(string username, string password)
        {
            return userAccessObj.GetUserDetails(username, password);
        }

        /// <summary>
        /// get the admin list
        /// </summary>
        /// <returns></returns>
        public List<UserEntity> GetAdminList()
        {
            return userAccessObj.GetAdminList();
        }

        public List<UserEntity> GetAdminSearchList(string last_name, string first_name, string user_name)
        {
            return userAccessObj.GetAdminSearchList(last_name,first_name,user_name);
        }
        /// <summary>
        /// add a new admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public string AddNewAdmin(UserEntity admin)
        {
            return userAccessObj.AddNewAdmin(admin);
        }

        /// <summary>
        /// edit an admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool UpdateAdmin(UserEntity admin)
        {
            return userAccessObj.UpdateAdmin(admin);
        }

        /// <summary>
        /// get member details of an admin
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserEntity GetAdminDetails(int Id)
        {
            return userAccessObj.GetAdminDetails(Id);
        }

        /// <summary>
        /// soft delete an admin
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteAdmin(int Id)
        {
            return userAccessObj.DeleteAdmin(Id);
        }

        public List<MemberEntity> GetAdminEmailId()
        {
            return userAccessObj.GetAdminEmailId();
        }

        public List<MemberEntity> GetAdminEmailId(int Id)
        {
            return userAccessObj.GetAdminEmailId(Id);
        }

        public List<UserEntity> GetActiveSuperAdminandAdmin()
        {
            return userAccessObj.GetActiveSuperAdminandAdmin();
        }
    }
}
