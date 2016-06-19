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
using RaysHotDogs.Adapters;

namespace RaysHotDogs
{
    [Activity(Label = "HotDogMenuActivity")]
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

            hotDogListView.Adapter = new HotDogListAdaper(this, allHotDogs);

            hotDogListView.FastScrollEnabled = true;

            hotDogListView.ItemClick += HotDogListView_ItemClick;
        }

        private void HotDogListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var selectedItem = allHotDogs[e.Position]; //get selected item
            var intent = new Intent();
            intent.SetClass(this, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", selectedItem.HotDogId); //Stores this in the 'Extra" property

            StartActivityForResult(intent, 100); //the number represents the request, which can be used in the called activity
        }
    }
}