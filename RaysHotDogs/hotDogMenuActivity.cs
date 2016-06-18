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
using RaysHotDogs.Core;
using RaysHotDogs.Core.Service;

namespace RaysHotDogs
{
    [Activity(Label = "hotDogMenuActivity", MainLauncher = true)]
    public class hotDogMenuActivity : Activity
    {
        private ListView hotDogListView;
        private List<HotDog> allHotDogs;
        private HotDogDataService hotDogDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogMenuView); //Reference the layout (.axml)

            hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView); //get reference to control

            hotDogDataService = new HotDogDataService();

            allHotDogs = hotDogDataService.GetAllHotDogs(); //returns list of all available hotdogs



        }
    }
}