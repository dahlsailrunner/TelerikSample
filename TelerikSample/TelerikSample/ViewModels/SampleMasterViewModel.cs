using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Prism.Events;
using Prism.Navigation;
using TelerikSample.Models;
using TelerikSample.DataServices;
using Prism.Commands;
using Xamarin.Forms;

namespace TelerikSample.ViewModels
{
    public class SampleMasterViewModel : MyBindableBase, INavigationAware
    {
        public DelegateCommand SampleCommand { get; set; }

        private bool _multiSelect;

        public bool MultiSelect
        {
            get { return _multiSelect; }
            set { SetProperty(ref _multiSelect, value); }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }

        private string _resolveStr;

        public string ResolveStr
        {
            get { return _resolveStr; }
            set { SetProperty(ref _resolveStr, value); }
        }

        private string _selectStr;

        public string SelectStr
        {
            get { return _selectStr; }
            set { SetProperty(ref _selectStr, value); }
        }

        private string _groupStr;

        public string GroupStr
        {
            get { return _groupStr; }
            set { SetProperty(ref _groupStr, value); }
        }

        private string _selectedActionTypes;

        public string SelectedActionTypes
        {
            get { return _selectedActionTypes; }
            set { SetProperty(ref _selectedActionTypes, value); }
        }

        private ObservableCollection<ActionItem> _actionItems;

        public ObservableCollection<ActionItem> ActionItems
        {
            get { return _actionItems; }
            set { SetProperty(ref _actionItems, value); }
        }

        private string _psrName;

        public string PsrName
        {
            get { return _psrName; }
            set { SetProperty(ref _psrName, value); }
        }

        private string _psrPhone;

        public string PsrPhone
        {
            get { return _psrPhone; }
            set { SetProperty(ref _psrPhone, value); }
        }

        private string _psrEmail;

        public string PsrEmail
        {
            get { return _psrEmail; }
            set { SetProperty(ref _psrEmail, value); }
        }

        private string _amName;

        public string AmName
        {
            get { return _amName; }
            set { SetProperty(ref _amName, value); }
        }

        private string _amPhone;

        public string AmPhone
        {
            get { return _amPhone; }
            set { SetProperty(ref _amPhone, value); }
        }

        private string _amEmail;

        public string AmEmail
        {
            get { return _amEmail; }
            set { SetProperty(ref _amEmail, value); }
        }

        private string _loadText;

        public string LoadText
        {
            get { return _loadText; }
            set { SetProperty(ref _loadText, value); }
        }

        public SampleMasterViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService, eventAggregator)
        {
            MultiSelect = false;
            LoadText = "Inverting the flux capacitor. One moment!";

            SampleCommand = new DelegateCommand(RunSampleCommand);

            LoadData();

            SelectStr = "Select";
            SelectedActionTypes = "";
            GroupStr = "Action Type";
            ResolveStr = "Resolve";

            IsLoading = false;
        }

        private void RunSampleCommand()
        {
            NavService.Navigate("MasterDetailPage");
            //var s = DependencyService.Get<ISaveAndLoad>();
            //s.Save("filename", new MemoryStream());
        }

        //private void HandleLoginEvent(string notReallyUsedButNeeded)
        //{
        //    LoadData();
        //}

        public void LoadData()
        {
            var actions = ApiServiceMock.GetActionItems();
            foreach (var actionItem in actions)
            {
                actionItem.PropertyChanged += ItemChanged;
                switch (actionItem.ActionType)
                {
                    case ActionItemType.MissingUtilityBill:
                       
                        break;
                    case ActionItemType.PrebillingApproval:
                        
                        break;

                    case ActionItemType.UtilityAlert:
                        
                        break;
                }
            }

            ActionItems = new ObservableCollection<ActionItem>(actions);

            PsrName = actions[0].PropSvcRep;
            PsrPhone = actions[0].PsrPhone;
            PsrEmail = actions[0].PsrEmail;
            AmName = actions[0].AcctManager;
            AmPhone = actions[0].AcctMgrPhone;
            AmEmail = actions[0].AcctMgrEmail;

            if (IsLoading) IsLoading = false;
        }

        private void ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("AreAnySelected");
        }

        #region Implementation of INavigationAware

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (ActionItems.Count < 1)
                LoadData();

            var knock = parameters["knock"] as ActionItem;
            if (knock == null) return;
            var items = ActionItems.Where(x => x.InstanceId != knock.InstanceId).ToList();
            ActionItems = new ObservableCollection<ActionItem>(items);
        }

        #endregion

        public bool AreAnySelected
        {
            get { return ActionItems.Any(x => x.IsSelected); }
        }
    }
}


