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
        public List<TvProgram> ShowSVT1 ()
        {
            var templist = from p in db.TvProgram where p.Channel == "SVT1" select p;
            SVT1 = templist.OrderBy(p => p.Start.Hour).ToList();           
            return SVT1.ToList();
        }
        public List<TvProgram> ShowSVT2()
        {
            var templist = from p in db.TvProgram where p.Channel == "SVT2" select p;
            SVT2 = templist.OrderBy(p => p.Start.Hour).ToList();
            return SVT2.ToList();
        }
        public List<TvProgram> ShowTV3()
        {
            var templist = from p in db.TvProgram where p.Channel == "TV3" select p;
            TV3 = templist.OrderBy(p => p.Start.Hour).ToList();
            return TV3.ToList();
        }
        public List<TvProgram> ShowTV4()
        {
            var templist = from p in db.TvProgram where p.Channel == "TV4" select p;
            TV4 = templist.OrderBy(p => p.Start.Hour).ToList();
            return TV4.ToList();
        }
        public List<TvProgram> ShowTV6()
        {
            var templist = from p in db.TvProgram where p.Channel == "TV6" select p;
            TV6 = templist.OrderBy(p => p.Start.Hour).ToList();
            return TV6.ToList();
        }

        public void CreateAllLists()
        {
            ReturnAllShows();
            ShowSVT1();
            ShowSVT2();
            ShowTV3();
            ShowTV4();
            ShowTV6();
        }

     



    }
}