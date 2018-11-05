using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Uppgift4Interaktiva.Models;

namespace Uppgift4Interaktiva.Models.ViewModels
{
    public partial class ChannelLists
    {

        private Uppgift4Entities db = new Uppgift4Entities();
        

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

            /*  var templist1 = new List<TvProgram>();

              var templist = from program in db.TvProgram.Where(x => x.Channel == channel)
                          join user in dblogin.Users.Where(z => z.UserId == username.Value)
                               on program.Id equals user.UserId
                          select new
                          {                           

                          }; */

           

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

        public string ReturnDateTimeAsString(DateTime x)
        {
            return x.ToString();
        }



    }
}