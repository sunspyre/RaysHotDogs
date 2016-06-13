using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core
{
    public class HotDog
    {
        public int HotDogId { get; set; }
        public int Price { get; set; }
        public int PrepTime { get; set; }
        public string ImagePath { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public bool Favorite { get; set; }
        public List<string> Ingredients { get; set; }

    }
}
