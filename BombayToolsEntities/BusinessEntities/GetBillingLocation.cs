using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class GetBillingLocation
    {

        public GetBillingLocation()
        {
            responseMessage = new ResponseMessage();
            billingLocation = new List<SalesOrderM>(); 
            shippingLocation = new List<SalesOrderM>();
        }

        public ResponseMessage responseMessage { get; set; }
        public List<SalesOrderM> billingLocation { get; set; } 
        public List<SalesOrderM> shippingLocation { get; set; }

    }
}
