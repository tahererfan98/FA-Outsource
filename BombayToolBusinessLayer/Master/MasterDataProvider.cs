using BombayToolsEntities.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE = BombayToolsEntities.BusinessEntities;
using BO = BombayToolsEntities.BusinessEntities;
using DB = BombayToolsDataLayer;
using MDBL = BombayToolsDataLayer.Master;

namespace BombayToolBusinessLayer.Master
{
    public class MasterDataProvider
    {
        DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
        MDBL.Master MDBManager = new MDBL.Master();
        //Start Of Principal

        public List<BO.OutsourcePartner> OutsourcePartnerSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = MDBManager.OutsourcePartnerSummary();
                List<BO.OutsourcePartner> enqBL = new List<BO.OutsourcePartner>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.OutsourcePartner Flight = new BO.OutsourcePartner();
                        i++;
                        Flight.SrNo = i;
                        Flight.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        Flight.PartnerName = Convert.ToString(row["PartnerName"]).Trim();
                        Flight.PartnerLoc = Convert.ToString(row["PartnerLoc"]).Trim();
                        Flight.Address = Convert.ToString(row["Address"]).Trim();
                        Flight.ContactPerson = Convert.ToString(row["ContactPerson"]).Trim();
                        Flight.ContactNo = Convert.ToString(row["ContactNo"]).Trim();
                        Flight.EmailID = Convert.ToString(row["EmailID"]).Trim();
                        Flight.VatNo = Convert.ToString(row["VatNo"]).Trim();
                        Flight.IsActive = Convert.ToInt32(row["IsActive"]);
                        Flight.Status = Convert.ToString(row["Status"]);
                        enqBL.Add(Flight);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OutsourcePartner GetOutsourcePartnerDetail(int PartnerID)
        {
            try
            {
                OutsourcePartner purchases = new OutsourcePartner();
                List<OutsourcePartner> POD = new List<OutsourcePartner>();

                DataSet set = new DataSet();
                set = MDBManager.GetOutsourcePartnerDetail(PartnerID);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                dt1 = set.Tables[0];
                dt2 = set.Tables[1];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        purchases.PartnerName = Convert.ToString(row["PartnerName"]).Trim();
                        purchases.PartnerLoc = Convert.ToString(row["PartnerLoc"]).Trim();
                        purchases.Address = Convert.ToString(row["Address"]).Trim();
                        purchases.VatNo = Convert.ToString(row["VatNo"]).Trim();
                        purchases.IsActive = Convert.ToInt32(row["IsActive"]);
                        purchases.Status = Convert.ToString(row["Status"]);

                    }
                }
                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        OutsourcePartner orderD = new OutsourcePartner();
                        orderD.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        orderD.SrNo = Convert.ToInt32(row["SrNo"]);
                        orderD.ContactPerson = Convert.ToString(row["ContactPerson"]);
                        orderD.ContactNo = Convert.ToString(row["ContactNo"]);
                        orderD.EmailID = Convert.ToString(row["EmailID"]);
                        POD.Add(orderD);

                    }
                }
                

                purchases.POBilling = POD;
            
                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public BE.ResponseMessage SaveOutsourcePartner(BE.OutsourcePartner data, DataTable DataTable)
        {
            BE.ResponseMessage response = new BE.ResponseMessage();
            try
            {
                DataTable dt = new DataTable();
                dt = MDBManager.SaveOutsourcePartner(data.PartnerID, data.PartnerName,data.PartnerLoc, data.Address, data.VatNo, data.IsActive, data.AddedBy, DataTable);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        response.Message = Convert.ToString(row["Message"]);
                        response.Status = Convert.ToInt32(row["Status"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }





        public List<BO.Principal> GetPrincipalItemDetail(int PrincipalID)
        {
            try
            {

                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetPrincipalDetails(PrincipalID);
                List<BO.Principal> enqBL = new List<BO.Principal>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Principal enq = new BO.Principal();
                        i++;
                        enq.SrNo = i;
                        enq.PrincipalID = Convert.ToInt32(row["PrincipalID"]);
                        enq.PrincipalName = Convert.ToString(row["Principal"]);

                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.Principal> PrincipalSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetPrincipalSummary();
                List<BO.Principal> enqBL = new List<BO.Principal>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Principal enq = new BO.Principal();
                        i++;
                        enq.SrNo = i;
                        enq.PrincipalID = Convert.ToInt32(row["PrincipalID"]);
                        enq.PrincipalName = Convert.ToString(row["Principal"]).Trim();
                        enq.PrincipalCount = list.Rows.Count;

                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeletePrincipalDetails(BO.Principal Principal)
        {

            try
            {
                string success = "Item deleted successfully";
                DataTable isRecordAdded = new DataTable();

                isRecordAdded = BTdatamanager.DeletePrincipalDetails(Principal.PrincipalID, Principal.ModifiedBY);
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string BeforeSavePrincipalDetails(BO.Principal Principal)
        {

            try
            {
                string success = "Principal details already present";
                DataTable isRecordAdded = new DataTable();
                if (Principal.PrincipalName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SavePrincipalDetails(Principal.IsNew, Principal.PrincipalName, Principal.PrincipalID, Principal.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SavePrincipalDetails(BO.Principal Principal)
        {

            try
            {
                string success = "Principal details added successfully";
                DataTable isRecordAdded = new DataTable();
                if (Principal.PrincipalName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SavePrincipalDetails(Principal.IsNew, Principal.PrincipalName, Principal.PrincipalID, Principal.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdatePrincipalDetails(BO.Principal Principal)
        {

            try
            {
                string success = "Principal details updated successfully";
                DataTable isRecordAdded = new DataTable();
                if (Principal.PrincipalName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.UpdatePrincipalDetails(Principal.IsNew, Principal.PrincipalName, Principal.PrincipalID, Principal.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.Principal> GetPrincipal()
        {
            try
            {
                DataTable list = new DataTable();
                list = BTdatamanager.GetPrincipalSummary();
                List<BO.Principal> enqBL = new List<BO.Principal>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.Principal enq = new BO.Principal();
                        enq.PrincipalID = Convert.ToInt32(row["PrincipalID"]);
                        enq.PrincipalName = Convert.ToString(row["Principal"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ValidPrincipal(BO.Principal Principal)
        {

            try
            {
                string Count = "0";

                DataTable isRecordAdded = new DataTable();
                if (Principal.PrincipalName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.ValidPrincipal(Principal.PrincipalName);
                    var principal = isRecordAdded.Rows[0]["Principal"];
                    if (isRecordAdded.Rows.Count > 0)
                    {
                        Count = Convert.ToString(isRecordAdded.Rows[0]["Principal"]);
                    }

                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
                return Count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //End Of Principal
        //Start For Industry
        public List<BO.Industry> GetIndustryItemDetail(int IndustryID)
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetIndustryDetails(IndustryID);
                List<BO.Industry> enqBL = new List<BO.Industry>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Industry enq = new BO.Industry();
                        i++;
                        enq.SrNo = i;
                        enq.IndustryId = Convert.ToInt32(row["IndusryID"]);
                        enq.IndustryName = Convert.ToString(row["Industry"]);

                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.Industry> GetIndustry()
        {
            try
            {
                DataTable list = new DataTable();
                list = BTdatamanager.GetIndustrySummary();
                List<BO.Industry> enqBL = new List<BO.Industry>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.Industry enq = new BO.Industry();
                        enq.IndustryId = Convert.ToInt32(row["IndusryID"]);
                        enq.IndustryName = Convert.ToString(row["Industry"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SaveIndustry(BO.Industry Industry)
        {

            try
            {
                string success = "Industry detail added successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Industry.IndustryName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveIndustry(Industry.IsNew, Industry.IndustryName, Industry.IndustryId, Industry.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateIndustry(BO.Industry Industry)
        {

            try
            {
                string success = "Industry detail updated successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Industry.IndustryName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveIndustry(Industry.IsNew, Industry.IndustryName, Industry.IndustryId, Industry.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.Industry> IndustrySummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetIndustrySummary();
                List<BO.Industry> enqBL = new List<BO.Industry>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Industry Flight = new BO.Industry();
                        i++;
                        Flight.SrNo = i;
                        Flight.IndustryId = Convert.ToInt32(row["IndusryID"]);
                        Flight.IndustryName = Convert.ToString(row["Industry"]).Trim();
                        Flight.IndustryCount = list.Rows.Count;
                        enqBL.Add(Flight);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteIndustryDetails(BO.Industry Industry)
        {

            try
            {
                string success = "Industry detail deleted successfully";
                DataTable isRecordAdded = new DataTable();

                isRecordAdded = BTdatamanager.DeleteIndustry(Industry.IndustryId, Industry.AddedBY);
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //End For Industry
        //Sector
        public string SaveSector(BO.Sector Sector)
        {

            try
            {
                string success = "Sector detail added successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Sector.SectorName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveSector(Sector.IsNew, Sector.SectorName, Sector.SectorID, Sector.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateSector(BO.Sector Sector)
        {

            try
            {
                string success = "Sector detail updated successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Sector.SectorName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveSector(Sector.IsNew, Sector.SectorName, Sector.SectorID, Sector.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteSectorDetails(BO.Sector Sector)
        {

            try
            {
                string success = "Sector detail deleted successfully";
                DataTable isRecordAdded = new DataTable();

                isRecordAdded = BTdatamanager.DeleteSector(Sector.SectorID, Sector.AddedBY);
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.Sector> GetSector()
        {
            try
            {
                DataTable list = new DataTable();
                list = BTdatamanager.GetSectorSummary();
                List<BO.Sector> enqBL = new List<BO.Sector>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.Sector enq = new BO.Sector();
                        enq.SectorID = Convert.ToInt32(row["SectorID"]);
                        enq.SectorName = Convert.ToString(row["SectorName"]).Trim();
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.Sector> GetSectorItemDetail(int SectorID)
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetSectorDetails(SectorID);
                List<BO.Sector> enqBL = new List<BO.Sector>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Sector enq = new BO.Sector();
                        i++;
                        enq.SrNo = i;
                        enq.SectorID = Convert.ToInt32(row["SectorID"]);
                        enq.SectorName = Convert.ToString(row["SectorName"]);

                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.Sector> SectorSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetSectorSummary();
                List<BO.Sector> enqBL = new List<BO.Sector>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Sector Flight = new BO.Sector();
                        i++;
                        Flight.SrNo = i;
                        Flight.SectorID = Convert.ToInt32(row["SectorID"]);
                        Flight.SectorName = Convert.ToString(row["SectorName"]);
                        Flight.SectorCount = list.Rows.Count;
                        enqBL.Add(Flight);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // end Sector
        //For Department
        public List<BO.Department> DepartmentSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetDepartmentSummary();
                List<BO.Department> enqBL = new List<BO.Department>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Department Flight = new BO.Department();
                        i++;
                        Flight.SrNo = i;
                        Flight.DepartmentID = Convert.ToInt32(row["DepartmentID"]);
                        Flight.DepartmentName = Convert.ToString(row["Department"]).Trim();
                        Flight.DepartmentCount = list.Rows.Count;
                        enqBL.Add(Flight);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteDepartmentDetails(BO.Department Department)
        {

            try
            {
                string success = "Department detail deleted successfully";
                DataTable isRecordAdded = new DataTable();

                isRecordAdded = BTdatamanager.DeleteDepartment(Department.DepartmentID, Department.AddedBY);
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SaveDepartment(BO.Department Department)
        {

            try
            {
                string success = "Department detail added successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Department.DepartmentName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveDepartment(Department.IsNew, Department.DepartmentName, Department.DepartmentID, Department.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateDepartment(BO.Department Department)
        {

            try
            {
                string success = "Department detail updated successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Department.DepartmentName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveDepartment(Department.IsNew, Department.DepartmentName, Department.DepartmentID, Department.AddedBY);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BO.VendorM> GetVendorSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = MDBManager.GetVendorSummary();
                List<BO.VendorM> enqBL = new List<BO.VendorM>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.VendorM Flight = new BO.VendorM();
                        i++;
                        Flight.SrNo = i;
                        Flight.VendorID = Convert.ToInt32(row["VendorID"]);
                        Flight.VendorName = Convert.ToString(row["VendorName"]).Trim();
                        Flight.VendorCode = Convert.ToString(row["Vendor_Code"]).Trim();
                        Flight.Contact = Convert.ToString(row["GSTNo"]).Trim();
                        Flight.Registration = Convert.ToString(row["PANNo"]).Trim();
                        enqBL.Add(Flight);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BO.Vendor GetVendorDetails(int id)
        {
            BO.Vendor vendor = new BO.Vendor();
            DataSet Vendormaster = new DataSet();
            Vendormaster = MDBManager.GetVendorDetails(id);
            List<BO.VendorContactDetails> ContactList = new List<BO.VendorContactDetails>();
            List<BO.VendorDocs> VendorDocsList = new List<BO.VendorDocs>();
            List<BO.VendorAccountDetails> BankList = new List<BO.VendorAccountDetails>();
            List<BO.VendorTerms> TermList = new List<BO.VendorTerms>();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            dt1 = Vendormaster.Tables[0];
            dt2 = Vendormaster.Tables[1];
            dt3 = Vendormaster.Tables[2];
            dt4 = Vendormaster.Tables[3];
            dt5 = Vendormaster.Tables[4];
            if (dt1 != null)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    vendor.VendorID = Convert.ToInt32(row["VendorID"]);
                    vendor.VendorName = Convert.ToString(row["VendorName"]).Trim();
                    vendor.Vendor_Code = Convert.ToString(row["Vendor_Code"]).Trim();
                    vendor.Vendor_Address = Convert.ToString(row["Vendor_Address"]).Trim();
                    vendor.ContactPerson = Convert.ToString(row["ContactPerson"]).Trim();
                    vendor.EmailAddress = Convert.ToString(row["EmailAddress"]).Trim();
                    vendor.GSTNo = Convert.ToString(row["GSTNo"]).Trim();
                    vendor.PANNo = Convert.ToString(row["PANNo"]).Trim();
                    vendor.TallyName = Convert.ToString(row["TallyLedgerName"]).Trim();
                    vendor.address2 = Convert.ToString(row["address2"]).Trim();
                    vendor.Discountable = Convert.ToString(row["Discountable"]).Trim();
                    vendor.Creditores = Convert.ToString(row["Creditores"]).Trim();
                    vendor.relatedPerson = Convert.ToString(row["relatedPerson"]).Trim();
                    vendor.Gstscheme = Convert.ToString(row["Gstscheme"]).Trim();
                    vendor.status = Convert.ToString(row["status"]).Trim();
                    vendor.StateID = Convert.ToInt32(row["StateID"]);
                    vendor.registration = Convert.ToString(row["registration"]).Trim();
                    vendor.GSTRegistrationDate = Convert.ToString(row["GSTRegistrationDate"]).Trim();
                    vendor.GSTLocation = Convert.ToString(row["GSTLocation"]).Trim();
                    vendor.GSTAddress = Convert.ToString(row["GSTAddress"]).Trim();
                    vendor.GSTContactNo = Convert.ToString(row["GSTContactNo"]).Trim();
                    vendor.GSTRegistrationTypeName = Convert.ToString(row["GSTRegistrationTypeName"]).Trim();
                    vendor.RegisterTypeID = Convert.ToInt32(row["GSTRegistrationTypeID"]);
                }
            }
            int i = 0;
            if (dt2 != null)
            {
                foreach (DataRow row in dt2.Rows)
                {
                    i++;
                    BO.VendorContactDetails basic = new BO.VendorContactDetails();
                    basic.counter = i;
                    basic.ID = Convert.ToInt32(row["Autoid"]);
                    basic.Name = Convert.ToString(row["ContactPerson"]).Trim();
                    basic.Email = Convert.ToString(row["EmailID"]).Trim();
                    basic.Mobile = Convert.ToString(row["ContactNo"]).Trim();
                    basic.Location = Convert.ToString(row["LocationDetails"]).Trim();
                    basic.IsCancel = 0;
                    ContactList.Add(basic);
                }
            }
            i = 0;
            if (dt3 != null)
            {
                foreach (DataRow row in dt3.Rows)
                {
                    i++;
                    BO.VendorAccountDetails basic = new BO.VendorAccountDetails();
                    basic.Counter = i;
                    basic.AutoID = Convert.ToInt32(row["AutoID"]);
                    basic.AccountName = Convert.ToString(row["AccountName"]).Trim();
                    basic.AccountNo = Convert.ToString(row["AccountNo"]).Trim();
                    basic.BankID = Convert.ToString(row["BankID"]).Trim();
                    basic.BranchName = Convert.ToString(row["BranchName"]).Trim();
                    basic.IFSCCode = Convert.ToString(row["IFSCCode"]).Trim();
                    basic.BankName = Convert.ToString(row["bankname"]).Trim();
                    basic.IsActive = 1;
                    BankList.Add(basic);
                }
            }
            i = 0;
            if (dt4 != null)
            {
                foreach (DataRow row in dt4.Rows)
                {
                    i++;
                    BO.VendorTerms basic = new BO.VendorTerms();
                    basic.Counter = i;
                    basic.ID = Convert.ToInt32(row["Autoid"]);
                    basic.Term = Convert.ToString(row["Terms"]).Trim();
                    basic.IsActive = 1;
                    TermList.Add(basic);
                }
            }
            i = 0;
            if (dt5 != null)
            {
                foreach (DataRow row in dt5.Rows)
                {
                    i++;
                    BO.VendorDocs basic = new BO.VendorDocs();
                    basic.Counter = i;
                    basic.DocID = Convert.ToInt32(row["Autoid"]);
                    basic.DocumentType = Convert.ToString(row["DocType"]).Trim();
                    basic.FileName = Convert.ToString(row["FileName"]).Trim();
                    basic.FilePath = Convert.ToString(row["FilePath"]).Trim();
                    basic.IsActive = 1;
                    VendorDocsList.Add(basic);
                }
            }
            vendor.VendorAccountDetails = BankList;
            vendor.VendorContactDetails = ContactList;
            vendor.Terms = TermList;
            vendor.VendorDoc = VendorDocsList;
            return vendor;
        }

        public BO.Vendor GetVendorDropdownDetails()
        {
            try
            {
                BO.Vendor Getdetails = new BO.Vendor();
                DataSet VendormasterDropdown = new DataSet();
                VendormasterDropdown = BTdatamanager.GetVendorDropdownDetails();

                List<BO.Locationmaster> LocationdList = new List<BO.Locationmaster>();
                List<BO.StateMaster> StateMasterList = new List<BO.StateMaster>();
                List<BO.GSTRegistrationType> GSTRegistrationTypeList = new List<BO.GSTRegistrationType>();
                List<BO.Vendor_Docs> VendorDocsList = new List<BO.Vendor_Docs>();
                List<BO.Item> ItemList = new List<BO.Item>();
                List<BO.BankList> BankList = new List<BO.BankList>();

                if (VendormasterDropdown.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow row in VendormasterDropdown.Tables[0].Rows)
                    {
                        BO.Locationmaster Location = new BO.Locationmaster();
                        Location.LocationID = Convert.ToInt16(row["LocationID"]);
                        Location.LocationName = Convert.ToString(row["Location"]);

                        LocationdList.Add(Location);
                    }
                }
                if (VendormasterDropdown.Tables[1].Rows.Count != 0)
                {
                    foreach (DataRow row in VendormasterDropdown.Tables[1].Rows)
                    {
                        BO.StateMaster StateDL = new BO.StateMaster();
                        StateDL.StateID = Convert.ToInt16(row["State_ID"]);
                        StateDL.StateName = Convert.ToString(row["State"]);

                        StateMasterList.Add(StateDL);
                    }
                }
                if (VendormasterDropdown.Tables[2].Rows.Count != 0)
                {
                    foreach (DataRow row in VendormasterDropdown.Tables[2].Rows)
                    {
                        BO.GSTRegistrationType ISO = new BO.GSTRegistrationType();
                        ISO.RGID = Convert.ToInt16(row["RGID"]);
                        ISO.RGType = Convert.ToString(row["RGTYPE"]);

                        GSTRegistrationTypeList.Add(ISO);
                    }
                }
                if (VendormasterDropdown.Tables[3].Rows.Count != 0)
                {
                    foreach (DataRow row in VendormasterDropdown.Tables[3].Rows)
                    {
                        BO.Vendor_Docs DocList = new BO.Vendor_Docs();
                        DocList.Docid = Convert.ToInt16(row["DOCID"]);
                        DocList.DocType = Convert.ToString(row["DOCNAME"]);

                        VendorDocsList.Add(DocList);
                    }
                }
                if (VendormasterDropdown.Tables[4].Rows.Count != 0)
                {
                    foreach (DataRow row in VendormasterDropdown.Tables[4].Rows)
                    {
                        BO.Item Itemdl = new BO.Item();
                        Itemdl.ItemID = Convert.ToInt16(row["Itemid"]);
                        Itemdl.ItemDescription = Convert.ToString(row["PartNo"]);

                        ItemList.Add(Itemdl);
                    }
                }
                if (VendormasterDropdown.Tables[5].Rows.Count != 0)
                {
                    foreach (DataRow row in VendormasterDropdown.Tables[5].Rows)
                    {
                        BO.BankList Bank = new BO.BankList();
                        Bank.BankID = Convert.ToString(row["Bankid"]);
                        Bank.BankName = Convert.ToString(row["BankName"]);

                        BankList.Add(Bank);
                    }
                }


                Getdetails.Locationmaster = LocationdList;
                Getdetails.StateMaster = StateMasterList;
                Getdetails.GSTRegistrationType = GSTRegistrationTypeList;
                Getdetails.Vendor_Docs = VendorDocsList;
                Getdetails.Item = ItemList;
                Getdetails.BankList = BankList;

                return Getdetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string GetstateCode(string stateID)
        {
            DataTable JOAttachmentDT = new DataTable();
            string message = "";
            JOAttachmentDT = BTdatamanager.GetStateCode(stateID);
            if (JOAttachmentDT != null)
            {
                message = Convert.ToString(JOAttachmentDT.Rows[0]["State_Code"]);
            }
            return message;
        }

        public List<BO.Department> GetDepartment()
        {
            try
            {
                DataTable list = new DataTable();
                list = BTdatamanager.GetDepartmentSummary();
                List<BO.Department> enqBL = new List<BO.Department>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.Department enq = new BO.Department();
                        enq.DepartmentID = Convert.ToInt32(row["DepartmentID"]);
                        enq.DepartmentName = Convert.ToString(row["Department"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BO.MailCampaign GetDataForCampaignRecord(int recordID)
        {
            try
            {
                MDBL.Master master = new MDBL.Master();
                DataSet list = new DataSet();
                DataTable list1 = new DataTable();
                DataTable list2 = new DataTable();
                list = master.GetDataForCampaignRecord(recordID);
                list1 = list.Tables[0];
                list2 = list.Tables[1];
                BO.MailCampaign temp = new BO.MailCampaign();
                List<BO.EmployeeAttachments> mail = new List<BO.EmployeeAttachments>();
                if (list1 != null)
                {
                    foreach (DataRow row in list1.Rows)
                    {
                        temp.EmailID = Convert.ToString(row["EmailID"]);
                        temp.CampaignPassword = Convert.ToString(row["Password"]).Trim();
                        temp.To = Convert.ToString(row["To"]);
                        temp.Body = Convert.ToString(row["Body"]);                        
                        temp.Subject = Convert.ToString(row["Subject"]);
                    }
                }
                if (list2 != null)
                {
                    int i = 1;
                    foreach (DataRow row in list2.Rows)
                    {
                        BO.EmployeeAttachments attachments = new BO.EmployeeAttachments();
                        attachments.SrNo = i++;
                        attachments.FilePath = Convert.ToString(row["FilePath"]).Trim();
                        attachments.DocName = Convert.ToString(row["FILENAME"]);
                        attachments.ContentType = Convert.ToString(row["ContentType"]);
                        mail.Add(attachments);
                    }
                }
                temp.Attachments = mail;
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setCountForRecord(string t)
        {
            MDBManager.setCountForRecord(t);
        }

        public void setStatusForRecord(int recordID)
        {
            MDBManager.setStatusForRecord(recordID);
        }


        //End For Department

        public List<BO.Zone> ZoneSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetZoneSummary();
                List<BO.Zone> enqBL = new List<BO.Zone>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Zone enq = new BO.Zone();
                        i++;
                        enq.SrNo = i;
                        enq.ZoneID = Convert.ToInt32(row["ZoneID"]);
                        enq.ZoneName = Convert.ToString(row["ZoneName"]).Trim();

                        enq.ZoneCount = Convert.ToInt32(row["Count"]);

                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.State> StateSummary()
        {
            DataTable list = new DataTable();
            List<BO.State> StateList = new List<BO.State>();
            list = BTdatamanager.GetStateSummary();
            int i = 0;
            if (list != null)
            {
                foreach (DataRow row in list.Rows)
                {
                    i++;
                    BO.State State = new BO.State();

                    State.StateID = Convert.ToInt32(row["StateID"]);
                    State.StateName = Convert.ToString(row["StateName"]);
                    State.StateCount = list.Rows.Count;
                    StateList.Add(State);
                }
            }
            return StateList;
        }

        public void UpdateVendorDocs(string data, DataTable uploadDT)
        {
            DataTable dt = MDBManager.UpdateVendorDocs(data, uploadDT);
        }

        public BO.ResponseMessage AddOrEditVendorData(BO.Vendor data, DataTable vendorContact, DataTable bankListDT, DataTable termListDT)
        {
            DataTable dt = new DataTable();
            BO.ResponseMessage response = new BO.ResponseMessage();
            dt = MDBManager.GetAddOrEditVendorData(data.VendorID, data.Vendor_Name, data.Vendor_Code, data.TallyName, data.Vendor_Address, data.ContactPerson,
                    data.GSTNo, data.EmailAddress, data.address2, data.Discountable, data.Creditores, data.relatedPerson, data.Gstscheme, data.status,
                    data.registration, data.PANNo, data.StateCode, data.RegisterTypeID, data.GSTRegistrationDate, data.GSTLocation, data.GSTAddress, data.GSTContactNo, data.StateID, data.AddedBy, vendorContact, bankListDT, termListDT);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    response.Status = Convert.ToInt32(row["Status"]);
                    response.Message = Convert.ToString(row["message"]);
                    response.Data = Convert.ToString(row["VendorID"]);
                }
            }

            return response;
        }

        public List<BO.State> SaveOrEditZone(int id)
        {
            try
            {
                List<BO.State> vesselBL = new List<BO.State>();
                DataTable dt = new DataTable();
                dt = BTdatamanager.SaveOrEditZone(id);
                int i = 0;
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        i++;
                        BO.State vl = new BO.State();
                        vl.SrNo = i;
                        vl.StateID = Convert.ToInt32(row["StateID"]);
                        vl.StateName = Convert.ToString(row["StateName"]);
                        vl.Selected = Convert.ToInt32(row["IsSelected"]);
                        vesselBL.Add(vl);
                    }

                }
                return vesselBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string AddorEditZone(BO.Zone data)
        {

            try
            {
                string success = "";
                DataTable isRecordAdded = new DataTable();



                if (data.ZoneName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.AddorEditZone(data.IsNew, data.ZoneID, data.ZoneName, data.State, data.AddedBY, data.AddedON, data.IsActive);
                    success = Convert.ToString(isRecordAdded.Rows[0][0]);
                    return success;
                }

                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        //Start For Email
        public List<BO.EmailBodyTemplate> EmailSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetEmailSummary();
                List<BO.EmailBodyTemplate> enqBL = new List<BO.EmailBodyTemplate>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.EmailBodyTemplate Flight = new BO.EmailBodyTemplate();
                        i++;
                        Flight.SrNo = i;
                        Flight.TemplateID = Convert.ToInt32(row["TemplateID"]);
                        Flight.TemplateName = Convert.ToString(row["TemplateName"]).Trim();
                        Flight.Body = Convert.ToString(row["Body"]).Trim();
                        Flight.TemplateCount = list.Rows.Count;
                        enqBL.Add(Flight);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SaveTemplate(BO.EmailBodyTemplate Template)
        {

            try
            {
                string success = "Template detail added successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Template.TemplateName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveTemplate(Template.IsNew, Template.TemplateName, Template.TemplateID, Template.AddedBY, Template.Body);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateTemplate(BO.EmailBodyTemplate Template)
        {

            try
            {
                string success = "Template detail updated successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Template.TemplateName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveTemplate(Template.IsNew, Template.TemplateName, Template.TemplateID, Template.AddedBY, Template.Body);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.EmailBodyTemplate> GetTemplate()
        {
            try
            {
                DataTable list = new DataTable();
                list = BTdatamanager.GetDepartmentSummary();
                List<BO.EmailBodyTemplate> enqBL = new List<BO.EmailBodyTemplate>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.EmailBodyTemplate enq = new BO.EmailBodyTemplate();
                        enq.TemplateID = Convert.ToInt32(row["TemplateID"]);
                        enq.TemplateName = Convert.ToString(row["TemplateName"]);
                        enq.Body = Convert.ToString(row["Body"]);
                        enqBL.Add(enq);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteTemplateDetails(BO.EmailBodyTemplate Template)
        {

            try
            {
                string success = "Template detail deleted successfully";
                DataTable isRecordAdded = new DataTable();

                isRecordAdded = BTdatamanager.DeleteTemplate(Template.TemplateID, Template.AddedBY);
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //End For  Email
        //Start For term Condition
        public List<BO.QuotationTermsTemplate> QuotTermConditionSummary()
        {
            try
            {
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetQuotTermConditionSummary();
                List<BO.QuotationTermsTemplate> enqBL = new List<BO.QuotationTermsTemplate>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.QuotationTermsTemplate Flight = new BO.QuotationTermsTemplate();
                        i++;
                        Flight.SrNo = i;
                        Flight.TemplateID = Convert.ToInt32(row["TemplateID"]);
                        Flight.TemplateName = Convert.ToString(row["TemplateName"]).Trim();
                        Flight.Packing = Convert.ToString(row["Packing"]);
                        Flight.Freight = Convert.ToString(row["Freight"]);
                        Flight.Exgodown = Convert.ToString(row["ExGodown"]).Trim();
                        Flight.Tax = Convert.ToString(row["Taxes"]);
                        Flight.Warranty = Convert.ToString(row["Warranty"]).Trim();
                        Flight.Payment = Convert.ToString(row["Payment"]).Trim();
                        Flight.Delivery = Convert.ToString(row["Delivery"]).Trim();
                        Flight.TemplateCount = list.Rows.Count;
                        enqBL.Add(Flight);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string SaveQuotTermCondition(BO.QuotationTermsTemplate Template)
        {

            try
            {
                string success = "Terms and conditions added successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Template.TemplateName.Trim() != "")
                {

                    isRecordAdded = BTdatamanager.SaveQuotTermCondition(Template.IsNew, Template.TemplateName, Template.TemplateID, Template.AddedBY, Template.Packing,
                        Template.Freight, Template.Exgodown, Template.Tax, Template.Warranty, Template.Payment, Template.Delivery);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateQuotTermCondition(BO.QuotationTermsTemplate Template)
        {

            try
            {
                string success = "Terms and conditions added successfully.";
                DataTable isRecordAdded = new DataTable();
                if (Template.TemplateName.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.SaveQuotTermCondition(Template.IsNew, Template.TemplateName, Template.TemplateID, Template.AddedBY, Template.Packing,
                        Template.Freight, Template.Exgodown, Template.Tax, Template.Warranty, Template.Payment, Template.Delivery);
                    return success;
                }
                else
                {
                    return "Could not insert the record. Kindly Try again later! ";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BO.QuotationTermsTemplate> GetQuotTermCondition()
        {
            try
            {
                DataTable list = new DataTable();
                list = BTdatamanager.GetQuotTermConditionSummary();
                List<BO.QuotationTermsTemplate> enqBL = new List<BO.QuotationTermsTemplate>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.QuotationTermsTemplate Flight = new BO.QuotationTermsTemplate();

                        Flight.TemplateID = Convert.ToInt32(row["TemplateID"]);
                        Flight.TemplateName = Convert.ToString(row["TemplateName"]).Trim();
                        Flight.Packing = Convert.ToString(row["Packing"]);
                        Flight.Freight = Convert.ToString(row["Freight"]);
                        Flight.Exgodown = Convert.ToString(row["ExGodown"]).Trim();
                        Flight.Tax = Convert.ToString(row["Taxes"]);
                        Flight.Warranty = Convert.ToString(row["Warranty"]).Trim();
                        Flight.Payment = Convert.ToString(row["Payment"]).Trim();
                        Flight.Delivery = Convert.ToString(row["Delivery"]).Trim();
                        Flight.TemplateCount = list.Rows.Count;
                        enqBL.Add(Flight);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteQuotTermConditionDetails(BO.QuotationTermsTemplate Template)
        {

            try
            {
                string success = "Terms and conditions deleted successfully";
                DataTable isRecordAdded = new DataTable();

                isRecordAdded = BTdatamanager.DeleteQuotTermCondition(Template.TemplateID, Template.AddedBY);
                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public BO.ResponseMessage AjaxAddorEditMailTemplate(BO.MailCampaignTemplate doc, DataTable uploadDT)
        {
            MDBL.Master master = new MDBL.Master();
            BO.ResponseMessage message = new BO.ResponseMessage();
            try
            {
                DataTable list = new DataTable();
                list = master.AjaxAddorEditMailTemplate(doc, uploadDT);
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.Message = Convert.ToString(row["Message"]);
                   
                    }
                }
            }
            catch(Exception ex)
            {
                message.Message = ex.Message;
                message.Status = 0;
            }
            return message;
        }


        public List<BO.MailCampaignTemplate> GetMailTemplateSummary()
        {
            try
            {
                MDBL.Master master = new MDBL.Master();
                DataTable list = new DataTable();
                list = master.GetMailTemplateSummary();
                int i = 0;
                List<BO.MailCampaignTemplate> enqBL = new List<BO.MailCampaignTemplate>();
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.MailCampaignTemplate temp = new BO.MailCampaignTemplate();
                        i++;
                        temp.SrNo = i;
                        temp.AutoID = Convert.ToInt32(row["RecordID"]);
                        temp.TemplateName = Convert.ToString(row["TEMPLATENAME"]).Trim();
                        temp.Remark = Convert.ToString(row["REMARK"]);
                        temp.Subject = Convert.ToString(row["Subject"]);
                        temp.DisplayAddedOnName = Convert.ToString(row["AddedBy"]).Trim();
                        temp.DisplayAddedOn = Convert.ToString(row["AddedOn"]);
                        
                        enqBL.Add(temp);
                    }
                }
                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public BO.MailCampaignTemplate GetDocumentDetails(int id)
        {
            try
            {
                MDBL.Master master = new MDBL.Master();
                DataSet list = new DataSet();
                DataTable list1 = new DataTable();
                DataTable list2 = new DataTable();
                list = master.GetDocumentDetails(id);
                list1 = list.Tables[0];
                list2 = list.Tables[1];
                BO.MailCampaignTemplate temp = new BO.MailCampaignTemplate();
                List<BO.EmployeeAttachments> mail = new List<BO.EmployeeAttachments>();
                if (list1 != null)
                {
                    foreach (DataRow row in list1.Rows)
                    {                        
                        temp.AutoID = Convert.ToInt32(row["RecordID"]);
                        temp.TemplateName = Convert.ToString(row["TEMPLATENAME"]).Trim();
                        temp.DocHTML = Convert.ToString(row["TEMPLATEBODY"]);
                        temp.Remark = Convert.ToString(row["REMARK"]);
                        temp.Subject = Convert.ToString(row["Subject"]);
                        temp.DisplayAddedOnName = Convert.ToString(row["AddedBy"]).Trim();
                        temp.DisplayAddedOn = Convert.ToString(row["AddedOn"]);

                    }
                }
                if (list2 != null)
                {
                    int i = 1;
                    foreach (DataRow row in list2.Rows)
                    {
                        BO.EmployeeAttachments attachments = new BO.EmployeeAttachments();
                        attachments.SrNo =i++;
                        attachments.FilePath = Convert.ToString(row["FilePath"]).Trim();
                        attachments.DocName = Convert.ToString(row["FileName"]);
                        attachments.ContentType = Convert.ToString(row["ContentType"]);
                        mail.Add(attachments);
                    }
                }
                temp.Attachments = mail;
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public BO.ResponseMessage AddOrEditFrieght(BO.FreightMaster master)
        //{
        //    BO.ResponseMessage response = new BO.ResponseMessage();
        //    try
        //    {

        //        DataTable dt = new DataTable();
        //        dt = MDBManager.AddOrEditFrieght(master.AutoID,master.Name,master.Description, master.AddedBy, master.AddedOn);
        //        if (dt != null)
        //        {
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                response.Status = Convert.ToInt32(row["Status"]);
        //                response.Message = Convert.ToString(row["message"]);
        //            }
        //        }

        //    }
        //    catch ( Exception ex)
        //    {
        //        response.Status = 0;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}


        public List<BO.MailCampaignTemplate> GetCampaignSummaryData()
        {
            MDBL.Master dBManager = new MDBL.Master();
            List<BO.MailCampaignTemplate> CampaignsummaryList = new List<BO.MailCampaignTemplate>();
            DataTable dt = new DataTable();
            dt = dBManager.GetCampaignSummaryData();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    BO.MailCampaignTemplate Csummary = new BO.MailCampaignTemplate();
                    Csummary.RecordID = Convert.ToInt32(row["RecordID"]);
                    Csummary.CampaignName = Convert.ToString(row["CampaignName"]);
                    Csummary.DisplayAddedOn = Convert.ToString(row["DisplayAddedOn"]);
                    Csummary.DisplayAddedOnName = Convert.ToString(row["AddedOnName"]);
                    CampaignsummaryList.Add(Csummary);
                }
            }
            return CampaignsummaryList;
        }

        public List<BO.CampaignDetails> GetCampaignDetailsSummary(int recordID)
        {
            MDBL.Master dBManager = new MDBL.Master();
            List<BO.CampaignDetails> campaignDetails = new List<BO.CampaignDetails>();
            DataTable dt = new DataTable();
            dt = dBManager.GetCampaignDetails(recordID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    BO.CampaignDetails CDetails = new BO.CampaignDetails();
                    CDetails.CampaignName = Convert.ToString(row["CampaignName"]);
                    CDetails.AddedOn = Convert.ToString(row["AddedOn"]);
                    CDetails.MailID = Convert.ToString(row["MailID"]);
                    CDetails.Status = Convert.ToString(row["Status"]);
                    CDetails.ReadCount = Convert.ToInt32(row["ReadCount"]);
                    campaignDetails.Add(CDetails);
                }
            }
            return campaignDetails;
        }

    }
}
