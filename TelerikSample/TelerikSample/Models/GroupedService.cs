using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikSample.Models
{
    public class GroupedService
    {
        public string ServiceType { get; set; }
        public List<UtilityAllocation> ServiceDetails { get; set; }
        public int BillCount { get; set; }
        public decimal TotalAllocation { get; set; }
    }
}
