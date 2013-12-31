using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NobleEntity;
using System.Data.SqlClient;
using System.Data;

namespace NobleDAL
{
    public class MemberDBAccess
    {
        public List<MemberEntity> GetZones()
        {
            List<MemberEntity> lizones = null;
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_MEM_Zones_SelectAll", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    lizones = new List<MemberEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity memObj = new MemberEntity();
                        memObj.ZoneId = Convert.ToInt32(row["ZoneId"]);
                        memObj.ZoneName = Convert.ToString(row["ZoneDescription"]);
                        lizones.Add(memObj);
                    }
                }
            }

            return lizones;

        }
        public List<MemberEntity> GetZonesByMemberId(int memberId)
        {
            List<MemberEntity> lizones = null;
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@MemberId", memberId),
               
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MEM_MemberZone_SelectByID", CommandType.StoredProcedure,parameters))
            {
                if (table.Rows.Count > 0)
                {
                    lizones = new List<MemberEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity memObj = new MemberEntity();
                        memObj.ZoneId = Convert.ToInt32(row["ZoneId"]);
                        lizones.Add(memObj);
                    }
                }
            }

            return lizones;

        }


        public List<MemberEntity> GetProductCategoryByMemberId(int memberId)
        {
            List<MemberEntity> lstProdCat = null;
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@MemberId", memberId),
               
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MEM_MemberProductCategory_SelectByID", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    lstProdCat = new List<MemberEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity memObj = new MemberEntity();
                        memObj.CategoryId = Convert.ToInt32(row["categoryid"]);
                        lstProdCat.Add(memObj);
                    }
                }
            }

            return lstProdCat;

        }

        public string GetBankNo(int BankId)
        {
            MemberEntity membEntity = null;
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@BankId", BankId),
               
		    };
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MEM_BankNo_SelectById", CommandType.StoredProcedure, parameters))
            {
                foreach (DataRow row in table.Rows)
                {
                    if (table.Rows.Count > 0)
                    {
                        membEntity = new MemberEntity();
                        membEntity.BankNo = (string)row["BankNo"];
                    }
                }
            }
            return membEntity.BankNo;
        }

        public List<MemberEntity> GetBank()
        {
            List<MemberEntity> lstBank = null;

            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_MEM_Bank_SelectAll", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    lstBank = new List<MemberEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity memObj = new MemberEntity();
                        memObj.BankId = Convert.ToInt32(row["BankId"]);
                        memObj.BankName = Convert.ToString(row["BankName"]);
                        lstBank.Add(memObj);
                    }
                }
            }

            return lstBank;
        }
        public List<MemberEntity> GetMemberSearchList()
        {
            List<MemberEntity> listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {      
                //new SqlParameter("@LN", last_name),
                //new SqlParameter("@MN", middle_name),
                //new SqlParameter("@FN", first_name),
                //new SqlParameter("@PHONE", phone)
		    };
            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MEM_SelectAll", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<MemberEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity memObj = new MemberEntity();
                        memObj.ID = Convert.ToInt32(row["MemberId"]);
                        // memObj.InstallTypeId = Convert.ToInt32(row["InstallTypeId"]);
                        memObj.InstallType = Convert.ToString(row["InstallType"]);
                        memObj.PreviousAccountNo = Convert.ToString(row["PreviousAccountNo"]);
                        memObj.Firstname = Convert.ToString(row["Firstname"]);
                        memObj.Lastname = Convert.ToString(row["Lastname"]);
                        memObj.AlarmAccountNo = Convert.ToString(row["AlarmAccountNo"]);
                        memObj.Email = Convert.ToString(row["Email"]);
                        memObj.DateOfInstall = row["DateOfInstall"] == "" ? DateTime.Today : Convert.ToDateTime(row["DateOfInstall"]);
                        memObj.CancelationDate = row["CancelationDate"] == "" ? DateTime.Today : Convert.ToDateTime(row["CancelationDate"]);
                        memObj.InstallerName = Convert.ToString(row["InstallerName"]);
                        memObj.Companyname = Convert.ToString(row["CompanyName"]);
                        memObj.HouseAddress = Convert.ToString(row["HouseAddress"]);
                        memObj.HouseCity = Convert.ToString(row["HouseCity"]);
                        memObj.HouseProvince = Convert.ToString(row["HouseProvince"]);
                        memObj.HousePostelCode = Convert.ToString(row["HousePostelCode"]);
                        memObj.BusinessAddress = Convert.ToString(row["BusinessAddress"]);
                        memObj.BusinessCity = Convert.ToString(row["BusinessCity"]);
                        memObj.BusinessProvince = Convert.ToString(row["BusinessProvince"]);
                        memObj.BusinessPostelCode = Convert.ToString(row["BusinessPostelCode"]);
                        memObj.HousePhone = Convert.ToString(row["HousePhone"]);
                        memObj.CellPhone = Convert.ToString(row["CellPhone"]);
                        memObj.BusinessPhone = Convert.ToString(row["BusinessPhone"]);
                        memObj.Fax = Convert.ToString(row["Fax"]);
                        memObj.EmgContactName = Convert.ToString(row["EmgContactName"]);
                        memObj.EmgPhone = Convert.ToString(row["EmgPhone"]);
                        memObj.EmgCellNo = Convert.ToString(row["EmgCellNo"]);
                        memObj.Password = Convert.ToString(row["Password"]);
                        memObj.EmgContactName1 = Convert.ToString(row["EmgContactName1"]);
                        memObj.EmgPhone1 = Convert.ToString(row["EmgPhone1"]);
                        memObj.EmgCellNo1 = Convert.ToString(row["EmgCellNo1"]);
                        memObj.Password1 = Convert.ToString(row["Password1"]);
                        memObj.EmgContactName2 = Convert.ToString(row["EmgContactName2"]);
                        memObj.EmgPhone2 = Convert.ToString(row["EmgPhone2"]);
                        memObj.EmgCellNo2 = Convert.ToString(row["EmgCellNo2"]);
                        memObj.Password2 = Convert.ToString(row["Password2"]);
                        memObj.SecurityLevel = Convert.ToString(row["SecurityLevel"]);
                        memObj.MonthlyAlamPayment = Convert.ToInt32(row["MonthlyAlamPayment"]);
                        memObj.BankName = Convert.ToString(row["BankName"]);
                        memObj.BankId = Convert.ToInt32(row["BankId"]);
                        memObj.BankNo = Convert.ToString(row["BankNo"]);
                        memObj.BankAccountHoldername = Convert.ToString(row["BankAccountHoldername"]);
                        memObj.AccountNo = Convert.ToString(row["AccountNo"]);
                        memObj.BankTransit = Convert.ToString(row["BankTransit"]);
                        memObj.AlarmPanelMakeModel = Convert.ToString(row["AlarmPanelMakeModel"]);
                        memObj.Version = Convert.ToInt32(row["Version"]);
                        memObj.SignalFormat = Convert.ToString(row["SignalFormat"]);
                        memObj.AlarmProduct = Convert.ToString(row["AlarmProduct"]);
                        memObj.Note = Convert.ToString(row["Note"]);
                        listMember.Add(memObj);
                    }
                }
            }

            return listMember;
        }

        public bool DeleteMember(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[]
	        {
		        new SqlParameter("@MemberId", Id)
	        };

            return SqlDBHelper.ExecuteNonQuery("USP_MEM_MemberDeleteById", CommandType.StoredProcedure, parameters);
        }

        public string AddNewMember(MemberEntity member, List<MemberEntity> LstMember, List<ProductCategoryEntity> LstCat)
        {
            string result1;
            SqlParameter[] parameters = new SqlParameter[]
		    {      
                new SqlParameter("@InstallType", member.InstallType),
                new SqlParameter("@PreviousAccountNo", member.PreviousAccountNo),
                new SqlParameter("@AlarmAccountNo", member.AlarmAccountNo),
                new SqlParameter("@DateOfInstall", member.DateOfInstall),
                new SqlParameter("@CancelationDate", member.CancelationDate),
                new SqlParameter("@InstallerName", member.InstallerName),
                new SqlParameter("@FirstName", member.Firstname),
                new SqlParameter("@LastName", member.Lastname),
                new SqlParameter("@CompanyName", member.Companyname),
                new SqlParameter("@HouseAddress", member.HouseAddress),

                new SqlParameter("@HouseCity", member.HouseCity),
                new SqlParameter("@HouseProvince", member.HouseProvince),
                new SqlParameter("@HousePostelCode", member.HousePostelCode),
                new SqlParameter("@BusinessAddress", member.BusinessAddress),
                new SqlParameter("@BusinessCity", member.BusinessCity),
                new SqlParameter("@BusinessProvince", member.BusinessProvince),
                new SqlParameter("@BusinessPostelCode", member.BusinessPostelCode),
                new SqlParameter("@HousePhone", member.HousePhone),
                new SqlParameter("@CellPhone", member.CellPhone),
                new SqlParameter("@BusinessPhone", member.BusinessPhone),

                new SqlParameter("@Fax", member.Fax),
                new SqlParameter("@Email", member.Email),
                new SqlParameter("@EmgContactName", member.EmgContactName),
                new SqlParameter("@EmgPhone", member.EmgPhone),
                new SqlParameter("@EmgCellNo", member.EmgCellNo),
                new SqlParameter("@Password", member.Password),
                new SqlParameter("@EmgContactName1", member.EmgContactName1),
                new SqlParameter("@EmgPhone1", member.EmgPhone1),
                new SqlParameter("@EmgCellNo1", member.EmgCellNo1),
                new SqlParameter("@Password1", member.Password1),
                new SqlParameter("@EmgContactName2", member.EmgContactName2),
                new SqlParameter("@EmgPhone2", member.EmgPhone2),
                new SqlParameter("@EmgCellNo2", member.EmgCellNo2),
                new SqlParameter("@Password2", member.Password2),

                new SqlParameter("@SecurityLevel", member.SecurityLevel),
                new SqlParameter("@MonthlyAlamPayment", member.MonthlyAlamPayment),
              
                new SqlParameter("@Bankid", member.BankId),

                new SqlParameter("@BankAccountHoldername", member.BankAccountHoldername),
                new SqlParameter("@AccountNo", member.AccountNo),
                new SqlParameter("@BankTransit", member.BankTransit),
                new SqlParameter("@AlarmPanelMakeModel", member.AlarmPanelMakeModel),
                new SqlParameter("@Version", member.BankTransit),
                new SqlParameter("@SignalFormat", member.SignalFormat),
                new SqlParameter("@AlarmProduct", member.AlarmProduct),
                new SqlParameter("@Note",member.Note),
                new SqlParameter("@out_message", SqlDbType.VarChar,5)
                { 
                    Direction = ParameterDirection.Output 
                }
		    };

            result1= SqlDBHelper.ExecuteNonQuerywithOutput("USP_MEM_Member_Insert", CommandType.StoredProcedure, parameters);
            if(result1 == "2000")
            {

                //Insert Zones

                foreach (var item in LstMember)
                {
                    SqlParameter[] para = new SqlParameter[]
                    {

                        new SqlParameter("@MemberId", GetMaxId()),
                        new SqlParameter("@ZoneId", item.ZoneId)
                    };
                    SqlDBHelper.ExecuteNonQuery("USP_MEM_MemberZone_Insert", CommandType.StoredProcedure, para);
                }

                //Insert ProductCategory

                foreach (var item in LstCat)
                {
                    SqlParameter[] para = new SqlParameter[]
                    {

                        new SqlParameter("@MemberId", GetMaxId()),
                        new SqlParameter("@CategoryId", item.ProductCategory_id)
                    };
                    SqlDBHelper.ExecuteNonQuery("USP_MEM_MemberCategory_Insert", CommandType.StoredProcedure, para);
                }

            }
            return result1;
        }

        public int GetMaxId()
        {
            int MemberId = 0;
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("USP_MEM_GetMaxMemberId", CommandType.StoredProcedure))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity memObj = new MemberEntity();
                        MemberId = Convert.ToInt32(row["MemberId"]);

                    }
                }
            }

            return MemberId;
        }


        public List<MemberEntity> GetMemberDetails_search(int Id)
        {
            List<MemberEntity> listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@Id", Id)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MEM_SelectById", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<MemberEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberEntity memObj = new MemberEntity();
                        memObj.ID = Convert.ToInt32(row["MemberId"]);
                        // memObj.InstallTypeId = Convert.ToInt32(row["InstallTypeId"]);
                        memObj.InstallType = Convert.ToString(row["InstallType"]);
                        memObj.PreviousAccountNo = Convert.ToString(row["PreviousAccountNo"]);
                        memObj.Firstname = Convert.ToString(row["Firstname"]);
                        memObj.Lastname = Convert.ToString(row["Lastname"]);
                        memObj.AlarmAccountNo = Convert.ToString(row["AlarmAccountNo"]);
                        memObj.Email = Convert.ToString(row["Email"]);
                        memObj.DateOfInstall = row["DateOfInstall"] == "" ? DateTime.Today : Convert.ToDateTime(row["DateOfInstall"]);
                        memObj.CancelationDate = row["CancelationDate"] == "" ? DateTime.Today : Convert.ToDateTime(row["CancelationDate"]);
                        memObj.InstallerName = Convert.ToString(row["InstallerName"]);
                        memObj.Companyname = Convert.ToString(row["CompanyName"]);
                        memObj.HouseAddress = Convert.ToString(row["HouseAddress"]);
                        memObj.HouseCity = Convert.ToString(row["HouseCity"]);
                        memObj.HouseProvince = Convert.ToString(row["HouseProvince"]);
                        memObj.HousePostelCode = Convert.ToString(row["HousePostelCode"]);
                        memObj.BusinessAddress = Convert.ToString(row["BusinessAddress"]);
                        memObj.BusinessCity = Convert.ToString(row["BusinessCity"]);
                        memObj.BusinessProvince = Convert.ToString(row["BusinessProvince"]);
                        memObj.BusinessPostelCode = Convert.ToString(row["BusinessPostelCode"]);
                        memObj.HousePhone = Convert.ToString(row["HousePhone"]);
                        memObj.CellPhone = Convert.ToString(row["CellPhone"]);
                        memObj.BusinessPhone = Convert.ToString(row["BusinessPhone"]);
                        memObj.Fax = Convert.ToString(row["Fax"]);
                        memObj.EmgContactName = Convert.ToString(row["EmgContactName"]);
                        memObj.EmgPhone = Convert.ToString(row["EmgPhone"]);
                        memObj.EmgCellNo = Convert.ToString(row["EmgCellNo"]);
                        memObj.Password = Convert.ToString(row["Password"]);
                        memObj.EmgContactName1 = Convert.ToString(row["EmgContactName1"]);
                        memObj.EmgPhone1 = Convert.ToString(row["EmgPhone1"]);
                        memObj.EmgCellNo1 = Convert.ToString(row["EmgCellNo1"]);
                        memObj.Password1 = Convert.ToString(row["Password1"]);
                        memObj.EmgContactName2 = Convert.ToString(row["EmgContactName2"]);
                        memObj.EmgPhone2 = Convert.ToString(row["EmgPhone2"]);
                        memObj.EmgCellNo2 = Convert.ToString(row["EmgCellNo2"]);
                        memObj.Password2 = Convert.ToString(row["Password2"]);
                        memObj.SecurityLevel = Convert.ToString(row["SecurityLevel"]);
                        memObj.MonthlyAlamPayment = Convert.ToInt32(row["MonthlyAlamPayment"]);
                        memObj.BankName = Convert.ToString(row["BankName"]);
                        memObj.BankId = row["BankId"]==DBNull.Value ? 0 :  Convert.ToInt32(row["BankId"]);
                        memObj.BankNo = Convert.ToString(row["BankNo"]);
                        memObj.BankAccountHoldername = Convert.ToString(row["BankAccountHoldername"]);
                        memObj.AccountNo = Convert.ToString(row["AccountNo"]);
                        memObj.BankTransit = Convert.ToString(row["BankTransit"]);
                        memObj.AlarmPanelMakeModel = Convert.ToString(row["AlarmPanelMakeModel"]);
                        memObj.Version = Convert.ToInt32(row["Version"]);
                        memObj.SignalFormat = Convert.ToString(row["SignalFormat"]);
                        memObj.AlarmProduct = Convert.ToString(row["AlarmProduct"]);
                        memObj.Note = Convert.ToString(row["Note"]);
                        listMember.Add(memObj);
                    }
                }
            }

            return listMember;
        }

        public MemberEntity GetMemberDetails(int Id)
        {
            MemberEntity memObj = null;
            List<MemberEntity> listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@Id", Id)
		    };
            using (
                DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MEM_SelectById",
                    CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count == 1)
                {
                    listMember = new List<MemberEntity>();
                    DataRow row = table.Rows[0];

                    memObj = new MemberEntity();
                    memObj.ID = Convert.ToInt32(row["MemberId"]);
                    // memObj.InstallTypeId = Convert.ToInt32(row["InstallTypeId"]);
                    memObj.InstallType = Convert.ToString(row["InstallType"]);
                    memObj.PreviousAccountNo = Convert.ToString(row["PreviousAccountNo"]);
                    memObj.Firstname = Convert.ToString(row["Firstname"]);
                    memObj.Lastname = Convert.ToString(row["Lastname"]);
                    memObj.AlarmAccountNo = Convert.ToString(row["AlarmAccountNo"]);
                    memObj.Email = Convert.ToString(row["Email"]);
                    memObj.DateOfInstall = row["DateOfInstall"] == "" ? DateTime.Today : Convert.ToDateTime(row["DateOfInstall"]);
                    memObj.CancelationDate = row["CancelationDate"] == "" ? DateTime.Today : Convert.ToDateTime(row["CancelationDate"]);
                    memObj.InstallerName = Convert.ToString(row["InstallerName"]);
                    memObj.Companyname = Convert.ToString(row["CompanyName"]);
                    memObj.HouseAddress = Convert.ToString(row["HouseAddress"]);
                    memObj.HouseCity = Convert.ToString(row["HouseCity"]);
                    memObj.HouseProvince = Convert.ToString(row["HouseProvince"]);
                    memObj.HousePostelCode = Convert.ToString(row["HousePostelCode"]);
                    memObj.BusinessAddress = Convert.ToString(row["BusinessAddress"]);
                    memObj.BusinessCity = Convert.ToString(row["BusinessCity"]);
                    memObj.BusinessProvince = Convert.ToString(row["BusinessProvince"]);
                    memObj.BusinessPostelCode = Convert.ToString(row["BusinessPostelCode"]);
                    memObj.HousePhone = Convert.ToString(row["HousePhone"]);
                    memObj.CellPhone = Convert.ToString(row["CellPhone"]);
                    memObj.BusinessPhone = Convert.ToString(row["BusinessPhone"]);
                    memObj.Fax = Convert.ToString(row["Fax"]);
                    memObj.EmgContactName = Convert.ToString(row["EmgContactName"]);
                    memObj.EmgPhone = Convert.ToString(row["EmgPhone"]);
                    memObj.EmgCellNo = Convert.ToString(row["EmgCellNo"]);
                    memObj.Password = Convert.ToString(row["Password"]);
                    memObj.EmgContactName1 = Convert.ToString(row["EmgContactName1"]);
                    memObj.EmgPhone1 = Convert.ToString(row["EmgPhone1"]);
                    memObj.EmgCellNo1 = Convert.ToString(row["EmgCellNo1"]);
                    memObj.Password1 = Convert.ToString(row["Password1"]);
                    memObj.EmgContactName2 = Convert.ToString(row["EmgContactName2"]);
                    memObj.EmgPhone2 = Convert.ToString(row["EmgPhone2"]);
                    memObj.EmgCellNo2 = Convert.ToString(row["EmgCellNo2"]);
                    memObj.Password2 = Convert.ToString(row["Password2"]);
                    memObj.SecurityLevel = Convert.ToString(row["SecurityLevel"]);
                    memObj.MonthlyAlamPayment = Convert.ToInt32(row["MonthlyAlamPayment"]);
                    memObj.BankName = Convert.ToString(row["BankName"]);
                    memObj.BankId = row["BankId"] == DBNull.Value ? 0: Convert.ToInt32(row["BankId"]);
                    memObj.BankNo = Convert.ToString(row["BankNo"]);
                    memObj.BankAccountHoldername = Convert.ToString(row["BankAccountHoldername"]);
                    memObj.AccountNo = Convert.ToString(row["AccountNo"]);
                    memObj.BankTransit = Convert.ToString(row["BankTransit"]);
                    memObj.AlarmPanelMakeModel = Convert.ToString(row["AlarmPanelMakeModel"]);
                    memObj.Version = Convert.ToInt32(row["Version"]);
                    memObj.SignalFormat = Convert.ToString(row["SignalFormat"]);
                    memObj.AlarmProduct = Convert.ToString(row["AlarmProduct"]);
                    memObj.Note = Convert.ToString(row["Note"]);
                    listMember.Add(memObj);
                }

                return memObj;
            }
        }

        public bool UpdateMember(MemberEntity member, List<MemberEntity> LstMember, List<ProductCategoryEntity> LstCat)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {
                new SqlParameter("@MemberId", member.ID),
                new SqlParameter("@InstallType", member.InstallType),
                new SqlParameter("@PreviousAccountNo", member.PreviousAccountNo),
                new SqlParameter("@AlarmAccountNo", member.AlarmAccountNo),
                new SqlParameter("@DateOfInstall", member.DateOfInstall),
                new SqlParameter("@CancelationDate", member.CancelationDate),
                new SqlParameter("@InstallerName", member.InstallerName),
                new SqlParameter("@FirstName", member.Firstname),
                new SqlParameter("@LastName", member.Lastname),
                new SqlParameter("@CompanyName", member.Companyname),
                new SqlParameter("@HouseAddress", member.HouseAddress),

                new SqlParameter("@HouseCity", member.HouseCity),
                new SqlParameter("@HouseProvince", member.HouseProvince),
                new SqlParameter("@HousePostelCode", member.HousePostelCode),
                new SqlParameter("@BusinessAddress", member.BusinessAddress),
                new SqlParameter("@BusinessCity", member.BusinessCity),
                new SqlParameter("@BusinessProvince", member.BusinessProvince),
                new SqlParameter("@BusinessPostelCode", member.BusinessPostelCode),
                new SqlParameter("@HousePhone", member.HousePhone),
                new SqlParameter("@CellPhone", member.CellPhone),
                new SqlParameter("@BusinessPhone", member.BusinessPhone),

                new SqlParameter("@Fax", member.Fax),
                new SqlParameter("@Email", member.Email),
                new SqlParameter("@EmgContactName", member.EmgContactName),
                new SqlParameter("@EmgPhone", member.EmgPhone),
                new SqlParameter("@EmgCellNo", member.EmgCellNo),
                new SqlParameter("@Password", member.Password),
                new SqlParameter("@EmgContactName1", member.EmgContactName1),
                new SqlParameter("@EmgPhone1", member.EmgPhone1),
                new SqlParameter("@EmgCellNo1", member.EmgCellNo1),
                new SqlParameter("@Password1", member.Password1),
                new SqlParameter("@EmgContactName2", member.EmgContactName2),
                new SqlParameter("@EmgPhone2", member.EmgPhone2),
                new SqlParameter("@EmgCellNo2", member.EmgCellNo2),
                new SqlParameter("@Password2", member.Password2),

                new SqlParameter("@SecurityLevel", member.SecurityLevel),
                new SqlParameter("@MonthlyAlamPayment", member.MonthlyAlamPayment),
              
                new SqlParameter("@Bankid", member.BankId),

                new SqlParameter("@BankAccountHoldername", member.BankAccountHoldername),
                new SqlParameter("@AccountNo", member.AccountNo),
                new SqlParameter("@BankTransit", member.BankTransit),
                new SqlParameter("@AlarmPanelMakeModel", member.AlarmPanelMakeModel),
                new SqlParameter("@Version", member.Version),
                new SqlParameter("@SignalFormat", member.SignalFormat),
                new SqlParameter("@AlarmProduct", member.AlarmProduct),
                new SqlParameter("@Note",member.Note) 
            };

            SqlDBHelper.ExecuteNonQuery("USP_MEM_MemberUpdateById", CommandType.StoredProcedure, parameters);

            //Insert Zones
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@MemberId", member.ID)
            };
            SqlDBHelper.ExecuteNonQuery("USP_MEM_MemberZone_Delete", CommandType.StoredProcedure, param);


            foreach (var item in LstMember)
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    
                    new SqlParameter("@MemberId",member.ID), 
                    new SqlParameter("@ZoneId",item.ZoneId)
                };

                SqlDBHelper.ExecuteNonQuery("USP_MEM_MemberZone_Insert", CommandType.StoredProcedure, para);
            }

            //Insert ProductCategory
            SqlParameter[] paramer = new SqlParameter[]
            {
                new SqlParameter("@MemberId", member.ID)
            };
            SqlDBHelper.ExecuteNonQuery("USP_MEM_MemberCategory_Delete", CommandType.StoredProcedure, paramer);

            foreach (var item in LstCat)
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    
                    new SqlParameter("@MemberId",member.ID), 
                    new SqlParameter("@CategoryId",item.ProductCategory_id)
                };
                SqlDBHelper.ExecuteNonQuery("USP_MEM_MemberCategory_Insert", CommandType.StoredProcedure, para);
            }

            return true;
        }
        public List<MemberHomeEntity> GetMemberDetailsHome(int Id)
        {
            List<MemberHomeEntity> listMember = null;

            SqlParameter[] parameters = new SqlParameter[]
		    {
			    new SqlParameter("@MemberId", Id)
		    };

            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("USP_MEM_SelectByIdHome", CommandType.StoredProcedure, parameters))
            {
                if (table.Rows.Count > 0)
                {
                    listMember = new List<MemberHomeEntity>();
                    foreach (DataRow row in table.Rows)
                    {
                        MemberHomeEntity memObj = new MemberHomeEntity();

                        memObj.Title1 = Convert.ToString(row["Title1"]);
                        memObj.Value1 = Convert.ToString(row["Value1"]);
                        memObj.Title2 = Convert.ToString(row["Title2"]);
                        memObj.Value2 = Convert.ToString(row["Value2"]);

                        listMember.Add(memObj);
                    }
                }
            }

            return listMember;
        }
    }
}
