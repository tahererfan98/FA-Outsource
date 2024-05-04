using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class CategoryData
    {

        public CategoryData()
        {
            Categories = new List<Category>();
        }

        public List<Category> Categories { get; set; }

    }
}
