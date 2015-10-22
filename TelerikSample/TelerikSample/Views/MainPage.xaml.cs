using Telerik.XamarinForms.DataControls.ListView;
using TelerikSample.ViewModels;
using Xamarin.Forms;

namespace TelerikSample.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ActionListView.RefreshRequested += (sender, args) =>
            {
                var bc = BindingContext as MainPageViewModel;
                if (bc == null) return;
                bc.LoadData();
                ActionListView.EndRefresh(true);
            };
        }

        private void ActionListView_OnItemTapped(object sender, ItemTapEventArgs e)
        {
            var bc = BindingContext as MainPageViewModel;
            if (bc == null) return;
        }
    }
}
