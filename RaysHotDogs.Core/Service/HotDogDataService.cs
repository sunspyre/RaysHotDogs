using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Service
{
    public class HotDogDataService
    {
        private static HotDogRepository hotDogRepository = new HotDogRepository();

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return null;
        }

        public HotDog GetHotDogById(int v)
        {
            return new HotDog
            {
                Name = "Big dog",
                Description = "Big one",
                ShortDescription = "Big",
                Available = true,
                HotDogId = 1,
                ImagePath = "http://images.wisegeek.com/hot-dog-with-mustard.jpg",
                Price = 2332

            };
        }
    }
}
