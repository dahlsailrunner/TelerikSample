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
using System;
using System.Collections.Generic;
using XLabs.Ioc;
using XLabs.Platform.Device;
using System.Threading.Tasks;

namespace TelerikSample.ViewModels
{
    public class MainPageViewModel : MyBindableBase, INavigationAware
    {
        public bool ShouldPSRCardBeShown
        {
            get { return !IsPropertyManager; }
        }

        private bool _isPropertyManager;

        public bool IsPropertyManager
        {
            get { return _isPropertyManager; }
            set { SetProperty(ref _isPropertyManager, value); }
        }

        public bool ShouldActionListBeShown
        {
            get { return IsActionGrp && AreThereAnyActionItems; }
        }

        public bool ShouldPropertyListBeShown
        {
            get { return IsNotActionGrp && AreThereAnyActionItems; }
        }

        public bool ShouldShowNoActions
        {
            get { return !IsLoading && AreNoActionItems; }
        }

        public bool ShouldShowOnLoadOrNone
        {
            get
            {
                var should = IsLoading || AreNoActionItems;
                return should;
            }
        }

        public bool AreNoActionItems
        {
            get { return !AreThereAnyActionItems; }
        }

        public bool AreThereAnyActionItems
        {
            get
            {
                if (Device.OS == TargetPlatform.iOS)
                {
                    return ActionItems != null && ActionItems.Any() && ActionItems[0].Description != "Dummy";
                }
                else
                {
                    return ActionItems != null && ActionItems.Any();
                }

            }
        }

        private bool _isSwiping;

        public bool IsSwiping
        {
            get { return _isSwiping; }
            set { SetProperty(ref _isSwiping, value); }
        }

        private bool _isActionGrp;

        public bool IsActionGrp
        {
            get { return _isActionGrp; }
            set { SetProperty(ref _isActionGrp, value); }
        }

        private ActionItem _swipedItem;

        public ActionItem SwipedItem
        {
            get { return _swipedItem; }
            set
            {
                SetProperty(ref _swipedItem, value);
                OnPropertyChanged("PrebillingSwiped");
                OnPropertyChanged("UtilityAlertSwiped");
            }
        }

        public bool PrebillingSwiped
        {
            get { return SwipedItem.ActionType == ActionItemType.PrebillingApproval; }
        }

        public bool UtilityAlertSwiped
        {
            get { return SwipedItem.ActionType == ActionItemType.UtilityAlert; }
        }

        private bool _isPrebillingSwiped;

        public bool IsPrebillingSwiped
        {
            get { return _isPrebillingSwiped; }
            set { SetProperty(ref _isPrebillingSwiped, value); }
        }

        private bool _isUtilityAlertSwiped;

