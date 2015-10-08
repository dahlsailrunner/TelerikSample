using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Events;
using TelerikSample.DataServices;
using TelerikSample.Models;

namespace TelerikSample.ViewModels
{
    public class ListViewIssuesViewModel : MyBindableBase
    {
        public string NwpBillPeriod
        {
            get
            {
                DateTime beginDt, endDt;
                if (DateTime.TryParse(ActionItem.Details["PerBegDt"].ToString(), out beginDt) &&
                    DateTime.TryParse(ActionItem.Details["PerEndDt"].ToString(), out endDt))
                {
                    return string.Format("{0} - {1}", beginDt.Date, endDt.Date);
                }

                return "";
            }
        }

        private string _selectedRejectionReason;
        public string SelectedRejectionReason
        {
            get { return _selectedRejectionReason; }
            set
            {
                SetProperty(ref _selectedRejectionReason, value);
                OnPropertyChanged("CanReject");
            }
        }
        public DelegateCommand AcceptBilling { get; set; }
        public DelegateCommand RejectBilling { get; set; }
        private string _billDate;
        public string BillDate
        {
            get { return _billDate; }
            set { SetProperty(ref _billDate, value); }
        }
        private string _acceptBtnStr;
        public string AcceptBtnStr
        {
            get { return _acceptBtnStr; }
            set { SetProperty(ref _acceptBtnStr, value); }
        }
        private string _rejectBtnStr;
        public string RejectBtnStr
        {
            get { return _rejectBtnStr; }
            set { SetProperty(ref _rejectBtnStr, value); }
        }

        public string NwpDayStr
        {
            get { return _nwpDayStr; }
            set { SetProperty(ref _nwpDayStr, value); }
        }

        public string GroupByStr
        {
            get { return _groupByStr; }
            set { SetProperty(ref _groupByStr, value); }
        }

        public int NWPDays
        {
            get { return _nwpDays; }
            set { SetProperty(ref _nwpDays, value); }
        }

        private ActionItem _actionItem;

        public ActionItem ActionItem
        {
            get { return _actionItem; }
            set { SetProperty(ref _actionItem, value); }
        }
        private bool _isGroupedByService;
        public bool IsGroupedByService
        {
            get { return _isGroupedByService; }
            set { SetProperty(ref _isGroupedByService, value); }
        }
        public bool IsGroupedByAccount { get { return !IsGroupedByService; } }
        private List<GroupedAccount> _accounts;
        public List<GroupedAccount> Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }
        private string _rejectionNotes;
        public string RejectionNotes
        {
            get { return _rejectionNotes; }
            set { SetProperty(ref _rejectionNotes, value); }
        }

        private bool _isRejecting;
        public bool IsRejecting
        {
            get { return _isRejecting; }
            set
            {
                if (_isRejecting == value) return;
                SetProperty(ref _isRejecting, value);
                IsNotRejecting = !value;
            }
        }

        public bool CanReject
        {
            get { return !string.IsNullOrWhiteSpace(SelectedRejectionReason); }
        }

        private bool _isNotRejecting;
        public bool IsNotRejecting
        {
            get { return _isNotRejecting; }
            private set
            {
                SetProperty(ref _isNotRejecting, value);
            }
        }

        public List<string> RejectionReasons { get; private set; }

        private List<GroupedService> _services;
        private int _nwpDays;
        private string _groupByStr;
        private string _nwpDayStr;

        public List<GroupedService> Services
        {
            get { return _services; }
            set { SetProperty(ref _services, value); }
        }

        public ListViewIssuesViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            //EventAgg.GetEvent<PrebillingEvent>().Subscribe(HandlePrebillingEvent);
            IsGroupedByService = true;
            GroupByStr = "Service";
            GroupByCommand = new DelegateCommand(HandleGroupByCommand);
            AcceptBilling = new DelegateCommand(Approve);
            RejectBilling = new DelegateCommand(Reject);
            AcceptBtnStr = "Accept";
            RejectBtnStr = "Reject";
            IsRejecting = false;
            IsNotRejecting = true;
            RejectionNotes = "";
            BillDate = "";
            RejectionReasons = new List<string>()
                {
                    "Billing methodology incorrect",
                    "Billing period incorrect",
                    "Bills too high",
                    "Incorrect utility bills used",
                    "Resident data incorrect",
                    "Other" //we need 6 things in this list for the next line to work.
                };
            //Hard-coded to above list
            //SelectedRejectionReason = RejectionReasons[5];

