using System;

namespace TelerikSample.Models
{
    public class UtilityAllocation
    {
        public string UtlBillAcctNo { get; set; }
        public string UtilityNm { get; set; }
        public DateTime ServicePeriodBeginDate { get; set; }
        public DateTime ServicePeriodEndDate { get; set; }

        public string ServicePeriod
        {
            get { return string.Format("{0} - {1}", ServicePeriodBeginDate.Date, ServicePeriodEndDate.Date); }
        }

        public int NumDays { get; set; }
        public int NwpDays { get; set; }
        public string Offering { get; set; }
        public string OfferingTypeCd { get; set; }
        public string OfferingDesc { get; set; }
        public decimal Consumption { get; set; }
        public decimal ChargeAmt { get; set; }
        public decimal DnaLwdAmt { get; set; }
        public decimal ProratedAmt { get; set; }
        public DateTime BillDate { get; set; }
        public int DocId { get; set; }
        public int ImageId { get; set; }
        //public string FilePath { get; set; }
        public string Url { get; set; }
        public bool IsDefaulted { get; set; }
    }
}
