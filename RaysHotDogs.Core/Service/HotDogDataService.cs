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
            throw new NotImplementedException();
        }
    }
}
