using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class ItemSetDetail
    {
        public int SetID { get; set; }
        public int SetCategoryID { get; set; }
        public string SetCategoryName { get; set; }
        public string SetName { get; set; }
        public string SetNo { get; set; }
        public int Piece { get; set; }
        public string Notes { get; set; }
        public int SetPrice { get; set; }
        public int ItemID { get; set; }
        public int RunningNo { get; set; }
        public string ItemDesc { get; set; }
        public string HSNCode { get; set; }
        public string Unit { get; set; }
        public string Manufacture { get; set; }
        public string PartNo { get; set; }

        public int QTY { get; set; }
        public int Rate { get; set; }  // Selling price
        public string SetHSN { get; set; }
        public string SetUnit { get; set; }
        public string SetMake { get; set; }
        public float CostPrice { get; set; }
        public string Remark { get; set; }
        public float RevisedCP { get; set; }
        public float RevisedSP { get; set; }
    }
}
