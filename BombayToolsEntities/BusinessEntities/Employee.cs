using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
   public class Employee
    {
        public Boolean IsNew { get; set; }
        public Int64 SrNo { get; set; }
        public Int64 EmployeeID { get; set; }
        public String Emp_Name { get; set; }
        public String Emp_CurrentAddress { get; set; }
        public String Emp_MobileNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String BloodGroup { get; set; }
        public String Currently_LivingWith { get; set; }
        public String Emp_FatherName { get; set; }
        public String Emp_MotherName { get; set; }
        public String Emp_BrotherSister { get; set; }
        public String Parent_ContNo { get; set; }
        public String ParentAddress { get; set; }
        public String VillageAddress { get; set; }
        public String EmergencyContact { get; set; }
        public String EducationQualification { get; set; }
        public String OtherCertification { get; set; }
        public Int64 AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public Boolean IsCancel { get; set; }
        public string EmployeeDeviceID { get; set; }
        public String SpouseName { get; set; }
        public String Gender { get; set; }
        public string Email { get; set; }
        public string CompanyContactNo { get; set; }
        public string DateOfBirthN { get; set; }
        public string GmailPwd { get; set; }
    }
}
