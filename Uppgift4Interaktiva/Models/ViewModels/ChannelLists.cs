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
        public List<TvProgram> ShowSVT1 (DateTime dt)           
        {
            List<TvProgram> templist1 = new List<TvProgram>();         
            var templist = from p in db.TvProgram.Where(x => x.Channel == "SVT1") select p;
            templist1 = templist.ToList();
            SVT1 = templist1.Where(y => y.Start.Date == dt.Date).ToList();
            return SVT1;
        }
        public List<TvProgram> ShowSVT2(DateTime dt)
        {
            List<TvProgram> templist1 = new List<TvProgram>();
            var templist = from p in db.TvProgram.Where(x => x.Channel == "SVT2") select p;
            templist1 = templist.ToList();
            SVT2 = templist1.Where(y => y.Start.Date == dt.Date).ToList();
            return SVT2;
        }
        public List<TvProgram> ShowTV3(DateTime dt)
        {
            List<TvProgram> templist1 = new List<TvProgram>();
            var templist = from p in db.TvProgram.Where(x => x.Channel == "TV3") select p;
            templist1 = templist.ToList();
            TV3 = templist1.Where(y => y.Start.Date == dt.Date).ToList();
            return TV3;
        }
        public List<TvProgram> ShowTV4(DateTime dt)
        {
            List<TvProgram> templist1 = new List<TvProgram>();
            var templist = from p in db.TvProgram.Where(x => x.Channel == "TV4") select p;
            templist1 = templist.ToList();
            TV4 = templist1.Where(y => y.Start.Date == dt.Date).ToList();
            return TV4;
        }
        public List<TvProgram> ShowTV6(DateTime dt)
        {
            List<TvProgram> templist1 = new List<TvProgram>();
            var templist = from p in db.TvProgram.Where(x => x.Channel == "TV6") select p;
            templist1 = templist.ToList();
            TV6 = templist1.Where(y => y.Start.Date == dt.Date).ToList();
            return TV6;
        }

        public void CreateAllLists(DateTime dtinput)
        {
            ReturnAllShows();
            ShowSVT1(dtinput);
            ShowSVT2(dtinput);
            ShowTV3(dtinput);
            ShowTV4(dtinput);
            ShowTV6(dtinput);
        }

     



    }
}