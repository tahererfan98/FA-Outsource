using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BombayToolsEntities.BusinessEntities;
using DB = BombayToolsDBConnector;

namespace BombayToolsDataLayer.Email
{
    public class EmailDBManager
    {
        public DataTable AjaxSheduleCampaign(DataTable dt, MailCampaign campaign)
        {
            string sqlCommandString;
            DB.DBConnection objConn = new DB.DBConnection();
            using (SqlConnection connection = objConn.GetConnection)
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    sqlCommandString = "USP_AddNewMailCampaign";
                    SqlCommand objCommand = new SqlCommand(sqlCommandString, connection);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@TEMPLATEID", campaign.TemplateID);
                    objCommand.Parameters.AddWithValue("@CAMPAIGNNAME", campaign.CampaignName);
                    objCommand.Parameters.AddWithValue("@MAILID", campaign.EmailID);
                    objCommand.Parameters.AddWithValue("@PASSWORD", campaign.CampaignPassword);
                    objCommand.Parameters.AddWithValue("@AddedBy", campaign.AddedBy);
                    objCommand.Parameters.AddWithValue("@AddedOn", campaign.AddedOn);
                    if (dt != null)
                    {
                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@PT_EmailCampaign";
                        param1.Value = dt;
                        param1.TypeName = "PT_EmailCampaign";
                        param1.SqlDbType = SqlDbType.Structured;
                        objCommand.Parameters.Add(param1);
                    }
                    DataTable dtClass = new DataTable();


                    using (SqlDataAdapter _Data = new SqlDataAdapter())
                    {
                        _Data.SelectCommand = objCommand;

                        _Data.Fill(dtClass);
                    }
                    connection.Close();

                    return dtClass;

                }
                catch (Exception ex)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    throw ex;
                }
            }
        }
    }
}
