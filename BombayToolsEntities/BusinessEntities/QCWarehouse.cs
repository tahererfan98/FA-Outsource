using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class QCWarehouse
    {
        public QCWarehouse()
        {
            SiliconTagList = new List<QCWarehouse>();
            MoleculeTagList = new List<QCWarehouse>();
            ButylTagList = new List<QCWarehouse>();
            SpacerTagList = new List<QCWarehouse>();
            GlassData = new List<QCWarehouse>();
            PISpecData = new List<QCWarehouse>();
            PISizesData = new List<QCWarehouse>();
            PIMasterData = new List<QCWarehouse>();
            PIFrieghtData = new List<QCWarehouse>();
            PIIFrieghtData = new List<QCWarehouse>();
            PIWastageData = new List<QCWarehouse>();
        }
        public List<QCWarehouse> SiliconTagList { get; set; }
        public List<QCWarehouse> MoleculeTagList { get; set; }
        public List<QCWarehouse> ButylTagList { get; set; }
        public List<QCWarehouse> SpacerTagList { get; set; }
        public List<QCWarehouse> GlassData { get; set; }
        public List<QCWarehouse> PISpecData { get; set; }
        public List<QCWarehouse> PISizesData { get; set; }
        public List<QCWarehouse> PIMasterData { get; set; }
        public List<QCWarehouse> PIFrieghtData { get; set; }
        public List<QCWarehouse> PIIFrieghtData { get; set; }
        public List<QCWarehouse> PIWastageData { get; set; }
        public int DeptID { get; set; }
        public int DraftID { get; set; }
        public int OffCutID { get; set; }
        public int IsSpecialTest { get; set; }
        public string SpacerName { get; set; }
        public int ProjectID { get; set; }
        public string ConsumptionDate { get; set; }
        public string ConsumptionNo { get; set; }
        public decimal LiterPerSQM { get; set; }
        public string ProjectName { get; set; }
        public string EMPID { get; set; }
        public string NextDepartment { get; set; }
        public string PINo { get; set; }
        public string WONO1 { get; set; }
        public string PINo1 { get; set; }
        public string ProcessDate { get; set; }
        public string ShiftName { get; set; }
        public string PersonName { get; set; }
        public string Department { get; set; }
        public string RM { get; set; }
        public string DeptName { get; set; }
        public string WOYear { get; set; }
        public string WONo { get; set; }
        public string SrNo { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string DoneWONo { get; set; }
        public string Type { get; set; }
        public int Qty { get; set; }
        public int BalQty { get; set; }
        public int SpecID { get; set; }
        public int SrNo1 { get; set; }
        public decimal SQM { get; set; }
        public decimal Grms { get; set; }
        public decimal Kgs { get; set; }
        public decimal Ltrs { get; set; }
        public int ParameterID { get; set; }
        public int IsNumeric { get; set; }
        public int AttachCount { get; set; }
        public string IsReason { get; set; }
        public int IsRAP { get; set; }
        public int IsCheckForCurveshield { get; set; }
        public int IsAllowSize { get; set; }
        public int Priority { get; set; }
        public string AllowNA { get; set; }
        public string Parameter { get; set; }
        public string Limit { get; set; }
        public string Unit { get; set; }
        public string Observation { get; set; }
        public string Remarks { get; set; }
        public string Criteria { get; set; }
        public string ValueFrom { get; set; }
        public string ValueTo { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string Cal { get; set; }
        public string Reason { get; set; }
        public string GlassDesc { get; set; }
        public string Thickness { get; set; }
        public string Brand { get; set; }
        public string GlassType { get; set; }
        public string Description { get; set; }
        public string Hole { get; set; }
        public string FullDesc { get; set; }
        public string AddedOn { get; set; }
        public int AddedBy { get; set; }
        public string Message { get; set; }
        public int StatusID { get; set; }
        public string Component { get; set; }
        public string RollNo { get; set; }
        public string TagNo { get; set; }
        public string StartDate { get; set; }
        public string Combination { get; set; }
        public string Colour { get; set; }
        public string BatchWorkYear { get; set; }
        public string Make { get; set; }
        public string Length { get; set; }
        public string PVBName { get; set; }
        public string IssueDate { get; set; }
        public string BatchNo { get; set; }
        public decimal ConsQty_SQM { get; set; }
        public decimal PurchQty_SQM { get; set; }
        public decimal Bal_SQM { get; set; }
        public decimal WastageSQM { get; set; }
        public int IsEditable { get; set; }
        public int IsImage { get; set; }
        public int IsSelected { get; set; }
        public int Count { get; set; }
        public int TypeNo { get; set; }
        public string IssueTo { get; set; }
        public string UserName { get; set; }
        public string QCNO { get; set; }
        public string QCDate { get; set; }
        public string url { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string RangeUnit { get; set; }
        public string ColourClass { get; set; }
        public bool IsUpdate { get; set; }
        public int AutoID { get; set; }
        public int QCID { get; set; }
        public int TestParameterID { get; set; }
        public string CutOut { get; set; }
        public string EndDate { get; set; }
        public int Done { get; set; }
        public string GRNNo { get; set; }
        public string GRNDate { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public string Specification { get; set; }
        public string Process { get; set; }
        public decimal TestThickness1 { get; set; }
        public decimal TestThickness2 { get; set; }
        public decimal TestThickness3 { get; set; }
        public decimal TestThickness4 { get; set; }
        public decimal LocalBow { get; set; }
        public decimal OverallBow { get; set; }

        //For PI Report
        public string PriorityName { get; set; }
        public string PIDate { get; set; }
        public string Customer { get; set; }
        public string ApprovedByCust { get; set; }
        public string ApprovedByAccounts { get; set; }
        public string Status { get; set; }
        public string ReasonForHold { get; set; }
        public string SalesPerson { get; set; }
        public string ReasonForCancel { get; set; }
        public string Mode { get; set; }
        public string ContactPersonName { get; set; }
        public string EstimatedShipTime { get; set; }
        public string OtherDetailsClient { get; set; }
        public string OtherDetailsShipment { get; set; }
        public string POD { get; set; }
        public string POL { get; set; }
        public string ModeOfTransPortation { get; set; }
        public string TransportationTerms { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Currency { get; set; }
        public string IndentNo { get; set; }
        public int RevisionNo { get; set; }
        public int PendingFrom { get; set; }
        public decimal PIAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public int AHeight { get; set; }
        public int AWidth { get; set; }
        public int CHeight { get; set; }
        public int CWidth { get; set; }

        //18-1-2022
        public string MobileNo { get; set; }
        public string ShiftToAddrs { get; set; }
        public string BillToAddrs { get; set; }
        public string ShiftGSTNo { get; set; }
        public string BillGSTNo { get; set; }
        public string CustRefNo { get; set; }
        public string Product { get; set; }
        public string DisplayUnit { get; set; }
        public string DisplayAmount { get; set; }
        public string PaymentTerms { get; set; }
        public string PaymentRemarks { get; set; }
        public string RemarksForLandedCost { get; set; }
        public string ApplicableGST { get; set; }
        public string DisplayGrandTotal { get; set; }
        public string PackingType { get; set; }
        public string Unloading { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal GSTAmount { get; set; }
        public decimal GSTPer { get; set; }
        public string DisplayCGST { get; set; }
        public string DisplayIGST { get; set; }
        public string FreightName { get; set; }
        public string DisplayFrieghtAmount { get; set; }
        public string GlassDetails { get; set; }
        public string ProjectTeam { get; set; }
        public int FrieghtID { get; set; }
        public decimal Amount { get; set; }
        //28-01-22(TI)
        public string AckNo { get; set; }
        public string AckDate { get; set; }
        public string IRNNo { get; set; }
        public string signedQRCode { get; set; }
        public string Telephone { get; set; }
        public string RunningNo { get; set; }
        public string TIDate { get; set; }
        public string WayBillNo { get; set; }
        public string EWayBillNo { get; set; }
        public string PrepTime { get; set; }
        public string PrepTimeInWords { get; set; }
        public string Transport { get; set; }
        public string VehicleNo { get; set; }
        public string TINo { get; set; }
        public string DisplayWstgAmt { get; set; }
        public string DisplayGlassRate { get; set; }
        public string ItemName { get; set; }
        public string DisplayBasicAmt { get; set; }
        public decimal Wastage_Calc { get; set; }
        public decimal DisplayGSTPer { get; set; }
        public string TotalBasic { get; set; }
        public string DisplayTCS { get; set; }
        public decimal TCSPer { get; set; }
        public decimal WstgAmt { get; set; }
        public string GlassDescription { get; set; }
        public string Holes_Desc { get; set; }
        public string DisplayCOAmt { get; set; }
        public string DisplayHolesAmt { get; set; }
        public string DisplayBAmt { get; set; }
        public int TotalPcs { get; set; }
        public decimal TotalSQM { get; set; }
        public string InsPolicyNo { get; set; }
        public string AmtInWords { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }
        public string PanNo { get; set; }
        public string ShipToState { get; set; }
        public string DisplayEXBasicAmt { get; set; }
        public string DisplayExGrandTotal { get; set; }
        public string AmtInWordsEx { get; set; }
        public string DisplayExUnit { get; set; }
        public string DisplayExAmount { get; set; }
        public string DisplayExFreight { get; set; }
        public string DisplayExIGST { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal ExRate { get; set; }
        public int TIStatus { get; set; }
        public int ProStatus { get; set; }
        public string DisplayExportSEZ { get; set; }
        public string WastageAmt { get; set; }
        public decimal Wastage { get; set; }
        public decimal GlassRate { get; set; }
        public string NameOfGoods { get; set; }
        public string HSNCODE { get; set; }
        public decimal ScrapSQM { get; set; }
        public decimal ScrapTotalSQM { get; set; }
        public string CombSpecification { get; set; }
        public string DCNo { get; set; }
        public string DCDate { get; set; }
        public string DriverNo { get; set; }
        public string DisplayScrapTotalSQM { get; set; }
        public string ExportInvoiceNo { get; set; }


    }
}
