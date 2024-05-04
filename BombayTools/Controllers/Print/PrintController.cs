
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using SelectPdf;

using EXBL = BombayToolBusinessLayer.ExportInvoice;
using BO = BombayToolsEntities.BusinessEntities;
using BombayTools.Filters;
using HC = BombayToolsDBConnector.Helper;
using System.Net.Mail;
using System.IO;
using BombayToolsEntities.BusinessEntities;
using System.Web.Services.Description;
using System.Data;



namespace BombayTools.Controllers.Print
{

    //[UserAuthenticationFilter]
    public class PrintController : Controller
    {
        //GET: Print
        //string ip = System.Web.HttpContext.Current.Request.Url.Authority;
        //string ip = "https://fgglass.in:92/";
        //string ip = "https://facrm.globaledgeme.tech/";
        string ip = System.Web.HttpContext.Current.Request.Url.Authority;


        public ActionResult SampleRequestPdf(string SMPNo)
        {

            string url = ip + "/Print/SampleRequest?SMPNo=" + SMPNo;

            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;
            converter.Options.MarginTop = 10;
            converter.Options.MarginBottom = 10;
            converter.Options.MaxPageLoadTime = 120;

            // create a new pdf document converting an url
            PdfDocument doc = new PdfDocument();
            doc.CompressionLevel = PdfCompressionLevel.Best;

            doc = converter.ConvertUrl(url);
            // save pdf document
            byte[] pdf = doc.Save(); //Server.MapPath("~/Uploads/Sample.pdf")

            // close pdf document
            //doc.Close();

            string name = SMPNo + ".pdf";
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            //fileResult.FileDownloadName = name;

            return fileResult;
        }
        // SampleRequest END


        public ActionResult Header()
        {
            return View();
        }

        public ActionResult Footer()
        {
            return View();
        }



      

        ////// 24-06-23 By Rohit

        //public ActionResult ProformaInvoicePdf(string PINO)
        //{

        //    string url = ip + "/Print/PIPrintDetails?PINo=" + PINO;
        //    string footerUrl = ip + "/Print/PIFooter?PINo=" + PINO;
        //    string headerUrl = ip + "/Print/PIHeader?PINo=" + PINO;

        //    HtmlToPdf converter = new HtmlToPdf();
        //    converter.Options.DisplayHeader = true;
        //    converter.Header.DisplayOnFirstPage = true;
        //    converter.Header.DisplayOnOddPages = true;
        //    converter.Header.DisplayOnEvenPages = true;
        //    converter.Header.Height = 100;

        //    PdfHtmlSection headerHtml = new PdfHtmlSection(headerUrl);

        //    headerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
        //    converter.Header.Add(headerHtml);

        //    //footer settings
        //    converter.Options.DisplayFooter = true;
        //    converter.Footer.DisplayOnFirstPage = true;
        //    converter.Footer.DisplayOnOddPages = true;
        //    converter.Footer.DisplayOnEvenPages = true;
        //    converter.Footer.Height = 50;


        //    PdfHtmlSection footerHtml = new PdfHtmlSection(footerUrl);
        //    footerHtml.AutoFitHeight = HtmlToPdfPageFitMode.AutoFit;
        //    converter.Footer.Add(footerHtml);

        //    converter.Options.PdfPageSize = PdfPageSize.A4;
        //    converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
        //    converter.Options.MarginLeft = 20;
        //    converter.Options.MarginRight = 20;
        //    converter.Options.MarginTop = 20;
        //    converter.Options.MarginBottom = 10;
        //    converter.Options.MaxPageLoadTime = 120;


        //    // create a new pdf document converting an url
        //    PdfDocument doc = new PdfDocument();
        //    doc.CompressionLevel = PdfCompressionLevel.Best;
        //    //doc.AddFont(new System.Drawing.Font("Poppins-Black", 16));


        //    doc = converter.ConvertUrl(url);


        //    string URL2 = ip + "/Print/PIAnnexurePrint?PINo=" + PINO;
        //    string footerURL = ip + "/Print/PIFooter?PINo" + PINO;
        //    string headerURL = ip + "/Print/PIHeader?PINo=" + PINO;

        //    PdfDocument doc2 = new PdfDocument();
        //    doc2.CompressionLevel = PdfCompressionLevel.Best;
        //    //doc2.AddFont(new System.Drawing.Font("Poppins-Black", 16));

        //    doc2 = converter.ConvertUrl(URL2);

        //    PdfDocument doc3 = new PdfDocument();
        //    doc.Append(doc);
        //    //doc3.Append(doc2);

