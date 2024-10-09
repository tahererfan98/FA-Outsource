using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBView = BombayToolBusinessLayer.Enquiry;
using BO = BombayToolsEntities.BusinessEntities;
using Newtonsoft.Json;
using BombayTools.Filters;
using System.Diagnostics;
using DP = BombayToolBusinessLayer.Login;
using POBL = BombayToolBusinessLayer.ExportInvoice;
using HC = BombayToolsDBConnector.Helper;
using BombayToolsEntities.BusinessEntities;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Web.Services.Description;
using System.Net.NetworkInformation;
using System.Web.DynamicData;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using static Google.Apis.Requests.BatchRequest;
using SelectPdf;
using System.Net.Mail;
using System.Net;
using BombayToolBusinessLayer.Email;
using System.Security.Policy;

namespace BombayTools.Controllers.Enquiry
{
    [UserAuthenticationFilter]

    public class EnquiryController : Controller
    {
        DP.LoginDataProvider LoginManager = new DP.LoginDataProvider();
        DBView.EnquiryDataProvider BussinesManager = new DBView.EnquiryDataProvider();
        POBL.ExportInvoiceBusinessLayer DataProvider = new POBL.ExportInvoiceBusinessLayer();

        //////////// 03-02-23 Enquiry

        public ActionResult EnquiryEntrySummary()
        {
            return View();
        }

        public JsonResult GetEnquiryEntrySummary(BO.EnquiryM data1)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            List<BO.EnquiryM> list = new List<BO.EnquiryM>();
            list = BussinesManager.GetEnquiryEntrySummary(data1, UserID);
            return Json(list);
        }

        public ActionResult _AddOrEditEnquiry(string ENQNO, String Action)
        {
            List<BO.CustomerM> CustomerList = BussinesManager.GetCustomerMasterList();
            ViewBag.ddlCustomerDropdown = new SelectList(CustomerList, "CustomerID", "CustomerName");

            List<BO.EnquiryM> FGTypeListM = BussinesManager.GetFGTypeList();
            ViewBag.FGTypeListM = new SelectList(FGTypeListM, "FGTypeID", "FGTypeName");
            ViewBag.FGTypeListM = JsonConvert.SerializeObject(ViewBag.FGTypeListM);

            if (ENQNO != "0")
            {
                BO.EnquiryM data = new BO.EnquiryM();
                data = BussinesManager.GetEnquiryDetail(ENQNO);
                ViewBag.Action = Action;
                ViewBag.ENQNO = ENQNO;
                ViewBag.ENQDate = data.ENQDate;
                ViewBag.RevisionNo = data.RevisionNo;
                ViewBag.CustomerID = data.CustomerID;
                ViewBag.ProjectID = data.ProjectID;
                ViewBag.CustomerName = data.CustomerName;
                ViewBag.ProjectName = data.ProjectName;
                ViewBag.Remarks = data.Remarks;
                ViewBag.UserName = data.UserName;

                ViewBag.ENQItemD = JsonConvert.SerializeObject(data.ENQItemD);
                ViewBag.ENQSizesD = JsonConvert.SerializeObject(data.ENQSizesD);
            }
            else
            {
                ViewBag.ENQItemD = null;
                ViewBag.ENQSizesD = null;
                ViewBag.Action = Action;
            }

            ViewBag.ENQNO = ENQNO;
            return PartialView();
        }

        public ActionResult GetProjectListAgainstCustomer(int CustomerID)
        {
            List<BO.EnquiryInfo> Location = BussinesManager.GetProjectListAgainstCustomer(CustomerID);
            return Json(Location);
        }

