using System.Collections.Generic;
using System.Linq;
using Prism.Events;
using Prism.Navigation;
using TelerikSample.DataServices;
using TelerikSample.Models;

namespace TelerikSample.ViewModels
{
    public class ChartPageViewModel : MyBindableBase
    {
        public ChartPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            Chart = ApiServiceMock.GetChartData();
            ActionItem = ApiServiceMock.GetActionItems().First();
            ActionItem.SetPrebillingAttributes();
        }

        private ActionItem _actionItem;
        public ActionItem ActionItem
        {
            get { return _actionItem; }
            set { SetProperty(ref _actionItem, value); }
        }
        
        private LocalChart _chart;
        public LocalChart Chart
        {
            get { return _chart; }
            set { SetProperty(ref _chart, value); }
        }
    }
}
