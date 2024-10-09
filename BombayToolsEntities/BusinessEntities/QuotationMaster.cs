using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class QuotationMaster
    {
        public int QTNNO { get; set; }
        public int RevNO { get; set; }
        public DateTime QTNDate { get; set; }
        public DateTime SalesOrderDate { get; set; }
        public string Refe { get; set; }
        public string Industry { get; set; }
        public int ENQNo { get; set; }
        public DateTime DueDate { get; set; }
        public int SalesPersonID { get; set; }
        public int ContactPersonID { get; set; }
        public int StatusID { get; set; }
        public int AddedBY { get; set; }
        public string AddedName { get; set; }
        public DateTime AddedON { get; set; }
        public bool IsCancelled { get; set; }
        public int CancelledBY { get; set; }
        public DateTime CancelledON { get; set; }

        public string Company { get; set; }
        public int CompanyID { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public int QTY { get; set; }
        public float Amount { get; set; }
        public string DisplayAmount { get; set; }
        public string SalesPerson { get; set; }
        public string SalesCoordinatorName { get; set; }
        public int Status { get; set; }
        public string Location { get; set; }
        public int LocationID { get; set; }
        public string LocationEmailID { get; set; }
        public int LocationContact { get; set; }
        public string ContactPersonNo { get; set; }
        public string ContactPersonEmail { get; set; }

        public string QuotCreated { get; set; }
        public string QuotDue { get; set; }
        public string QuotType { get; set; }
        public int CurrencyID { get; set; }
        public string Currency { get; set; }
        public string Remark { get; set; }
        public string Salutation { get; set; }
        public string OtherChargeDescription { get; set; }
        public double OtherCharges { get; set; }
        public float DiscountPercent { get; set; }
        public float DiscountAmount { get; set; }
        public float PackingPercent { get; set; }
        public float PackingAmount { get; set; }
        public float FreightPercent { get; set; }
        public float FreightAmount { get; set; }
        public float GST { get; set; }
        public float GSTAmount { get; set; }
        public float Total { get; set; }
        public int Vertical { get; set; }
        public string VerticalName { get; set; }
        public string Pricipal { get; set; }
        public string Sector { get; set; }
        public string AddedONDate { get; set; }
        public string QuotID { get; set; }
        public string SalesOrderID { get; set; }
        public string PONo { get; set; }
        public string PODate { get; set; }
        public string SalesOrderFrom { get; set; }
        public string SalesOrderNO { get; set; }
        public string WorkYear { get; set; }
        public string Message { get; set; }
        public string DT_RowClass { get; set; }
        public int BoxID { get; set; }
    }
}
