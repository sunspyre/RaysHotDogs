using RaysHotDogs.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>()
        {
            new HotDogGroup()
            {
                HotDogGroupId = 1, Title = "Meat Lovers", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog
                    {
                        Available = true,
                        Description = "Meat lovers"
                    }
                }

            }
        };

        public List<HotDog> GetAllHotDogs()
        {
            return null;
        }

    }


}
