using Android.App;
using Android.Widget;
using Android.OS;

namespace AdroidApp2
{
	[Activity(Label = "AdroidApp2", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			//// Set our view from the "main" layout resource
			//SetContentView(Resource.Layout.Main);

			//// Get our button from the layout resource,
			//// and attach an event to it
			//Button button = FindViewById<Button>(Resource.Id.myButton);

			//button.Click += delegate { button.Text = $"{count++} clicks!"; };
			//base.OnCreate(bundle);
			Validate();
		}
		private async void Validate()
		{
			SALLab02.ServiceClient ServiceClient = new SALLab02.ServiceClient();
			string StudentEmail = "francisco_renan-dt@hotmail.com";
			string Password = "zxxzpa6413";
			string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
			//string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, AndroidApp.Provider.Settings.Secure.AndroidId);
			SALLab02.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);
			Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
			AlertDialog Alert = Builder.Create();
			Alert.SetTitle("Resulltado de la verificacion");
			//Alert.SetIcon(Resource.Drawable.Icon);
			//Alert.SetIcon(Resource.);
			Alert.SetMessage($"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
			Alert.SetButton("OK", (s, ev) => { });
			Alert.Show();   
		}
	}
}

