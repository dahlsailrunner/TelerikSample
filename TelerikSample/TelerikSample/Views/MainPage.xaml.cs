using System;
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
            }

        private bool _isSwiping;
        private void List_OnItemTapped(object sender, ItemTapEventArgs args)
        {
            if (!_isSwiping)
            {
                var x = 1;
            }
            else _isSwiping = false;
        }
        private void ActionListView_OnItemSwiping(object sender, ItemSwipingEventArgs e)
        {
            _isSwiping = true;
        }
        private void ActionListView_OnRefreshRequested(object sender, PullToRefreshRequestedEventArgs e)
        {
            var x = 1;
        }
        private void AcceptButton_OnClicked(object sender, EventArgs e)
        {
            
        }

        private void RejectButton_OnClicked(object sender, EventArgs e)
        {
        }
    }
}
