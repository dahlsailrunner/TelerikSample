using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikSample.Models
{
    public class PropertyDetail
    {
        public int SupplierId { get; set; }
        public string PropertyNm { get; set; }
        public string PortfolioNm { get; set; }
        public int PortfolioId { get; set; }
        public string AcctManager { get; set; }
        public string AcctMgrPhone { get; set; }
        public string AcctMgrEmail { get; set; }
        public string PropSvcRep { get; set; }
        public string PsrPhone { get; set; }
        public string PsrEmail { get; set; }
        public string PsrIconUrl { get; set; }
        public string AmIconUrl { get; set; }

        public string PsrFirstName
        {
            get { return string.IsNullOrWhiteSpace(PropSvcRep) ? "" : PropSvcRep.Split(' ')[0].Trim(); }
        }

        public string AmFirstName
        {
            get { return string.IsNullOrWhiteSpace(PropSvcRep) ? "" : AcctManager.Split(' ')[0].Trim(); }
        }
    }
}