        public ActionResult GetPINOListAgainstCustomer(int CustomerID, int ProjectID)
        {
            List<BO.PIMaster> OpenIndentList = new List<BO.PIMaster>();
            OpenIndentList = BussinesManager.GetPINOListAgainstCustomer(CustomerID, ProjectID);
            var jsonResult = Json(OpenIndentList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult GetItemListAgainstPINONew(List<PIMaster> PIItemListSearch1)
        {
            BO.PIDetails OpenIndentList = new BO.PIDetails();
            DataTable dtWONO = new DataTable();
            dtWONO.Columns.Add("PINO");
            dtWONO.TableName = "PT_PINOItemList";
            foreach (BO.PIMaster item in PIItemListSearch1)
            {
                DataRow row = dtWONO.NewRow();
                row["PINO"] = item.PINO;
                dtWONO.Rows.Add(row);
            }

            OpenIndentList = BussinesManager.GetItemListAgainstPINONew(dtWONO);
            List<BO.PIDetails> POBilling = OpenIndentList.POBilling;
            return Json(new
            {
                POBilling = POBilling
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPISizesListAgainstWONO(string PINO, string WONO)
        {
            List<BO.EnquiryD> OpenIndentList = new List<BO.EnquiryD>();
            OpenIndentList = BussinesManager.GetPISizesListAgainstWONO(PINO, WONO);
            var jsonResult = Json(OpenIndentList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveEnquiryEntry( BO.EnquiryM EnquiryDetails, List<BO.EnquiryD> ItemListD , List<BO.EnquiryD> SizesListD)
        {
            try
            {
                var AddedBy = Convert.ToInt16(Session["userid"]);
                EnquiryDetails.AddedOn = System.DateTime.Now;
                BO.ResponseMessage message = new BO.ResponseMessage();
                DataTable dataTable = new DataTable();
                
                if (ItemListD != null)
                {
                    dataTable.Columns.Add("SrNo");
                    dataTable.Columns.Add("SpecID");
                    dataTable.Columns.Add("PINO");
                    dataTable.Columns.Add("WONO");
                    dataTable.Columns.Add("ItemDesc");
                    dataTable.Columns.Add("ProjectName");
                    dataTable.Columns.Add("Unit");
                    dataTable.Columns.Add("Qty");
                    dataTable.Columns.Add("SQM");
                    dataTable.Columns.Add("OutQty");
                    dataTable.Columns.Add("OutSQM");
                    dataTable.Columns.Add("OutTypeID");
                    dataTable.Columns.Add("IsAllSelected");
                    dataTable.TableName = "PT_ENQItemList";
                    foreach (BO.EnquiryD item in ItemListD)
                    {
                        DataRow row = dataTable.NewRow();
                        row["SrNo"] = item.SrNo;
                        row["SpecID"] = item.SpecID;
                        row["PINO"] = item.PINO;
                        row["WONO"] = item.WONO;
                        row["ItemDesc"] = item.ItemDescription;
                        row["ProjectName"] = item.ProjectName;
                        row["Unit"] = item.Unit;
                        row["Qty"] = item.Qty;
                        row["SQM"] = item.SQM;
                        row["OutQty"] = item.OutQty;
                        row["OutSQM"] = item.OutSQM;
                        row["OutTypeID"] = item.OutTypeID;
                        row["IsAllSelected"] = item.IsAllSelected;
                        dataTable.Rows.Add(row);
                    }
                }

                DataTable dataTable1 = new DataTable();

                if (SizesListD != null)
                {
                    dataTable1.Columns.Add("PINO");
                    dataTable1.Columns.Add("WONO");
                    dataTable1.Columns.Add("SizeAutoID");
                    dataTable1.Columns.Add("SrNo");
                    dataTable1.Columns.Add("StepSrNo");
                    dataTable1.Columns.Add("SpecID");
                    dataTable1.Columns.Add("Height");
                    dataTable1.Columns.Add("Width");
                    dataTable1.Columns.Add("Qty");
                    dataTable1.Columns.Add("SQM");
                    dataTable1.Columns.Add("Remark");
                    dataTable1.Columns.Add("IsStepGlass");
                    dataTable1.TableName = "PT_ENQSizesList";
                    var i = 0;
                    foreach (BO.EnquiryD item in SizesListD)
                    {
                        i++;
                        DataRow row = dataTable1.NewRow();
                        row["PINO"] = item.PINO;
                        row["WONO"] = item.WONO;
                        row["SizeAutoID"] = item.AutoID;
                        row["StepSrNo"] = item.StepSrNo;
                        row["SrNo"] = item.SrNo; 
                        row["SpecID"] = item.SpecID;
                        row["Height"] = item.Height;
                        row["Width"] = item.Width;
                        row["Qty"] = item.Qty;
                        row["SQM"] = item.SQM;
                        row["Remark"] = item.Remark;
                        row["IsStepGlass"] = item.IsStepGlass;
                        dataTable1.Rows.Add(row);
                    }
                }
               
                message = BussinesManager.SaveEnquiryEntry(EnquiryDetails, AddedBy, dataTable, dataTable1);
                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //////////// 03-02-23 Enquiry Send to Partner
        public ActionResult _AddorEditENQSendToPartner(String ESNO, string ENQNO, String Action)
        {
            List<BO.CustomerM> OSPartnerList = BussinesManager.GetOutsourcePartnerList();
            ViewBag.ddlOSPartnerDropdown = new SelectList(OSPartnerList, "PartnerID", "PartnerName");

            BO.EnquiryM data = new BO.EnquiryM();
            data = BussinesManager.GetEnquiryDetail(ENQNO);
            ViewBag.ESNO = ESNO;
            ViewBag.ENQNO = ENQNO;
            ViewBag.AllWONO = data.AllWONO;
            ViewBag.ENQID = data.ENQID;
            ViewBag.ENQDate = data.ENQDate;
            ViewBag.RevisionNo = data.RevisionNo;
            ViewBag.CustomerID = data.CustomerID;
            ViewBag.ProjectID = data.ProjectID;
            ViewBag.CustomerName = data.CustomerName;
            ViewBag.ProjectName = data.ProjectName;
            ViewBag.Remarks = data.Remarks;
            ViewBag.UserName = data.UserName;
            ViewBag.Action = Action;

            ViewBag.ENQItemD = JsonConvert.SerializeObject(data.ENQItemD);

            if(Action == "View") {
                BO.EnquiryM data1 = new BO.EnquiryM();
                data1 = BussinesManager.GetEnquirySentPartnerDetail(ESNO, ENQNO);
                ViewBag.ENQSentPartnerD = JsonConvert.SerializeObject(data1.ENQSentPartnerD);
                ViewBag.AttachmentD = JsonConvert.SerializeObject(data1.AttachmentD);
            }
            else
            {
                ViewBag.ENQSentPartnerD = null;
            }
            return PartialView();
        }

        public ActionResult _AddAttachmentForENQSendToPartner()
        {
            return PartialView();
        }

        public ActionResult UploadEnquirySentAttachment(BO.EnquiryM fileData)
        {
            BO.AttachmentM SupplierInfoAttach = new BO.AttachmentM();
            if (Request.Files.Count > 0)
            {
                try
                {
                    int Userid = Convert.ToInt16(Session["userid"]);
                    string Type = fileData.EnqType;
                    Type = Type + Userid;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        string root = Server.MapPath("~/Uploads/ENQSentAttachment/" + Type + "/");
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string contentType;
                        contentType = MimeMapping.GetMimeMapping(fname);
                        if (!System.IO.Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        string check = Path.Combine(Server.MapPath("~/Uploads/ENQSentAttachment/" + Type + "/"), fname);
                        if (System.IO.File.Exists(fname))
                        {
                            System.IO.File.Delete(fname);
                        }
                        file.SaveAs(check);
                        SupplierInfoAttach.DocName = fname;
                        SupplierInfoAttach.FilePath = check;
                        SupplierInfoAttach.ContentType = contentType;
                        //SupplierInfoAttach.NewFileName = NewFileName;
                    }
                }
                catch (System.Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            return Json(SupplierInfoAttach);
        }

        public ActionResult TempDataForENQSentM(string DocName, string Filepath, string ContentType)
        {
            TempData["DocName"] = DocName;
            TempData["Filepath"] = Filepath;
            TempData["ContentType"] = ContentType;
            int i = 1;
            return Json(i);

        }
        
        public FileResult DownloadENQFile(int id)
        {
            string DocName = Convert.ToString(TempData["DocName"]);
            string Filepath = Convert.ToString(TempData["Filepath"]);
            string ContentType = Convert.ToString(TempData["ContentType"]);

            byte[] fileBytes = System.IO.File.ReadAllBytes(Filepath);

            return File(fileBytes, ContentType, DocName);

        }

        public ActionResult DeleteFileEnquirySentM(string ESNO, string DocName, string Filepath, string ContentType)
        {
            int AddedBy = Convert.ToInt16(Session["Tracker_userID"]);
            string message = BussinesManager.DeleteFileEnquirySentM(ESNO, DocName, Filepath, ContentType, AddedBy);

            string fname = Filepath;
            if (System.IO.File.Exists(fname))
            {
                System.IO.File.Delete(fname);
            }
            return Json(message);

        }

        [HttpPost]
        public ActionResult StorePINoInTemp(string ENQNo, List<BO.EnquiryM> ItemListD, int PartnerID)
        {
            TempData["ENQNo"] = ENQNo;
            TempData["PartnerID"] = PartnerID;
            TempData["ItemListD"] = ItemListD;
            TempData.Keep("ItemListD");
            int i = 1;
            return Json(i);
        }

        ////////////// Generate EXCEL TEMPLATE

        public ActionResult ExportToExcelWODetailsTemplate()
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                //var Filenames = "Template";
                //var Name = "PartnerID_";
                List<EnquiryM> ItemListD = new List<EnquiryM>();
                string ENQNO = (string)TempData["ENQNo"];
                var PartnerID = TempData["PartnerID"];
                ItemListD = (List<EnquiryM>)TempData["ItemListD"];
                BO.EnquiryD OpenIndentList = new BO.EnquiryD();
                DataTable dtWONO = new DataTable();
                dtWONO.Columns.Add("PINO");
                dtWONO.Columns.Add("WONO");
                dtWONO.TableName = "PT_ItemListForTemplate";
                foreach (BO.EnquiryM item in ItemListD)
                {
                    DataRow row = dtWONO.NewRow();
                    row["PINO"] = item.PINO;
                    row["WONO"] = item.WONO;
                    dtWONO.Rows.Add(row);
                }
                DataSet dataSet = new DataSet();
                dataSet = BussinesManager.GetSizesListForTemplateOLD(dtWONO, ENQNO);

                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                dt1 = dataSet.Tables[0];
                dt2 = dataSet.Tables[1];

                using (var package = new ExcelPackage())
                {
                    // Save the Excel package to a MemoryStream
                    using (var stream = new MemoryStream())
                    {
                        EnquiryD WOSpecListM = new EnquiryD();

                        if (dt1 != null)
                        {
                            List<EnquiryD> WOSpecList = new List<EnquiryD>();

                            foreach (DataRow row in dt1.Rows)
                            {
                                WOSpecListM.WOSpec = Convert.ToString(row["WOSpec"]);
                                WOSpecListM.WONO = Convert.ToString(row["WONo"]);
                                WOSpecListM.WONumber = Convert.ToString(row["WONumber"]);
                                WOSpecList.Add(WOSpecListM);

                                if (dt2 != null)
                                {
                                    int i = 0;
                                    List<EnquiryD> TempList = new List<EnquiryD>();
                                    foreach (DataRow row1 in dt2.Rows)
                                    {
                                        EnquiryD OpenGRNData = new EnquiryD();
                                        if (WOSpecListM.WONO == Convert.ToString(row1["WONo"]))
                                        {
                                            OpenGRNData.SrNo = Convert.ToInt32(row1["SrNo"]); ;
                                            OpenGRNData.StepSrNo = Convert.ToString(row1["StepSrNo"]);
                                            //OpenGRNData.PINO = Convert.ToString(row1["PINO"]);
                                            //OpenGRNData.WONO = Convert.ToString(row1["WONo"]);
                                            //OpenGRNData.SpecID = Convert.ToInt32(row1["SpecID"]);
                                            OpenGRNData.Width = Convert.ToInt32(row1["Width"]);
                                            OpenGRNData.Height = Convert.ToInt32(row1["Height"]);
                                            OpenGRNData.Qty = Convert.ToInt32(row1["Pcs"]);
                                            OpenGRNData.SQM = Convert.ToDecimal(row1["SQM"]);
                                            OpenGRNData.Remark = Convert.ToString(row1["Remark"]);
                                            TempList.Add(OpenGRNData);
                                        }

                                    }
                                    DataTable dtTemp = new DataTable();

                                    if (TempList != null)
                                    {
                                        dtTemp.Columns.Add("SrNo");
                                        dtTemp.Columns.Add("StepSrNo");
                                        //dtTemp.Columns.Add("PINO");
                                        //dtTemp.Columns.Add("WONO");
                                        //dtTemp.Columns.Add("SpecID");
                                        dtTemp.Columns.Add("Width");
                                        dtTemp.Columns.Add("Height");
                                        dtTemp.Columns.Add("Pcs");
                                        dtTemp.Columns.Add("SQM");
                                        dtTemp.Columns.Add("Remark");
                                        foreach (BO.EnquiryD item in TempList)
                                        {
                                            DataRow row2 = dtTemp.NewRow();
                                            row2["SrNo"] = item.SrNo;
                                            row2["StepSrNo"] = item.StepSrNo;
                                            //row2["PINO"] = item.PINO;
                                            //row2["WONO"] = item.WONO;
                                            //row2["SpecID"] = item.SpecID;
                                            row2["Width"] = item.Width;
                                            row2["Height"] = item.Height;
                                            row2["Pcs"] = item.Qty;
                                            row2["SQM"] = item.SQM;
                                            row2["Remark"] = item.Remark;
                                            dtTemp.Rows.Add(row2);
                                        }
                                    }
                                    AddToExcelSheet(package, dtTemp, WOSpecListM.WONumber, WOSpecListM.WOSpec); //adding in sheet
                                }

                            }

                        }
                        //string filePath = @"D:\FAOutsource\BombayTools\Uploads\Template\"+ ENQNO+"_"+ PartnerID + ".xlsx"; // Provide your desired path
                        //string filePath = @"~/Uploads/ENQSentAttachment/" + ENQNO+"_"+ PartnerID + ".xlsx"; // Provide your desired path
                        string filePath = Server.MapPath("~/Uploads/ENQSentAttachment/" + ENQNO + "_" + PartnerID + ".xlsx"); // Provide your desired path
                        FileInfo fileInfo = new FileInfo(filePath);
                        package.SaveAs(fileInfo);
                        package.SaveAs(stream);
                        stream.Position = 0;
                        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ENQNO + "_"+ PartnerID + ".xlsx");
                        //return Convert.ToString(filePath);
                        //return Content(filePath.Replace("D:\\FAOutsource\\BombayTools\\", "http://localhost:44951/"), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        private void AddToExcelSheet(ExcelPackage package, DataTable data, string WONumber, string WOSpec)
        {
            // Add a new worksheet to the Excel package
            var worksheet = package.Workbook.Worksheets.Add(WONumber);
            DataTable CompanyMaster = new DataTable();

            // Fill the worksheet with data from the DataTable
            worksheet.Cells["A1"].Value = "Work Order Cutting List";
            worksheet.Cells["A2"].Value = WOSpec;

            worksheet.Cells[1, 1, 1, 7].Merge = true; // Merge 7 columns for the header
            worksheet.Cells["A2:G7"].Merge = true; // Merge 6 columns for the WOSpec
                                                   // Enable text wrapping for the merged range (A2:F7)
            worksheet.Cells["A2:G7"].Style.WrapText = true;
            // Set vertical alignment for A2 to Top
            worksheet.Cells["A2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;

            // Add borders to the entire range A2:F7
            using (var range = worksheet.Cells["A2:G7"])
            {
                range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }

            worksheet.Column(1).AutoFit();

            // Style the header cell
            var headerCell = worksheet.Cells[1, 1];
            headerCell.Style.Font.Bold = true;
            headerCell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            headerCell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Set horizontal alignment
            headerCell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // Set vertical alignment
            headerCell.Style.Font.Size = 14; // Set font size
            headerCell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);

            // Set the column names in the first row
            for (int i = 0; i < data.Columns.Count; i++)
            {
                worksheet.Cells[8, i + 1].Value = data.Columns[i].ColumnName;
                var headerCell3 = worksheet.Cells[8, i + 1];
                headerCell3.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                headerCell3.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
                headerCell3.Style.Font.Bold = true;

                worksheet.Cells[8, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[8, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[8, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[8, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            }

            for (int row = 0; row < data.Rows.Count; row++)
            {
                for (int col = 0; col < data.Columns.Count; col++)
                {
                    object cellValue = data.Rows[row][col];

                    // Set the number format for the first 5 columns
                    if (col < 5)
                    {
                        worksheet.Cells[row + 9, col + 1].Style.Numberformat.Format = "General";
                    }
                    else
                    {
                        // Set the format for the last column as a string
                        worksheet.Cells[row + 9, col + 1].Style.Numberformat.Format = "@";
                    }

                    // Check if the content can be converted to a number
                    if (double.TryParse(cellValue.ToString(), out double numericValue))
                    {
                        // If successful, set the value as a number
                        worksheet.Cells[row + 9, col + 1].Value = numericValue;
                    }
                    else
                    {
                        // If not successful, set the value as a string
                        worksheet.Cells[row + 9, col + 1].Value = cellValue.ToString();
                    }

                    // Apply border styles
                    worksheet.Cells[row + 9, col + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row + 9, col + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row + 9, col + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[row + 9, col + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                }
            }

            ///// Calculate totals for columns 4 and 5
            double totalColumn4 = 0;
            double totalColumn5 = 0;

            //for (int row = 0; row < data.Rows.Count; row++)
            //{
            //    totalColumn4 += Convert.ToDouble(data.Rows[row][4]); // Assuming column 4 is at index 3
            //    totalColumn5 += Convert.ToDouble(data.Rows[row][5]); // Assuming column 5 is at index 4
            //}
          
            for (int row = 0; row < data.Rows.Count; row++)
            {
                // Check if the first column contains 'A' or is empty
                if (string.IsNullOrWhiteSpace(data.Rows[row][1].ToString()) || data.Rows[row][1].ToString().Contains("A"))
                {
                    // Perform calculations
                    totalColumn4 += Convert.ToDouble(data.Rows[row][4]); // Assuming column 4 is at index 3
                    totalColumn5 += Convert.ToDouble(data.Rows[row][5]); // Assuming column 5 is at index 4
                }
            }

            // Display totals below column 4 and column 5
            worksheet.Cells[data.Rows.Count + 9, 1].Value = "Total";
            worksheet.Cells[data.Rows.Count + 9, 5].Value = totalColumn4;
            worksheet.Cells[data.Rows.Count + 9, 6].Value = totalColumn5;

            for (int i = 1; i <= 7; i++)
            {
                worksheet.Cells[data.Rows.Count + 9, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[data.Rows.Count + 9, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[data.Rows.Count + 9, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[data.Rows.Count + 9, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                worksheet.Cells[data.Rows.Count + 9, i].Style.Font.Bold = true;
            }

            // Set fixed width for header column(s)
            worksheet.Column(1).Width = 200; // Set width for column 1
                                             // Auto-fit columns
            worksheet.Cells[worksheet.Dimension.Start.Row + 1, worksheet.Dimension.Start.Column, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].AutoFitColumns();
        }


        //private void AddToExcelSheet(ExcelPackage package, DataTable data, string WONumber, string WOSpec)
        //{

        //    // Add a new worksheet to the Excel package
        //    var worksheet = package.Workbook.Worksheets.Add(WONumber);
        //    DataTable CompanyMaster = new DataTable();

        //    // Fill the worksheet with data from the DataTable
        //    worksheet.Cells["A1"].Value = "Work Order Cutting List";
        //    worksheet.Cells["A2"].Value = WOSpec;

        //    worksheet.Cells[1, 1, 1, 7].Merge = true; // Merge 6 columns for the header
        //    worksheet.Cells["A2:f7"].Merge = true;
        //    // Enable text wrapping for the merged range (A2:F4)
        //    worksheet.Cells["A2:G4"].Style.WrapText = true;
        //    // Set vertical alignment for A2 to Top
        //    worksheet.Cells["A2"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;

        //    // Add borders to the entire range A2:F6
        //    using (var range = worksheet.Cells["A2:G6"])
        //    {
        //        range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //        range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //    }

        //    worksheet.Column(1).AutoFit();

        //    ////Style the header cell
        //    var headerCell = worksheet.Cells[1, 1];
        //    headerCell.Style.Font.Bold = true;
        //    headerCell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //    headerCell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center; // Set horizontal alignment
        //    headerCell.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center; // Set vertical alignment
        //    headerCell.Style.Font.Size = 14; // Set font size
        //    headerCell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
        //    //.Column(2).Width = 30

        //    var headerCell1 = worksheet.Cells[2, 1];
        //    headerCell1.Style.Font.Bold = true;

        //    // Set the column names in the first row
        //    for (int i = 0; i < data.Columns.Count; i++)
        //    {
        //        worksheet.Cells[8, i + 1].Value = data.Columns[i].ColumnName;
        //        var headerCell3 = worksheet.Cells[8, i + 1];
        //        headerCell3.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

        //        headerCell3.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);
        //        headerCell3.Style.Font.Bold = true;

        //        worksheet.Cells[8, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells[8, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells[8, i + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells[8, i + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells[8, i + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells[8, i + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

        //    }

        //    // Set the data starting from the second row
        //    //for (int row = 0; row < data.Rows.Count; row++)
        //    //{
        //    //    for (int col = 0; col < data.Columns.Count; col++)
        //    //    {
        //    //        // Set the first 5 columns as numbers
        //    //        if (col < 5)
        //    //        {
        //    //            worksheet.Cells[row + 8, col + 1].Style.Numberformat.Format = "General";
        //    //        }
        //    //        else
        //    //        {
        //    //            // Set the last column as a string
        //    //            worksheet.Cells[row + 8, col + 1].Style.Numberformat.Format = "@";
        //    //        }
        //    //        worksheet.Cells[row + 8, col + 1].Value = data.Rows[row][col];

        //    //        worksheet.Cells[row + 8, col + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //    //        worksheet.Cells[row + 8, col + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //    //        worksheet.Cells[row + 8, col + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //    //        worksheet.Cells[row + 8, col + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //    //    }
        //    //}

        //    for (int row = 0; row < data.Rows.Count; row++)
        //    {
        //        for (int col = 0; col < data.Columns.Count; col++)
        //        {
        //            object cellValue = data.Rows[row][col];

        //            // Set the number format for the first 5 columns
        //            if (col < 6)
        //            {
        //                worksheet.Cells[row + 9, col + 1].Style.Numberformat.Format = "General";
        //            }
        //            else
        //            {
        //                // Set the format for the last column as a string
        //                worksheet.Cells[row + 9, col + 1].Style.Numberformat.Format = "@";
        //            }

        //            // Check if the content can be converted to a number
        //            if (double.TryParse(cellValue.ToString(), out double numericValue))
        //            {
        //                // If successful, set the value as a number
        //                worksheet.Cells[row + 9, col + 1].Value = numericValue;
        //            }
        //            else
        //            {
        //                // If not successful, set the value as a string
        //                worksheet.Cells[row + 9, col + 1].Value = cellValue.ToString();
        //            }

        //            // Apply border styles
        //            worksheet.Cells[row + 9, col + 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //            worksheet.Cells[row + 9, col + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //            worksheet.Cells[row + 9, col + 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //            worksheet.Cells[row + 9, col + 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        //        }
        //    }

        //    // Calculate totals for columns 4 and 5
        //    double totalColumn4 = 0;
        //    double totalColumn5 = 0;

        //    for (int row = 0; row < data.Rows.Count; row++)
        //    {
        //        totalColumn4 += Convert.ToDouble(data.Rows[row][4]); // Assuming column 4 is at index 3
        //        totalColumn5 += Convert.ToDouble(data.Rows[row][5]); // Assuming column 5 is at index 4
        //    }

        //    // Display totals below column 4 and column 5
        //    worksheet.Cells[data.Rows.Count + 9, 1].Value = "Total";
        //    worksheet.Cells[data.Rows.Count + 9, 5].Value = totalColumn4;
        //    worksheet.Cells[data.Rows.Count + 9, 6].Value = totalColumn5;

        //    for (int i = 1; i <= 6; i++)
        //    {
        //        worksheet.Cells[data.Rows.Count + 9, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells[data.Rows.Count + 9, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells[data.Rows.Count + 9, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
        //        worksheet.Cells[data.Rows.Count + 9, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;

        //        worksheet.Cells[data.Rows.Count + 9, i].Style.Font.Bold = true;

        //    }



        //    // Set fixed width for header column(s)
        //    worksheet.Column(1).Width = 200; // Set width for column 1
        //    // Auto-fit columns
        //    //worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        //    worksheet.Cells[worksheet.Dimension.Start.Row + 1, worksheet.Dimension.Start.Column, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].AutoFitColumns();

        //}

        ////////////// Sent Mail
        public ActionResult GetContactPersonList(string ENQNO, int PartnerID)
        {
            DataTable UserList = new DataTable();
            int UserID = Convert.ToInt32(Session["userid"]);
            UserList = BussinesManager.GetContactPersonList(ENQNO, PartnerID);
            Session["GetUserList"] = UserList;
            string json = JsonConvert.SerializeObject(UserList);
            var jsonResult = Json(json, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult GetApprovalMailDetails(string ENQNO, int PartnerID)
        {
            ViewBag.DocName = ENQNO + ".xlsx";
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("RunningID");
            dataTable.Columns.Add("SrNo");
            dataTable.Columns.Add("DocName");
            dataTable.Columns.Add("FilePath");
            dataTable.Columns.Add("ContentType");
            dataTable.Columns.Add("FileType");

            DataRow row = dataTable.NewRow();
            row["RunningID"] = 1;
            row["SrNo"] = 1;
            row["DocName"] = ENQNO + "_"+ PartnerID+ ".xlsx";
            //row["FilePath"] = Server.MapPath("~/PurchaseOrderPDF/" + IndentNo + "/" + ViewBag.DocName);
            //row["FilePath"] = Server.MapPath("~/Uploads/" + ENQNO + "_Template.xlsx");
            row["FilePath"] = Server.MapPath("~/Uploads/ENQSentAttachment/" + ENQNO + "_" + PartnerID + ".xlsx");
            row["ContentType"] = "application/xlsx";
            row["FileType"] = "Template";
            dataTable.Rows.Add(row);

            ViewBag.QuotationPDFList = JsonConvert.SerializeObject(dataTable);

            var returnField = new { QuotationPDFList = ViewBag.QuotationPDFList };
            var jsonResult = Json(returnField, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult SendEnquiryEmail(BO.EmailEntity data, List<BO.EmailEntity> MasterAttachment)
        {
            try
            {

                string msg = "";
                
                // create email message
                string from = "priyan@faglass.com";
                //string from = "do-not-reply@fgglass.com";
                /******************remove below line after testing******************************/
                //data.To = "vijay.navale@fgglass.com,datta@digidisruptors.com";
                data.To = data.To;
                //data.CC = "vishal@digidisruptors.com,vijay.navale@fgglass.com,datta@digidisruptors.com";
                //if (data.To == "purchase@fgglass.com")
                //{
                //    data.CC = null;
                //}
                //else
                //{
                //    data.CC = data.CC.Replace(";", ",");
                //}
                //data.BCC = "vijay.navale@fgglass.com,datta@digidisruptors.com";
                /*********************remove above line after testing***************************/
                using (MailMessage mail = new MailMessage(from, data.To))
                {
                    var Today = DateTime.Now.ToLocalTime().ToString("yyyy-mmm-ddTHHmm");

                    mail.Subject = data.Subject;

                    mail.Body = data.Body;
                    msg = mail.Body;
                    //if (data.BCC != null)
                    //{
                    //    mail.Bcc.Add(data.BCC);
                    //}
                    if (data.CC != null)
                    {

                        string[] CCId = data.CC.Split(',');
                        foreach (string CCEmail in CCId)
                        {
                            if (CCEmail != "")
                            {
                                mail.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                            }
                        }
                    }
                    //if (data.CC != null)
                    //{
                    //    mail.CC.Add(data.CC);
                    //}

                    var strAttachement = Server.MapPath("~/Uploads/Template/" + MasterAttachment[0].DocFileName );

                    //if (strAttachement != "")
                    //{

                    //    // adding multiple attachment
                    //    string[] values = strAttachement.Split(',');

                    //    for (int i = 0; i < values.Length; i++)
                    //    {
                    //        values[i] = values[i].Trim();
                    //        string strAttachement1 = values[i];
                    //        mail.Attachments.Add(new System.Net.Mail.Attachment(strAttachement1));
                    //        strAttachement1 = "";

                    //    }

                    //}

                    if (MasterAttachment != null && MasterAttachment.Count > 0)
                    {
                        // Iterate over each BO.EmailEntity object in MasterAttachment
                        foreach (var emailEntity in MasterAttachment)
                        {
                            // Get the file path property from the BO.EmailEntity object
                            string attachmentPath = emailEntity.FilePath;

                            // Ensure attachmentPath is not null or empty before adding it as an attachment
                            if (!string.IsNullOrEmpty(attachmentPath))
                            {
                                // Add the attachment to the email message
                                mail.Attachments.Add(new System.Net.Mail.Attachment(attachmentPath));
                            }
                        }
                    }

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.Host = "smtp.gmail.com";
                    smtp.Host = "smtp.office365.com";
                    smtp.EnableSsl = true;
                    //NetworkCredential networkCredential = new NetworkCredential(from, "ixjkuusmnqhlputz");
                    //NetworkCredential networkCredential = new NetworkCredential(from, "Bah99839");
                    NetworkCredential networkCredential = new NetworkCredential(from, "etisalat@2023");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; 
                    smtp.Port = 587;
                    smtp.Send(mail);

                }

                int AddedBY = Convert.ToInt16(Session["userid"]);
                BO.ResponseMessage message = new BO.ResponseMessage();
                //message = POdataProvider.SavePOEmailLog(data, AddedBY, msg);

                return Json(message);
            }
            catch (System.Exception ex)
            {
                BO.ResponseMessage message = new BO.ResponseMessage();
                message.Message = ex.Message.ToString();
                return Json(message);
            }

        }
        ////////////// Sent MAIL
        public JsonResult CheckIsEnquirySendToPartner(string ENQNO, int PartnerID)
        {
            try
            {
                var AddedBy = Convert.ToInt16(Session["userid"]);
                BO.ResponseMessage message = new BO.ResponseMessage();
                message = BussinesManager.CheckIsEnquirySendToPartner(ENQNO, PartnerID);
                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult SaveEnquirySendToPartnerEntry(BO.EnquiryM BasicDetails, List<BO.EnquiryD> ItemListD , List<BO.AttachmentM> AttachmentList)
        {
            try
            {
                var AddedBy = Convert.ToInt16(Session["userid"]);
                BasicDetails.AddedOn = System.DateTime.Now;
                BO.ResponseMessage message = new BO.ResponseMessage();
                message = BussinesManager.SaveEnquirySendToPartnerEntry(BasicDetails, AddedBy);
                /************************* For Saving Attachments ********************************/
                if (AttachmentList != null)
                {
                    for (int j = 0; j < AttachmentList.Count; j++)
                    {
                        string root = Server.MapPath("~/Uploads/ENQSentAttachment/AttachmentFor_" + message.ESNO + "/");
                        if (!Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        string oldPath = AttachmentList[j].FilePath;
                        string newPath = Path.Combine(Server.MapPath("~/Uploads/ENQSentAttachment/AttachmentFor_" + message.ESNO + "/"), AttachmentList[j].DocName);
                        if (!System.IO.File.Exists(newPath))
                        {
                            System.IO.File.Move(oldPath, newPath);
                        }
                        AttachmentList[j].FilePath = newPath;
                    }
                }

                if (AttachmentList != null)
                {
                    DataTable dataTableAttachment = new DataTable();
                    dataTableAttachment.Columns.Add("NO");
                    dataTableAttachment.Columns.Add("UploadFor");
                    dataTableAttachment.Columns.Add("DocName");
                    dataTableAttachment.Columns.Add("FilePath");
                    dataTableAttachment.Columns.Add("ContentType");
                    dataTableAttachment.TableName = "PT_AttachmentM";
                    foreach (BO.AttachmentM item in AttachmentList)
                    {
                        DataRow row = dataTableAttachment.NewRow();
                        row["NO"] = message.ESNO;
                        row["UploadFor"] = "EnquirySent";
                        row["DocName"] = item.DocName;
                        row["FilePath"] = item.FilePath;
                        row["ContentType"] = item.ContentType;
                        dataTableAttachment.Rows.Add(row);
                    }
                    string message1 = BussinesManager.SaveEnquirySendToPartnerAttachment(dataTableAttachment, AddedBy);
                }

                /************************* For Saving Attachments ********************************/

                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult EnquirySentSummary()
        {
            return View();
        }

        public JsonResult GetEnquirySentSummary(BO.EnquiryM data1)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            List<BO.EnquiryM> list = new List<BO.EnquiryM>();
            list = BussinesManager.GetEnquirySentSummary(data1, UserID);
            return Json(list);
        }

        ////////////// OLD Method
        public JsonResult ApproveSentEnquiryPartner(FormCollection formData)
        {
            BO.ResponseMessage response = new BO.ResponseMessage();
            try
            {
                BO.EnquiryM Master = new BO.EnquiryM();
                int UserID = Convert.ToInt32(Session["userid"]);
                Master.AddedBy = UserID;
                Master.ESNO = Convert.ToString(formData["ESNO"]);
                Master.ENQNO = Convert.ToString(formData["ENQNO"]);
                response = BussinesManager.ApproveSentEnquiry(Master);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(response);
        }

       

        /////////////// 03-02-23  Approve Enquiry
        public ActionResult _AddEnquiryApproveDetails( string ENQNO)
        {
            List<BO.CustomerM> OSPartnerList = BussinesManager.GetOSPartnerListAgainstENQNO(ENQNO);
            ViewBag.ddlOSPartnerDropdown = new SelectList(OSPartnerList, "ESNO", "PartnerName");

            BO.EnquiryM data = new BO.EnquiryM();
            data = BussinesManager.GetSentEnquiryDetail(ENQNO);
            ViewBag.ENQNO = ENQNO;
            ViewBag.ENQID = data.ENQID;
            ViewBag.ENQDate = data.ENQDate;
            ViewBag.RevisionNo = data.RevisionNo;
            ViewBag.CustomerID = data.CustomerID;
            ViewBag.ProjectID = data.ProjectID;
            ViewBag.PartnerID = data.PartnerID;
            ViewBag.CustomerName = data.CustomerName;
            ViewBag.ProjectName = data.ProjectName;
            ViewBag.PartnerName = data.PartnerName;
            ViewBag.PartnerLoc = data.PartnerLoc;
            ViewBag.OutSQM = data.OutSQM;
            ViewBag.UserName = data.UserName;
            ViewBag.ENQItemD = JsonConvert.SerializeObject(data.ENQItemD);
            return PartialView();
        }

        public ActionResult _AddAttachmentApproveDetails()
        {
            return PartialView();
        }

        public ActionResult UploadAttachmentApproveDetails(BO.EnquiryM fileData)
        {
            BO.AttachmentM SupplierInfoAttach = new BO.AttachmentM();
            if (Request.Files.Count > 0)
            {
                try
                {
                    int Userid = Convert.ToInt16(Session["userid"]);
                    string Type = fileData.EnqType;
                    Type = Type + Userid;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        string root = Server.MapPath("~/Uploads/ENQApproveAttachment/" + Type + "/");
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string contentType;
                        contentType = MimeMapping.GetMimeMapping(fname);

                        if (!System.IO.Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        string check = Path.Combine(Server.MapPath("~/Uploads/ENQApproveAttachment/" + Type + "/"), fname);
                        if (System.IO.File.Exists(fname))
                        {
                            System.IO.File.Delete(fname);
                        }
                        file.SaveAs(check);
                        SupplierInfoAttach.DocName = fname;
                        SupplierInfoAttach.FilePath = check;
                        SupplierInfoAttach.ContentType = contentType;
                        //SupplierInfoAttach.NewFileName = NewFileName;
                    }
                }
                catch (System.Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            return Json(SupplierInfoAttach);
        }

        public ActionResult getPartnerLocation(string ESNO)
        {
            EnquiryM PartnerLoc = new EnquiryM();
            PartnerLoc = BussinesManager.getPartnerLocation(ESNO);
            var jsonResult = Json(PartnerLoc, JsonRequestBehavior.AllowGet);
            ViewBag.PartnerLoc = JsonConvert.SerializeObject(PartnerLoc);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveEnquiryApproveDetails(BO.EnquiryM BasicDetails, List<BO.EnquiryD> ItemListD, List<BO.EnquiryD> ScheduleList, List<BO.AttachmentM> AttachmentList)
        {
            try
            {
                var AddedBy = Convert.ToInt16(Session["userid"]);
                BasicDetails.AddedOn = System.DateTime.Now;
                BO.ResponseMessage message = new BO.ResponseMessage();

                DataTable dataTable = new DataTable();
                if (ItemListD != null)
                {
                    dataTable.Columns.Add("SrNo");
                    dataTable.Columns.Add("SpecID");
                    dataTable.Columns.Add("PINO");
                    dataTable.Columns.Add("WONO");
                    dataTable.Columns.Add("ItemDesc");
                    dataTable.Columns.Add("ProjectName");
                    dataTable.Columns.Add("Unit");
                    dataTable.Columns.Add("Qty");
                    dataTable.Columns.Add("SQM");
                    dataTable.Columns.Add("OutQty");
                    dataTable.Columns.Add("OutSQM");
                    dataTable.Columns.Add("ApprovedRate");
                    dataTable.Columns.Add("Amount");
                    dataTable.Columns.Add("OutType");
                    dataTable.TableName = "PT_ApprovedItemList";
                    foreach (BO.EnquiryD item in ItemListD)
                    {
                        DataRow row = dataTable.NewRow();
                        row["SrNo"] = item.SrNo;
                        row["SpecID"] = item.SpecID;
                        row["PINO"] = item.PINO;
                        row["WONO"] = item.WONO;
                        row["ItemDesc"] = item.ItemDescription;
                        row["ProjectName"] = item.ProjectName;
                        row["Unit"] = item.Unit;
                        row["Qty"] = item.Qty;
                        row["SQM"] = item.SQM;
                        row["OutQty"] = item.OutQty;
                        row["OutSQM"] = item.OutSQM;
                        row["ApprovedRate"] = item.ApprovedRate;
                        row["Amount"] = item.Amount;
                        row["OutType"] = item.OutType;
                        dataTable.Rows.Add(row);
                    }
                }

                DataTable dataTable1 = new DataTable();
                if (ScheduleList != null)
                {
                    dataTable1.Columns.Add("SrNo");
                    dataTable1.Columns.Add("ReceivedSQM");
                    dataTable1.Columns.Add("ScheduleDate");
                    dataTable1.TableName = "PT_ScheduleList";
                    foreach (BO.EnquiryD item in ScheduleList)
                    {
                        DataRow row = dataTable1.NewRow();
                        row["SrNo"] = item.SrNo;
                        row["ReceivedSQM"] = item.ReceivedSQM;
                        row["ScheduleDate"] = item.ScheduleDate;
                        dataTable1.Rows.Add(row);
                    }
                }
                message = BussinesManager.SaveEnquiryApproveDetails(BasicDetails, AddedBy, dataTable, dataTable1);
                /************************* For Saving Attachments ********************************/
                if (AttachmentList != null)
                {
                    for (int j = 0; j < AttachmentList.Count; j++)
                    {
                        string root = Server.MapPath("~/Uploads/ENQApproveAttachment/AttachmentFor_" + message.EANO + "/");
                        if (!Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        string oldPath = AttachmentList[j].FilePath;
                        string newPath = Path.Combine(Server.MapPath("~/Uploads/ENQApproveAttachment/AttachmentFor_" + message.EANO + "/"), AttachmentList[j].DocName);
                        if (!System.IO.File.Exists(newPath))
                        {
                            System.IO.File.Move(oldPath, newPath);
                        }
                        AttachmentList[j].FilePath = newPath;
                    }
                }
                if (AttachmentList != null)
                {
                    DataTable dataTableAttachment = new DataTable();
                    dataTableAttachment.Columns.Add("NO");
                    dataTableAttachment.Columns.Add("UploadFor");
                    dataTableAttachment.Columns.Add("DocName");
                    dataTableAttachment.Columns.Add("FilePath");
                    dataTableAttachment.Columns.Add("ContentType");
                    dataTableAttachment.TableName = "PT_AttachmentM";
                    foreach (BO.AttachmentM item in AttachmentList)
                    {
                        DataRow row = dataTableAttachment.NewRow();
                        row["NO"] = message.EANO;
                        row["UploadFor"] = "Approve";
                        row["DocName"] = item.DocName;
                        row["FilePath"] = item.FilePath;
                        row["ContentType"] = item.ContentType;
                        dataTableAttachment.Rows.Add(row);
                    }
                    string message1 = BussinesManager.SaveENQApproveAttachment(dataTableAttachment, AddedBy);
                }
                /************************* For Saving Attachments ********************************/
                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /////////////// 03-02-23 Generate Costing
        public ActionResult _GenerateCostingSheet( string ENQNO)
        {
            //List<BO.CustomerM> OSPartnerList = BussinesManager.GetOutsourcePartnerList();
            //ViewBag.ddlOSPartnerDropdown = new SelectList(OSPartnerList, "PartnerID", "PartnerName");

            //BO.EnquiryM data = new BO.EnquiryM();
            //data = BussinesManager.GetSentEnquiryDetail(ESNO, ENQNO);
            //ViewBag.ESNO = ESNO;
            //ViewBag.ENQNO = ENQNO;
            //ViewBag.ENQID = data.ENQID;
            //ViewBag.ENQDate = data.ENQDate;
            //ViewBag.RevisionNo = data.RevisionNo;
            //ViewBag.CustomerID = data.CustomerID;
            //ViewBag.ProjectID = data.ProjectID;
            //ViewBag.PartnerID = data.PartnerID;
            //ViewBag.CustomerName = data.CustomerName;
            //ViewBag.ProjectName = data.ProjectName;
            //ViewBag.PartnerName = data.PartnerName;
            //ViewBag.UserName = data.UserName;

            //ViewBag.ENQItemD = JsonConvert.SerializeObject(data.ENQItemD);
            return PartialView();
        }

        ///////////////@@@@@@@@@@@@@@@ 03-02-23  Req Raw Material screen
        public ActionResult _AddReqRawMaterialDetails(string RRMNO, string ENQNO, String Action)
        {
            List<BO.IndentInfo> ItemGroupList = BussinesManager.GetItemGroupList();
            ViewBag.ItemGroupList = new SelectList(ItemGroupList, "ItemGroup_ID", "ItemGroup_Name");

            BO.EnquiryM data = new BO.EnquiryM();
            data = BussinesManager.GetSentEnquiryDetailForRRM(ENQNO);
            ViewBag.ESNO = data.ESNO;
            ViewBag.ENQNO = ENQNO;
            ViewBag.ENQID = data.ENQID;
            ViewBag.ENQDate = data.ENQDate;
            ViewBag.RevisionNo = data.RevisionNo;
            ViewBag.CustomerID = data.CustomerID;
            ViewBag.ProjectID = data.ProjectID;
            ViewBag.PartnerID = data.PartnerID;
            ViewBag.CustomerName = data.CustomerName;
            ViewBag.ProjectName = data.ProjectName;
            ViewBag.PartnerName = data.PartnerName;
            ViewBag.UserName = data.UserName;

            if (RRMNO != "0")
            {
                BO.EnquiryM data1 = new BO.EnquiryM();
                data1 = BussinesManager.GetReqRawMaterialDetails(RRMNO, ENQNO);
                ViewBag.Action = Action;
                ViewBag.RRMNO = RRMNO;
                ViewBag.RRMID = data.RRMID;
                ViewBag.ENQNO = ENQNO;
                ViewBag.RRMDate = data1.RRMDate;
                ViewBag.RevisionNo = data1.RevisionNo;
                ViewBag.CustomerID = data1.CustomerID;
                ViewBag.ProjectID = data1.ProjectID;
                ViewBag.PartnerID = data1.PartnerID;
                ViewBag.CustomerName = data1.CustomerName;
                ViewBag.ItemGroupID = data1.ItemGroupID;
                ViewBag.IsCutSize = data1.IsCutSize;
                ViewBag.ReqVehicle = data1.ReqVehicle;
                ViewBag.Remarks = data1.Remarks;
                ViewBag.UserName = data1.UserName;

                ViewBag.ENQItemD = JsonConvert.SerializeObject(data1.ENQItemD);
            }
            else
            {
                ViewBag.Action = Action;
                ViewBag.ItemGroupID = 1;

            }
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetRMItemList(string Search, string ENQNO)
        {
            List<BO.Item> ItemList = new List<BO.Item>();
            ItemList = BussinesManager.GetRMItemList(Search, ENQNO);
            var jsonResult = Json(ItemList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult GetCOItemList(string Search)
        {
            List<BO.Item> ItemList = new List<BO.Item>();
            ItemList = BussinesManager.GetCOItemList(Search);
            var jsonResult = Json(ItemList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult SaveReqRawMaterialDetails(BO.EnquiryM BasicDetails, List<BO.EnquiryD> ItemListD)
        {
            try
            {
                var AddedBy = Convert.ToInt16(Session["userid"]);
                BasicDetails.AddedOn = System.DateTime.Now;
                BO.ResponseMessage message = new BO.ResponseMessage();
                DataTable dataTable = new DataTable();
                if (ItemListD != null)
                {
                    dataTable.Columns.Add("SrNo");
                    dataTable.Columns.Add("ItemID");
                    dataTable.Columns.Add("ItemCode");
                    dataTable.Columns.Add("ItemDesc");
                    dataTable.Columns.Add("Unit");
                    dataTable.Columns.Add("Height");
                    dataTable.Columns.Add("Width");
                    dataTable.Columns.Add("Qty");
                    dataTable.Columns.Add("SQM");
                    dataTable.Columns.Add("Weight");
                    dataTable.TableName = "PT_ReqRawMaterialList";
                    foreach (BO.EnquiryD item in ItemListD)
                    {
                        DataRow row = dataTable.NewRow();
                        row["SrNo"] = item.SrNo;
                        row["ItemID"] = item.ItemID;
                        row["ItemCode"] = item.ItemCode;
                        row["ItemDesc"] = item.ItemDescription;
                        row["Unit"] = item.Unit;
                        row["Height"] = item.Height;
                        row["Width"] = item.Width;
                        row["Qty"] = item.Qty;
                        row["SQM"] = item.SQM;
                        row["Weight"] = item.Weight;

                        dataTable.Rows.Add(row);
                    }
                }
                message = BussinesManager.SaveReqRawMaterialDetails(BasicDetails, AddedBy, dataTable);
                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ReqRawMaterialSummary()
        {
            List<BO.EnquiryM> ClosingRemarkList = BussinesManager.GetClosingRemarkList();
            ViewBag.ClosingRemarkList = new SelectList(ClosingRemarkList, "RemarkID", "RemarkName");

            return View();
        }

        public JsonResult GetReqRawMaterialSummary(BO.EnquiryM data1)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            List<BO.EnquiryM> list = new List<BO.EnquiryM>();
            list = BussinesManager.GetReqRawMaterialSummary(data1, UserID);
            return Json(list);
        }

        public JsonResult UpdateClosingRemarkStatus(string RRMNO, int RemarkID)
        {
            ResponseMessage response = new ResponseMessage();
            try
            {
                EnquiryM Master = new EnquiryM();
                Master.RRMNO = RRMNO;
                Master.RemarkID = RemarkID;
                Master.AddedBy = Convert.ToInt32(Session["userid"]);
                response = BussinesManager.UpdateClosingRemarkStatus(Master);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(response);
        }

        public JsonResult GetReqRawMaterialDetailsForMail(string RRMNO, string ENQNO)
        {
            //List<BO.EnquiryD> detail = new List<BO.EnquiryD>();
            //detail = BussinesManager.POItemsDetails(PONo);

            BO.EnquiryM data1 = new BO.EnquiryM();
            data1.UserName = Convert.ToString(Session["username"]);
            data1 = BussinesManager.GetReqRawMaterialDetails(RRMNO, ENQNO);
            var jsonResult = Json(data1, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
            //return Json(detail);
        }

        [HttpPost]
        public ActionResult SendMailToPurchase(BO.EmailEntity data, string Subject, string Body, List<BO.EmailEntity> MasterAttachment)
        {
            try
            {

                string msg = "";


                // create email message
                //string from = "approvals@fgglass.in";
                string from = data.From;
                //string from = "do-not-reply@fgglass.com";
                /******************remove below line after testing******************************/
                //data.To = "vijay.navale@fgglass.com,datta@digidisruptors.com";
                data.To = data.To;
                //data.CC = "vishal@digidisruptors.com,vijay.navale@fgglass.com,datta@digidisruptors.com";
                //if (data.To == "purchase@fgglass.com")
                //{
                //    data.CC = null;
                //}
                //else
                //{
                //    data.CC = data.CC.Replace(";", ",");
                //}
                //data.BCC = "vijay.navale@fgglass.com,datta@digidisruptors.com";
                /*********************remove above line after testing***************************/
                using (MailMessage mail = new MailMessage(from, data.To))
                {
                    var Today = DateTime.Now.ToLocalTime().ToString("yyyy-mmm-ddTHHmm");

                    mail.Subject = Subject;

                    mail.Body = Body;
                    msg = mail.Body;
                    //if (data.BCC != null)
                    //{
                    //    mail.Bcc.Add(data.BCC);
                    //}
                    if (data.CC != null)
                    {

                        string[] CCId = data.CC.Split(',');
                        foreach (string CCEmail in CCId)
                        {
                            if (CCEmail != "")
                            {
                                mail.CC.Add(new MailAddress(CCEmail)); //Adding Multiple CC email Id
                            }
                        }
                    }
                    //if (data.CC != null)
                    //{
                    //    mail.CC.Add(data.CC);
                    //}

                    //var strAttachement = Server.MapPath("~/Uploads/Template/" + MasterAttachment[0].DocFileName);

                    //if (strAttachement != "")
                    //{

                    //    // adding multiple attachment
                    //    string[] values = strAttachement.Split(',');

                    //    for (int i = 0; i < values.Length; i++)
                    //    {
                    //        values[i] = values[i].Trim();
                    //        string strAttachement1 = values[i];
                    //        mail.Attachments.Add(new System.Net.Mail.Attachment(strAttachement1));
                    //        strAttachement1 = "";

                    //    }

                    //}

                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //smtp.Host = "smtp.gmail.com";
                    smtp.Host = "smtp.office365.com";
                    smtp.EnableSsl = true;
                    //NetworkCredential networkCredential = new NetworkCredential(from, "ixjkuusmnqhlputz");
                    //NetworkCredential networkCredential = new NetworkCredential(from, "Bah99839");
                    NetworkCredential networkCredential = new NetworkCredential(from, "etisalat@1234");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    smtp.Port = 587;
                    smtp.Send(mail);

                }

                int AddedBY = Convert.ToInt16(Session["userid"]);
                BO.ResponseMessage message = new BO.ResponseMessage();
                //message = POdataProvider.SavePOEmailLog(data, AddedBY, msg);
                message.Message = "Mail sent successfully.";
                return Json(message);
            }
            catch (System.Exception ex)
            {
                BO.ResponseMessage message = new BO.ResponseMessage();
                message.Message = ex.Message.ToString();
                return Json(message);
            }


        }



        /////////////// 03-02-23 Enquiry RECEIVE
        public ActionResult _ReceiveOutsourceItems( string ERNO, string ENQNO, String Action)
        {
            List<BO.EnquiryM> TransporterList = BussinesManager.GetTransporterList();
            ViewBag.TransporterList = new SelectList(TransporterList, "TransporterID", "TransporterName");

            BO.EnquiryM data = new BO.EnquiryM();
            data = BussinesManager.GetSentEnquiryDetailForReceiveItem( ENQNO);
            ViewBag.ENQNO = ENQNO;
            ViewBag.ESNO = data.ESNO;
            ViewBag.EANO = data.EANO;
            ViewBag.ENQDate = data.ENQDate;
            ViewBag.RevisionNo = data.RevisionNo;
            ViewBag.CustomerID = data.CustomerID;
            ViewBag.ProjectID = data.ProjectID;
            ViewBag.PartnerID = data.PartnerID;
            ViewBag.CustomerName = data.CustomerName;
            ViewBag.ProjectName = data.ProjectName;
            ViewBag.PartnerName = data.PartnerName;
            ViewBag.UserName = data.UserName;

            ViewBag.ENQItemD = JsonConvert.SerializeObject(data.ENQItemD);

            if (ERNO != "0")
            {
                BO.EnquiryM data1 = new BO.EnquiryM();
                data1 = BussinesManager.GetEnquiryReceiveDetails(ERNO);
                ViewBag.Action = Action;
                ViewBag.ERNO = ERNO;
                ViewBag.ENQNO = ENQNO;
                ViewBag.ERDate = data1.ERDate;
                ViewBag.RevisionNo = data1.RevisionNo;
                ViewBag.CustomerID = data1.CustomerID;
                ViewBag.ProjectID = data1.ProjectID;
                ViewBag.PartnerID = data1.PartnerID;
                ViewBag.CustomerName = data1.CustomerName;
                ViewBag.ProjectName = data1.ProjectName;
                ViewBag.PartnerName = data1.PartnerName;
                ViewBag.ChallanNo = data1.ChallanNo;
                ViewBag.TransporterID = data1.TransporterID;
                ViewBag.DriverName = data1.DriverName;
                ViewBag.VehicleNo = data1.VehicleNo;
                ViewBag.VehType = data1.VehType;
                ViewBag.InvAmount = data1.InvAmount;
                ViewBag.TotalVehCost = data1.TotalVehCost;
                ViewBag.Remarks = data1.Remarks;
                ViewBag.UserName = data1.UserName;

                ViewBag.ENQItemD = JsonConvert.SerializeObject(data1.ENQItemD);
                ViewBag.AttachmentD = JsonConvert.SerializeObject(data1.AttachmentD);
            }
            else
            {
                ViewBag.Action = Action;
            }
            return PartialView();
        }

        public ActionResult GetENQNOTemplateList(string PINO, string WONO, string ENQNO, string EANO)
        {
            List<BO.EnquiryD> OpenIndentList = new List<BO.EnquiryD>();
            OpenIndentList = BussinesManager.GetENQNOTemplateList(PINO, WONO,  ENQNO,  EANO);
            var jsonResult = Json(OpenIndentList, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public ActionResult _AddAttachmentReceiveDetails()
        {
            return PartialView();
        }

        public ActionResult UploadAttachmentReceiveDetails(BO.EnquiryM fileData)
        {
            BO.AttachmentM SupplierInfoAttach = new BO.AttachmentM();
            if (Request.Files.Count > 0)
            {
                try
                {
                    int Userid = Convert.ToInt16(Session["userid"]);
                    string Type = fileData.EnqType;
                    Type = Type + Userid;
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        string root = Server.MapPath("~/Uploads/ENQReceiveAttachment/" + Type + "/");
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        string contentType;
                        contentType = MimeMapping.GetMimeMapping(fname);

                        if (!System.IO.Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        string check = Path.Combine(Server.MapPath("~/Uploads/ENQReceiveAttachment/" + Type + "/"), fname);
                        if (System.IO.File.Exists(fname))
                        {
                            System.IO.File.Delete(fname);
                        }
                        file.SaveAs(check);
                        SupplierInfoAttach.DocName = fname;
                        SupplierInfoAttach.FilePath = check;
                        SupplierInfoAttach.ContentType = contentType;
                        //SupplierInfoAttach.NewFileName = NewFileName;
                    }
                }
                catch (System.Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            return Json(SupplierInfoAttach);
        }

        public JsonResult SaveReceiveOutsourceItem(BO.EnquiryM BasicDetails, List<BO.EnquiryD> ItemListD, List<BO.EnquiryD> SizesListD, List<BO.AttachmentM> AttachmentList)
        {
            try
            {
                var AddedBy = Convert.ToInt16(Session["userid"]);
                BasicDetails.AddedOn = System.DateTime.Now;
                BO.ResponseMessage message = new BO.ResponseMessage();
                DataTable dataTable = new DataTable();
                if (ItemListD != null)
                {
                    dataTable.Columns.Add("SrNo");
                    dataTable.Columns.Add("SpecID");
                    dataTable.Columns.Add("PINO");
                    dataTable.Columns.Add("WONO");
                    dataTable.Columns.Add("ItemDesc");
                    dataTable.Columns.Add("ProjectName");
                    dataTable.Columns.Add("Unit");
                    dataTable.Columns.Add("OutQty");
                    dataTable.Columns.Add("OutSQM");
                    dataTable.Columns.Add("RecQty");
                    dataTable.Columns.Add("RecSQM");
                    dataTable.Columns.Add("ARQty");
                    dataTable.Columns.Add("ARSQM");
                    dataTable.Columns.Add("BQty");
                    dataTable.Columns.Add("BSQM");
                    dataTable.Columns.Add("ApprovedRate");
                    dataTable.Columns.Add("Amount");
                    dataTable.Columns.Add("OutTypeID");
                    dataTable.Columns.Add("OutType");
                    dataTable.TableName = "PT_ReceiveItemList";
                    foreach (BO.EnquiryD item in ItemListD)
                    {
                        DataRow row = dataTable.NewRow();
                        row["SrNo"] = item.SrNo;
                        row["SpecID"] = item.SpecID;
                        row["PINO"] = item.PINO;
                        row["WONO"] = item.WONO;
                        row["ItemDesc"] = item.ItemDescription;
                        row["ProjectName"] = item.ProjectName;
                        row["Unit"] = item.Unit;
                        row["OutQty"] = item.OutQty;
                        row["OutSQM"] = item.OutSQM;
                        row["RecQty"] = item.RecQty;
                        row["RecSQM"] = item.RecSQM;
                        row["ARQty"] = item.ARQty;
                        row["ARSQM"] = item.ARSQM;
                        row["BQty"] = item.BQty;
                        row["BSQM"] = item.BSQM;
                        row["ApprovedRate"] = item.ApprovedRate;
                        row["Amount"] = item.Amount;
                        row["OutTypeID"] = item.OutTypeID;
                        row["OutType"] = item.OutType;
                        dataTable.Rows.Add(row);
                    }
                }
                DataTable dataTable1 = new DataTable();

                if (SizesListD != null)
                {
                    dataTable1.Columns.Add("PINO");
                    dataTable1.Columns.Add("WONO");
                    dataTable1.Columns.Add("SizeAutoID");
                    dataTable1.Columns.Add("SrNo");
                    dataTable1.Columns.Add("StepSrNo");
                    dataTable1.Columns.Add("SpecID");
                    dataTable1.Columns.Add("Height");
                    dataTable1.Columns.Add("Width");
                    dataTable1.Columns.Add("Qty");
                    dataTable1.Columns.Add("SQM");
                    dataTable1.Columns.Add("RecQty");
                    dataTable1.Columns.Add("RecSQM");
                    dataTable1.Columns.Add("ARQty");
                    dataTable1.Columns.Add("ARSQM");
                    dataTable1.Columns.Add("BQty");
                    dataTable1.Columns.Add("BSQM");
                    dataTable1.Columns.Add("Remark");
                    dataTable1.Columns.Add("IsStepGlass");
                    dataTable1.TableName = "PT_ENQSizesListForReceiveT";
                    var i = 0;
                    foreach (BO.EnquiryD item in SizesListD)
                    {
                        i++;
                        DataRow row = dataTable1.NewRow();
                        row["PINO"] = item.PINO;
                        row["WONO"] = item.WONO;
                        row["SizeAutoID"] = item.AutoID;
                        row["SrNo"] = item.SrNo;
                        row["StepSrNo"] = item.StepSrNo;
                        row["SpecID"] = item.SpecID;
                        row["Height"] = item.Height;
                        row["Width"] = item.Width;
                        row["Qty"] = item.Qty;
                        row["SQM"] = item.SQM;
                        row["RecQty"] = item.RecQty;
                        row["RecSQM"] = item.RecSQM;
                        row["ARQty"] = item.ARQty;
                        row["ARSQM"] = item.ARSQM;
                        row["BQty"] = item.BQty;
                        row["BSQM"] = item.BSQM;
                        row["Remark"] = item.Remark;
                        row["IsStepGlass"] = item.IsStepGlass;
                        dataTable1.Rows.Add(row);
                    }
                }

                message = BussinesManager.SaveReceiveOutsourceItem(BasicDetails, AddedBy, dataTable, dataTable1);
                /************************* For Saving Attachments ********************************/
                if (AttachmentList != null)
                {
                    for (int j = 0; j < AttachmentList.Count; j++)
                    {
                        string root = Server.MapPath("~/Uploads/ENQReceiveAttachment/AttachmentFor_" + message.ERNO + "/");
                        if (!Directory.Exists(root))
                        {
                            Directory.CreateDirectory(root);
                        }
                        string oldPath = AttachmentList[j].FilePath;
                        string newPath = Path.Combine(Server.MapPath("~/Uploads/ENQReceiveAttachment/AttachmentFor_" + message.ERNO + "/"), AttachmentList[j].DocName);
                        if (!System.IO.File.Exists(newPath))
                        {
                            System.IO.File.Move(oldPath, newPath);
                        }
                        AttachmentList[j].FilePath = newPath;
                    }
                }
                if (AttachmentList != null)
                {
                    DataTable dataTableAttachment = new DataTable();
                    dataTableAttachment.Columns.Add("NO");
                    dataTableAttachment.Columns.Add("UploadFor");
                    dataTableAttachment.Columns.Add("DocName");
                    dataTableAttachment.Columns.Add("FilePath");
                    dataTableAttachment.Columns.Add("ContentType");
                    dataTableAttachment.TableName = "PT_AttachmentM";
                    foreach (BO.AttachmentM item in AttachmentList)
                    {
                        DataRow row = dataTableAttachment.NewRow();
                        row["NO"] = message.ERNO;
                        row["UploadFor"] = "Receive";
                        row["DocName"] = item.DocName;
                        row["FilePath"] = item.FilePath;
                        row["ContentType"] = item.ContentType;
                        dataTableAttachment.Rows.Add(row);
                    }
                    string message1 = BussinesManager.SaveENQReceiveAttachment(dataTableAttachment, AddedBy);
                }
                /************************* For Saving Attachments ********************************/
                return Json(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult EnquiryReceiveSummary()
        {
            return View();
        }

        public JsonResult GetEnquiryReceiveSummary(BO.EnquiryM data1)
        {
            int UserID = Convert.ToInt16(Session["userid"]);
            List<BO.EnquiryM> list = new List<BO.EnquiryM>();
            list = BussinesManager.GetEnquiryReceiveSummary(data1, UserID);
            return Json(list);
        }


        /// ////////////////// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        /// ////////////////// @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        public ActionResult Email()
        {
            string popConnect = "pop.gmail.com";
            string userEmailID = "phoenixtechnosoftkreation@gmail.com";
            string password = "phoenix@kumar";
            //string popConnect = "pop-mail.outlook.com";
            //string userEmailID = "phoenixkreationswebapi@hotmail.com";
            //string password = "Phoenix_18";
            DBView.EnquiryDataProvider dashboardBussinesManager = new DBView.EnquiryDataProvider();
            List<BO.Recieved_Emails> emailList = dashboardBussinesManager.GetEmail(popConnect, userEmailID, password);
            ViewBag.EmailList = emailList;
            return View(emailList.ToList());
        }

        [HttpPost]
        public JsonResult AjaxDeleteEnquiry(BO.Enquiry data)
        {
            DBView.EnquiryDataProvider dashboardBussinesManager = new DBView.EnquiryDataProvider();
            BO.ResponseMessage response = new BO.ResponseMessage();
            data.AddedBY = Convert.ToInt16(Session["userid"]);
            response = dashboardBussinesManager.AjaxDeleteEnquiry(data);
            return Json(response);
        }
    
    }
}