        public bool IsUtilityAlertSwiped
        {
            get { return _isUtilityAlertSwiped; }
            set { SetProperty(ref _isUtilityAlertSwiped, value); }
        }
        private bool _isNotActionGrp;
        public bool IsNotActionGrp
        {
            get { return !IsLoading && _isNotActionGrp && AreThereAnyActionItems; }
            set { SetProperty(ref _isNotActionGrp, value); }
        }
        private bool _multiSelect;
        public bool MultiSelect
        {
            get { return _multiSelect; }
            set { SetProperty(ref _multiSelect, value); }
        }
        private string _loadText;
        public string LoadText
        {
            get { return _loadText; }
            set { SetProperty(ref _loadText, value); }
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
        private ObservableCollection<PropertyDetail> _properties;
        public ObservableCollection<PropertyDetail> Properties
        {
            get { return _properties; }
            set { SetProperty(ref _properties, value); }
        }
        private ObservableCollection<ActionItem> _actionItems;
        public ObservableCollection<ActionItem> ActionItems
        {
            get { return _actionItems; }
            set
            {
                SetProperty(ref _actionItems, value);
            }
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
        public bool AreAnySelected
        {
            get { return ActionItems.Any(x => x.IsSelected); }
        }
        public bool AreAnyPrebillingSelected
        {
            get { return ActionItems.Any(x => x.IsSelected && x.ActionType == ActionItemType.PrebillingApproval); }
        }
        public bool AreAnyUtilitySelected
        {
            get { return ActionItems.Any(x => x.IsSelected && x.ActionType == ActionItemType.UtilityAlert); }
        }
        public DelegateCommand<string> PhoneCommand { get; set; }
        public DelegateCommand<string> EmailCommand { get; set; }
        public DelegateCommand HamburgerCommand { get; set; }
        public DelegateCommand GroupByCommand { get; set; }
        public DelegateCommand ForwardCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }

        #region Commands
        
        private void ExecGroupBy()
        {
            IsActionGrp = !IsActionGrp;
            IsNotActionGrp = !IsNotActionGrp;
            GroupStr = IsActionGrp ? "Type" : "Property";
            UpdateProperties();
        }
        private void ExecHamburger()
        {
            NavService.Navigate("NwpSelector");
        }
        #endregion

        #region Methods
        public void LoadData()
        {
            IsLoading = true;
            UpdateProperties();
            try
            {
                
                    var actions = ApiServiceMock.GetActionItems();

                    if (actions != null && actions.Any())
                    {
                        foreach (var actionItem in actions)
                        {
                            actionItem.PropertyChanged += ItemChanged;
                            if (actionItem.ActionType == ActionItemType.PrebillingApproval)
                            {
                                actionItem.SetPrebillingAttributes();
                            }
                            else if (actionItem.ActionType == ActionItemType.UtilityAlert)
                            {
                                actionItem.SetUtilityAttributes();
                            }
                        }
                        ActionItems = new ObservableCollection<ActionItem>(actions);
                    }
                    IsLoading = false;
                    UpdateProperties();
            }
            catch (Exception)
            {
                IsLoading = false;
                UpdateProperties();
            }
        }
        public void RemoveActionItem(ActionItem actionItem)
        {
            if (ActionItems == null || actionItem == null || !ActionItems.Contains(actionItem)) return;
            ActionItems.Remove(actionItem);
            UpdateProperties();
        }
        #endregion

        #region Navigation
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Refresh();
        }
        public void NavigateToActionItem(ActionItem actionItem)
        {
            
            if (actionItem == null) throw new ArgumentNullException("actionItem");
            var navParams = new NavigationParameters { { "ActionItem", actionItem } };
            switch (actionItem.ActionType)
            {
                case ActionItemType.PrebillingApproval:
                    NavService.Navigate("PrebillingTabbedPage", navParams);
                    break;
                case ActionItemType.UtilityAlert:
                    NavService.Navigate("UtilityAlert", navParams);
                    break;
            }
        }
        
        #endregion

        #region Helper Methods
        private void ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged("AreAnySelected");
            OnPropertyChanged("AreAnyPrebillingSelected");
            OnPropertyChanged("AreAnyUtilitySelected");
        }
        
        private bool _isLoading;
        public bool IsLoading { get; set; }
        private void UpdateProperties()
        {
            OnPropertyChanged("AreThereAnyActionItems");
            OnPropertyChanged("AreNoActionItems");
            OnPropertyChanged("IsActionGrp");
            OnPropertyChanged("IsNotActionGrp");
            OnPropertyChanged("ShouldActionListBeShown");
            OnPropertyChanged("ShouldPropertyListBeShown");
            OnPropertyChanged("ShouldShowNoActions");
            OnPropertyChanged("ShouldShowOnLoadOrNone");
        }
        #endregion

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService, eventAggregator)
        {
            
            Properties = new ObservableCollection<PropertyDetail>();
            HamburgerCommand = new DelegateCommand(ExecHamburger);
            GroupByCommand = new DelegateCommand(ExecGroupBy);
            RefreshCommand = new DelegateCommand(Refresh);
            MultiSelect = false;
            IsActionGrp = true;
            IsNotActionGrp = false;
            IsPrebillingSwiped = false;
            IsUtilityAlertSwiped = false;
            GroupStr = "Type";
            SwipedItem = new ActionItem { ActionType = ActionItemType.PrebillingApproval };
            var ds = DependencyService.Get<IInitializer>();
            ActionItems = ds.InitializeActionItems();
        }

        public void Refresh()
        {
            LoadData();
        }
    }
}