        //    // save pdf document
        //    byte[] pdf = doc.Save(); //Server.MapPath("~/Uploads/Sample.pdf")

        //    // close pdf document
        //    //doc.Close();

        //    string name = PINO + ".pdf";
        //    FileResult fileResult = new FileContentResult(pdf, "application/pdf");
        //    //fileResult.FileDownloadName = name;

        //    return fileResult;
        //}

        //public ActionResult PIHeader(string PINo)
        //{
        //    DataSet getJobOrderSet = new DataSet();
        //    DataTable tblMasterDetails = new DataTable();
        //    DataTable tblInvoiceDetails = new DataTable();
        //    DataTable tblContainerDetails = new DataTable();

        //    getJobOrderSet = PIBL.GetProformaInvoicePrintDetails(PINo, Convert.ToString(Session["LoginType"]));

        //    if (getJobOrderSet.Tables.Count > 0)
        //    {
        //        tblMasterDetails = getJobOrderSet.Tables[0];
        //        //tblInvoiceDetails = getJobOrderSet.Tables[1];
        //        //tblContainerDetails = getJobOrderSet.Tables[2];

        //        foreach (DataRow dr in tblMasterDetails.Rows)
        //        {
        //            ViewBag.PINo = dr["PINo"];
        //            ViewBag.PIDate = dr["PIDate"];
        //            ViewBag.ValidUntil = dr["ValidUntil"];
        //            ViewBag.Cust_Name = dr["Cust_Name"];
        //            ViewBag.RevisionNo = dr["RevisionNo"];
        //            ViewBag.SalesPerson_Name = dr["SalesPerson_Name"];
        //            ViewBag.BillToAddrs = dr["BillToAddrs"];
        //            ViewBag.ShipToAddrs = dr["ShipToAddrs"];

        //            ViewBag.TRNNo = dr["LSTVAT"];
        //            ViewBag.Project_Name = dr["Project_Name"];
        //            ViewBag.BankName = dr["BankName"];
        //            ViewBag.Branch = dr["Branch"];
        //            ViewBag.AccountNo = dr["AccountNo"];
        //            ViewBag.SwiftCode = dr["SwiftCode"];
        //            ViewBag.IBANno = dr["IBANno"];


        //        }

        //    }
        //    return View();
        //}
        //public ActionResult PIFooter(string PINo)
        //{
        //    DataSet getJobOrderSet = new DataSet();
        //    DataTable tblMasterDetails = new DataTable();
        //    DataTable tblInvoiceDetails = new DataTable();
        //    DataTable tblContainerDetails = new DataTable();

        //    getJobOrderSet = PIBL.GetProformaInvoicePrintDetails(PINo, Convert.ToString(Session["LoginType"]));

        //    if (getJobOrderSet.Tables.Count > 0)
        //    {
        //        tblMasterDetails = getJobOrderSet.Tables[0];
        //        //tblInvoiceDetails = getJobOrderSet.Tables[1];
        //        //tblContainerDetails = getJobOrderSet.Tables[2];

        //        foreach (DataRow dr in tblMasterDetails.Rows)
        //        {
        //            ViewBag.PINo = dr["PINo"];
        //            ViewBag.PIDate = dr["PIDate"];
        //            ViewBag.ValidUntil = dr["ValidUntil"];
        //            ViewBag.Cust_Name = dr["Cust_Name"];
        //            ViewBag.RevisionNo = dr["RevisionNo"];
        //            ViewBag.SalesPerson_Name = dr["SalesPerson_Name"];
        //            ViewBag.BillToAddrs = dr["BillToAddrs"];
        //            ViewBag.ShipToAddrs = dr["ShipToAddrs"];

        //            ViewBag.TRNNo = dr["LSTVAT"];
        //            ViewBag.Project_Name = dr["Project_Name"];
        //            ViewBag.BankName = dr["BankName"];
        //            ViewBag.Branch = dr["Branch"];
        //            ViewBag.AccountNo = dr["AccountNo"];
        //            ViewBag.SwiftCode = dr["SwiftCode"];
        //            ViewBag.IBANno = dr["IBANno"];
        //        }



        //    }
        //    return View();
        //}
        //public ActionResult PIPrintDetails(string PINo)
        //{
        //    DataSet getJobOrderSet = new DataSet();
        //    DataTable tblMasterDetails = new DataTable();
        //    DataTable tblGlassDetails = new DataTable();
        //    DataTable tblGlassDetailsTotal = new DataTable();
        //    DataTable tblKeyTerm = new DataTable();
        //    DataTable tblProcessDetails = new DataTable();
        //    DataTable tblTotalProcessDetails = new DataTable();
        //    DataTable tblSizes = new DataTable();

