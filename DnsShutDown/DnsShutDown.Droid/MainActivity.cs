using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DnsShutDown.Droid
{
	[Activity (Label = "DnsShutDown.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        ShutDowner shutdowner;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            shutdowner = new ShutDowner();
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += async delegate {
                try
                {
                    button.Enabled = false;
                    

                    await shutdowner.shutAsync();
                    button.Enabled = true;
                }
                catch (Exception)
                {
                    Toast.MakeText(this, "Error", ToastLength.Long).Show();
                    button.Enabled = true;
                }
                
            };
		}
	}
}


