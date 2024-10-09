using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ExportInvoiceD
    {
        public int index { get; set; }
        public int POID { get; set; }
        public string HSNCode { get; set; }
        public string PONO { get; set; }
        public string GRNNo { get; set; }
        public string IndentNo { get; set; }
        public string WONO { get; set; }
        public string ItemCode { get; set; }
        public int ItemID { get; set; }
        public string Heading { get; set; }
        public int HeadingID { get; set; }
        public int NoOfPackages { get; set; }
        public int TotalPackages { get; set; }
        public int NetWeight { get; set; }
        public int GrossWeight { get; set; }
        public int SrNo { get; set; }
        public string GLNO { get; set; }
        public string ItemDescription { get; set; }
        public string Project_Name { get; set; }
        public string ContainerNo { get; set; }
        public string PackageName { get; set; }
        public string ProjectName { get; set; }
        public string WareHouse { get; set; }
        public string TagNo { get; set; }
        public string PartNo { get; set; }
        public string DisplayNetTotal { get; set; }
        public string DisplayGrandTotal { get; set; }
        public string Manufacture { get; set; }
        public string IndentDate { get; set; }
        public decimal Rate { get; set; }
        public decimal Qty { get; set; }
        public decimal IndQty { get; set; }

        public decimal Discount { get; set; }
        public decimal GST { get; set; }
        public decimal NetTotal { get; set; }
        public decimal FinalTotal { get; set; }
        public decimal LastPurchase { get; set; }
        public decimal ChargeAmount { get; set; }
        public int InStock { get; set; }   // For count
        public int PendingPO { get; set; }   // For count
        public int PendingSO { get; set; }   // For count
        public int TotalItem { get; set; }   // For count
        public int NoOfCase { get; set; }   // For count
        public int SheetPerCase { get; set; }   // For count
        public int GSTID { get; set; }   // For count
        public int ProjectID { get; set; }   // For count
        public string Unit { get; set; }
        public string SaleUnit { get; set; }
        public string Status { get; set; }
        public string CGST { get; set; }
        public string SGST { get; set; }
        public string IGST { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal SQM { get; set; }
        public decimal SQFT { get; set; }
        public decimal TotalLC { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal GSTPercent { get; set; }
        public decimal CGSTPer { get; set; }
        public decimal SGSTPer { get; set; }
        public decimal IGSTPer { get; set; }
        public decimal BalanceQty { get; set; }
        public decimal FixedBalanceQty { get; set; }
        public decimal AlreadyReceivedQty { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string ChargeName { get; set; }
        public string DisplayChargeAmount { get; set; }
        public int ChargeID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string ItemGroup { get; set; }
        public string PINO { get; set; }
        public string DNNO { get; set; }
        public string DCNO { get; set; }
        public int SpecID { get; set; }
        ////// Packing list 09-09-23
        
        public decimal BatchNo { get; set; }
        public decimal AHeight { get; set; }
        public decimal AWidth { get; set; }
        public decimal Inch_Height { get; set; }
        public decimal Inch_Width { get; set; }
        public decimal Qty_SQFT { get; set; }
        public decimal ASQM { get; set; }
        public string Remark { get; set; }
        public decimal ToatlQTY { get; set; }
        public decimal TotalSQFT { get; set; }
        public decimal TotASQM { get; set; }

    }
}
