using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Parse;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Data;

namespace Spirit
{
	[Activity (Theme="@style/Theme.Splash",Label = "LoginActivity",MainLauncher=true)]			
	public class LoginActivity : Activity
	{
		public EditText EmailIDText;
		public EditText PasswordText;
		public Task OnSignUp;
		public Task OnSignUpTask;
		public Task OnSignInTask;
		public Button SignUpButton;
		public Button SignInButton;
		public Button AddDataButton;
		public Button GetDataButton;
		public Button OpenGalleryButton;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			EmailIDText = (EditText)FindViewById (Resource.Id.editTextEmailId);
			PasswordText = (EditText)FindViewById (Resource.Id.editTextPasswordBox);
			SignUpButton = (Button) FindViewById (Resource.Id.SignUpButton);
			SignInButton = (Button)FindViewById (Resource.Id.SignInButton);
			AddDataButton = (Button)FindViewById (Resource.Id.AddDataButton);
			GetDataButton = (Button)FindViewById (Resource.Id.GetDataButton);
			OpenGalleryButton = (Button)FindViewById (Resource.Id.OpenGalleryButton);
			AddDataButton.Enabled = true;
			SignUpButton.Click += OnButtonClick;
			SignInButton.Click+= OnSignInClick;
			AddDataButton.Click+= OnAddDataClick;
			GetDataButton.Click+= OnGetDataClick;
			OpenGalleryButton.Click+= OnOpenGalleryClick;



			// Create your application here
		}

		void OnOpenGalleryClick (object sender, EventArgs e)
		{
			Intent = new Intent();
			Intent.SetType("image/*");
			Intent.SetAction(Intent.ActionGetContent);
			StartActivityForResult(Intent.CreateChooser(Intent, "Select Picture"), 1000);
		}
		public string GetRealPathfromUri(Context _context, Android.Net.Uri contentUri)
		{
			string[] projection = new string[] {Android.Provider.MediaStore.MediaColumns.Data };
			ContentResolver cr = _context.ContentResolver;
			Android.Database.ICursor cursor = cr.Query(contentUri, projection,null, null, null);
			if (cursor != null && cursor.Count > 0)
			{
				cursor.MoveToFirst();
				int index =cursor.GetColumnIndex(Android.Provider.MediaStore.MediaColumns.Data);
				return cursor.GetString(index);
			}
			return "";
		}
		async	protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{ 
			//byte[] image =  data.ToArray<Byte> ();

			if ((requestCode == 1000) && (resultCode == Result.Ok) && (data != null))
			{
				Android.Net.Uri uri = data.Data;

			//	_imageView.SetImageURI(uri);
				ImageView Imgview = (ImageView)FindViewById (Resource.Id.imageFromCloudview);
				string realpath = GetRealPathfromUri (this, uri);
				Bitmap bmp = BitmapFactory.DecodeFile (realpath);
				//Java.Nio.ByteBuffer byteBuffer =Java.Nio.ByteBuffer.Allocate(bmp.ByteCount);
				//bmp.CopyPixelsToBuffer(byteBuffer);
				//byte[] bytes = byteBuffer.ToArray<byte>();
				//int size     = bmp.RowBytes * bmp.Height;
				//ByteArrayInputStream istream = new ByteArrayInputStream ();
				//Convert.ToByte (bmp);
				//byte[] byteArray = bmp.ToArray<byte> ();
				//bmp.Compress (Bitmap.CompressFormat.Png, 100, ostream);
				//Bitmap anotherBmp = BitmapFactory.DecodeByteArray (byteArray, 0, byteArray.Length);
				//MemoryStream s = new MemoryStream();
				//bmp.Compress (Bitmap.CompressFormat.Png, 100, s);
				//byte[] byteArray= s.GetBuffer ();
				//Java.Nio.ByteBuffer Bffr = Java.Nio.ByteBuffer.Allocate();
				//bmp.CopyPixelsToBuffer (Bffr);
				//byte[] byteArray = new byte[size];
				//Bffr.Get (byteArray, 0, byteArray.Length);
				//Imgview.SetImageBitmap (bmp);
				//Imgview.SetImageURI (uri);
				EmailIDText.Text = realpath;
				using (MemoryStream stream = new MemoryStream ()) {
				
					bmp.Compress (Bitmap.CompressFormat.Png, 100, stream);
					byte[] byteArray = stream.ToArray ();
					Bitmap anotherBmp = BitmapFactory.DecodeByteArray (byteArray, 0, byteArray.Length);

					Imgview.SetImageBitmap (anotherBmp);
					ParseFile pic = new ParseFile ("profile.png", byteArray);
					await pic.SaveAsync();
					ParseUser user = ParseUser.CurrentUser;
					user ["ProfilePic"] = pic;
					await user.SaveAsync ();
				}
				//Imgview.SetImageBitmap (bmp);
			//	string path = GetPathToImage(uri);
				//Toast.MakeText(this, uri.Path, ToastLength.Long);
			}
		}
		async void OnGetDataClick (object sender, EventArgs e)
		{  
			ProgressBar PB = (ProgressBar)FindViewById (Resource.Id.progressBar);
			PB.Visibility = ViewStates.Visible;
			PB.Indeterminate = true;
			ParseUser user = ParseUser.CurrentUser;
			//var fileUrl = user.Get<ParseFile> ("About");
			var imageUrl = user.Get<ParseFile> ("Image");
			EmailIDText.Text="Getting data";
			//string resume = await new HttpClient ().GetStringAsync (fileUrl.Url);
			byte[] data = await new HttpClient ().GetByteArrayAsync (imageUrl.Url);
			ImageView Imgview = (ImageView)FindViewById (Resource.Id.imageFromCloudview);
			Bitmap bitmap = BitmapFactory.DecodeByteArray (data, 0, data.Length);
			EmailIDText.Text="Got data";
			Imgview.SetImageBitmap (bitmap);
			//TextView s =(TextView) FindViewById(Resource.Id.dataViewtext);
			//s.Text = resume;
			PB.Indeterminate = false;
			PB.Visibility = ViewStates.Invisible;
		}

