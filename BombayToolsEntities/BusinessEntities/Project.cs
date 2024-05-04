using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class Project
    {
        public Project()
        {
            ProjectDetail = new List<ProjectDetails>();
        }
        public int ProjectID { get; set; }
        public string Code { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public bool Favourite { get; set; }
        public string BackgroundColor { get; set; }
        public string Color { get; set; }
        public List<ProjectDetails> ProjectDetail { get; set; }
        public LiveProjectOrCustomerDetails ProjectDetailsList { get; set; }
        public int LivePICount { get; set; }
        public int LiveWOCount { get; set; }
        public int LiveTICount { get; set; }
        public string ProjectType { get; set; }
        public string LatestInvoiceDate { get; set; }
    }
}
