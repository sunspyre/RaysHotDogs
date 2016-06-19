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
using Android.Graphics;
using System.Net;
using System.IO;

namespace RaysHotDogs.Utility
{
    public static class ImageHelper
    {
        public static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;
            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);

                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }
            }
            catch (Exception)
            {

            }

            return imageBitmap;
        }

        public static Bitmap GetImageBitmapFromLocal(string path)
        {
            return BitmapFactory.DecodeFile(path); 
        }
    }
}