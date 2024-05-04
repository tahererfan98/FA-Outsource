using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ProformaInvoice
    {

        public int PIID { get; set; }
        public string PINO { get; set; }
        public string PIDate { get; set; }
        public string PIDate2 { get; set; }
        public string Customer { get; set; }
        public string ProjectName { get; set; }
        public decimal PCS { get; set; }
        public decimal SQM { get; set; }
        public decimal Amount { get; set; }
        public string Amount1 { get; set; }
        public string Owner { get; set; }
        public string SalesPerson { get; set; }
        public string PIType { get; set; }
        public string Description { get; set; }
        public int ProjectID { get; set; }
        public Boolean IsFavourite { get; set; }
        public string Color { get; set; }
        public int CustomerID { get; set; }
        public string ShortDescription { get; set; }
        public DateTime ExpectedDeliverTime { get; set; }
        public string Number { get; set; }
        public int BoxID { get; set; }
        public int No { get; set; }
        public int RevisionNo { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public string ReasonForClosure { get; set; }
    }
}
