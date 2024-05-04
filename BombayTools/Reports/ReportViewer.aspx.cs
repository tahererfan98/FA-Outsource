

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using PODP = BombayToolsEntities.BusinessEntities.PurchaseOrderD;
using BO = BombayToolsEntities.BusinessEntities;
//using GRNDBM = TrackerPurchaseDataLayer.GRN;
//using OUTDBM = TrackerPurchaseDataLayer.OutSource;


namespace BombayTools.Reports
{
    public partial class ReportViewer : System.Web.UI.Page
    {

        //GRNDBM.GRNDBManager GRNDBManager = new GRNDBM.GRNDBManager();
        //OUTDBM.OutSourceDBManager OutsourceBManager = new OUTDBM.OutSourceDBManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string PrintType = Request.QueryString["PrintType"];

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;


                List<BO.PurchaseOrderD> ItemArray = Session["ItemArray"] as List<BO.PurchaseOrderD>;
                string PONO = Convert.ToString(Session["PONO"]);
                string LableSize = Convert.ToString(Session["LableSize"]);



                if (LableSize == "75-50")
                {
                    ReportViewer1.LocalReport.ReportPath = @"Reports\rpt_RM_Barcode_Format2.rdlc";
                }
                if (LableSize == "70-40")
                {
                    ReportViewer1.LocalReport.ReportPath = @"Reports\rpt_RM_Barcode_Format_70-40.rdlc";
                }


                ReportViewer1.LocalReport.DataSources.Clear();
                DataTable dt = new DataTable();

                DataTable ItemTable = new DataTable();

                ItemTable.Columns.Add("ItemID");
                ItemTable.Columns.Add("PrintQTY");
                ItemTable.TableName = "PT_POBarcodeItem";

                foreach (BO.PurchaseOrderD element in ItemArray)
                {
                    DataRow row = ItemTable.NewRow();

                    row["ItemID"] = element.ItemID;
                    row["PrintQTY"] = element.PrintQTY;
                    ItemTable.Rows.Add(row);
                }
                //dt = POCont.POItemBarcodePrintingData(ItemTable);
                Session["ItemArray"] = null;
                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Add(rds);
                dt.Dispose();
                byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                //Response.AddHeader("content-disposition", "attachment; filename=Barcode." + extension);
                Response.AddHeader("content-disposition", "attachment; filename=" + PONO + "." + extension);
                Response.BinaryWrite(bytes); // create the file
                Response.Flush(); // send it to the client to download
                
                //List<BO.PurchaseOrderD> objlt = (List<BO.PurchaseOrderD>)Session["ItemArray"];
                //List<BO.PurchaseOrderD> ItemArrayList = ItemArray;

                //if (PrintType == "GRN")
                //{


                //    ReportViewer1.LocalReport.ReportPath = @"Reports\rpt_RM_Barcode_Format2.rdlc";
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    string GRNNo = Request.QueryString["GRNNo"];
                //    DataTable dt = new DataTable();
                //    dt = GRNDBManager.GRNPrintForBarcode(GRNNo);
                //    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                //    ReportViewer1.LocalReport.DataSources.Add(rds);
                //    dt.Dispose();

                //    byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                //    Response.Buffer = true;
                //    Response.Clear();
                //    Response.ContentType = mimeType;
                //    Response.AddHeader("content-disposition", "attachment; filename=" + GRNNo + "." + extension);
                //    Response.BinaryWrite(bytes); // create the file
                //    Response.Flush(); // send it to the client to download

                //}
                //if (PrintType == "RepairIn")
                //{
                //    ReportViewer1.LocalReport.ReportPath = @"Reports\rpt_RM_Barcode_Format2.rdlc";
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    string RINO = Request.QueryString["RINO"];
                //    DataTable dt = new DataTable();
                //    dt = OutsourceBManager.RepairInPrintForBarcode(RINO);
                //    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                //    ReportViewer1.LocalReport.DataSources.Add(rds);
                //    dt.Dispose();

                //    byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                //    Response.Buffer = true;
                //    Response.Clear();
                //    Response.ContentType = mimeType;
                //    Response.AddHeader("content-disposition", "attachment; filename=" + RINO + "." + extension);
                //    Response.BinaryWrite(bytes); // create the file
                //    Response.Flush(); // send it to the client to download
                //}


            }
            //if (ClientQueryString["PrintType"] != "GRN")
            //{

            //    Warning[] warnings;
            //    string[] streamIds;
            //    string mimeType = string.Empty;
            //    string encoding = string.Empty;
            //    string extension = string.Empty;

            //    ReportViewer1.LocalReport.ReportPath = @"\Reports\rpt_RM_Barcode_Format2.rdlc";
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    //string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings[""].ConnectionString;
            //    //SqlConnection conn = new SqlConnection(connString);
            //    string GRNNo = Request.QueryString["GRNNo"];
            //    DataTable dt = new DataTable();
            //    dt = GRNDBManager.GRNPrintForBarcode(GRNNo);
            //    //dt = PrintConroller.PrintController.GRNPrintPreviewForBarcode("");
            //    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            //    ReportViewer1.LocalReport.DataSources.Add(rds);
            //    dt.Dispose();

            //byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            //Response.Buffer = true;
            //Response.Clear();
            //Response.ContentType = mimeType;
            //Response.AddHeader("content-disposition", "attachment; filename=" + GRNNo + "." + extension);
            //Response.BinaryWrite(bytes); // create the file
            //Response.Flush(); // send it to the client to download
        }




    }
    //}
}