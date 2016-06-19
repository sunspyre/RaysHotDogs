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

        public List<HotDog> GetGroupedHotDogs(int groupId)
        {
            return hotDogRepository.GetHotDogGroup(groupId);
        }

        public HotDog GetHotDogById(int v)
        {
            return hotDogRepository.GetHotDogById(v);
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            return hotDogRepository.GetFavoriteHotDogs();
        }

        public List<HotDog> GetAllHotDogs()
        {
            return hotDogRepository.GetAllHotDogs();
        }
    }
}
