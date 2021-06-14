using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Evolent_Pankaj.Models;
using Evolent_Pankaj.Repository;
using System.ComponentModel.Composition;

namespace Evolent_Pankaj.Controllers
{
    public class ContactsController : Controller
    {
        //private EvolentHealthEntities db = new EvolentHealthEntities();
        [Import]
        private IContactsRepository contactsRepository=MEFContainer.Container.GetExportedValue<IContactsRepository>();

       
        // GET: Contacts
        public ActionResult Index()
        {
           return View(contactsRepository.GetAll());
            //return View(db.tblContacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContact tblContact = contactsRepository.Details(id);
            if (tblContact == null)
            {
                return HttpNotFound();
            }
            return View(tblContact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,Status")] tblContact tblContact)
        {
            if (ModelState.IsValid)
            {
                contactsRepository.Create(tblContact);
                return RedirectToAction("Index");
            }

            return View(tblContact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContact tblContact = contactsRepository.Find((int)id);
            if (tblContact == null)
            {
                return HttpNotFound();
            }
            return View(tblContact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,Status")] tblContact tblContact)
        {
            if (ModelState.IsValid)
            {
                contactsRepository.Edit(tblContact);
                return RedirectToAction("Index");
            }
            return View(tblContact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContact tblContact = contactsRepository.Find((int)id);
            if (tblContact == null)
            {
                return HttpNotFound();
            }
            return View(tblContact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            contactsRepository.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
