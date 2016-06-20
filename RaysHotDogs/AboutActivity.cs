using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RaysHotDogs
{
    [Activity(Label = "AboutActivity")]
    public class AboutActivity : Activity
    {
        private Button callButton;
        private EditText phoneNumber;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.AboutView);

            FindViews();
            HandleEvents();
        }

        private void HandleEvents()
        {
            callButton.Click += CallButton_Click;
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse($"tel:+{phoneNumber.Text}"));
            StartActivity(intent);
        }

        private void FindViews()
        {
            callButton = FindViewById<Button>(Resource.Id.callButton);
            phoneNumber = FindViewById<EditText>(Resource.Id.phoneNumber);
        }
    }
}