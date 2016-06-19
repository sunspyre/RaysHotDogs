
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using RaysHotDogs.Core;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;
using RaysHotDogs.Utility;

namespace RaysHotDogs
{
    //[Activity(Label = "Hot Dog Detail", MainLauncher = true)]
    [Activity(Label = "Hot Dog Detail")]
    public class HotDogDetailActivity : Activity
    {
        //create fields for the controls here to be available to entire class
        private ImageView hotDogImageView;
        private TextView hotDogNameTextView;
        private TextView priceTextView;
        private TextView shortDescriptionTextView;
        private TextView descriptionTextView;
        private EditText amountEditText;
        private Button cancelButton;
        private Button orderButton;

        private HotDog selectedHotDog;
        private HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HotDogDetailView);

            HotDogDataService dataService = new HotDogDataService();

            var selectedHotDogId = Intent.Extras.GetInt("selectedHotDogId"); //Get Int from the calling activity (HotDogId)

            selectedHotDog = dataService.GetHotDogById(selectedHotDogId); //get HotDog object by Id

            FindViews();
            BindData();
            HandleEvents();
        }

        private void FindViews()
        {
            //attach controls to their local variable:
            hotDogImageView = FindViewById<ImageView>(Resource.Id.hotDogImageView);
            hotDogNameTextView = FindViewById<TextView>(Resource.Id.hotDogNameTextView);
            priceTextView = FindViewById<TextView>(Resource.Id.priceTextView);
            shortDescriptionTextView = FindViewById<TextView>(Resource.Id.shortDescriptionTextView);
            descriptionTextView = FindViewById<TextView>(Resource.Id.descriptionTextView);
            amountEditText = FindViewById<EditText>(Resource.Id.amountEditText);
            cancelButton = FindViewById<Button>(Resource.Id.cancelButton);
            orderButton = FindViewById<Button>(Resource.Id.orderButton);
        }

        private void BindData()
        {

            hotDogNameTextView.Text = selectedHotDog.Name;
            shortDescriptionTextView.Text = selectedHotDog.ShortDescription;
            descriptionTextView.Text = selectedHotDog.Description;
            priceTextView.Text = $"Price: {selectedHotDog.Price}";

            //hotDogImageView.SetImageBitmap(ImageHelper.GetImageBitmapFromUrl(selectedHotDog.ImagePath));
        }

        private void HandleEvents()
        {
            orderButton.Click += OrderButton_Click;
            cancelButton.Click += CancelButton_Click;
        }

        private void CancelButton_Click(object sender, System.EventArgs e)
        {
            //TODO
        }

        private void OrderButton_Click(object sender, System.EventArgs e)
        {
            var amount = int.Parse(amountEditText.Text);
            //var dialog = new AlertDialog.Builder(this);
            //dialog.SetTitle("Confirmation");
            //dialog.SetMessage("Added to cart!");
            //dialog.Show();
            var intent = new Intent();
            intent.PutExtra("selectedHotDogId", selectedHotDog.HotDogId);
            intent.PutExtra("amount", amount);
            SetResult(Result.Ok, intent); //Calls result method from class that called this method

            this.Finish(); //closes out the method and remove from the stack

        }
    }
}