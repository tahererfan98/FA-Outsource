using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Data;
using BO = BombayToolsEntities.BusinessEntities;
using DB = BombayToolsDataLayer;
using EO = BombayToolBusinessLayer.Email;
using DF = BombayToolsDataLayer.SelectFilter;
using EDL = BombayToolsDataLayer.Enquiry;
using BombayToolsEntities.BusinessEntities;
using System.Web.UI.WebControls;

namespace BombayToolBusinessLayer.Enquiry
{
    public class EnquiryDataProvider
    {
        DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
        DF.DBOperationForSelectFilter obj = new DF.DBOperationForSelectFilter();
        EDL.EnquiryDBManager DataLayer = new EDL.EnquiryDBManager();


        public List<CustomerM> GetCustomerMasterList()
        {
            try
            {
                List<CustomerM> list = new List<CustomerM>();
                DataTable dt = new DataTable();
                dt = DataLayer.GetCustomerMasterList();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CustomerM enq = new CustomerM();
                        enq.CustomerID = Convert.ToInt32(row["Cust_ID"]);
                        enq.CustomerName = Convert.ToString(row["Cust_Name"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EnquiryM> GetFGTypeList()
        {
            List<EnquiryM> EmployeeDL = new List<EnquiryM>();
            DataTable EmployeeDT = new DataTable();
            string Table = "OSFGTypeM";
            string Column = "FGTypeID,FGTypeName";
            string Condition = "IsNull(IsActive,0)=1";
            string OrderBy = "FGTypeID";

            EmployeeDT = BTdatamanager.GetDropdownList(Table, Column, Condition, OrderBy);
            if (EmployeeDT != null)
            {
                foreach (DataRow row in EmployeeDT.Rows)
                {
                    EnquiryM CustomerList = new EnquiryM();
                    CustomerList.FGTypeID = Convert.ToInt32(row["FGTypeID"]);
                    CustomerList.FGTypeName = Convert.ToString(row["FGTypeName"]);

                    EmployeeDL.Add(CustomerList);
                }
            }
            return EmployeeDL;
        }

        public List<EnquiryM> GetTransporterList()
        {
            List<EnquiryM> EmployeeDL = new List<EnquiryM>();
            DataTable EmployeeDT = new DataTable();
            string Table = "TransporterM";
            string Column = "TransporterID,TransporterName";
            string Condition = "IsNull(IsActive,0)=1";
            string OrderBy = "TransporterID";

            EmployeeDT = BTdatamanager.GetDropdownList(Table, Column, Condition, OrderBy);
            if (EmployeeDT != null)
            {
                foreach (DataRow row in EmployeeDT.Rows)
                {
                    EnquiryM CustomerList = new EnquiryM();
                    CustomerList.TransporterID = Convert.ToInt32(row["TransporterID"]);
                    CustomerList.TransporterName = Convert.ToString(row["TransporterName"]);

                    EmployeeDL.Add(CustomerList);
                }
            }
            return EmployeeDL;
        }


        public List<CustomerM> GetOutsourcePartnerList()
        {
            try
            {
                List<CustomerM> list = new List<CustomerM>();
                DataTable dt = new DataTable();
                dt = DataLayer.GetOutsourcePartnerList();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CustomerM enq = new CustomerM();
                        enq.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        enq.PartnerName = Convert.ToString(row["PartnerName"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomerM> GetOSPartnerListAgainstENQNO( string ENQNO)
        {
            try
            {
                List<CustomerM> list = new List<CustomerM>();
                DataTable dt = new DataTable();
                dt = DataLayer.GetOSPartnerListAgainstENQNO(ENQNO);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        CustomerM enq = new CustomerM();
                        //enq.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        enq.PartnerName = Convert.ToString(row["PartnerName"]);
                        enq.ESNO = Convert.ToString(row["ESNO"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<IndentInfo> GetItemGroupList()
        {
            List<IndentInfo> EmployeeDL = new List<IndentInfo>();
            DataTable EmployeeDT = new DataTable();
            string Table = "ItemGroupM";
            string Column = "ItemGroup_ID,ItemGroup_Name";
            string Condition = " ItemGroup_ID IN (1,5)";
            string OrderBy = "ItemGroup_Code";

            EmployeeDT = BTdatamanager.GetDropdownList(Table, Column, Condition, OrderBy);
            if (EmployeeDT != null)
            {
                foreach (DataRow row in EmployeeDT.Rows)
                {
                    IndentInfo CustomerList = new IndentInfo();
                    CustomerList.ItemGroup_ID = Convert.ToInt32(row["ItemGroup_ID"]);
                    CustomerList.ItemGroup_Name = Convert.ToString(row["ItemGroup_Name"]);

                    EmployeeDL.Add(CustomerList);
                }
            }
            return EmployeeDL;
        }

        public List<EnquiryM> GetClosingRemarkList()
        {
            List<EnquiryM> EmployeeDL = new List<EnquiryM>();
            DataTable EmployeeDT = new DataTable();
            string Table = "OSClosingRemarkM";
            string Column = "RemarkID,RemarkName";
            string Condition = "";
            string OrderBy = "RemarkID";

            EmployeeDT = BTdatamanager.GetDropdownList(Table, Column, Condition, OrderBy);
            if (EmployeeDT != null)
            {
                foreach (DataRow row in EmployeeDT.Rows)
                {
                    EnquiryM CustomerList = new EnquiryM();
                    CustomerList.RemarkID = Convert.ToInt32(row["RemarkID"]);
                    CustomerList.RemarkName = Convert.ToString(row["RemarkName"]);

                    EmployeeDL.Add(CustomerList);
                }
            }
            return EmployeeDL;
        }

        public List<EnquiryM> GetEnquiryEntrySummary(EnquiryM data1, int UserID)
        {
            try
            {
                List<EnquiryM> list = new List<EnquiryM>();
                DataTable dt = new DataTable();
                dt = DataLayer.GetEnquiryEntrySummary(data1.FromDate, data1.ToDate, data1.SearchCriteria, data1.Search, UserID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        EnquiryM data = new EnquiryM();
                        data.SrNo = Convert.ToInt32(row["SrNo"]);
                        data.ENQID = Convert.ToInt32(row["ENQID"]);
                        data.ENQNO = Convert.ToString(row["ENQNO"]);
                        data.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        data.ENQDate = Convert.ToString(row["ENQDate"]);
                        data.CustomerName = Convert.ToString(row["CustomerName"]);
                        data.ProjectName = Convert.ToString(row["ProjectName"]);
                        data.UserName = Convert.ToString(row["UserName"]);
                        data.ENQStatus = Convert.ToString(row["ENQStatus"]);
                        data.IsENQSend = Convert.ToInt32(row["IsENQSend"]);
                        data.IsApproved = Convert.ToInt32(row["IsApproved"]);
                        data.OutQty = Convert.ToInt32(row["OutQty"]);
                        data.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                        data.AllPINO = Convert.ToString(row["AllPINO"]);
                        data.AllWONO = Convert.ToString(row["AllWONO"]);

                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                    throw ex;
            }
        }

        public List<EnquiryInfo> GetProjectListAgainstCustomer(int CustomerID)
        {
            try
            {
                List<EnquiryInfo> list = new List<EnquiryInfo>();
                DataTable dt = new DataTable();
                dt = DataLayer.GetProjectListAgainstCustomer(CustomerID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        EnquiryInfo enq = new EnquiryInfo();
                        enq.ProjectID = Convert.ToInt32(row["ProjectID"]);
                        enq.ProjectName = Convert.ToString(row["ProjectName"]);
                        list.Add(enq);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PIMaster> GetPINOListAgainstCustomer(int CustomerID, int ProjectID)
        {
            List<PIMaster> OpenGRNList = new List<PIMaster>();
            DataTable OpenGRNDL = new DataTable();
            OpenGRNDL = DataLayer.GetPINOListAgainstCustomer(CustomerID, ProjectID);
            if (OpenGRNDL != null)
            {
                int i = 0;
                foreach (DataRow row in OpenGRNDL.Rows)
                {
                    PIMaster OpenGRNData = new PIMaster();

                    OpenGRNData.IPINO = Convert.ToInt32(row["IPINO"]);
                    OpenGRNData.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                    OpenGRNData.WorkYear = Convert.ToString(row["WorkYear"]);
                    OpenGRNData.PINO = Convert.ToString(row["PINO"]);
                    OpenGRNData.DocumentDate = Convert.ToString(row["DocumentDate"]);
                    OpenGRNData.PIType = Convert.ToString(row["PIType"]);
                    OpenGRNData.Status = Convert.ToString(row["Status"]);
                    OpenGRNData.ProjectID = Convert.ToInt32(row["ProjectID"]);
                    OpenGRNData.ProjectName = Convert.ToString(row["ProjectName"]);
                    OpenGRNData.TotalPcs = Convert.ToInt32(row["TotalPcs"]);
                    OpenGRNData.TotalSQM = Convert.ToDecimal(row["TotalSQM"]);
                    OpenGRNData.WONO = Convert.ToString(row["WONo"]);
                    OpenGRNData.SrNo = i++;
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            return OpenGRNList;
        }

        public PIDetails GetItemListAgainstPINONew(DataTable dtWONO)
        {
            PIDetails purchases = new PIDetails();
            List<PIDetails> OpenGRNList = new List<PIDetails>();

            DataSet set = new DataSet();
            set = DataLayer.GetItemListAgainstPINONew(dtWONO);
            DataTable dt1 = new DataTable();
            //DataTable dt2 = new DataTable();
            //DataTable dt3 = new DataTable();

            dt1 = set.Tables[0];
            //dt2 = set.Tables[1];
            //dt3 = set.Tables[2];


            if (dt1 != null)
            {
                int i = 0;
                foreach (DataRow row in dt1.Rows)
                {
                    PIDetails OpenGRNData = new PIDetails();
                    //OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    OpenGRNData.SrNo = i++;
                    ////OpenGRNData.ItemCode = Convert.ToString(row["ItemCode"]);
                    //OpenGRNData.HeadingID = Convert.ToInt32(row["HeadingID"]);
                    //OpenGRNData.Heading = Convert.ToString(row["Heading"]);
                    OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                    OpenGRNData.ProjectName = Convert.ToString(row["ProjectName"]);
                    OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                    OpenGRNData.HSNCode = Convert.ToString(row["HSNCode"]);
                    OpenGRNData.SaleUnit = Convert.ToString(row["SaleUnit"]);
                    OpenGRNData.Qty = Convert.ToDecimal(row["TotPcs"]);
                    OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                    OpenGRNData.SQFT = Convert.ToDecimal(row["SQFT"]);
                    OpenGRNData.Rate = Convert.ToDecimal(row["Rate"]);
                    //OpenGRNData.GrossWeight = Convert.ToDecimal(row["GrossWeight"]);
                    //OpenGRNData.NetWeight = Convert.ToDecimal(row["NetWeight"]);
                    //OpenGRNData.NoOfCases = Convert.ToDecimal(row["NoOfCases"]);
                    //OpenGRNData.ContainerNo = Convert.ToString(row["ContainerNo"]);
                    OpenGRNData.NetTotal = Convert.ToDecimal(row["TotalLC"]);
                    OpenGRNData.PINO = Convert.ToString(row["PINo"]);
                    OpenGRNData.WONO = Convert.ToString(row["WONO"]);
                    OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            purchases.POBilling = OpenGRNList;
            return purchases;
        }

        public List<EnquiryD> GetPISizesListAgainstWONO(string PINO, string WONO)
        {
            List<EnquiryD> OpenGRNList = new List<EnquiryD>();
            DataTable OpenGRNDL = new DataTable();
            OpenGRNDL = DataLayer.GetPISizesListAgainstWONO( PINO,  WONO);
            if (OpenGRNDL != null)
            {
                int i = 0;
                foreach (DataRow row in OpenGRNDL.Rows)
                {
                    EnquiryD OpenGRNData = new EnquiryD();
                    //OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    OpenGRNData.IsStepGlass = Convert.ToInt32(row["IsStepGlass"]);
                    OpenGRNData.StepSrNo = Convert.ToString(row["StepSrNo"]);
                    OpenGRNData.AutoID = Convert.ToInt32(row["AutoID"]);
                    OpenGRNData.PINO = Convert.ToString(row["PINO"]);
                    OpenGRNData.WONO = Convert.ToString(row["WONo"]);
                    OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                    OpenGRNData.Height = Convert.ToInt32(row["Height"]);
                    OpenGRNData.Width = Convert.ToInt32(row["Width"]);
                    OpenGRNData.Qty = Convert.ToInt32(row["Pcs"]);
                    OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                    OpenGRNData.Remark = Convert.ToString(row["Remark"]);
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            return OpenGRNList;
        }



        public ResponseMessage SaveEnquiryEntry(EnquiryM POM, int AddedBy, DataTable dataTable, DataTable dataTable1)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DataLayer.SaveEnquiryEntry( POM.ENQID, POM.ENQNO, POM.ENQDate, POM.CustomerID , POM.ProjectID, POM.Remarks, POM.AddedOn, AddedBy, dataTable, dataTable1 );

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.ENQNO = Convert.ToString(row["ENQNO"]);

                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }

        public EnquiryM GetEnquiryDetail( string ENQNO)
        {
            try
            {
                EnquiryM purchases = new EnquiryM();
                List<EnquiryD> ItemD = new List<EnquiryD>();
                List<EnquiryD> SizesD = new List<EnquiryD>();

                DataSet set = new DataSet();
                set = DataLayer.GetEnquiryDetail(ENQNO);
                
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();

                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                dt3 = set.Tables[2];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.SrNo = Convert.ToInt32(row["SrNo"]);
                        purchases.ENQID = Convert.ToInt32(row["ENQID"]);
                        purchases.ENQNO = Convert.ToString(row["ENQNO"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.ENQDate = Convert.ToString(row["ENQDate"]);
                        purchases.CustomerID = Convert.ToInt32(row["CustomerID"]);
                        purchases.ProjectID = Convert.ToInt32(row["ProjectID"]);
                        purchases.CustomerName = Convert.ToString(row["CustomerName"]);
                        purchases.ProjectName = Convert.ToString(row["ProjectName"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.Remarks = Convert.ToString(row["Remarks"]);
                        purchases.AllWONO = Convert.ToString(row["AllWONO"]);
                        purchases.TotalQty = Convert.ToInt32(row["TotalQty"]);
                    }
                }

                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        EnquiryD OpenGRNData = new EnquiryD();
                        OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                        OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                        OpenGRNData.PINO = Convert.ToString(row["PINo"]);
                        OpenGRNData.WONO = Convert.ToString(row["WONO"]);
                        OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                        OpenGRNData.ProjectName = Convert.ToString(row["ProjectName"]);
                        OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                        OpenGRNData.Qty = Convert.ToInt32(row["Qty"]);
                        OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                        OpenGRNData.OutQty = Convert.ToInt32(row["OutQty"]);
                        OpenGRNData.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                        OpenGRNData.ApprovedRate = Convert.ToDecimal(row["ApprovedRate"]);
                        OpenGRNData.Amount = Convert.ToDecimal(row["Amount"]);
                        OpenGRNData.OutType = Convert.ToString(row["OutType"]);
                        OpenGRNData.OutTypeID = Convert.ToInt32(row["OutTypeID"]);
                        OpenGRNData.IsAllSelected = Convert.ToInt32(row["IsAllSelected"]);
                        ItemD.Add(OpenGRNData);
                    }
                }
                if (dt3 != null)
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        EnquiryD OpenGRNData1 = new EnquiryD();
                        OpenGRNData1.SrNo = Convert.ToInt32(row["SrNo"]);
                        OpenGRNData1.StepSrNo = Convert.ToString(row["StepSrNo"]);
                        OpenGRNData1.AutoID = Convert.ToInt32(row["AutoID"]);
                        OpenGRNData1.SpecID = Convert.ToInt32(row["SpecID"]);
                        OpenGRNData1.PINO = Convert.ToString(row["PINO"]);
                        OpenGRNData1.WONO = Convert.ToString(row["WONO"]);
                        OpenGRNData1.Height = Convert.ToInt32(row["Height"]);
                        OpenGRNData1.Width = Convert.ToInt32(row["Width"]);
                        OpenGRNData1.Qty = Convert.ToInt32(row["Qty"]);
                        OpenGRNData1.SQM = Convert.ToDecimal(row["SQM"]);
                        OpenGRNData1.Remark = Convert.ToString(row["Remark"]);
                        SizesD.Add(OpenGRNData1);
                    }
                }

                purchases.ENQItemD = ItemD;
                purchases.ENQSizesD = SizesD;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EnquiryM GetEnquirySentPartnerDetail(string ESNO, string ENQNO)
        {
            try
            {
                EnquiryM purchases = new EnquiryM();
                List<EnquiryD> ItemD = new List<EnquiryD>();
                List<AttachmentM> AttachmentDetails = new List<AttachmentM>();

                DataSet set = new DataSet();

                set = DataLayer.GetEnquirySentPartnerDetail(ESNO, ENQNO);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();


                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        EnquiryD OpenGRNData = new EnquiryD();
                        OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                        OpenGRNData.ENQNO = Convert.ToString(row["ENQNO"]);
                        OpenGRNData.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        OpenGRNData.PartnerName = Convert.ToString(row["PartnerName"]);
                        OpenGRNData.Status = Convert.ToString(row["Status"]);
                        ItemD.Add(OpenGRNData);
                    }
                }

                if (dt2 != null)
                {
                    int SrNo1 = 0;
                    foreach (DataRow row in dt2.Rows)
                    {
                        SrNo1 = SrNo1 + 1;
                        AttachmentM AttachmentData = new AttachmentM();
                        //AttachmentData.SrNo = SrNo1;
                        AttachmentData.DocID = Convert.ToInt32(row["DocID"]);
                        AttachmentData.DocName = Convert.ToString(row["DocName"]);
                        AttachmentData.FilePath = Convert.ToString(row["FilePath"]).Replace("\\", "\\\\");
                        AttachmentData.UploadFor = Convert.ToString(row["UploadFor"]);
                        AttachmentData.ContentType = Convert.ToString(row["ContentType"]);
                        AttachmentData.RunningID = Convert.ToInt32(row["RunningID"]);
                        AttachmentDetails.Add(AttachmentData);
                    }
                }

                purchases.ENQSentPartnerD = ItemD;
                purchases.AttachmentD = AttachmentDetails;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage SaveEnquirySendToPartnerEntry(EnquiryM POM, int AddedBy)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DataLayer.SaveEnquirySendToPartnerEntry(POM.ESID, POM.ESNO, POM.ESDate, POM.ENQNO, POM.CustomerID, POM.ProjectID, POM.PartnerID, POM.Remarks, POM.AddedOn, AddedBy);

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.ESNO = Convert.ToString(row["ESNO"]);

                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }

        public string SaveEnquirySendToPartnerAttachment(DataTable dataTable, int AddedBY)
        {
            string Message = "";
            DataTable itemD = new DataTable();
            itemD = DataLayer.SaveEnquirySendToPartnerAttachment(dataTable, AddedBY);

            if (itemD != null)
            {
                Message = "Attachment Added successfully";
            }

            return Message;
        }

        public List<EnquiryM> GetEnquirySentSummary(EnquiryM data1, int UserID)
        {
            try
            {
                List<EnquiryM> list = new List<EnquiryM>();
                DataTable dt = new DataTable();
                dt = DataLayer.GetEnquirySentSummary(data1.FromDate, data1.ToDate, data1.SearchCriteria, data1.Search, UserID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        EnquiryM data = new EnquiryM();
                        //data.SrNo = Convert.ToInt32(row["SrNo"]);
                        //data.ESID = Convert.ToInt32(row["ESID"]);
                        //data.ESNO = Convert.ToString(row["ESNO"]);
                        data.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        //data.ESDate = Convert.ToString(row["ESDate"]);
                        data.ENQNO = Convert.ToString(row["ENQNO"]);
                        data.CustomerName = Convert.ToString(row["CustomerName"]);
                        data.ProjectName = Convert.ToString(row["ProjectName"]);
                        //data.PartnerName = Convert.ToString(row["PartnerName"]);
                        data.UserName = Convert.ToString(row["UserName"]);
                        data.IsApproved = Convert.ToInt32(row["IsApproved"]);
                        data.OutQty = Convert.ToInt32(row["OutQty"]);
                        data.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                        data.AllPINO = Convert.ToString(row["AllPINO"]);
                        data.AllWONO = Convert.ToString(row["AllWONO"]);

                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteFileEnquirySentM(string ESNO, string DocName, string Filepath, string ContentType, int AddedBy)
        {
            string Message = "";
            try
            {
                DataTable itemD = new DataTable();
                List<BO.AttachmentM> SUpplierBillListDL = new List<BO.AttachmentM>();
                itemD = DataLayer.DeleteFileEnquirySentM(ESNO, DocName, Filepath, ContentType, AddedBy);
                if (itemD != null)
                {
                    Message = "Attachment deleted successfully";
                }

                return Message;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet GetSizesListForTemplateOLD(DataTable dtWONO, string ENQNo)
        {
            EnquiryD purchases = new EnquiryD();
            List<EnquiryD> OpenGRNList = new List<EnquiryD>();

            DataSet set = new DataSet();
            set = DataLayer.GetSizesListForTemplateOLD(dtWONO, ENQNo);
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            //DataTable dt3 = new DataTable();

            dt1 = set.Tables[0];
            dt2 = set.Tables[1];
            //dt3 = set.Tables[2];

            if (dt1 != null)
            {
                foreach (DataRow row in dt1.Rows)
                {

                    purchases.WOSpec = Convert.ToString(row["WOSpec"]);
                    purchases.WONO = Convert.ToString(row["WONo"]);
                    purchases.WONumber = Convert.ToString(row["WONumber"]);

                }
            }
            if (dt2 != null)
            {
                int i = 0;
                foreach (DataRow row in dt2.Rows)
                {
                    EnquiryD OpenGRNData = new EnquiryD();
                    //OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]); 
                    OpenGRNData.StepSrNo = Convert.ToString(row["StepSrNo"]);
                    OpenGRNData.PINO = Convert.ToString(row["PINO"]);
                    OpenGRNData.WONO = Convert.ToString(row["WONo"]);
                    OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                    OpenGRNData.Width = Convert.ToInt32(row["Width"]);
                    OpenGRNData.Height = Convert.ToInt32(row["Height"]);
                    OpenGRNData.Qty = Convert.ToInt32(row["Pcs"]);
                    OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                    OpenGRNData.Remark = Convert.ToString(row["Remark"]);
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            //purchases.POBilling = OpenGRNList1;
            //purchases.POBilling = OpenGRNList;
            return set;
        }

        ///// Sent Mail
        public DataTable GetContactPersonList(string ENQNO, int PartnerID)
        {
            try
            {
                DataTable ItemDL = new DataTable();
                ItemDL = DataLayer.GetContactPersonList(ENQNO, PartnerID);
                return ItemDL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSizesListForTemplate(DataTable dtWONO)
        {

            DataTable table = new DataTable();
            table = DataLayer.GetSizesListForTemplate(dtWONO);
            return table;
        }

        public BO.ResponseMessage ApproveSentEnquiry(BO.EnquiryM ENQDetails)
        {
            BO.ResponseMessage response = new BO.ResponseMessage();
            try
            {
                BO.EnquiryM dataBL = new BO.EnquiryM();
                DataTable dt = new DataTable();
                dt = DataLayer.ApproveSentEnquiry(ENQDetails);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        response.Message = Convert.ToString(row["Message"]);
                        response.Status = Convert.ToInt32(row["Status"]);
                        response.ENQNO = Convert.ToString(row["ENQNO"]);
                        response.ESNO = Convert.ToString(row["ESNO"]);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public EnquiryM GetSentEnquiryDetail( string ENQNO)
        {
            try
            {
                EnquiryM purchases = new EnquiryM();
                List<EnquiryD> ItemD = new List<EnquiryD>();

                DataSet set = new DataSet();
                set = DataLayer.GetSentEnquiryDetail( ENQNO);

                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();

                dt1 = set.Tables[0];
                dt2 = set.Tables[1];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        //purchases.SrNo = Convert.ToInt32(row["SrNo"]);
                        purchases.ESNO = Convert.ToString(row["ESNO"]);
                        purchases.ENQNO = Convert.ToString(row["ENQNO"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.ENQDate = Convert.ToString(row["ENQDate"]);
                        purchases.CustomerID = Convert.ToInt32(row["CustomerID"]);
                        purchases.ProjectID = Convert.ToInt32(row["ProjectID"]);
                        purchases.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        purchases.CustomerName = Convert.ToString(row["CustomerName"]);
                        purchases.ProjectName = Convert.ToString(row["ProjectName"]);
                        purchases.PartnerName = Convert.ToString(row["PartnerName"]);
                        purchases.PartnerLoc = Convert.ToString(row["PartnerLoc"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.OutQty = Convert.ToInt32(row["OutQty"]);
                        purchases.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                    }
                }

                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        EnquiryD OpenGRNData = new EnquiryD();
                        OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                        OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                        OpenGRNData.PINO = Convert.ToString(row["PINo"]);
                        OpenGRNData.WONO = Convert.ToString(row["WONO"]);
                        OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                        OpenGRNData.ProjectName = Convert.ToString(row["ProjectName"]);
                        OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                        OpenGRNData.Qty = Convert.ToInt32(row["Qty"]);
                        OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                        OpenGRNData.OutQty = Convert.ToInt32(row["OutQty"]);
                        OpenGRNData.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                        OpenGRNData.OutType = Convert.ToString(row["OutType"]);
                        ItemD.Add(OpenGRNData);
                    }
                }

                purchases.ENQItemD = ItemD;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EnquiryM GetSentEnquiryDetailForRRM(string ENQNO)
        {
            try
            {
                EnquiryM purchases = new EnquiryM();
                List<EnquiryD> ItemD = new List<EnquiryD>();

                DataSet set = new DataSet();
                set = DataLayer.GetSentEnquiryDetailForRRM(ENQNO);

                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();

                dt1 = set.Tables[0];
                dt2 = set.Tables[1];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        //purchases.SrNo = Convert.ToInt32(row["SrNo"]);
                        purchases.ESNO = Convert.ToString(row["ESNO"]);
                        purchases.ENQNO = Convert.ToString(row["ENQNO"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.ENQDate = Convert.ToString(row["ENQDate"]);
                        purchases.CustomerID = Convert.ToInt32(row["CustomerID"]);
                        purchases.ProjectID = Convert.ToInt32(row["ProjectID"]);
                        purchases.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        purchases.CustomerName = Convert.ToString(row["CustomerName"]);
                        purchases.ProjectName = Convert.ToString(row["ProjectName"]);
                        purchases.PartnerName = Convert.ToString(row["PartnerName"]);
                        purchases.PartnerLoc = Convert.ToString(row["PartnerLoc"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.OutQty = Convert.ToInt32(row["OutQty"]);
                        purchases.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                    }
                }

                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        EnquiryD OpenGRNData = new EnquiryD();
                        OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                        OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                        OpenGRNData.PINO = Convert.ToString(row["PINo"]);
                        OpenGRNData.WONO = Convert.ToString(row["WONO"]);
                        OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                        OpenGRNData.ProjectName = Convert.ToString(row["ProjectName"]);
                        OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                        OpenGRNData.Qty = Convert.ToInt32(row["Qty"]);
                        OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                        OpenGRNData.OutQty = Convert.ToInt32(row["OutQty"]);
                        OpenGRNData.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                        OpenGRNData.OutType = Convert.ToString(row["OutType"]);
                        ItemD.Add(OpenGRNData);
                    }
                }

                purchases.ENQItemD = ItemD;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public EnquiryM getPartnerLocation(String ESNO)
        {
            EnquiryM response = new EnquiryM();
            try
            {
                DataTable dt = new DataTable();
                dt = DataLayer.getPartnerLocation(ESNO);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        response.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        response.PartnerLoc = Convert.ToString(row["PartnerLoc"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public ResponseMessage CheckIsEnquirySendToPartner(string ENQNO, int PartnerID)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DataLayer.CheckIsEnquirySendToPartner(ENQNO, PartnerID);

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);

                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }

        public ResponseMessage SaveEnquiryApproveDetails(EnquiryM POM, int AddedBy, DataTable dataTable ,DataTable dataTable1)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DataLayer.SaveEnquiryApproveDetails(POM, AddedBy, dataTable, dataTable1);

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.EANO = Convert.ToString(row["EANO"]);

                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }

        public string SaveENQApproveAttachment(DataTable dataTable, int AddedBY)
        {
            string Message = "";
            DataTable itemD = new DataTable();
            itemD = DataLayer.SaveENQApproveAttachment(dataTable, AddedBY);

            if (itemD != null)
            {
                Message = "Attachment Added successfully";
            }

            return Message;
        }


        public EnquiryM GetSentEnquiryDetailForReceiveItem(string ENQNO)
        {
            try
            {
                EnquiryM purchases = new EnquiryM();
                List<EnquiryD> ItemD = new List<EnquiryD>();

                DataSet set = new DataSet();
                set = DataLayer.GetSentEnquiryDetailForReceiveItem(ENQNO);

                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();

                dt1 = set.Tables[0];
                dt2 = set.Tables[1];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.ENQNO = Convert.ToString(row["ENQNO"]);
                        purchases.ESNO = Convert.ToString(row["ESNO"]);
                        purchases.EANO = Convert.ToString(row["EANO"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.ESDate = Convert.ToString(row["ESDate"]);
                        purchases.CustomerID = Convert.ToInt32(row["CustomerID"]);
                        purchases.ProjectID = Convert.ToInt32(row["ProjectID"]);
                        purchases.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        purchases.CustomerName = Convert.ToString(row["CustomerName"]);
                        purchases.ProjectName = Convert.ToString(row["ProjectName"]);
                        purchases.PartnerName = Convert.ToString(row["PartnerName"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.TotalQty = Convert.ToInt32(row["TotalQty"]);
                    }
                }

                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        EnquiryD OpenGRNData = new EnquiryD();
                        OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                        OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                        OpenGRNData.PINO = Convert.ToString(row["PINo"]);
                        OpenGRNData.WONO = Convert.ToString(row["WONO"]);
                        OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                        OpenGRNData.ProjectName = Convert.ToString(row["ProjectName"]);
                        OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                        OpenGRNData.Qty = Convert.ToInt32(row["Qty"]);
                        OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                        OpenGRNData.OutQty = Convert.ToInt32(row["OutQty"]);
                        OpenGRNData.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                        OpenGRNData.ARQty = Convert.ToInt32(row["ARQty"]);
                        OpenGRNData.ARSQM = Convert.ToDecimal(row["ARSQM"]);
                        OpenGRNData.BQty = Convert.ToInt32(row["BQty"]);
                        OpenGRNData.BSQM = Convert.ToDecimal(row["BSQM"]);
                        OpenGRNData.OutType = Convert.ToString(row["OutType"]);
                        OpenGRNData.OutTypeID = Convert.ToInt32(row["OutTypeID"]);
                        OpenGRNData.ApprovedRate = Convert.ToDecimal(row["ApprovedRate"]);
                        OpenGRNData.Amount = Convert.ToDecimal(row["Amount"]);

                        ItemD.Add(OpenGRNData);
                    }
                }

                purchases.ENQItemD = ItemD;

                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EnquiryM GetEnquiryReceiveDetails(string ERNO)
        {
            try
            {
                EnquiryM purchases = new EnquiryM();
                List<EnquiryD> ItemD = new List<EnquiryD>();
                List<AttachmentM> AttachmentDetails = new List<AttachmentM>();

                DataSet set = new DataSet();
                set = DataLayer.GetEnquiryReceiveDetails(ERNO);

                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();

                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                dt3 = set.Tables[2];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.SrNo = Convert.ToInt32(row["SrNo"]);
                        purchases.ERID = Convert.ToInt32(row["ERID"]);
                        purchases.ERNO = Convert.ToString(row["ERNO"]);
                        purchases.ENQNO = Convert.ToString(row["ENQNO"]);
                        purchases.ESNO = Convert.ToString(row["ESNO"]);
                        purchases.EANO = Convert.ToString(row["EANO"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.ERDate = Convert.ToString(row["ERDate"]);
                        purchases.CustomerID = Convert.ToInt32(row["CustomerID"]);
                        purchases.ProjectID = Convert.ToInt32(row["ProjectID"]);
                        purchases.CustomerName = Convert.ToString(row["CustomerName"]);
                        purchases.ProjectName = Convert.ToString(row["ProjectName"]);
                        purchases.PartnerName = Convert.ToString(row["PartnerName"]);
                        purchases.ChallanNo = Convert.ToString(row["ChallanNo"]);
                        purchases.InvAmount = Convert.ToDecimal(row["InvAmount"]);
                        purchases.TransporterID = Convert.ToInt32(row["TransporterID"]);
                        purchases.DriverName = Convert.ToString(row["DriverName"]);
                        purchases.VehicleNo = Convert.ToString(row["VehicleNo"]);
                        purchases.TotalVehCost = Convert.ToDecimal(row["TotalVehCost"]);
                        purchases.VehType = Convert.ToString(row["VehType"]);
                        purchases.UserName = Convert.ToString(row["UserName"]);
                        purchases.Remarks = Convert.ToString(row["Remarks"]);
                    }
                }

                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        EnquiryD OpenGRNData = new EnquiryD();
                        OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                        OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                        OpenGRNData.PINO = Convert.ToString(row["PINo"]);
                        OpenGRNData.WONO = Convert.ToString(row["WONO"]);
                        OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                        OpenGRNData.ProjectName = Convert.ToString(row["ProjectName"]);
                        OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                        OpenGRNData.OutQty = Convert.ToInt32(row["OutQty"]);
                        OpenGRNData.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                        OpenGRNData.RecQty = Convert.ToInt32(row["RecQty"]);
                        OpenGRNData.RecSQM = Convert.ToDecimal(row["RecSQM"]);
                        OpenGRNData.ARQty = Convert.ToInt32(row["ARQty"]);
                        OpenGRNData.ARSQM = Convert.ToDecimal(row["ARSQM"]);
                        OpenGRNData.BQty = Convert.ToInt32(row["BQty"]);
                        OpenGRNData.BSQM = Convert.ToDecimal(row["BSQM"]);
                        OpenGRNData.OutType = Convert.ToString(row["OutType"]);
                        OpenGRNData.ApprovedRate = Convert.ToDecimal(row["ApprovedRate"]);
                        OpenGRNData.Amount = Convert.ToDecimal(row["Amount"]);
                        ItemD.Add(OpenGRNData);
                    }
                }
                
                if (dt3 != null)
                {
                    int SrNo1 = 0;
                    foreach (DataRow row in dt3.Rows)
                    {
                        SrNo1 = SrNo1 + 1;
                        AttachmentM AttachmentData = new AttachmentM();
                        //AttachmentData.SrNo = SrNo1;
                        AttachmentData.DocID = Convert.ToInt32(row["DocID"]);
                        AttachmentData.DocFileName = Convert.ToString(row["DocName"]);
                        AttachmentData.FilePath = Convert.ToString(row["FilePath"]);
                        AttachmentData.UploadFor = Convert.ToString(row["UploadFor"]);
                        AttachmentData.ContentType = Convert.ToString(row["ContentType"]);
                        AttachmentData.RunningID = Convert.ToInt32(row["RunningID"]);
                        AttachmentDetails.Add(AttachmentData);
                    }
                }
                
                purchases.ENQItemD = ItemD;
                purchases.AttachmentD = AttachmentDetails;
                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EnquiryD> GetENQNOTemplateList(string PINO, string WONO, string ENQNO, string EANO)
        {
            List<EnquiryD> OpenGRNList = new List<EnquiryD>();
            DataTable OpenGRNDL = new DataTable();
            OpenGRNDL = DataLayer.GetENQNOTemplateList(PINO, WONO, ENQNO, EANO);
            if (OpenGRNDL != null)
            {
                int i = 0;
                foreach (DataRow row in OpenGRNDL.Rows)
                {
                    EnquiryD OpenGRNData = new EnquiryD();
                    //OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                    OpenGRNData.StepSrNo = Convert.ToString(row["StepSrNo"]);
                    OpenGRNData.AutoID = Convert.ToInt32(row["AutoID"]);
                    OpenGRNData.PINO = Convert.ToString(row["PINO"]);
                    OpenGRNData.WONO = Convert.ToString(row["WONo"]);
                    OpenGRNData.SpecID = Convert.ToInt32(row["SpecID"]);
                    OpenGRNData.Height = Convert.ToInt32(row["Height"]);
                    OpenGRNData.Width = Convert.ToInt32(row["Width"]);
                    OpenGRNData.Qty = Convert.ToInt32(row["Pcs"]);
                    OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                    OpenGRNData.RecQty = Convert.ToInt32(row["RecQty"]);
                    OpenGRNData.RecSQM = Convert.ToDecimal(row["RecSQM"]);
                    OpenGRNData.ARQty = Convert.ToInt32(row["ARQty"]);
                    OpenGRNData.ARSQM = Convert.ToDecimal(row["ARSQM"]);
                    OpenGRNData.BQty = Convert.ToInt32(row["BQty"]);
                    OpenGRNData.BSQM = Convert.ToDecimal(row["BSQM"]);
                    OpenGRNData.Remark = Convert.ToString(row["Remark"]);
                    OpenGRNData.IsStepGlass = Convert.ToInt32(row["IsStepGlass"]);
                    OpenGRNList.Add(OpenGRNData);
                }
            }
            return OpenGRNList;
        }


        public ResponseMessage SaveReceiveOutsourceItem(EnquiryM POM, int AddedBy, DataTable dataTable, DataTable dataTable1)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DataLayer.SaveReceiveOutsourceItem(POM, AddedBy, dataTable, dataTable1);

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.ENQNO = Convert.ToString(row["ENQNO"]);
                        message.ERNO = Convert.ToString(row["ERNO"]);

                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }

        public string SaveENQReceiveAttachment(DataTable dataTable, int AddedBY)
        {
            string Message = "";
            DataTable itemD = new DataTable();
            itemD = DataLayer.SaveENQReceiveAttachment(dataTable, AddedBY);

            if (itemD != null)
            {
                Message = "Attachment Added successfully";
            }

            return Message;
        }


        public List<EnquiryM> GetEnquiryReceiveSummary(EnquiryM data1, int UserID)
        {
            try
            {
                List<EnquiryM> list = new List<EnquiryM>();
                DataTable dt = new DataTable();
                dt = DataLayer.GetEnquiryReceiveSummary(data1.FromDate, data1.ToDate, data1.SearchCriteria, data1.Search, UserID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        EnquiryM data = new EnquiryM();
                        //data.SrNo = Convert.ToInt32(row["SrNo"]);
                        //data.ESID = Convert.ToInt32(row["ESID"]);
                        data.ERNO = Convert.ToString(row["ERNO"]);
                        data.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        data.ERDate = Convert.ToString(row["ERDate"]);
                        data.ENQNO = Convert.ToString(row["ENQNO"]);
                        data.CustomerName = Convert.ToString(row["CustomerName"]);
                        data.ProjectName = Convert.ToString(row["ProjectName"]);
                        data.PartnerName = Convert.ToString(row["PartnerName"]);
                        data.ChallanNo = Convert.ToString(row["ChallanNo"]);
                        data.UserName = Convert.ToString(row["UserName"]);
                        data.InvAmount = Convert.ToDecimal(row["InvAmount"]);
                        data.OutQty = Convert.ToInt32(row["OutQty"]);
                        data.OutSQM = Convert.ToDecimal(row["OutSQM"]);
                        data.RecQty = Convert.ToInt32(row["RecQty"]);
                        data.RecSQM = Convert.ToDecimal(row["RecSQM"]);
                        data.BQty = Convert.ToInt32(row["BQty"]);
                        data.BSQM = Convert.ToDecimal(row["BSQM"]);

                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////////////// Req Raw material
        public EnquiryM GetReqRawMaterialDetails(string RRMNO, string ENQNO)
        {
            try
            {
                EnquiryM purchases = new EnquiryM();
                EmailEntity EmailList = new EmailEntity();
                List<EnquiryD> ItemD = new List<EnquiryD>();
                List<AttachmentM> AttachmentDetails = new List<AttachmentM>();

                DataSet set = new DataSet();
                set = DataLayer.GetReqRawMaterialDetails(RRMNO, ENQNO);

                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();

                dt1 = set.Tables[0];
                dt2 = set.Tables[1];
                dt3 = set.Tables[2];

                if (dt1 != null)
                {
                    foreach (DataRow row in dt1.Rows)
                    {
                        purchases.SrNo = Convert.ToInt32(row["SrNo"]);
                        purchases.RRMID = Convert.ToInt32(row["RRMID"]);
                        purchases.RRMNO = Convert.ToString(row["RRMNO"]);
                        purchases.ENQNO = Convert.ToString(row["ENQNO"]);
                        purchases.ESNO = Convert.ToString(row["ESNO"]);
                        purchases.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        purchases.RRMDate = Convert.ToString(row["RRMDate"]);
                        purchases.CustomerID = Convert.ToInt32(row["CustomerID"]);
                        purchases.ProjectID = Convert.ToInt32(row["ProjectID"]);
                        purchases.PartnerID = Convert.ToInt32(row["PartnerID"]);
                        purchases.CustomerName = Convert.ToString(row["CustomerName"]);
                        purchases.ProjectName = Convert.ToString(row["ProjectName"]);
                        purchases.PartnerName = Convert.ToString(row["PartnerName"]);
                        purchases.ItemGroupID = Convert.ToInt32(row["ItemGroupID"]);
                        purchases.IsCutSize = Convert.ToInt32(row["IsCutSize"]);
                        purchases.ReqVehicle = Convert.ToInt32(row["ReqVehicle"]);
                        purchases.Remarks = Convert.ToString(row["Remarks"]);
                        purchases.Qty = Convert.ToInt32(row["Qty"]);
                        purchases.SQM = Convert.ToDecimal(row["SQM"]);
                        purchases.PINO = Convert.ToString(row["PINO"]);
                        purchases.WONO = Convert.ToString(row["WONO"]);

                    }
                }
                if (dt2 != null)
                {
                    foreach (DataRow row in dt2.Rows)
                    {
                        EnquiryD OpenGRNData = new EnquiryD();
                        OpenGRNData.SrNo = Convert.ToInt32(row["SrNo"]);
                        OpenGRNData.ItemID = Convert.ToInt32(row["ItemID"]);
                        OpenGRNData.ItemCode = Convert.ToString(row["ItemCode"]);
                        OpenGRNData.ItemDescription = Convert.ToString(row["ItemDescription"]);
                        OpenGRNData.Unit = Convert.ToString(row["Unit"]);
                        OpenGRNData.Height = Convert.ToInt32(row["Height"]);
                        OpenGRNData.Width = Convert.ToInt32(row["Width"]);
                        OpenGRNData.Qty = Convert.ToInt32(row["Qty"]);
                        OpenGRNData.SQM = Convert.ToDecimal(row["SQM"]);
                        OpenGRNData.Weight = Convert.ToDecimal(row["Weight"]);
                        ItemD.Add(OpenGRNData);
                    }
                }
                if (dt3 != null)
                {
                    foreach (DataRow row in dt3.Rows)
                    {
                        EmailList.To = Convert.ToString(row["MailIds_To"]);
                        EmailList.From = Convert.ToString(row["MailID_From"]);
                        EmailList.CC = Convert.ToString(row["MailIds_Cc"]);
                        EmailList.BCC = Convert.ToString(row["MailIds_Bcc"]);
                        EmailList.MailDomain = Convert.ToString(row["MailDomain"]);
                        EmailList.Pswrd = Convert.ToString(row["Pswrd"]);
                        EmailList.PortNo = Convert.ToInt32(row["PortNo"]);
                    }
                }

                purchases.ENQItemD = ItemD;
                purchases.EmailM = EmailList;
                return purchases;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BO.Item> GetRMItemList(string Search,string ENQNO)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable list = new DataTable();
                list = DataLayer.GetRMItemList(Search, ENQNO);
                List<BO.Item> enqBL = new List<BO.Item>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.Item enq = new BO.Item();
                        i++;

                        enq.SrNo = i;
                        enq.ItemID = Convert.ToInt32(row["ID"]);
                        enq.ItemCode = Convert.ToString(row["CODE"]);
                        enq.HSNCode = Convert.ToString(row["HSNCode"]);
                        enq.ItemDescription = Convert.ToString(row["ItemDescrp"]);
                        enq.Height = Convert.ToString(row["Height"]);
                        enq.Width = Convert.ToString(row["Width"]);
                        enq.InStock = Convert.ToInt32(row["In Stock"]);
                        enq.Unit = Convert.ToString(row["Unit"]);
                        enq.WarehouseName = Convert.ToString(row["Warehouse"]);
                        enq.PartNo = Convert.ToString(row["PartNo"]);
                        enq.Thickness = Convert.ToDecimal(row["Thickness"]);
             
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
        public List<BO.Item> GetCOItemList(string Search)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable list = new DataTable();
                list = DataLayer.GetCOItemList(Search);
                List<BO.Item> enqBL = new List<BO.Item>();
                int i = 0;
                if (list != null)
                {
                    foreach (DataRow row in list.Rows)
                    {
                        BO.Item enq = new BO.Item();
                        i++;

                        enq.SrNo = i;
                        enq.ItemID = Convert.ToInt32(row["ID"]);
                        enq.ItemCode = Convert.ToString(row["CODE"]);
                        enq.PartNo = Convert.ToString(row["PartNo"]);
                        enq.ItemDescription = Convert.ToString(row["ItemDescrp"]);
                        enq.Height = Convert.ToString(row["Height"]);
                        enq.Width = Convert.ToString(row["Width"]);
                        enq.InStock = Convert.ToInt32(row["In Stock"]);
                        enq.Unit = Convert.ToString(row["Unit"]);
                        enq.WarehouseName = Convert.ToString(row["Warehouse"]);
                        //enq.IndentNo = "";
                        //enq.IndentDate = "";
                        //enq.Location = Convert.ToString(row["Location"]);
                        //enq.MinQty = Convert.ToInt32(row["MinQty"]);
                        //enq.MaxQty = Convert.ToInt32(row["MaxQty"]);

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

        public ResponseMessage SaveReqRawMaterialDetails(EnquiryM POM, int AddedBy, DataTable dataTable)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DataTable data = new DataTable();
                data = DataLayer.SaveReqRawMaterialDetails(POM, AddedBy, dataTable);

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.ENQNO = Convert.ToString(row["ENQNO"]);
                        message.RRMNO = Convert.ToString(row["RRMNO"]);

                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }

        public List<EnquiryM> GetReqRawMaterialSummary(EnquiryM data1, int UserID)
        {
            try
            {
                List<EnquiryM> list = new List<EnquiryM>();
                DataTable dt = new DataTable();
                dt = DataLayer.GetReqRawMaterialSummary(data1.FromDate, data1.ToDate, data1.SearchCriteria, data1.Search, UserID);
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        EnquiryM data = new EnquiryM();
                        //data.SrNo = Convert.ToInt32(row["SrNo"]);
                        //data.ESID = Convert.ToInt32(row["ESID"]);
                        data.RRMNO = Convert.ToString(row["RRMNO"]);
                        data.RevisionNo = Convert.ToInt32(row["RevisionNo"]);
                        data.RRMDate = Convert.ToString(row["RRMDate"]);
                        data.ENQNO = Convert.ToString(row["ENQNO"]);
                        data.CustomerName = Convert.ToString(row["CustomerName"]);
                        data.ProjectName = Convert.ToString(row["ProjectName"]);
                        //data.PartnerName = Convert.ToString(row["PartnerName"]);
                        data.Qty = Convert.ToInt32(row["Qty"]);
                        data.SQM = Convert.ToDecimal(row["SQM"]);
                        data.Weight = Convert.ToDecimal(row["Weight"]);
                        data.UserName = Convert.ToString(row["UserName"]);
                        data.IsApproved = Convert.ToInt32(row["IsApproved"]);
                        data.ClosingRemark = Convert.ToString(row["ClosingRemark"]);
                        data.ItemGroupName = Convert.ToString(row["ItemGroupName"]);
                        list.Add(data);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseMessage UpdateClosingRemarkStatus(EnquiryM ProcessDetails)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                EnquiryM dataBL = new EnquiryM();
                DataTable dt = new DataTable();
                dt = DataLayer.UpdateClosingRemarkStatus(ProcessDetails);
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



        /// /////////////////////////////////////////////////////////////////

        public List<BO.CompanySearchData> GetCompanyDetailsFromEmailORContactNoORMobileNO(string searchText, int UserID, string logType)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable companyDL = new DataTable();
                companyDL = BTdatamanager.GetCompanyDetailsFromEmailORContactNoORMobileNO(searchText, UserID, logType);
                List<BO.CompanySearchData> companyBL = new List<BO.CompanySearchData>();
                int i = 0;
                if (companyDL != null)
                {
                    foreach (DataRow row in companyDL.Rows)
                    {
                        BO.CompanySearchData company = new BO.CompanySearchData();
                        i++;
                        company.index = i;
                        company.CompanyName = Convert.ToString(row["Company"]);
                        company.Address = Convert.ToString(row["Address"]);
                        company.City = Convert.ToString(row["City"]);
                        company.ContactPersonName = Convert.ToString(row["Contact Person"]);
                        company.ContactNo = Convert.ToString(row["Contact No"]);
                        company.MobileNo = Convert.ToString(row["Mobile No"]);
                        company.EmailID = Convert.ToString(row["Email ID"]);
                        company.CompanyID = Convert.ToInt32(row["CompanyID"]);
                        company.LocationID = Convert.ToInt32(row["LocationID"]);
                        company.Location = Convert.ToString(row["Location"]);
                        company.ContactPersonID = Convert.ToInt32(row["Contact Person ID"]);
                        companyBL.Add(company);
                    }
                }
                return companyBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public List<BO.EnquiryCount> GetEnquiryListCountForDashboard()
        {
            try
            {
                List<BO.EnquiryCount> countList = new List<BO.EnquiryCount>();

                int todayBL = GetEnquiryListCount(2, DateTime.Now);
                if (todayBL != 0)
                {
                    BO.EnquiryCount enq = new BO.EnquiryCount();
                    enq.Name = "Generated Today";
                    enq.Count = todayBL;
                    countList.Add(enq);
                }
                int pendingBL = GetEnquiryListCount(0, DateTime.Now);
                if (pendingBL != 0)
                {
                    BO.EnquiryCount enq = new BO.EnquiryCount();
                    enq.Name = "Pending";
                    enq.Count = pendingBL;
                    countList.Add(enq);
                }
                return countList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BO.EnquiryList> GetEnquiryCustomerSummary(int cPID)
        {
            try
            {
                int Status = 1;
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable enqDL = new DataTable();
                enqDL = BTdatamanager.GetEnquiryCustomerSummary(Status, cPID);
                List<BO.EnquiryList> enqBL = new List<BO.EnquiryList>();
                if (enqDL != null)
                {
                    foreach (DataRow row in enqDL.Rows)
                    {
                        BO.EnquiryList enq = new BO.EnquiryList();
                        enq.EnqNO = Convert.ToString(row["Enquiry No"]);
                        enq.EnqDate = Convert.ToDateTime(row["Enquiry Date"]);
                        enq.Reference = Convert.ToString(row["Reference"]);
                        enq.Company = Convert.ToString(row["Company"]);
                        enq.Address = Convert.ToString(row["Address"]);
                        enq.EnqFrom = Convert.ToString(row["Enquiry From"]);
                        enq.Description = Convert.ToString(row["Description"]).Trim();
                        enq.DisplayDesc = Convert.ToString(row["View Description"]).Trim();
                        enq.DisplayDesc = enq.DisplayDesc.Replace("   ", "\n");
                        enq.SalesPerson = Convert.ToString(row["Salesperson"]);
                        enq.Status = Convert.ToString(row["Status"]);
                        enq.AttendedBY = Convert.ToString(row["Attended By"]);
                        enq.Location = Convert.ToString(row["Location"]);
                        enq.DisplayDate = Convert.ToString(row["DisplayDate"]);
                        enq.ContactPersonID = Convert.ToInt32(row["ContactPersonID"]);
                        enq.CompanyID = Convert.ToInt32(row["CompanyID"]);
                        enq.LocationID = Convert.ToInt32(row["LocationID"]);
                        enq.SalesPersonID = Convert.ToInt32(row["SalespersonID"]);
                        enq.StatusID = Convert.ToInt32(row["StatusID"]);
                        enq.AddedBYID = Convert.ToInt32(row["AddedBy"]);
                        enq.CPEmailID = Convert.ToString(row["Enquiry From EmailID"]);
                        enq.CPContactNO = Convert.ToString(row["Enquiry From ContactNo"]);
                        enq.CPMobileNO = Convert.ToString(row["Enquiry From MobileNO"]);
                        enq.IsDeleted = Convert.ToBoolean(row["IsDeleted"]);
                        enq.AddedOn = Convert.ToDateTime(row["AddedOn"]);
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


        public int LinkEmailToEnquiry(BO.Enquiry data)
        {
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            int i = BTdatamanager.LinkEmailToEnquiry(data.MessageID, data.ThreadID, data.AddedBY, data.AddedON);
            return i;
        }

        private int GetEnquiryListCount(int typeID, DateTime from)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable enqDL = new DataTable();
                enqDL = BTdatamanager.GetEnquiryListCount(typeID, from);
                int enqBL = 0;
                if (enqDL != null)
                {
                    foreach (DataRow row in enqDL.Rows)
                    {
                        enqBL = Convert.ToInt32(row["EnquiryCount"]);
                    }
                }

                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BO.User> GetUserListToShare(int ID)
        {
            List<BO.User> user = new List<BO.User>();
            DataTable salePeopleDL = new DataTable();
            salePeopleDL = obj.GetUserListToShare(ID);

            if (salePeopleDL != null)
            {
                foreach (DataRow row in salePeopleDL.Rows)
                {
                    BO.User UserBL = new BO.User();

                    UserBL.ID = Convert.ToInt32(row["USerID"]);
                    UserBL.UserName = Convert.ToString(row["Emp_Name"]);
                    UserBL.Status = Convert.ToBoolean(row["Share"]);
                    user.Add(UserBL);
                }
            }
            return user;
        }

        public string AddNewEnquiry(BO.Enquiry data)
        {
            try
            {
                string success = "Enquiry details added successfully";
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable isRecordAdded = new DataTable();
                if(data.Remark == null)
                {
                    data.Remark = "NA";
                }
                if (data.Reference.Trim() != "" && data.Desc.Trim() != "")
                {
                    isRecordAdded = BTdatamanager.AddORUpdateNewEnquiry(data.EnquiryNO, data.RevisionNo, data.EnqDate, data.ContactPersonID, data.Reference, data.Desc.Replace("\"", " "), data.SalesPersonID, data.StatusID, data.AddedBY, data.AddedON, data.ModifiedBY, data.ModifiedON, data.IsDeleted, data.SalesCoordinatorID, data.Remark.Replace("'", " "));
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

        public List<BO.EnquiryList> GetEnquirySummary(int isFilterBYDate, DateTime from, DateTime to, string searchText, int AddedBY)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable enqDL = new DataTable();
                enqDL = BTdatamanager.GetEnquirySummary(isFilterBYDate, from, to, searchText, AddedBY);
                List<BO.EnquiryList> enqBL = new List<BO.EnquiryList>();
                if (enqDL != null)
                {
                    foreach (DataRow row in enqDL.Rows)
                    {
                        BO.EnquiryList enq = new BO.EnquiryList();
                        enq.EnqNO = Convert.ToString(row["Enquiry No"]);
                        enq.EnqDate = Convert.ToDateTime(row["Enquiry Date"]);
                        enq.Reference = Convert.ToString(row["Reference"]);
                        enq.Company = Convert.ToString(row["Company"]);
                        enq.Address = Convert.ToString(row["Address"]);
                        enq.EnqFrom = Convert.ToString(row["Enquiry From"]);
                        enq.Description = Convert.ToString(row["Description"]).Trim();
                        enq.DisplayDesc = Convert.ToString(row["View Description"]).Trim();
                        enq.SalesPerson = Convert.ToString(row["Salesperson"]);
                        enq.Status = Convert.ToString(row["Status"]);
                        enq.AttendedBY = Convert.ToString(row["Attended By"]);
                        enq.Location = Convert.ToString(row["Location"]);
                        enq.DisplayDate = Convert.ToString(row["DisplayDate"]);
                        enq.ContactPersonID = Convert.ToInt32(row["ContactPersonID"]);
                        enq.CompanyID = Convert.ToInt32(row["CompanyID"]);
                        enq.LocationID = Convert.ToInt32(row["LocationID"]);
                        enq.SalesPersonID = Convert.ToInt32(row["SalespersonID"]);
                        enq.StatusID = Convert.ToInt32(row["StatusID"]);
                        enq.AddedBYID = Convert.ToInt32(row["AddedBy"]);
                        enq.CPEmailID = Convert.ToString(row["Enquiry From EmailID"]);
                        enq.CPContactNO = Convert.ToString(row["Enquiry From ContactNo"]);
                        enq.CPMobileNO = Convert.ToString(row["Enquiry From MobileNO"]);
                        enq.IsDeleted = Convert.ToBoolean(row["IsDeleted"]);
                        enq.AddedOn = Convert.ToDateTime(row["AddedOn"]);
                        enq.SalesCoordinator = Convert.ToInt32(row["SalesCoordinatorID"]);
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

        public List<BO.EnquiryList> GetCloseEnquiryList(int status, int AddedBY, DateTime fromDate, DateTime to)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable enqDL = new DataTable();
                enqDL = BTdatamanager.GetCloseEnquiryList(status, AddedBY, fromDate, to);
                List<BO.EnquiryList> enqBL = new List<BO.EnquiryList>();
                if (enqDL != null)
                {
                    foreach (DataRow row in enqDL.Rows)
                    {
                        BO.EnquiryList enq = new BO.EnquiryList();
                        enq.EnqNO = Convert.ToString(row["Enquiry No"]);
                        enq.EnqDate = Convert.ToDateTime(row["Enquiry Date"]);
                        enq.Reference = Convert.ToString(row["Reference"]);
                        enq.Company = Convert.ToString(row["Company"]);
                        enq.Address = Convert.ToString(row["Address"]);
                        enq.EnqFrom = Convert.ToString(row["Enquiry From"]);
                        //enq.Description = Convert.ToString(row["Description"]);
                        enq.DisplayDesc = Convert.ToString(row["View Description"]);
                        enq.SalesPerson = Convert.ToString(row["Salesperson"]);
                        enq.Status = Convert.ToString(row["Status"]);
                        enq.AttendedBY = Convert.ToString(row["Attended By"]);
                        enq.Location = Convert.ToString(row["Location"]);
                        enq.DisplayDate = Convert.ToString(row["DisplayDate"]);
                        enq.CloseDate = Convert.ToString(row["CloseDate"]);
                        enq.ContactPersonID = Convert.ToInt32(row["ContactPersonID"]);
                        enq.CompanyID = Convert.ToInt32(row["CompanyID"]);
                        enq.LocationID = Convert.ToInt32(row["LocationID"]);
                        enq.SalesPersonID = Convert.ToInt32(row["SalespersonID"]);
                        enq.StatusID = Convert.ToInt32(row["StatusID"]);
                        enq.AddedBYID = Convert.ToInt32(row["AddedBy"]);
                        enq.CPEmailID = Convert.ToString(row["Enquiry From EmailID"]);
                        enq.CPContactNO = Convert.ToString(row["Enquiry From ContactNo"]);
                        enq.CPMobileNO = Convert.ToString(row["Enquiry From MobileNO"]);
                        enq.QuotationNo = Convert.ToString(row["QuotationNo"]);
                        enq.IsDeleted = Convert.ToBoolean(row["IsDeleted"]);
                        enq.AddedOn = Convert.ToDateTime(row["AddedOn"]);
                        enq.CloseRemark = Convert.ToString(row["REMARK"]);
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


        public int GetEnquiryListAgainstCustomer(int ID)
        {
            try
            {
                int StatusID = 1;
                DataTable enqDL = new DataTable();
                enqDL = BTdatamanager.GetEnquiryListCountAganistCustomer(StatusID, ID);
                int enqBL = 0;
                if (enqDL != null)
                {
                    foreach (DataRow row in enqDL.Rows)
                    {
                        enqBL = Convert.ToInt32(row["EnquiryCount"]);
                    }
                }

                return enqBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BO.Recieved_Emails> GetEmail(string popConnect, string userEmailID, string password)
        {
            try
            {
                List<EO.Email> email = new List<EO.Email>();
                EO.ReadEmail em = new EO.ReadEmail();
                email = em.Read_Emails(popConnect, userEmailID, password);
                List<BO.Recieved_Emails> emailBL = new List<BO.Recieved_Emails>();
                if (email.Count > 0)
                {
                    foreach (EO.Email row in email)
                    {
                        BO.Recieved_Emails re = new BO.Recieved_Emails();
                        re.Body = row.Body;
                        re.DateSent = row.DateSent;
                        re.FromEmail = row.FromEmail;
                        re.FromName = row.FromName;
                        re.MessageNumber = row.MessageNumber;
                        re.Subject = row.Subject;
                        if (row.Attachments.Count != 0)
                        {
                            foreach (EO.Attachment att in row.Attachments)
                            {
                                BO.Email_Attachment attach = new BO.Email_Attachment();
                                attach.Content = att.Content;
                                attach.ContentType = att.ContentType;
                                attach.FileName = att.FileName;
                                re.Attachments.Add(attach);
                            }
                        }
                        emailBL.Add(re);
                    }
                }
                return emailBL;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BO.SalesPerson> GetSalesPersonList()
        {
            List<BO.SalesPerson> salesPeople = new List<BO.SalesPerson>();
            DataTable salePeopleDL = new DataTable();
            salePeopleDL = obj.GetSalesPersonList();

            if (salePeopleDL != null)
            {
                foreach (DataRow row in salePeopleDL.Rows)
                {
                    BO.SalesPerson SalesBL = new BO.SalesPerson();

                    SalesBL.SalesPersonID = Convert.ToInt32(row["SalesPersonID"]);
                    SalesBL.SalesPersonName = Convert.ToString(row["SalesPersonName"]);
                    SalesBL.EmailID = Convert.ToString(row["EmailID"]);

                    salesPeople.Add(SalesBL);
                }
            }
            return salesPeople;

        }
        public List<BO.SalesCoordinator> GetSalesCoordinatorList()
        {
            List<BO.SalesCoordinator> salesPeople = new List<BO.SalesCoordinator>();
            DataTable salePeopleDL = new DataTable();
            salePeopleDL = obj.GetSalesCoordinatorList();

            if (salePeopleDL != null)
            {
                foreach (DataRow row in salePeopleDL.Rows)
                {
                    BO.SalesCoordinator SalesBL = new BO.SalesCoordinator();

                    SalesBL.SalesCoordinatorID = Convert.ToInt32(row["SalesCoordinatorID"]);
                    SalesBL.SalesCoordinatorName = Convert.ToString(row["SalesCoordinator"]);
                    SalesBL.EmailID = Convert.ToString(row["EmailID"]);

                    salesPeople.Add(SalesBL);
                }
            }
            return salesPeople;
        }

        public BO.EnquiryList GetEnquiryDetail(int id)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable enqDL = new DataTable();
                enqDL = BTdatamanager.GetEnquiryDetail(id);
                BO.EnquiryList enq = new BO.EnquiryList();
                if (enqDL != null)
                {
                    foreach (DataRow row in enqDL.Rows)
                    {
                        enq.EnqNO = Convert.ToString(row["Enquiry No"]);
                        enq.Reference = Convert.ToString(row["Reference"]);
                        enq.Company = Convert.ToString(row["Company"]);
                        enq.Address = Convert.ToString(row["Address"]);
                        enq.EnqFrom = Convert.ToString(row["Enquiry From"]);
                        enq.DisplayDesc = Convert.ToString(row["View Description"]);
                        enq.SalesPerson = Convert.ToString(row["Salesperson"]);
                        enq.Status = Convert.ToString(row["Status"]);
                        enq.Location = Convert.ToString(row["Location"]);
                        enq.DisplayDate = Convert.ToString(row["DisplayDate"]);
                        enq.SalesPersonID = Convert.ToInt32(row["SalespersonID"]);
                        enq.ContactPersonID = Convert.ToInt32(row["ContactPersonID"]);
                        enq.CPEmailID = Convert.ToString(row["Enquiry From EmailID"]);
                        enq.CPContactNO = Convert.ToString(row["Enquiry From ContactNo"]);
                        enq.CPMobileNO = Convert.ToString(row["Enquiry From MobileNO"]);
                    }
                }

                return enq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddEnquiryFollowUo(BO.EnquiryFollowUp data)
        {
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            int i = 0;
            i = BTdatamanager.AddEnquiryFollowUp(data.EnquiryNo, data.FollowUpID, data.FollowUpNote, data.AddedBy);
            return i;
        }


        public List<BO.EnquiryFollowUp> GetFollowUpListForSelectedEnquiry(int iD)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable FollowUpDL = new DataTable();
                FollowUpDL = BTdatamanager.GetFollowUpListForSelectedEnquiry(iD);
                List<BO.EnquiryFollowUp> FollowUpBL = new List<BO.EnquiryFollowUp>();
                int i = 0;
                if (FollowUpDL != null)
                {
                    foreach (DataRow row in FollowUpDL.Rows)
                    {
                        i = i + 1;
                        BO.EnquiryFollowUp List = new BO.EnquiryFollowUp();
                        List.LogNo = i;
                        List.DisplayDate = Convert.ToString(row["Date"]);
                        List.FollowUpName = Convert.ToString(row["FollowUpName"]);
                        List.FollowUpNote = Convert.ToString(row["FollowUpNote"]);

                        FollowUpBL.Add(List);

                    }
                }

                return FollowUpBL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BO.Enquiry> GetQuotationList(int iD)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable list = new DataTable();
                int i = 0;
                list = BTdatamanager.GetQuotationNumberList(iD);
                List<BO.Enquiry> enqBL = new List<BO.Enquiry>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.Enquiry enq = new BO.Enquiry();
                        i++;
                        enq.EnquiryNO = Convert.ToInt32(row["EnquiryNO"]);
                        enq.DisplayDate = Convert.ToString(row["DisplayDate"]);
                        enq.ShortDesc = Convert.ToString(row["PersonName"]);

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


        public int CheckEnquiryForMail(BO.Enquiry data1)
        {
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            DataTable list = new DataTable();
            int i = 0;
            list = BTdatamanager.CheckEnquiryForMail(data1.MessageID, data1.ThreadID);
            if (list != null)
            {
                foreach (DataRow row in list.Rows)
                {
                    i = Convert.ToInt32(row["EnquiryNO"]);
                }
            }
            return i;
        }


        public int SaveSharedList(string sharedWith, int modifiedBy, DateTime modifiedOn, int ID)
        {
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            int i = BTdatamanager.SaveSharedList(sharedWith, modifiedBy, modifiedOn, ID);
            return i;
        }


        public List<BO.EnquiryList> GetEnquirySummaryForAdmin(DateTime fromDate, DateTime to)
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable enqDL = new DataTable();
                enqDL = BTdatamanager.GetEnquirySummaryForAdmin(fromDate, to);
                List<BO.EnquiryList> enqBL = new List<BO.EnquiryList>();
                if (enqDL != null)
                {
                    foreach (DataRow row in enqDL.Rows)
                    {
                        BO.EnquiryList enq = new BO.EnquiryList();
                        enq.EnqNO = Convert.ToString(row["Enquiry No"]);
                        enq.EnqDate = Convert.ToDateTime(row["Enquiry Date"]);
                        enq.Reference = Convert.ToString(row["Reference"]);
                        enq.Company = Convert.ToString(row["Company"]);
                        enq.Address = Convert.ToString(row["Address"]);
                        enq.EnqFrom = Convert.ToString(row["Enquiry From"]);
                        enq.Description = Convert.ToString(row["Description"]).Trim();
                        enq.DisplayDesc = Convert.ToString(row["View Description"]).Trim();
                        enq.SalesPerson = Convert.ToString(row["Salesperson"]);
                        enq.Status = Convert.ToString(row["Status"]);
                        enq.AttendedBY = Convert.ToString(row["Attended By"]);
                        enq.Location = Convert.ToString(row["Location"]);
                        enq.DisplayDate = Convert.ToString(row["DisplayDate"]);
                        enq.ContactPersonID = Convert.ToInt32(row["ContactPersonID"]);
                        enq.CompanyID = Convert.ToInt32(row["CompanyID"]);
                        enq.LocationID = Convert.ToInt32(row["LocationID"]);
                        enq.SalesPersonID = Convert.ToInt32(row["SalespersonID"]);
                        enq.StatusID = Convert.ToInt32(row["StatusID"]);
                        enq.AddedBYID = Convert.ToInt32(row["AddedBy"]);
                        enq.CPEmailID = Convert.ToString(row["Enquiry From EmailID"]);
                        enq.CPContactNO = Convert.ToString(row["Enquiry From ContactNo"]);
                        enq.CPMobileNO = Convert.ToString(row["Enquiry From MobileNO"]);
                        enq.IsDeleted = Convert.ToBoolean(row["IsDeleted"]);
                        enq.AddedOn = Convert.ToDateTime(row["AddedOn"]);
                        enq.SalesCoordinator = Convert.ToInt32(row["SalesCoordinatorID"]);
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


        public List<BO.EnquirySummary> GetAjaxEnquirySummary(DateTime fromDate, DateTime toDate, string searchText, int statusID, int userID)
        {
            EDL.EnquiryDBManager dBManager = new EDL.EnquiryDBManager();
            List<BO.EnquirySummary> enquiries = new List<BO.EnquirySummary>();
            DataTable data = new DataTable();
            int i = 0;
            data = dBManager.GetAjaxEnquirySummary(fromDate,toDate,searchText,statusID,userID);
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    i++;
                    BO.EnquirySummary enq = new BO.EnquirySummary();
                    enq.SrNo = i;
                    enq.Date = Convert.ToString(row["EnquiryDate"]);
                    enq.EnquiryNo = Convert.ToInt32(row["EnquiryNo"]);
                    enq.ContactPersonID = Convert.ToInt32(row["ContactPersonID"]);
                    enq.Reference = Convert.ToString(row["Reference"]);
                    enq.CompanyName = Convert.ToString(row["CompanyName"]);
                    enq.LocationName = Convert.ToString(row["Location"]);
                    enq.PersonName = Convert.ToString(row["PersonName"]);
                    enq.Assigned = Convert.ToString(row["Assigned"]).Trim();
                    enq.AddedBy = Convert.ToString(row["AddedBy"]).Trim();
                    enquiries.Add(enq);
                }
            }
            return enquiries;
        }


        public BO.Enquiry GetEnquiryDetails(int enquiryNo)
        {
            EDL.EnquiryDBManager dBManager = new EDL.EnquiryDBManager();
            BO.Enquiry enq = new BO.Enquiry();
            DataTable data = new DataTable();
            data = dBManager.GetEnquiryDetails(enquiryNo);
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    enq.Reference = Convert.ToString(row["Reference"]);
                    enq.SalesPersonID = Convert.ToInt32(row["SalesPersonID"]);
                    enq.SalesCoordinatorID = Convert.ToInt32(row["SalesCoordinatorID"]);
                    enq.Desc = Convert.ToString(row["Description"]);
                }
            }
            return enq;
        }

        public BO.ResponseMessage AjaxAddOrEditEnquiry(BO.Enquiry data)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();
            try
            {
                EDL.EnquiryDBManager dBManager = new EDL.EnquiryDBManager();
                DataTable dataTable = new DataTable();
                dataTable = dBManager.AjaxAddOrEditEnquiry(data.EnquiryNO,data.ContactPersonID,data.SalesPersonID,data.SalesCoordinatorID, data.Reference, data.Desc, data.AddedBY,data.AddedON);
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                        message.Data = Convert.ToString(row["DATA"]);
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }


        public BO.ResponseMessage AjaxDeleteEnquiry(BO.Enquiry data)
        {
            BO.ResponseMessage message = new BO.ResponseMessage();
            try
            {
                EDL.EnquiryDBManager dBManager = new EDL.EnquiryDBManager();
                DataTable dataTable = new DataTable();
                dataTable = dBManager.AjaxDeleteEnquiry(data.EnquiryNO, data.Remark, data.AddedBY, data.AddedON);
                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        message.Message = Convert.ToString(row["message"]);
                        message.Status = Convert.ToInt32(row["Status"]);
                    }
                }
                return message;
            }
            catch (Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }


    }
}
