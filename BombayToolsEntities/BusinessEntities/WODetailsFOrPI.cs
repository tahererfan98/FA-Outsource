using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class WODetailsFOrPI
    {
        public WODetailsFOrPI()
        {
            CuttingDetails = new ProductionDetails();
            TougheningDetails = new ProductionDetails();
            LaminationDetails = new ProductionDetails();
            DispatchesDetails = new ProductionDetails();
            TechGlassDetails = new ProductionDetails();
            IGDetails = new ProductionDetails();
            DCDetails = new List<DCTIDetails>();
            TIDetails = new List<DCTIDetails>();

        }
        public bool IsWOAuthorized { get; set; }
        public bool IsCuttingApplicable { get; set; }
        public bool IsTougheningApplicable { get; set; }
        public bool IsLaminationApplicable { get; set; }
        public bool IsIGApplicable { get; set; }
        public bool isDispacthesApplicable { get; set; }
        public bool isTechGlassApplicable { get; set; }
        public ProductionDetails CuttingDetails { get; set; }
        public ProductionDetails TougheningDetails { get; set; }
        public ProductionDetails LaminationDetails { get; set; }
        public ProductionDetails IGDetails { get; set; }
        public ProductionDetails DispatchesDetails { get; set; }
        public ProductionDetails TechGlassDetails { get; set; }
        public List<DCTIDetails> DCDetails { get; set; }
        public List<DCTIDetails> TIDetails { get; set; }
        public int WOYear { get; set; }
        public object FullDescription { get; set; }


    }
}
