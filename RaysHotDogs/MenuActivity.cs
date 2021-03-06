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
    [Activity(MainLauncher = true, Icon = "@drawable/Icon.png")]
    public class MenuActivity : Activity
    {
        private Button orderButton;
        private Button cartButton;
        private Button aboutButton;
        private Button mapButton;
        private Button takePictureButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.MainMenu); //Sets the view to Mainmenu.axml for this activity

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            //Instantiate all buttons on page to access them from code
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
            cartButton = FindViewById<Button>(Resource.Id.cartButton);
            aboutButton = FindViewById<Button>(Resource.Id.aboutButton);
            mapButton = FindViewById<Button>(Resource.Id.mapButton);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        private void HandleEvents()
        {
            //Give the order button a click event
            orderButton.Click += OrderButton_Click;
            aboutButton.Click += AboutButton_Click;
            takePictureButton.Click += TakePictureButton_Click;
            mapButton.Click += MapButton_Click;
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RayMapActivity));
            StartActivity(intent);
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePictureActivity));
            StartActivity(intent);

        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutActivity));
            StartActivity(intent);
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            //(Content packageContents, Type type)
            var intent = new Intent(this, typeof(hotDogMenuActivity));

            StartActivity(intent);
        }
    }
}