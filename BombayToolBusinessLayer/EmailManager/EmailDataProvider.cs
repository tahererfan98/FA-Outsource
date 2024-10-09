using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = BombayToolsDataLayer;
using System.IO;
using System.Threading;
using BO = BombayToolsEntities.BusinessEntities;
using System.Data;

namespace BombayToolBusinessLayer.EmailManager
{
    public class EmailDataProvider
    {
        DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();

        public int SaveTokenPathForUser(int userID, string credPath)
        {
            int i = BTdatamanager.SaveTokenPathForUser(userID, credPath);
            return i;
        }

        public string SaveEMailAganistQuotation(BO.QuotationAganistEmail data)
        {
            try
            {
                string success = "Details saved successfully";
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                int isRecordAdded = 0;
                isRecordAdded = BTdatamanager.SaveEMailAganistQuotation(data.QuotID, data.MessageID,data.ThreadID,data.Snippet, data.AddedBy, data.ModifiedBy, data.IsActive);
                if (isRecordAdded != 0)
                {
                    return success;
                }
                else
                {
                    return "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string SaveEMailAganistBox(BO.QuotationAganistEmail data)
        {
            try
            {
                string success = "Details saved successfully";
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                int isRecordAdded = 0;
                isRecordAdded = BTdatamanager.SaveEMailAganistBox(data.AutoID, data.MessageID, data.ThreadID, data.Snippet, data.AddedBy, data.ModifiedBy, data.IsActive);
                if (isRecordAdded != 0)
                {
                    return success;
                }
                else
                {
                    return "Something went wrong";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<BO.QuotationAganistEmail> GetEMailListForQuotation(int ID)
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetEMailListForQuotation(ID);
            List<BO.QuotationAganistEmail> dataBL = new List<BO.QuotationAganistEmail>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.QuotationAganistEmail data = new BO.QuotationAganistEmail();
                    data.MessageID = Convert.ToString(row["MessageID"]);
                    data.ThreadID = Convert.ToString(row["ThreadID"]);
                    data.AddedBy = Convert.ToInt32(row["AddedBy"]);
                    data.TokenPath = Convert.ToString(row["TokenPath"]);
                    dataBL.Add(data);
                }
            }
            return dataBL;
        }

        public List<BO.EmailScanner> GetEmailVerfied(DataTable dataTable, List<BO.Recieved_Emails> emails)
        {
            DataTable dt1 = new DataTable();
            BombayToolsDBConnector.Helper.DBOperationsForBombayTools db = new BombayToolsDBConnector.Helper.DBOperationsForBombayTools();
            dt1 = db.sub_Query_GetEmailVerfied("USP_EmailScanVerification", dataTable);
            List<BO.EmailScanner> dataBL = new List<BO.EmailScanner>();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    BO.EmailScanner data = new BO.EmailScanner();
                    data.MessageID = Convert.ToString(row["MessageID"]);
                    data.ContactID = Convert.ToInt32(row["ContactPersonID"]);
                    data.IsRegistered = Convert.ToInt32(row["IsRegistered"]);
                    dataBL.Add(data);
                }
            }
            
            foreach (BO.Recieved_Emails item in emails)
            {
                for(int i = 0;i< dataBL.Count;i++)
                    {
                        if (item.ID == dataBL[i].MessageID) {
                        dataBL[i].FromName = item.FromName;
                        dataBL[i].Subject = item.Subject;
                        dataBL[i].Body = item.Body;
                        }
                    }
            }
            return dataBL;
        }

        public BO.QuotationAganistEmail GetLinkedMailDetail(int ID)
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetLinkedMailDetail(ID);
            BO.QuotationAganistEmail data = new BO.QuotationAganistEmail();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    data.MessageID = Convert.ToString(row["MessageID"]);
                    data.ThreadID = Convert.ToString(row["ThreadID"]);
                    data.AddedBy = Convert.ToInt32(row["AddedBy"]);
                }
            }
            return data;
        }

        public BO.QuotationAganistEmail GetLinkedPipelineMail(int id)
        {
            DataTable dt1 = new DataTable();
            DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
            dt1 = BTdatamanager.GetLinkedPipelineMail(id);
            BO.QuotationAganistEmail data = new BO.QuotationAganistEmail();
            if (dt1.Rows.Count != 0)
            {
                foreach (DataRow row in dt1.Rows)
                {
                    data.MessageID = Convert.ToString(row["MessageID"]);
                    data.ThreadID = Convert.ToString(row["ThreadID"]);
                    data.AddedBy = Convert.ToInt32(row["AddedBy"]);
                }
            }
            return data;
        }
    }
}
