using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Webkit;
using AndroidX.AppCompat.App;

namespace WebViewAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        WebView webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            webView = FindViewById<WebView>(Resource.Id.webview);

            // Enable JavaScript (optional, depending on what you need)
            webView.Settings.JavaScriptEnabled = true;

            // Load Google.com
            webView.LoadUrl("https://www.google.com");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}