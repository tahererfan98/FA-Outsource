using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ExportInvoicePacking
    {
        public int SrNo { get; set; }
        public string ContainerNo { get; set; }
        public string PackageName { get; set; }
        public string PackingMarks { get; set; }
        public string NoOfPackages { get; set; }
        public int TotalPackages { get; set; }
        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }
    }
}
