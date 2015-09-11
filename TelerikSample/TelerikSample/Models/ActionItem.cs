using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TelerikSample.Models
{
    public enum ActionItemType
    {
        MissingUtilityBill,
        PrebillingApproval,
        UtilityAlert
    }

    public class ActionItem : INotifyPropertyChanged
    {
        private bool _isSelected;

        public ActionItemType ActionType { get; set; }

        public string ActionTypeStr
        {
            get { return ActionType.ToString(); }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public string Description { get; set; }
        public string Property { get; set; }
        public string AcctManager { get; set; }
        public string AcctMgrPhone { get; set; }
        public string AcctMgrEmail { get; set; }
        public string PropSvcRep { get; set; }
        public string PsrPhone { get; set; }
        public string PsrEmail { get; set; }
        public string InstanceId { get; set; }

        public string LeftAction { get; set; }

        public string RightAction { get; set; }

        public string CreatedAt
        {
            get { return CreatedAtDt.Date.ToString().Split(' ')[0]; }
        }

        public DateTime CreatedAtDt { get; set; }
        public Dictionary<string, object> Details { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0}-{1}", Description, InstanceId);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