		async void OnAddDataClick (object sender, EventArgs e)
		{
			ParseUser user = ParseUser.CurrentUser;
			//user.Add ("new data", "ssssss");
			user ["sss"] = "updated text";
			//byte[] data = System.Text.Encoding.UTF8.GetBytes("Working at Parse is great!");
			//ParseFile file = new ParseFile("resume.txt", data);
			//await file.SaveAsync();


			//await user.SaveAsync ();
			//EmailIDText.Text="file success";
			//user ["About"] = file;
			await user.SaveAsync ();
			EmailIDText.Text ="Data Success";
		}

		async void OnSignInClick (object sender, EventArgs e)
		{ 
			//try
			//{
			AddDataButton.Enabled = true;
				await ParseUser.LogInAsync(EmailIDText.Text,PasswordText.Text);
				EmailIDText.Text="Login Success";
			//ParseUser x =ParseUser.CurrentUser;
			//x["abc"]="sssss";
			//x["hjk"]="ddddddddd";
			//await x.SaveAsync ();
			//EmailIDText.Text = "success";
				// Login was successful.
		//	}
		//	catch (Exception e)
		//	{
				// The login failed. Check the error to see why.
		//	}
		
		}

	   void OnButtonClick (object sender, EventArgs e)
		{   
			OnSignUpTask = new Task (SignUp);
			OnSignUpTask.Start ();
		}

		async void SignUp()
		{
			ProgressBar PB = (ProgressBar)FindViewById (Resource.Id.progressBar);
			RunOnUiThread(()=>{
				PB.Visibility = ViewStates.Visible;
				PB.Indeterminate = true;

			});
			var user = new ParseUser()
			{
				Username = EmailIDText.Text,
				Password = PasswordText.Text
					//Email = EmailIDText.Text
			};

			// other fields can be set just like with ParseObject
			//user["phone"] = "415-392-0202";

			await user.SignUpAsync();
			RunOnUiThread (() => {
			
				PB.Indeterminate = true;
				EmailIDText.Text="Done";
			});

		}
	}
}

