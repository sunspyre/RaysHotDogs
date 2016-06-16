
using Android.App;
using Android.OS;
using RaysHotDogs.Core;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Service;

namespace RaysHotDogs
{
    [Activity(Label = "Hot Dog Detail", MainLauncher = true)]
    public class HotDogDetailActivity : Activity
    {
        //create fields for the controls here
        private HotDog selectedHotDog;
        private HotDogDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}