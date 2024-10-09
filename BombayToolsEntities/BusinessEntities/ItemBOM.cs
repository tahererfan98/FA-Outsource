using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ItemBOM
    {
        public int SetID { get; set; }
        public string SetName { get; set; }
        public string SetNo { get; set; }
        public int Piece { get; set; }
        public string Notes { get; set; }
        public int SetPrice { get; set; }
        public int AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int IsActive { get; set; }
        public int CategoryID { get; set; }
        public string HSN { get; set; }
        public string Unit { get; set; }
        public string MergedItemID { get; set; }
        public string Make { get; set; }
        public float CostPrice { get; set; }
        public float SellingPrice { get; set; }
        public string Remark { get; set; }
        public float RevisedCP { get; set; }
        public float RevisedSP { get; set; }
    }
}
