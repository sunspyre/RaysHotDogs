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

namespace RaysHotDogs.Adapters
{
    public class HotDogListAdaper : BaseAdapter<HotDog>
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
                throw new NotImplementedException();
            }
        }

        public override HotDog this[int position]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }
    }
}