using Xamarin.Forms;

namespace TelerikSample
{
    public class App : Application
    {
        public App()
        {
            var bs = new Bootstrapper();
            bs.Run(this);
        }

        //public static bool IsLoggedIn => !string.IsNullOrWhiteSpace(Token);

        //public static string Token { get; private set; }

        //public static void SaveToken(string token)
        //{
        //    Token = token;
        //}

        //protected override void OnStart()
        //{
        //    // Handle when your app starts
        //}

        //protected override void OnSleep()
        //{
        //    // Handle when your app sleeps
        //}

        //protected override void OnResume()
        //{
        //    // Handle when your app resumes
        //}
    }
}
