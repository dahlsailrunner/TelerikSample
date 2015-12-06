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
            try
            {
                var page = Container.Resolve<MainPage>();
                //var page = Container.Resolve<ChartPage>();
                return page;
            }
            catch (ResolutionFailedException ex)
            {
                
            }
            return null;
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainSettingsStuff>();
        }
    }
}
