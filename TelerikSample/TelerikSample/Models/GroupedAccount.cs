using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikSample.Models
{
    public class GroupedAccount
    {
        public string AccountNumber { get; set; }
        public bool IsDefaulted { get; set; }
        public List<UtilityAllocation> AccountDetails { get; set; }
        public decimal TotalAllocation { get; set; }
    }
}
