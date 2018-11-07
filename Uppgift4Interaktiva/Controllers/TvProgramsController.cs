using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Uppgift4Interaktiva.Models;
using Uppgift4Interaktiva.Models.ViewModels;

namespace Uppgift4Interaktiva.Controllers
{
    public class TvProgramsController : Controller
    {
        private Uppgift4Entities db = new Uppgift4Entities();       

        // GET: TvPrograms
        public ActionResult Index()
        {
          
            return View(db.TvProgram.ToList());
        }


        public ActionResult Startpage(DateTime? selectedDT)
        {
            if (selectedDT == null)
            {
                var dateTime = new DateTime(2018, 11, 11);
                selectedDT = dateTime;               
            }                             
            var allChannelList = new ChannelLists();
            allChannelList.CreateAllLists(selectedDT.Value);
            return View(allChannelList);
        }

        //After Login
        public ActionResult StartpageUser(DateTime? selectedDT)
        {
            if (selectedDT == null)
            {
                var dateTime = new DateTime(2018, 11, 11);
                selectedDT = dateTime;
            }
            if (Session["userName"] == null)
            {
                return RedirectToAction("Startpage", "TvPrograms");
            }

            var idString = Session["userId"].ToString();
            int userID = int.Parse(idString);
            
            var allChannelList = new ChannelLists();
            allChannelList.CreatePersonalList(selectedDT.Value, userID);
            return View(allChannelList);
        }


        public ActionResult HideChannel(int channel)
        {
            var idString = Session["userId"].ToString();
            int userID = int.Parse(idString);

            var allChannelList = new ChannelLists();
            allChannelList.RemoveChannelFromUser(userID, channel);
            return RedirectToAction("StartpageUser");
        }

       
        
        public ActionResult ShowChannel(int one, int two, int three, int four, int six)
        {
            var idString = Session["userId"].ToString();
            int userID = int.Parse(idString);

            var input = new UserChannels();
            var allChannelList = new ChannelLists();
            allChannelList.RemoveChannelFromUser(userID, one);
            allChannelList.RemoveChannelFromUser(userID, two);
            allChannelList.RemoveChannelFromUser(userID, three);
            allChannelList.RemoveChannelFromUser(userID, four);
            allChannelList.RemoveChannelFromUser(userID, six);
            allChannelList.AddChannelToUser(input, userID, one);
            allChannelList.AddChannelToUser(input, userID, two);
            allChannelList.AddChannelToUser(input, userID, three);
            allChannelList.AddChannelToUser(input, userID, four);
            allChannelList.AddChannelToUser(input, userID, six);
            return RedirectToAction("StartpageUser");
        }


        // GET: TvPrograms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvProgram tvProgram = db.TvProgram.Find(id);
            if (tvProgram == null)
            {
                return HttpNotFound();
            }
            return View(tvProgram);
        }
    

        // GET: TvPrograms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TvPrograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Genre,Start,Stop,Channel,Info")] TvProgram tvProgram)
        {
            if (ModelState.IsValid)
            {
                db.TvProgram.Add(tvProgram);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tvProgram);
        }

        // GET: TvPrograms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvProgram tvProgram = db.TvProgram.Find(id);
            if (tvProgram == null)
            {
                return HttpNotFound();
            }
            return View(tvProgram);
        }

        // POST: TvPrograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Genre,Start,Stop,Channel,Info")] TvProgram tvProgram)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tvProgram).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tvProgram);
        }

        // GET: TvPrograms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TvProgram tvProgram = db.TvProgram.Find(id);
            if (tvProgram == null)
            {
                return HttpNotFound();
            }
            return View(tvProgram);
        }

        // POST: TvPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TvProgram tvProgram = db.TvProgram.Find(id);

            db.TvProgram.Remove(tvProgram);
            db.SaveChanges();            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
