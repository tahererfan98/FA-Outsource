using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SupplierBillDetailsData
    {
        public SupplierBillDetailsData()
        {
            SupplierBillData = new SupplierBillM();
            SupplierBillItemList = new List<SupplierBillM>();
            SupplierBillFreightList = new List<SupplierBillM>();
            SupplierInfoAttach = new List<SupplierInfoAttach>();

        }
        public SupplierBillM SupplierBillData { get; set; }
        public List<SupplierBillM> SupplierBillItemList { get; set; }
        public List<SupplierBillM> SupplierBillFreightList { get; set; }
        public List<SupplierInfoAttach> SupplierInfoAttach { get; set; }
    }
}
