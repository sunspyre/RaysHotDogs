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
using Java.IO;
using Android.Provider;
using Android.Graphics;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    [Activity]
    public class TakePictureActivity : Activity
    {
        private ImageView rayPictureImageView;
        private Button takePictureButton;
        private Bitmap imageBitmap;
        private File imageDirectory;
        private File imageFile;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.TakePictureView);

            FindViews();
            HandleEvents();

            imageDirectory = new File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "RaysHotDogs");

            if (!imageDirectory.Exists())
            {
                if (!imageDirectory.Mkdirs())
                {
                    
                }
            }
                

        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
        }

        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new File(imageDirectory, $"PhotoWithRay_{Guid.NewGuid()}");
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
            StartActivityForResult(intent, 0);
        }

        private void FindViews()
        {
            rayPictureImageView = FindViewById<ImageView>(Resource.Id.rayPictureImageView);
            takePictureButton = FindViewById<Button>(Resource.Id.takePictureButton);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            //base.OnActivityResult(requestCode, resultCode, data);

            int height = rayPictureImageView.Height;
            int width = rayPictureImageView.Width;
            imageBitmap = ImageHelper.GetImageBitmapFromFilePath(imageFile.Path, width, height);

            if (imageBitmap != null)
            {
                rayPictureImageView.SetImageBitmap(imageBitmap);
                imageBitmap = null;

            }

            GC.Collect(); //required to avoid memory leaks
        }
    }
}