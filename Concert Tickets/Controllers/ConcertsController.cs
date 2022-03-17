using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Concert_Tickets.Models;

namespace Concert_Tickets.Controllers
{
    public class ConcertsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Concerts
        public ActionResult Index()
        {
            return View(db.Concerts.ToList());
        }

        [Authorize]
        // GET: Concerts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        [Authorize]
        // GET: Concerts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Concerts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Artist,Date,FloorTickets,FloorTicketPrice,PitTickets,PitTicketPrice,countFloor,countPit")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                concert.countPit = concert.PitTickets;
                concert.countFloor = concert.FloorTickets;
                concert.numberOfTicketsFloor = 0;
                concert.numberOfTicketsPit = 0;
                db.Concerts.Add(concert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(concert);
        }

        [Authorize]
        // GET: Concerts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Concert concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        // POST: Concerts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Artist,Date,FloorTickets,FloorTicketPrice,PitTickets,PitTicketPrice,countFloor,countPit")] Concert concert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(concert);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Concert concert = db.Concerts.Find(id);
            db.Concerts.Remove(concert);
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

        [Authorize]
        public ActionResult BuyTicket(int id)
        {
            Concert concert = db.Concerts.Find(id);
            if (concert == null)
            {
                return HttpNotFound();
            }
            return View(concert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuyTicket(Concert concert)
        {
            //if (ModelState.IsValid)
            {
                Concert temp = db.Concerts.Find(concert.ID);
                db.Concerts.Remove(temp);
                concert.countFloor -= concert.numberOfTicketsFloor;
                concert.countPit -= concert.numberOfTicketsPit;
                concert.numberOfTicketsPit = 0;
                concert.numberOfTicketsFloor = 0;
                //db.Entry(concert).State = EntityState.Modified;
                db.Concerts.Add(concert);
                db.SaveChanges();
                //try
                //{
                //    db.savechanges();
                //}
                //catch (dbentityvalidationexception ex)
                //{
                //    foreach (var entityvalidationerrors in ex.entityvalidationerrors)
                //    {
                //        foreach (var validationerror in entityvalidationerrors.validationerrors)
                //        {
                //            response.write("property: " + validationerror.propertyname + " error: " + validationerror.errormessage);
                //        }
                //    }
                //}
                return RedirectToAction("Index");
            }
            return View(concert);
        }
    }
}
