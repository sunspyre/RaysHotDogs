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
using RaysHotDogs.Fragments;

namespace RaysHotDogs
{
    [Activity]
    public class hotDogMenuActivity : Activity
    {
        private ListView hotDogListView;
        private List<HotDog> allHotDogs;
        private HotDogDataService hotDogDataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.HotDogMenuView); //Reference the layout (.axml)
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs; //set this activity to a tab layout

            //hotDogListView = FindViewById<ListView>(Resource.Id.hotDogListView); //get reference to control
            //hotDogDataService = new HotDogDataService();
            //allHotDogs = hotDogDataService.GetAllHotDogs(); //returns list of all available hotdogs
            //hotDogListView.Adapter = new HotDogListAdapter(this, allHotDogs);
            //hotDogListView.FastScrollEnabled = true;
            //hotDogListView.ItemClick += HotDogListView_ItemClick;
            AddTab("Favorites", Resource.Drawable.icon1, new FavoriteHotDogFragment());
            AddTab("Meat Lovers", Resource.Drawable.icon2, new MeatLoversHotDogFragment());
            AddTab("Veggie Lovers", Resource.Drawable.icon3, new VeggieHotDogFragment());

            
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok && requestCode == 100)
            {
                var selectedHotDog = hotDogDataService.GetHotDogById(data.GetIntExtra("selectedHotDogId", 0));

                var dialog = new AlertDialog.Builder(this);
                dialog.SetTitle("Confirmation");
                dialog.SetMessage($"You've added {data.GetIntExtra("amount", 0)} {selectedHotDog.Name} to the cart!");
                dialog.Show();
            }
        }

        private void HotDogListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var selectedItem = allHotDogs[e.Position]; //get selected item
            var intent = new Intent();
            intent.SetClass(this, typeof(HotDogDetailActivity));
            intent.PutExtra("selectedHotDogId", selectedItem.HotDogId); //Stores this in the 'Extra" property

            StartActivityForResult(intent, 100); //the number represents the request, which can be used in the called activity
            
        }

        private void AddTab(string tabText, int iconResourceId, Fragment view)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
            tab.SetIcon(iconResourceId);

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, view);
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            this.ActionBar.AddTab(tab);
        }
    }
}