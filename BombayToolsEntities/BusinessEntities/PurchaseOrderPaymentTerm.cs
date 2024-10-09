using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class PurchaseOrderPaymentTerm
    {
        //payment list 
        public int PaymentTermID { get; set; }
        public string PaymentTerm { get; set; }
        public bool IsDefault { get; set; }
    }

    public class PurchaseOrderFreight
    {
        //payment list 
        public int PaymentTermID { get; set; }
        public string PaymentTerm { get; set; }
        public bool IsDefault { get; set; }
    }

}