            LoadData();
        }

        private void HandleGroupByCommand()
        {
            IsGroupedByService = !IsGroupedByService;
            OnPropertyChanged("IsGroupedByAccount");
            GroupByStr = IsGroupedByService ? "Service" : "Bill";
        }

        public DelegateCommand GroupByCommand { get; set; }

        //private void HandlePrebillingEvent(ActionItem obj)
        //{
        //    ActionItem = obj;
        //    LoadData();

        //}



        public void Approve()
        {
            if (IsRejecting)
            {
                AcceptBtnStr = "Accept";
                RejectBtnStr = "Reject";
                IsRejecting = false;
                IsNotRejecting = true;
            }
            else
            {
                var spropId = ActionItem.Details["PropertyId"].ToString();
                int x;
                if (!int.TryParse(spropId, out x)) return;
                //NwpSmartApiService.ApprovePrebillingAsync(ActionItem.InstanceId, x);
                //NavigateToActionItems();
            }
        }

        public void Reject()
        {
            if (IsRejecting)
            {
                if (!CanReject) return;
                var spropId = ActionItem.Details["PropertyId"].ToString();
                int x;
                if (!int.TryParse(spropId, out x)) return;
                //NwpSmartApiService.RejectPrebillingAsync(ActionItem.InstanceId, x, SelectedRejectionReason, RejectionNotes);
                //NavigateToActionItems();
            }
            else
            {
                AcceptBtnStr = "Cancel";
                RejectBtnStr = "Confirm";
                IsRejecting = true;
                IsNotRejecting = false;
            }
        }
        //public void NavigateToActionItems()
        //{
        //    //var navParams = new NavigationParameters { { "knock", ActionItem } };
        //    NavService.Navigate("HomePage");
        //}

        private async void LoadData()
        {
            //IsLoading = true;
            //var propertyId = ActionItem.Details["PropertyId"].ToString();
            //int x;
            //if (!int.TryParse(propertyId, out x)) return;

            var utilityAllocations = ApiServiceMock.GetUtilityAllocations();

            Services = HandleGroupedServices(utilityAllocations);
            Accounts = HandleGroupedAccounts(utilityAllocations);
            if (Services.Any() && Services[0].ServiceDetails.Any())
                NwpDayStr = Services[0].ServiceDetails[0].NwpDays.ToString();
            //IsLoading = false;
        }
        private List<GroupedAccount> HandleGroupedAccounts(List<UtilityAllocation> utilityAllocations)
        {
            var currentAccount = "";
            var groupedAccounts = new List<GroupedAccount>();
            GroupedAccount obj2 = null;
            foreach (var item in utilityAllocations.OrderBy(a => a.UtlBillAcctNo))
            {
                if (item.UtlBillAcctNo != currentAccount)
                {
                    currentAccount = item.UtlBillAcctNo;
                    obj2 = new GroupedAccount()
                    {
                        AccountDetails = new List<UtilityAllocation>(),
                        AccountNumber = currentAccount,
                        IsDefaulted = item.IsDefaulted
                    };
                    groupedAccounts.Add(obj2);
                }
                if (obj2 != null)
                {
                    obj2.TotalAllocation += item.ProratedAmt;
                    obj2.AccountDetails.Add(item);
                }
            }

            return groupedAccounts;
        }
        private List<GroupedService> HandleGroupedServices(List<UtilityAllocation> utilityAllocations)
        {
            var currentServiceType = "";
            var groupedServices = new List<GroupedService>();
            GroupedService obj = null;
            foreach (var item in utilityAllocations.OrderBy(a => a.OfferingDesc))
            {
                if (item.OfferingDesc != currentServiceType)
                {
                    currentServiceType = item.OfferingDesc;
                    obj = new GroupedService
                    {
                        ServiceDetails = new List<UtilityAllocation>(),
                        ServiceType = currentServiceType
                    };
                    groupedServices.Add(obj);

                }
                if (obj != null)
                {
                    obj.BillCount++;
                    obj.TotalAllocation += item.ProratedAmt;
                    obj.ServiceDetails.Add(item);
                }
            }

            return groupedServices;
        }
    }
}
