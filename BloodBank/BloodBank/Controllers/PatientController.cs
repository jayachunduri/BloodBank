using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodBank.Models;

namespace BloodBank.Controllers
{
    public class PatientController : Controller
    {
        StoredProcPracticeEntities db = new StoredProcPracticeEntities();
        //
        // GET: /Patient/

        public ActionResult Index()
        {
            return View(db.Patients);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //return View(db.Donors.Find(id));
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Patient patientDetails)
        {
            //tell the DB context that the contact form need to be updated
            //db.Entry(patientDetails).State = System.Data.EntityState.Added;
            db.Patients.Add(patientDetails);
            //db.Entry(patientDetails.BloodGroup).State = System.Data.EntityState.Added;
            db.SaveChanges();

            //kick the user back to the list
            return RedirectToAction("Index", "Patient");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Patients.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.Patient patient)
        {
            //tell the DB context that the contact form need to be updated
            db.Entry(patient).State = System.Data.EntityState.Modified;

            db.SaveChanges();

            //kick the user back to the list
            return RedirectToAction("Index", "Patient");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Patients.Find(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            //get the form to delete from the data base
            Models.Patient formToDelete = db.Patients.Find(id);

            //set the fo
            db.Patients.Remove(formToDelete);

            db.SaveChanges();

            return RedirectToAction("Index", "Patient");
        }

        [HttpGet]
        public ActionResult Select(int id)
        {
            return View(db.Patients.Find(id));
        }
    }
}
