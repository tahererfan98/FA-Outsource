using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class GRNDetailsData
    {

        public GRNDetailsData()
        {
            GRNData = new GRNInfo();
            GRNItemList = new List<GRNInfo>();
            GRNSerialNoList = new List<GRNInfo>();

        }
        public GRNInfo GRNData { get; set; }
        public List<GRNInfo> GRNItemList { get; set; }
        public List<GRNInfo> GRNFreightList { get; set; }
        public List<GRNInfo> GRNSerialNoList { get; set; }
    }
}
