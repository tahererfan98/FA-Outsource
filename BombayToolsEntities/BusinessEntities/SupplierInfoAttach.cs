using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class SupplierInfoAttach
    {
        public int SrNo { get; set; }
        public int VisitID { get; set; }
        public int runningno { get; set; }
        public string EnqType { get; set; }
        public string MSNoFile { get; set; }
        public int DocID { get; set; }
        public string DocName { get; set; }
        public string FilePath { get; set; }
        public string AmountWords { get; set; }
        public byte[] Attachment { get; set; }
        public string ContentType { get; set; }
        public string DocType { get; set; }
        public string UploadFor { get; set; }
        public SupplierInfoAttach()
        {
            DocList = new List<DocList>();
        }
        public List<DocList> DocList { get; set; }
    }
    public class DocList
    {
        public int DocID { get; set; }

        public string DocName { get; set; }
    }
}
