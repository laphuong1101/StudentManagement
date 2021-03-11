using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class ClazzsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clazzs
        public ActionResult Index()
        {
            return View(db.Clazzs.ToList());
        }

        // GET: Clazzs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clazz clazz = db.Clazzs.Find(id);
            if (clazz == null)
            {
                return HttpNotFound();
            }
            var ListstudentID = clazz.ListStudentId.Split(',').ToList();
            var ListStudent = new List<ApplicationUser>();
            foreach(var userId in ListstudentID)
            {
                var student = db.Users.Find(userId);
                if (student != null)
                {
                    ListStudent.Add(student);
                }
            }
            ViewData["ListStudent"] = ListStudent;
            return View(clazz);
        }

        // GET: Clazzs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clazzs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClazzId,ClazzName,ClazzCode,ListStudentId,Description,Status")] Clazz clazz)
        {
            if (ModelState.IsValid)
            {
                db.Clazzs.Add(clazz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clazz);
        }

        // GET: Clazzs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clazz clazz = db.Clazzs.Find(id);
            if (clazz == null)
            {
                return HttpNotFound();
            }
            return View(clazz);
        }

        // POST: Clazzs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClazzId,ClazzName,ClazzCode,ListStudentId,Description,Status")] Clazz clazz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clazz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clazz);
        }

        // GET: Clazzs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clazz clazz = db.Clazzs.Find(id);
            if (clazz == null)
            {
                return HttpNotFound();
            }
            return View(clazz);
        }

        // POST: Clazzs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clazz clazz = db.Clazzs.Find(id);
            db.Clazzs.Remove(clazz);
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
