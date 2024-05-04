using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CompanyNotes
    {
        public int NoteID { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public string CompanyName { get; set; }
        public string LocationName { get; set; }
        public string Subject { get; set; }
        public string Notes { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsActive { get; set; }
    }
}
