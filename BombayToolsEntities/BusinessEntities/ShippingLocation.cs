using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ShippingLocation
    {
        public ShippingLocation()
        {
            responseMessage = new ResponseMessage();
            shippingLocation = new List<SalesOrderM>();
        }
        
        public ResponseMessage responseMessage { get; set; }
        public List<SalesOrderM> shippingLocation { get; set; }

    }
}
