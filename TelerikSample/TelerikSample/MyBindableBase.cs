using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace TelerikSample
{
    public abstract class MyBindableBase : BindableBase
    {
        protected readonly INavigationService NavService;
        protected readonly IEventAggregator EventAgg;
        public MyBindableBase(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            NavService = navigationService;
            EventAgg = eventAggregator;

            //if (!App.IsLoggedIn)
            //{
            //    NavService.Navigate("LoginPage");
            //    //Navigation.PushModalAsync(new LoginPage());
            //}
        }
    }
}
