using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StatisticController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Statistic
        public ActionResult Index()
        {

            return View(db.Sessions.ToList());
        }

        public ActionResult GetDetailSession(int Id)
        {
            if (Id == null)
            {
                return Redirect("Index");
            }
            var ListSessionDetail = db.SessionDetails.Where(x => x.SessionDetailId == Id).ToList();
            var numberSessionComplete = db.SessionDetails.Where(x => x.Status == SessionDetail.SessionDetailStatus.DONE).ToList().Count;
            var session = db.Sessions.Find(Id);
            ViewData["SubjectName"] = "";
            ViewData["numberSession"] = 0;
            ViewData["numberStudent"] = 0;
            var lstStudent = new List<ApplicationUser>();
            if (session != null)
            {
                var subject = db.Subjects.Find(session.SubjectId);
                ViewData["SubjectName"] = subject.SubjectName;
                ViewData["numberSession"] = session.NumBerSession;
                var ListStudent = session.ListStudent.Split(',').ToList();
                ViewData["numberStudent"] = ListStudent.Count;
                foreach(var userId in ListStudent)
                { 
                    var student = db.Users.Find(userId);
                    var numberAttend = db.Attendances.Where(x => x.ApplicationUserId == userId && x.Attend == 1).ToList().Count;
                    
                    if (student != null)
                    {
                        lstStudent.Add(student);
                    }
                }
            }
            ViewData["ListSessionDetail"] = ListSessionDetail;
            ViewData["session"] = session;
            ViewData["numberSessionComplete"] = numberSessionComplete;
            ViewData["ListStudent"] = lstStudent;
           
            return View();
        }
    }
}