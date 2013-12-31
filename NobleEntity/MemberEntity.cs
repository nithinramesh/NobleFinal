using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace NobleEntity
{
    public class MemberEntity : BaseEntity
    {
        public int InstallTypeId { get; set; }
        public string InstallType { get; set; }
        public string PreviousAccountNo { get; set; }
        public string AlarmAccountNo { get; set; }
        public DateTime DateOfInstall { get; set; }
        public DateTime CancelationDate { get; set; }
        public string InstallerName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Companyname { get; set; }
        public string HouseAddress { get; set; }
        public string HouseCity { get; set; }
        public string HouseProvince { get; set; }
        public string BusinessAddress { get; set; }
        public string HousePostelCode { get; set; }
        public string Email { get; set; }
        public string BankName { get; set; }
        public string BankNo { get; set; }
        public string BusinessCity { get; set; }
        public string BusinessProvince { get; set; }
        public string BusinessPostelCode { get; set; }
        public string HousePhone { get; set; }
        public string CellPhone { get; set; }
        public string BusinessPhone { get; set; }
        public string Fax { get; set; }
        public string EmgContactName { get; set; }
        public string EmgContactName2 { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string Password { get; set; }
        public string EmgContactName1 { get; set; }
        public string EmgPhone { get; set; }
        public string EmgPhone1 { get; set; }
        public string EmgCellNo { get; set; }
        public string EmgCellNo1 { get; set; }
        public string EmgPhone2 { get; set; }
        public string EmgCellNo2 { get; set; }
        public int MonthlyAlamPayment { get; set; }

        public string SecurityLevel { get; set; }
        public string BankAccountHoldername { get; set; }
        public int Uid { get; set; }
        public int Entityid { get; set; }
        public int ZoneId { get; set; }
        public int BankId { get; set; }
        public int CategoryId { get; set; }
        public string AccountNo { get; set; }
        public string AlarmPanelMakeModel { get; set; }
        public int Version { get; set; }
        public string SignalFormat { get; set; }
        public string AlarmProduct { get; set; }
        public string Note { get; set; }
        public string BankTransit { get; set; }
        public string ZoneName { get; set; }



    }
    public class MemberHomeEntity : BaseEntity
    {

        public string Title1 { get; set; }
        public string Value1 { get; set; }
        public string Title2 { get; set; }
        public string Value2 { get; set; }

    }
}
