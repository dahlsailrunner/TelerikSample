using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Navigation;

namespace TelerikSample.ViewModels
{
    public class SampleDetailViewModel : MyBindableBase
    {
        private string _mainText;

        public string MainText
        {
            get { return _mainText;}
            set { SetProperty(ref _mainText, value); }
        }
        public SampleDetailViewModel(INavigationService navigationService, IEventAggregator eventAggregator) : base(navigationService, eventAggregator)
        {
            MainText = "Hello from the details!!!";
        }
    }
}
