using System;
using Android.App;
using Android.Runtime;
using Parse;

namespace Spirit
{
	[Application]
	public class App : Application
	{
		public App (IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			// Initialize the Parse client with your Application ID and .NET Key found on
			// your Parse dashboard
			ParseClient.Initialize ("pgQJKECsElkLo4Um98iX2Lc8WFQo1hnyNudJoRuZ", "Kem8Cl0tPrOsC5AgRH9wJv1BpvgYoMK3PFkgkWzp");
			//ParseFacebookUtils.Initialize ("951550421541332");
		}
	}
}

