using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace StudentManagement.Controllers
{
    [Authorize]
    public class TimeTableController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: TimeTable
        public ActionResult GetListTimetableStudent()
        { 
            var userID = User.Identity.GetUserId();
            //var listTimetable = db.Sessions.Where(x => x.EndTime >= DateTime.Now).ToList();
            var listTimetable = db.Sessions.Where(x => x.EndTime < DateTime.Now).ToList();
            var timetableStudent = new List<SessionDetail>();
            var listSession = new List<Session>();
            foreach (var session in listTimetable)
            {
                var ListStudentID = session.ListStudent.Split(',').ToList();
                if (ListStudentID.Any(x => x == userID.ToString()))
                {
                    listSession.Add(session);
                    var sessionDetail = db.SessionDetails.Where(x => x.SessionId == session.SessionId).ToList();
                    foreach(var item in sessionDetail)
                    {
                        timetableStudent.Add(item);
                    }
                }
            }
            ViewData["listSession"] = listSession;
            ViewData["timetableStudent"] = timetableStudent;
            return View("ListTimetable");
        }

        public ActionResult GetListAttendStudent()
        {
            var userID = User.Identity.GetUserId();
            var listTimetable = db.Sessions.ToList();
            var timetableStudent = new List<SessionDetail>();
            var listSession = new List<Session>();
            foreach (var session in listTimetable)
            {
                var ListStudentID = session.ListStudent.Split(',').ToList();
                if (ListStudentID.Any(x => x == userID.ToString()))
                {
                    listSession.Add(session);
                    var sessionDetail = db.SessionDetails.Where(x => x.SessionId == session.SessionId).ToList();
                    foreach (var item in sessionDetail)
                    {
                        timetableStudent.Add(item);
                    }
                }
            }
            ViewData["listSession"] = listSession;
            ViewData["timetableStudent"] = timetableStudent;
            ViewData["userId"] = userID;
            return View("ListAttendStudent");
        }
    }
}