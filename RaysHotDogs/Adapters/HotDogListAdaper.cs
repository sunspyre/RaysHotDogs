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
using RaysHotDogs.Utility;
using Android.Graphics;

namespace RaysHotDogs.Adapters
{
    public class HotDogListAdaper : BaseAdapter<HotDog> //BaseAdapter is basically a List<> that can be used with a ListView
    {
        private List<HotDog> _items;
        private Activity _context;

        public HotDogListAdaper(Activity context, List<HotDog> items) : base()
        {
            _context = context;
            _items = items;
        }

        public override int Count
        {
            get
            {
                return _items.Count;
            }
        }

        public override HotDog this[int position]
        {
            get
            {
                return _items[position];
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            var image = BitmapFactory.DecodeFile(item.ImagePath);
            if (convertView == null)
            {
                //Inflate generates objects based on the XML
                //convertView = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null); //SimpleListItem1 is a built-in row style
                //convertView = _context.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null); //A different list style
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.HotDogRowView, null);

            }

            //convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name; //another built-in control style for the text portion of the list item
            //convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageBitmap(image); //list item icon
            convertView.FindViewById<TextView>(Resource.Id.hotDogNameTextView).Text = item.Name;
            convertView.FindViewById<TextView>(Resource.Id.hotDogDescriptionTextView).Text = item.Description;
            convertView.FindViewById<TextView>(Resource.Id.hotDogShortDescriptionTextView).Text = item.ShortDescription;
            convertView.FindViewById<TextView>(Resource.Id.hotDogPriceTextView).Text = $"${item.Price}";
            convertView.FindViewById<ImageView>(Android.Resource.Id.Icon).SetImageBitmap(image);

            return convertView;
        }
    }
}