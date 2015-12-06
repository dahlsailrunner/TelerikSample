using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TelerikSample.Models
{
    public enum ActionItemType
    {
        MissingUtilityBill,
        PrebillingApproval,
        UtilityAlert
    }

    public partial class ActionItem : INotifyPropertyChanged
    {
        public ActionItemType ActionType { get; set; }
        public string ActionTypeStr
        {
            get { return ActionType.ToString(); }
        }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                IsNotSelected = !value;
                OnPropertyChanged();
            }
        }
        private bool _isNotSelected;
        public bool IsNotSelected
        {
            get { return _isNotSelected; }
            private set
            {
                _isNotSelected = value;
                OnPropertyChanged();
            }
        }
        public string Description { get; set; }
        private string _property;
        public string Property
        {
            get { return _property; }
            set
            {
                if (value == _property) return;
                _property = value;
                OnPropertyChanged();
                OnPropertyChanged("PropertyStr");
            }
        }
        public string PropertyStr
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Property)) return "";
                var split = Property.TrimEnd(' ').Split(' ');
                // ReSharper disable once StringIndexOfIsCultureSpecific.2
                return Property.Replace(split.Last(), "");
            }
        }
        public string AcctManager { get; set; }
        public string AcctMgrPhone { get; set; }
        public string AcctMgrEmail { get; set; }
        public string PropSvcRep { get; set; }
        public string PsrPhone { get; set; }
        public string PsrEmail { get; set; }
        public string InstanceId { get; set; }
        
        public bool IsUtilityAlert
        {
            get { return ActionType == ActionItemType.UtilityAlert; }
        }
        public string CreatedAt
        {
            get
            {
                return CreatedAtDt.Date.ToString().Split(' ')[0];
            }
        }
        public DateTime CreatedAtDt { get; set; }
        public Dictionary<string, object> Details { get; set; }
        #region Overrides of Object
        public override string ToString() { return string.Format("{0}-{1}", Description, InstanceId); }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged == null) return;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
