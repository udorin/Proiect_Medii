using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AgendaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Agenda
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Agenda.ToList());
            }
            else
            {
                return View("NoLogin");
            }
            
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Agenda agenda = db.Agenda.Find(id);
                if (agenda == null)
                {
                    return HttpNotFound();
                }
                return View(agenda);
            }
            else
            {
                return View("NoLogin");
            }
            {

            }
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return View("NoLogin");
            }
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,note,EndUntil")] Agenda agenda)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Agenda.Add(agenda);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(agenda);
            }
            else
            {
                return View("NoLogin");
            }
            {

            }
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Agenda agenda = db.Agenda.Find(id);
                if (agenda == null)
                {
                    return HttpNotFound();
                }
                return View(agenda);
            }
            else
            {
                return View("NoLogin");
            }
            {

            }
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,note,EndUntil")] Agenda agenda)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(agenda).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(agenda);
            }
            else
            {
                return View("NoLogin");
            }
            {

            }
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Agenda agenda = db.Agenda.Find(id);
                if (agenda == null)
                {
                    return HttpNotFound();
                }
                return View(agenda);
            }
            else
            {
                return View("NoLogin");
            }
            {

            }
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Agenda agenda = db.Agenda.Find(id);
                db.Agenda.Remove(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NoLogin");
            }
            {

            }
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
