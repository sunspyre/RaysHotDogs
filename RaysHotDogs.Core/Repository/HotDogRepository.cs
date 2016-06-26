using Newtonsoft.Json;
using RaysHotDogs.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RaysHotDogs.Core.Repository
{
    public class HotDogRepository
    {
        #region Hardcoded data

        //{

        //    new HotDogGroup()
        //    {
        //        HotDogGroupId = 1, Title = "Regular Dog", ImagePath = "", HotDogs = new List<HotDog>()
        //        {
        //            new HotDog
        //            {
        //                HotDogId = 2,
        //                Available = true,
        //                ShortDescription = "A regular hot dog",
        //                Description = "Regular",
        //                Name = "Regular Dog",
        //                ImagePath = "2.png",
        //                Price = 3,
        //                Favorite = true
        //            }
        //        }
        //    },
        //    new HotDogGroup()
        //    {
        //        HotDogGroupId = 3, Title = "Relish Dog", ImagePath = "", HotDogs = new List<HotDog>()
        //        {
        //            new HotDog
        //            {
        //                HotDogId = 3,
        //                Available = true,
        //                ShortDescription = "Hot dog with extra relish",
        //                Description = "Relish Dog",
        //                Name = "Relish Dog",
        //                ImagePath = "3.png",
        //                Price = 4,
        //                Favorite = true
        //            },
        //            new HotDog
        //            {
        //                HotDogId = 4,
        //                Available = true,
        //                ShortDescription = "Veggie hot dog",
        //                Description = "Veggie Dog",
        //                Name = "Veggie Dog",
        //                ImagePath = "3.png",
        //                Price = 4,
        //                Favorite = true
        //            }
        //        }
        //    },
        //    new HotDogGroup()
        //    {
        //        HotDogGroupId = 2, Title = "Meat Lovers", ImagePath = "", HotDogs = new List<HotDog>()
        //        {
        //            new HotDog
        //            {
        //                HotDogId = 1,
        //                Available = true,
        //                ShortDescription = "Loaded with extra meat",
        //                Description = "Meat lovers",
        //                Name = "Meat Lovers",
        //                ImagePath = "1.png",
        //                Price = 6,
        //                Favorite = false
        //            }
        //        }
        //    }
        //};
        #endregion
        private static List<HotDogGroup> hotDogGroups = new List<HotDogGroup>();
        string url = "http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";

        public HotDogRepository()
        {
            Task.Run(() => this.LoadDataAsync(url)).Wait();
        }

        private async Task LoadDataAsync(string uri)
        {
            if (hotDogGroups != null)
            {
                string responseString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);
                        HttpResponseMessage response = await getResponse;
                        responseString = await response.Content.ReadAsStringAsync();
                        hotDogGroups = JsonConvert.DeserializeObject<List<HotDogGroup>>(responseString);

                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        internal HotDog GetHotDogById(int v)
        {
            foreach (HotDogGroup group in hotDogGroups)
            {
                foreach (HotDog hotdog in group.HotDogs)
                {
                    if (hotdog.HotDogId == v)
                    {
                        return hotdog;
                    }
                        
                }
            }
            return null;
        }

        internal List<HotDog> GetFavoriteHotDogs()
        {
            List<HotDog> list = new List<HotDog>();
            foreach (HotDogGroup group in hotDogGroups)
            {
                foreach (HotDog hotdog in group.HotDogs)
                {
                    if (hotdog.Favorite)
                        list.Add(hotdog);
                }
            }
            return list;
        }

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

        public List<HotDog> GetHotDogGroup(int groupId)
        {
            List<HotDog> list = new List<HotDog>();
            foreach (HotDogGroup group in hotDogGroups)
            {
                if (group.HotDogGroupId == groupId)
                {
                    foreach (HotDog hotdog in group.HotDogs)
                    {
                        list.Add(hotdog);
                    }
                }
            }
            return list;
        }
    }


}
