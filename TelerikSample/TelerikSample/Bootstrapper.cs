using Prism.Unity;
using Microsoft.Practices.Unity;
using Xamarin.Forms;
using TelerikSample.Views;

namespace TelerikSample
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override Page CreateMainPage()
        {
            return Container.Resolve<MainPage>();
        }

        protected override void RegisterTypes()
        {
            //Container.RegisterTypeForNavigation<LoginPage>();
        }
    }
}
