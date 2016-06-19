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
                        ShortDescription = "Loaded with extra meat",
                        Description = "Meat lovers",
                        Name = "Meat Lovers",
                        ImagePath = "1.png",
                        Price = 6
                    }
                }               
            },
            new HotDogGroup()
            {
                HotDogGroupId = 2, Title = "Regular Dog", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog
                    {
                        Available = true,
                        ShortDescription = "A regular hot dog",
                        Description = "Regular",
                        Name = "Regular Dog",
                        ImagePath = "2.png",
                        Price = 3
                    }
                }
            },
            new HotDogGroup()
            {
                HotDogGroupId = 3, Title = "Relish Dog", ImagePath = "", HotDogs = new List<HotDog>()
                {
                    new HotDog
                    {
                        Available = true,
                        ShortDescription = "Hot dog with extra relish",
                        Description = "Relish Dog",
                        Name = "Relish Dog",
                        ImagePath = "3.png",
                        Price = 4
                    }
                }
            }
        };

        public List<HotDog> GetAllHotDogs()
        {
            List<HotDog> list = new List<HotDog>();
            foreach (HotDogGroup group in hotDogGroups)
            {
                foreach (HotDog hotdog in group.HotDogs)
                {
                    list.Add(hotdog);
                }
            }
            return list;
        }

    }


}
