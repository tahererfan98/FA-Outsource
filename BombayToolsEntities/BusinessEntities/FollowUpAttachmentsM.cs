using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class FollowUpAttachmentsM
    {
        public int SrNo { get; set; }
        public int RevisionNo { get; set; }
        public int runningno { get; set; }
        public string QuotDate { get; set; }
        public string PIDate { get; set; }
        public string PINo { get; set; }
        public string EmpName { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNo { get; set; }
        public string EnqType { get; set; }
        public string MSNoFile { get; set; }
        public int BoxID { get; set; }
        public int DocID { get; set; }
        public string DocName { get; set; }
        public string FilePath { get; set; }
        public byte[] Attachment { get; set; }
        public string ContentType { get; set; }
        public string DocType { get; set; }
        public string UploadFor { get; set; }
        public FollowUpAttachmentsM()
        {
            DocMasterList = new List<DocList>();
        }
        public List<DocList> DocMasterList { get; set; }
        public string DisplayDate { get; set; }
        public string PreviewFilePath { get; set; }
    }
    public class DocMasterList
    {
        public int DocID { get; set; }

        public string DocName { get; set; }
    } 
}
