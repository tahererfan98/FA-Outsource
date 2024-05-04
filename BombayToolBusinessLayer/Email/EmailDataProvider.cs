using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombayToolsEntities.BusinessEntities;
using DB = BombayToolsDataLayer.Email;

namespace BombayToolBusinessLayer.Email
{
    public class EmailDataProvider
    {
        public ResponseMessage AjaxSheduleCampaign(DataTable dt, MailCampaign campaign)
        {
            ResponseMessage message = new ResponseMessage();
            try
            {
                DB.EmailDBManager dBManager = new DB.EmailDBManager();
                DataTable data = new DataTable();
                data = dBManager.AjaxSheduleCampaign(dt,campaign);
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
            catch(Exception ex)
            {
                message.Status = 0;
                message.Message = ex.Message;
                return message;
            }
        }
    }
}
