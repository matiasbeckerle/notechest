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
    public class OrganizationsController : Controller
    {
        private NotechestDBContext db = new NotechestDBContext();

        // GET: /Organizations/

        public ActionResult Index()
        {
            return View(db.Organizations.ToList());
        }

        // GET: /Organizations/Details/5

        public ActionResult Details(int id = 0)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: /Organizations/Create

        public ActionResult Create()
        {
            return View("Edit", new Organization());
        }

        // GET: /Organizations/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: /Organizations/Save

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Organization organization)
        {
            if (ModelState.IsValid)
            {
                if (organization.ID == 0)
                {
                    db.Organizations.Add(organization);
                }
                else
                {
                    db.Entry(organization).State = EntityState.Modified;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organization);
        }

        // GET: /Organizations/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: /Organizations/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
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