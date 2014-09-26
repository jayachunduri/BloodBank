using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class DonorController : Controller
    {
       StoredProcPracticeEntities db = new StoredProcPracticeEntities();
        //
        // GET: /Donor/

        public ActionResult Index()
        {
            
            return View(db.Donors);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //return View(db.Donors.Find(id));
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Donor donorDetails)
        {
            //tell the DB context that the contact form need to be updated
            //db.Entry(donorDetails.Name).State = System.Data.EntityState.Added;
            //db.Entry(donorDetails.BloodGroup).State = System.Data.EntityState.Added;

            db.Donors.Add(donorDetails);
            db.SaveChanges();

            //kick the user back to the list
            return RedirectToAction("Index", "Donor");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Donors.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.Donor donor)
        {
            //tell the DB context that the contact form need to be updated
            db.Entry(donor).State = System.Data.EntityState.Modified;

            db.SaveChanges();

            //kick the user back to the list
            return RedirectToAction("Index", "Donor");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Donors.Find(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            //get the form to delete from the data base
            Models.Donor formToDelete = db.Donors.Find(id);

            //set the fo
            db.Donors.Remove(formToDelete);

            db.SaveChanges();

            return RedirectToAction("Index", "Donor");
        }

        [HttpGet]
        public ActionResult Select (int id)
        {
            return View(db.Donors.Find(id));
        }
    }
}
