using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Phonesword;

namespace Phonesword
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);
      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.activity_main);
      EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
      TextView translatedPhoneWord = FindViewById<TextView>(Resource.Id.TranslatedPhoneword);
      TextView prevOne= FindViewById<TextView>(Resource.Id.prevOne);
      TextView prevTwo = FindViewById<TextView>(Resource.Id.prevTwo);
      TextView prevThree = FindViewById<TextView>(Resource.Id.prevThree);
      Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
      Button callButton = FindViewById<Button>(Resource.Id.CallButton);

      translateButton.Click += (sender, e) =>
      {
        // Translate user's alphanumeric phone number to numeric
        string prevTres = prevTwo.Text;
        string prevDos=prevOne.Text;
        string translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
        string prevUno = phoneNumberText.Text + ": " + translatedNumber;

        if (string.IsNullOrWhiteSpace(translatedNumber))
        {
          translatedPhoneWord.Text = string.Empty;
          prevOne.Text = string.Empty;
          prevTwo.Text = prevDos;
          prevThree.Text = prevTres;
        }
        else
        {
          translatedPhoneWord.Text = translatedNumber;
          prevOne.Text = prevUno;
          prevTwo.Text = prevDos;
          prevThree.Text = prevTres;
        }
      };

      callButton.Click += (sender, e) =>
      {
        Core.PhoneDialerTest.PlacePhoneCall(translatedPhoneWord.Text);
      };

    }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