        //    getJobOrderSet = PIBL.GetProformaInvoicePrintDetails(PINo, Convert.ToString(Session["LoginType"]));

        //    if (getJobOrderSet.Tables.Count > 0)
        //    {
        //        tblMasterDetails = getJobOrderSet.Tables[0];
        //        tblGlassDetails = getJobOrderSet.Tables[1];
        //        tblGlassDetailsTotal = getJobOrderSet.Tables[2];
        //        tblProcessDetails = getJobOrderSet.Tables[3];
        //        tblTotalProcessDetails = getJobOrderSet.Tables[4];
        //        tblSizes = getJobOrderSet.Tables[5];
        //        tblKeyTerm = getJobOrderSet.Tables[6];

        //        foreach (DataRow dr in tblMasterDetails.Rows)
        //        {
        //            ViewBag.PINo = dr["PINo"];
        //            ViewBag.PIDate = dr["PIDate"];
        //            ViewBag.ValidUntil = dr["ValidUntil"];
        //            ViewBag.Cust_Name = dr["Cust_Name"];
        //            ViewBag.RevisionNo = dr["RevisionNo"];
        //            ViewBag.SalesPerson_Name = dr["SalesPerson_Name"];
        //            ViewBag.BillToAddrs = dr["BillToAddrs"];
        //            ViewBag.ShipToAddrs = dr["ShipToAddrs"];
        //            ViewBag.TRNNo = dr["LSTVAT"];
        //            ViewBag.Project_Name = dr["Project_Name"];
        //            ViewBag.BankName = dr["BankName"];
        //            ViewBag.Branch = dr["Branch"];
        //            ViewBag.AccountNo = dr["AccountNo"];
        //            ViewBag.SwiftCode = dr["SwiftCode"];
        //            ViewBag.IBANno = dr["IBANno"];
        //            ViewBag.OAKNo = dr["OAKNo"];
        //            ViewBag.OrderType = dr["OrderType"];
        //            ViewBag.DelvPeriod = dr["DelvPeriod"];
        //            ViewBag.PackingType = dr["PackingType"];
        //            ViewBag.DiscountAmt = dr["DiscountAmt"];
        //            ViewBag.AmountInWord = dr["AmountInWord"];
        //            ViewBag.GrandTotal = dr["GrandTotal"];
        //            ViewBag.BasicAmt = dr["BasicAmt"];
        //            ViewBag.TotVATAmt = dr["TotVATAmt"];
        //            ViewBag.VATPer = dr["VATPer"];
        //            ViewBag.PreaparedBy = dr["PreaparedBy"];
        //            ViewBag.WastagePrint = dr["WastagePrint"];
        //            ViewBag.ContactPersonName = dr["ContactPersonName"];
        //            ViewBag.ApprovedBy = dr["ApprovedBy"];
        //            ViewBag.CheckedBy = dr["CheckedBy"];
        //            ViewBag.ClientTel = dr["ClientTel"];
        //        }

        //        foreach (DataRow dr in tblGlassDetailsTotal.Rows)
        //        {
        //            ViewBag.TotalSQM = dr["TotalSQM"];
        //            ViewBag.TotalPcs = dr["TotalPcs"];
        //            ViewBag.TotalLC = dr["TotalLC"];

        //        }
        //        foreach (DataRow dr in tblTotalProcessDetails.Rows)
        //        {
        //            ViewBag.TotProcessAmount = dr["TotAmount"];
        //            ViewBag.DisplayTotAmount = dr["DisplayTotAmount"];
        //        }
        //    }

        //    ViewBag.tblGlassDetails = tblGlassDetails.AsEnumerable();
        //    ViewBag.tblProcessDetails = tblProcessDetails.AsEnumerable();
        //    ViewBag.tblKeyTerm = tblKeyTerm.AsEnumerable();
        //    ViewBag.tblSizes = tblSizes.AsEnumerable();


        //    return View();
        //}

        //public ActionResult PIAnnexurePrint(string PINo)
        //{
        //    DataSet getJobOrderSet = new DataSet();
        //    DataTable tblKeyTerm = new DataTable();

        //    getJobOrderSet = PIBL.GetProformaInvoicePrintDetails(PINo, Convert.ToString(Session["LoginType"]));

        //    if (getJobOrderSet.Tables.Count > 0)
        //    {

        //        //tblInvoiceDetails = getJobOrderSet.Tables[1];
        //        tblKeyTerm = getJobOrderSet.Tables[6];

        //    }

        //    ViewBag.tblKeyTerm = tblKeyTerm.AsEnumerable();
        //    return View();
        //}







    }
}