using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class DRQueryResult
    {
        public DRQueryResult()
        {
            ConditonList = new List<DRQueryConditionParameter>();
            SortByList = new List<DRQuerySortByParameter>();
        }
        public int ReportFor { get; set; }
        public string MasterString { get; set; }
        public string ReportName { get; set; }
        public string Remark { get; set; }
        public string groupByValue { get; set; }
        public int groupMasterOption { get; set; }
        public int isGroupByDateSet { get; set; }
        public int _groupbyConditionDataSet { get; set; }
        public int _groupbyConditionValue { get; set; }
        public List<DRQueryConditionParameter> ConditonList { get; set; }
        public List<DRQuerySortByParameter> SortByList { get; set; }
        public int AutoID { get; set; }
    }
}
