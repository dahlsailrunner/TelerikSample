using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikSample.Models
{
    public partial class ActionItem
    {
        private string _alertType;
        private string _alertDescription;
        public bool IsAlertSameAsDesc
        {
            get
            {
                if (string.IsNullOrWhiteSpace(AlertType) || string.IsNullOrWhiteSpace(AlertDescription)) return false;
                return !string.Equals(AlertType.Trim(), AlertDescription.Trim(), StringComparison.OrdinalIgnoreCase);
            }
        }
        public string AlertType
        {
            get { return _alertType; }
            set
            {
                _alertType = value;
                OnPropertyChanged();
            }
        }
        public string AlertDescription
        {
            get { return _alertDescription; }
            set
            {
                _alertDescription = value;
                OnPropertyChanged();
            }
        }
        public void SetUtilityAttributes()
        {
            if (ActionType != ActionItemType.UtilityAlert) return;
            object oout;
            string x;
            if (Details.TryGetValue("AlertType", out oout))
            {
                x = (string)oout;
                if (!string.IsNullOrWhiteSpace(x))
                    AlertType = x;
            }
            if (Details.TryGetValue("AlertDescription", out oout))
            {
                x = (string)oout;
                if (!string.IsNullOrWhiteSpace(x))
                    AlertDescription = x;
            }
        }
    }
}
