using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombayToolsEntities.BusinessEntities
{
    public class EmployeeDetails
    {
        public EmployeeDetails()
        {
            employee = new Employee();
            employeeAttachment = new List<EmployeeAttachments>();
        }
        public Employee employee { get; set; }
        public List<EmployeeAttachments> employeeAttachment { get; set; }
    }
}
