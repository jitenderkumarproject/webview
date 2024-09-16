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
        private bool isBackPressedOnce = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            webView = FindViewById<WebView>(Resource.Id.webview);

            // Enable JavaScript and other settings
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.DomStorageEnabled = true;
            webView.Settings.LoadWithOverviewMode = true;
            webView.Settings.UseWideViewPort = true;

            // Set WebViewClient to handle navigation
            webView.SetWebViewClient(new WebViewClient());

            // Set WebChromeClient for additional features
            webView.SetWebChromeClient(new WebChromeClient());

            // Load Google.com
            webView.LoadUrl("https://www.google.com");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            if (webView.CanGoBack())
            {
                webView.GoBack();
            }
            else
            {
                ShowExitDialog();
            }
        }

        private void ShowExitDialog()
        {
            // Create and show the exit confirmation dialog
            var builder = new AndroidX.AppCompat.App.AlertDialog.Builder(this);
            builder.SetTitle("Exit");
            builder.SetMessage("Are you sure you want to exit?");
            builder.SetPositiveButton("Yes", (sender, args) =>
            {
                Finish(); // Close the activity
            });
            builder.SetNegativeButton("No", (sender, args) =>
            {
                // Do nothing, just dismiss the dialog
            });

            var dialog = builder.Create();
            dialog.Show();
        }

    }
}