using System.Collections.ObjectModel;
using TelerikSample.DataServices;
using TelerikSample.Droid;
using TelerikSample.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(Initializer))]
namespace TelerikSample.Droid
{
    public class Initializer : IInitializer
    {
        public ObservableCollection<ActionItem> InitializeActionItems()
        {
            return new ObservableCollection<ActionItem>();
        }
    }
}