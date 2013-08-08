using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notechest.Models;

namespace Notechest.Controllers
{
    public class NotesController : Controller
    {
        private NotechestDBContext db = new NotechestDBContext();

        //
        // GET: /Notes/

        public ActionResult Index()
        {
            var notes = db.Notes.Include(n => n.Organization).Include(n => n.Project);
            return View(notes.ToList());
        }

        //
        // GET: /Notes/Details/5

        public ActionResult Details(int id = 0)
        {
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        //
        // GET: /Notes/Create

        public ActionResult Create()
        {
            ViewBag.OrganizationID = new SelectList(db.Organizations, "ID", "Name");
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name");
            return View();
        }

        //
        // POST: /Notes/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationID = new SelectList(db.Organizations, "ID", "Name", note.OrganizationID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", note.ProjectID);
            return View(note);
        }

        //
        // GET: /Notes/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrganizationID = new SelectList(db.Organizations, "ID", "Name", note.OrganizationID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", note.ProjectID);
            return View(note);
        }

        //
        // POST: /Notes/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrganizationID = new SelectList(db.Organizations, "ID", "Name", note.OrganizationID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", note.ProjectID);
            return View(note);
        }

        //
        // GET: /Notes/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        //
        // POST: /Notes/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}