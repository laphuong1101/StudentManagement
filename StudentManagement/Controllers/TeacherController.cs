using Microsoft.AspNet.Identity;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StudentManagement.Controllers
{
    public class TeacherController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Teacher

        [Authorize(Roles = "Teacher")]
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            var ListIdClass = new List<int>();
            var clazzs = new List<Clazz>();
            ListIdClass = db.Sessions.Where(id => id.ApplicationUserId == UserId).Select(c => c.ClazzId).Distinct().ToList();
            foreach (var item in ListIdClass)
            {
                clazzs.Add(db.Clazzs.Find(item));
            }
            return View(clazzs);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult SessionDetail(int? id)
        {
            var DateNow = DateTime.Now.ToString("dd.MM.yyyy");
            var ListSS = db.Sessions.Where(s => s.ClazzId == id).ToList();
            SessionDetail SSDetail = null;
            foreach (var item in ListSS)
            {
                var ListSSDetail = db.SessionDetails.Where(ss => ss.SessionId == item.SessionId).ToList();
                foreach (SessionDetail detail in ListSSDetail)
                {

                    var rsStatus = detail.Status.Equals(Models.SessionDetail.SessionDetailStatus.DONE);
                    var date = detail.DateStart.ToString("dd.MM.yyyy");
                    if (date == DateNow && rsStatus == false)
                    {
                        TimeSpan TimeStart = item.StartTime;
                        TimeSpan FinishTime = item.FinishTime;
                        TimeSpan TimeNow = DateTime.Now.TimeOfDay;

                        int rs1 = TimeSpan.Compare(TimeNow, TimeStart);
                        int rs2 = TimeSpan.Compare(TimeNow, FinishTime);

                        if (rs1 == 1 && rs2 == -1)
                        {
                            detail.Status = Models.SessionDetail.SessionDetailStatus.ONGOING;
                            ViewBag.Attend = 1;
                            db.SaveChanges();
                        }
                        else
                        {
                            ViewBag.Attend = 0;
                        }

                        SSDetail = detail;
                        return View(SSDetail);
                    }
                    else
                    {
                        SSDetail = null;
                    }
                }

            }
            return View(SSDetail);
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult Attendance(int? id)
        {
            var SSDetail = db.SessionDetails.Find(id);
            if (SSDetail != null)
            {
                var listIdStudent = SSDetail.Session.ListStudent;
                if (listIdStudent.Length > 0)
                {
                    var listStudent = new List<ApplicationUser>();
                    string[] subs = listIdStudent.Split(',');
                    for (int i = 0; i < subs.Length - 1; i++)
                    {
                        var idStudent = subs[i];
                        listStudent.Add(db.Users.Where(s => s.Id == idStudent).Single());
                    }
                    ViewBag.IdSSdetail = id;
                    return View(listStudent);
                }
            }

            return View();
        }

        [Authorize(Roles = "Teacher")]
        public ActionResult AttendanceResult(string selectedID, int idSSDetail)
        {
            var str = selectedID;
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<StudentModelAjax> list = serializer.Deserialize<List<StudentModelAjax>>(str);

                foreach (var item in list)
                {
                    db.Attendances.Add(new Attendance() { SessionDetailId = idSSDetail, ApplicationUserId = item.idStudent, Attend = item.attend });
                }

                var SSDetail = db.SessionDetails.Find(idSSDetail);
                SSDetail.Status = Models.SessionDetail.SessionDetailStatus.DONE;
                db.SaveChanges();
                return Json(new { code = 200, msg = "Attendance Success"}, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { code = 500, msg = "Attendance Fail" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ListSubject(int? id)
        {
            var ListSS = db.Clazzs.Find(id).Sessions.ToList();
            var ListSubject = new List<Subject>();
            foreach (var item in ListSS)
            {
                ListSubject.Add(item.Subject);
            }
            return View(ListSubject);
        }

        public ActionResult ListSessionDetail(int? id)
        {
            var ListSS = db.Clazzs.Find(id).Sessions.ToList();
            var ListSSDetail = new List<SessionDetail>();
            foreach (var item in ListSS)
            {
                ListSSDetail.AddRange(item.SessionDetails);
            }
            return View(ListSSDetail);
        }

        public ActionResult ListStudent(int? id)
        {
            var ListStudentId = db.Clazzs.Find(id).ListStudentId;
            var listStudent = new List<ApplicationUser>();
            string[] subs = ListStudentId.Split(',');
            for (int i = 0; i < subs.Length - 1; i++)
            {
                var idStudent = subs[i];
                listStudent.Add(db.Users.Where(s => s.Id == idStudent).Single());
            }
            return View(listStudent);
        }
    }
}