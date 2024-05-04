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

namespace BombayToolBusinessLayer.Email
{


    public class GmailAPI
    {
        public List<BO.QuotationMaster> GetQuotationList()
        {
            try
            {
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                DataTable list = new DataTable();
                int i = 0;
                //list = BTdatamanager.GetQuotationNumberList();
                List<BO.QuotationMaster> enqBL = new List<BO.QuotationMaster>();
                if (list != null)
                {

                    foreach (DataRow row in list.Rows)
                    {
                        BO.QuotationMaster enq = new BO.QuotationMaster();
                        i++;
                        enq.QTNNO = Convert.ToInt32(row["QuotationNo"]);
                        enq.Industry = Convert.ToString(row["QuotID"]);


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

        public string SaveEMailAganistQuotation(BO.QuotationAganistEmail data)
        {
            try
            {
                string success = "Details saved successfully";
                DB.BombayToolsDBManager BTdatamanager = new DB.BombayToolsDBManager();
                int isRecordAdded =0;
                isRecordAdded = 0;
                if(isRecordAdded != 0)
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
                    dataBL.Add(data);
                }
            }
            return dataBL;
        }
    }
}
