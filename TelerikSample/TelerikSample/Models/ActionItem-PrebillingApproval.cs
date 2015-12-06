namespace TelerikSample.Models
{
    public partial class ActionItem
    {
        private int _previousBillCount;
        private int _currentBillCount;
        private decimal _previousAvgNormalBill;
        private decimal _currentAvgNormalBill;
        private decimal _previousBillingAmount;
        private decimal _previousMaxNormalBill;
        private decimal _currentMaxNormalBill;

        public int PreviousBillCount
        {
            get { return _previousBillCount; }
            set
            {
                _previousBillCount = value;
                OnPropertyChanged();
            }
        }

        public int CurrentBillCount
        {
            get { return _currentBillCount; }
            set
            {
                _currentBillCount = value;
                OnPropertyChanged();
            }
        }

        public decimal PreviousAvgNormalBill
        {
            get { return _previousAvgNormalBill; }
            set
            {
                _previousAvgNormalBill = value;
                OnPropertyChanged();
            }
        }

        public decimal CurrentAvgNormalBill
        {
            get { return _currentAvgNormalBill; }
            set
            {
                _currentAvgNormalBill = value;
                OnPropertyChanged();
            }
        }

        public decimal PreviousBillingAmount
        {
            get { return _previousBillingAmount; }
            set
            {
                _previousBillingAmount = value;
                OnPropertyChanged();
            }
        }

        public decimal PreviousMaxNormalBill
        {
            get { return _previousMaxNormalBill; }
            set
            {
                _previousMaxNormalBill = value;
                OnPropertyChanged();
            }
        }

        public decimal CurrentMaxNormalBill
        {
            get { return _currentMaxNormalBill; }
            set
            {
                _currentMaxNormalBill = value;
                OnPropertyChanged();
            }
        }

        public bool IsPrebillingApproval
        {
            get { return ActionType == ActionItemType.PrebillingApproval; }
        }

        public void SetPrebillingAttributes()
        {
            if (ActionType != ActionItemType.PrebillingApproval) return;
            object oout;
            int x;
            decimal y;
            if (Details.TryGetValue("CurrentBillCount", out oout))
            {
                if (int.TryParse(oout.ToString(), out x))
                    CurrentBillCount = x;
            }
            if (Details.TryGetValue("PreviousBillCount", out oout))
            {
                if (int.TryParse(oout.ToString(), out x))
                    PreviousBillCount = x;
            }
            if (Details.TryGetValue("PreviousAvgNormalBill", out oout))
            {
                if (decimal.TryParse(oout.ToString(), out y))
                    PreviousAvgNormalBill = y;
            }
            if (Details.TryGetValue("CurrentAvgNormalBill", out oout))
            {
                if (decimal.TryParse(oout.ToString(), out y))
                    CurrentAvgNormalBill = y;
            }
            if (Details.TryGetValue("PreviousBillingAmount", out oout))
            {
                if (decimal.TryParse(oout.ToString(), out y))
                    PreviousBillingAmount = y;
            }
            if (Details.TryGetValue("PreviousMaxNormalBill", out oout))
            {
                if (decimal.TryParse(oout.ToString(), out y))
                    PreviousMaxNormalBill = y;
            }
            if (Details.TryGetValue("CurrentMaxNormalBill", out oout))
            {
                if (decimal.TryParse(oout.ToString(), out y))
                    CurrentMaxNormalBill = y;
            }
        }
    }
}
