using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EmployeeAttachments
    {
        public int SrNo { get; set; }
        public string EmpID { get; set; }
        public string UploadFor { get; set; }
        public string DocName { get; set; }
        public string DocFileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public int runningno { get; set; }
    }
}
