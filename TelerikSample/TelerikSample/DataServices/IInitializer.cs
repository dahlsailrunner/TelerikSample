using System.Collections.ObjectModel;
using TelerikSample.Models;

namespace TelerikSample.DataServices
{
    public interface IInitializer
    {
        ObservableCollection<ActionItem> InitializeActionItems();
    }
}
