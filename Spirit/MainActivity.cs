using System;
using Parse;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Facebook;
[assembly:Permission (Name = Android.Manifest.Permission.Internet)]
[assembly:Permission (Name = Android.Manifest.Permission.WriteExternalStorage)]
[assembly:MetaData ("com.facebook.sdk.ApplicationId", Value ="@string/app_id")]
namespace Spirit
{

	//[Activity (Label = "Spirit", Icon = "@drawable/icon",MainLauncher = true)]
	public class MainActivity : Activity,Session.IStatusCallback, Request.IGraphUserCallback
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
	
			// Open a FB Session and show login if necessary
			Session.OpenActiveSession (this, true, this);
		}

		protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult (requestCode, resultCode, data);

			// Relay the result to our FB Session
			Session.ActiveSession.OnActivityResult (this, requestCode, (int)resultCode, data);
		}

		public void Call (Session session, SessionState state, Java.Lang.Exception exception)
		{
			// Make a request for 'Me' information about the current user
			if (session.IsOpened)
				Request.ExecuteMeRequestAsync (session, this);
		}

		public void OnCompleted (Xamarin.Facebook.Model.IGraphUser user, Response response)
		{
			// 'Me' request callback
			if (user != null)
				Console.WriteLine ("GOT USER: " + user.Name);
			else
				Console.WriteLine ("Failed to get 'me'!");

		}
	}
}


