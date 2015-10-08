using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using TelerikSample.Views;
using Xamarin.Forms;

namespace TelerikSample
{
    public class MainSettingsStuff : MasterDetailPage
    {
        public MainSettingsStuff()
        {
            Master = new SampleMaster();
            Detail = new SampleDetail();
            IsGestureEnabled = false;           
        }
    }
}
