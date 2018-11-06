using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Uppgift4Interaktiva.Models;

namespace Uppgift4Interaktiva.Models.ViewModels
{
    public partial class ChannelLists
    {

        private Uppgift4Entities db = new Uppgift4Entities();
        private Uppgift4UserChannels dbUserChannels = new Uppgift4UserChannels();
        private Uppgift4Channel dbChannel = new Uppgift4Channel();
        private Uppgift4EntitiesLogIn dbLogin = new Uppgift4EntitiesLogIn();
        

        public List<TvProgram> SVT1 { get; set; } = new List<TvProgram>();
        public List<TvProgram> SVT2 { get; set; } = new List<TvProgram>();
        public List<TvProgram> TV3 { get; set; } = new List<TvProgram>();
        public List<TvProgram> TV4 { get; set; } = new List<TvProgram>();
        public List<TvProgram> TV6 { get; set; } = new List<TvProgram>();
        public List<TvProgram> AllShows { get; set; } = new List<TvProgram>();

        public List<TvProgram> ReturnAllShows()
        {
            var templist = from p in db.TvProgram select p;
            AllShows = templist.ToList();
            return templist.ToList();
        }

        public List<TvProgram> GetSpecificChannelAndDay(DateTime dt, string channel)
        {
            List<TvProgram> templist1 = new List<TvProgram>();
            var templist = from p in db.TvProgram.Where(x => x.Channel == channel) select p;
            templist1 = templist.OrderBy(z => z.Start.Hour).ToList();           
            return templist1.Where(y => y.Start.Date == dt.Date).ToList();        
        }


        public List<TvProgram> GetOneChannelThroughUserId(DateTime dt, string chnl, int id)
        {
            var templist1 = new List<TvProgram>();
            var channel = (from ch in db.TvProgram.Where(x => x.Channel == chnl)
                           select ch).ToList();

            var person = (from p in dbUserChannels.UserChannels.Where(x => x.UserId == id) select p);

            var join = (from p in channel
                        join j in person on p.ChannelId equals j.ChannelId
                        select p);

            var sortChnl = join.Where(y => y.Start.Date == dt.Date).ToList();


            return templist1 = sortChnl.ToList();

        }

   

        public void CreateAllLists(DateTime dtinput)
        {
             ReturnAllShows();
             SVT1 = GetSpecificChannelAndDay(dtinput, "SVT1");
             SVT2 = GetSpecificChannelAndDay(dtinput, "SVT2");
             TV3 = GetSpecificChannelAndDay(dtinput, "TV3");
             TV4 = GetSpecificChannelAndDay(dtinput, "TV4");
             TV6 = GetSpecificChannelAndDay(dtinput, "TV6");
         
         
        }

        public void CreatePersonalList(DateTime dtinput, int id)
        {
            SVT1 = GetOneChannelThroughUserId(dtinput, "SVT1", id).ToList();
            SVT2 = GetOneChannelThroughUserId(dtinput, "SVT2", id).ToList();
            TV3 = GetOneChannelThroughUserId(dtinput, "TV3", id).ToList();
            TV4 = GetOneChannelThroughUserId(dtinput, "TV4", id).ToList();
            TV6 = GetOneChannelThroughUserId(dtinput, "TV6", id).ToList();
        }


        public void RemoveChannelFromUser(int userid, int channelid)
        {
            var temp = dbUserChannels.UserChannels.Where(x => x.UserId == userid).ToArray();

            var nytemp = temp.Where(y => y.ChannelId == channelid).ToArray();

            dbUserChannels.UserChannels.RemoveRange(nytemp);
            dbUserChannels.SaveChanges();
         
        }
        public string ReturnDateTimeAsString(DateTime x)
        {
            return x.ToString();
        }



    }
}