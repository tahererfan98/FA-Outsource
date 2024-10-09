using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class AttachmentM
    {

        public int SrNo { get; set; }
        public int runningno { get; set; }
        public string EnqType { get; set; }
        public string MSNoFile { get; set; }
        public int DocID { get; set; }
        public string DocName { get; set; }
        public string FilePath { get; set; }
        public string PreviewFilePath { get; set; }
        public string AmountWords { get; set; }
        public byte[] Attachment { get; set; }
        public string ContentType { get; set; }
        public string DocType { get; set; }
        public string UploadFor { get; set; }
        public string NewFileName { get; set; }
        public string DocumentTypeName { get; set; }
        public string DocFileName { get; set; }
        public int DocumentTypeID { get; set; }
        public int RunningID { get; set; }

        public List<DocListEstimation> DocList { get; set; }
    }
    public class DocListEstimation
    {
        public int DocID { get; set; }

        public string DocName { get; set; }
    }

}

