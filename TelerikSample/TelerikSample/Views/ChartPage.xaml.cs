using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Chart;
using TelerikSample.Models;
using TelerikSample.ViewModels;
using Xamarin.Forms;

namespace TelerikSample.Views
{
    public partial class ChartPage : ContentPage
    {
        public ChartPage()
        {
            InitializeComponent();
        }
        private void SingleSelected(object sender, EventArgs e)
        {
            var chartSelectionBehavior = sender as ChartSelectionBehavior;
            if (chartSelectionBehavior == null) return;
            var points = chartSelectionBehavior.SelectedPoints.FirstOrDefault();
            if (points == null) return;
            var data = points.DataItem as CategoricalData;
            if (data == null) return;
            var bc = BindingContext as ChartPageViewModel;
            if (bc == null) return;
            //bc.NavigateToDetails(data);
        }
    }
}
