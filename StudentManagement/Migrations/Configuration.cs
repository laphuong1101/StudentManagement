namespace StudentManagement.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using StudentManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentManagement.Models.ApplicationDbContext>
    {
        UserManager<ApplicationUser> UserManager = null;
        RoleManager<IdentityRole> RoleManager = null;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentManagement.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Database.ExecuteSqlCommand("DELETE FROM Attendances");
            context.Database.ExecuteSqlCommand("DELETE FROM Sessions");
            context.Database.ExecuteSqlCommand("DELETE FROM SessionDetails");
            context.Database.ExecuteSqlCommand("DELETE FROM Subjects");
            context.Database.ExecuteSqlCommand("DELETE FROM Clazzs");
            context.Database.ExecuteSqlCommand("DELETE FROM Rooms");

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Attendances', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Sessions', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('SessionDetails', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Subjects', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Clazzs', RESEED, 0)");
            context.Database.ExecuteSqlCommand(" DBCC CHECKIDENT('Rooms', RESEED, 0)");

            if (UserManager == null)
            {
                UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            }

            if (RoleManager == null)
            {
                RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            }

            var role1 = new IdentityRole { Name = "Admin" };
            var role2 = new IdentityRole { Name = "Manager" };
            var role3 = new IdentityRole { Name = "Teacher" };
            var role4 = new IdentityRole { Name = "Student" };
            RoleManager.Create(role1);
            RoleManager.Create(role2);
            RoleManager.Create(role3);
            RoleManager.Create(role4);

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("123456");

            context.Users.AddOrUpdate(new ApplicationUser() { Id = "1", Name = "Admin", Email = "admin@gmail.com", UserName = "admin@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Admin", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "Admin" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "2", Name = "Hong Hanh", Email = "honghanh@gmail.com", UserName = "honghanh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vu", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "2", RollNumber = "MSG1" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "3", Name = "Dao Hong Luyen", Email = "hongluyen@gmail.com", UserName = "hongluyen@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "GV1" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "4", Name = "La Phuong", Email = "laphuong@gmail.com", UserName = "laphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00631" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "5", Name = "Van Hien", Email = "vanhien@gmail.com", UserName = "vanhien@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00632" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "6", Name = "Dinh Nam", Email = "dinhnam@gmail.com", UserName = "dinhnam@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00633" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "7", Name = "Van Quy", Email = "vanquy@gmail.com", UserName = "vanquy@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00634" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "8", Name = "Duc Tung", Email = "ductung@gmail.com", UserName = "ductung@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00635" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "9", Name = "Huy Cuong", Email = "huycuong@gmail.com", UserName = "huycuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00636" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "10", Name = "Van Loi", Email = "vanloi@gmail.com", UserName = "vanloi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00637" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "11", Name = "Le Vinh", Email = "levinh@gmail.com", UserName = "levinh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00638" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "12", Name = "Duy Phuong", Email = "duyphuong@gmail.com", UserName = "duyphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00639" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "13", Name = "Kim Nghi", Email = "kimnghi@gmail.com", UserName = "kimnghi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00640" });

            UserManager.AddToRole("1", "Admin");
            UserManager.AddToRole("2", "Manager");
            UserManager.AddToRole("3", "Teacher");
            UserManager.AddToRole("4", "Student");
            UserManager.AddToRole("5", "Student");
            UserManager.AddToRole("6", "Student");
            UserManager.AddToRole("7", "Student");
            UserManager.AddToRole("8", "Student");
            UserManager.AddToRole("9", "Student");
            UserManager.AddToRole("10", "Student");
            UserManager.AddToRole("11", "Student");
            UserManager.AddToRole("12", "Student");
            UserManager.AddToRole("13", "Student");

            IList<Room> rooms = new List<Room>();
            IList<Clazz> clazzs = new List<Clazz>();
            IList<Subject> subjects = new List<Subject>();
            IList<string> listIdStudent = new List<string>();

            listIdStudent.Add("4");
            listIdStudent.Add("5");
            listIdStudent.Add("6");
            listIdStudent.Add("7");
            listIdStudent.Add("8");
            listIdStudent.Add("9");
            listIdStudent.Add("10");
            listIdStudent.Add("11");
            listIdStudent.Add("12");
            listIdStudent.Add("13");

            var list = "";
            foreach (var item in listIdStudent)
            {
                list += item + ",";
            }

            rooms.Add(new Room() { RoomId = 3, RoomName = "Class Room", RoomCode = "C3", Description = "hello world", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 2, RoomName = "Class Room", RoomCode = "C2", Description = "hello world", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 1, RoomName = "Class Room", RoomCode = "C1", Description = "hello world", Status = Room.RoomStatus.ACTIVE });

            subjects.Add(new Subject() { SubjectId = 1, SubjectCode = "ASPNETMVC", SubjectName = "ASP .Net MVC", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 2, SubjectCode = "JAVAWEB", SubjectName = "Java Web", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 3, SubjectCode = "C#", SubjectName = "C#", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });

            clazzs.Add(new Clazz() { ClazzId = 1, ClazzName = "T1908E", ClazzCode = "T1908E", Description = "hello world", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });

            context.Rooms.AddRange(rooms);
            context.Clazzs.AddRange(clazzs);
            context.Subjects.AddRange(subjects);

            TimeSpan StartTime = new TimeSpan(6, 0, 0);
            TimeSpan FinishTime = new TimeSpan(9, 0, 0);
<<<<<<< HEAD
            DateTime BeginTime = new DateTime(2021, 3, 7);
            DateTime EndTime = new DateTime(2021, 3, 8);

            context.Sessions.Add(new Session { SessionId = 1, RoomId = 3, SubjectId = 1, ClazzId = 1, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = StartTime, FinishTime = FinishTime, EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 1, SessionDetailCode = "ASP01", SessionDetailName = "ASP01", SessionId = 1, TeacherId = "3", RoomId = 3, DateStart = new DateTime(2021, 3, 7), Status = SessionDetail.SessionDetailStatus.UPCOMING });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "4", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "5", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "7", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "8", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "13", Attend = 0, Note = "hello world" });
=======
            DateTime BeginTime = new DateTime(2021, 3, 5);
            DateTime EndTime = new DateTime(2021, 3, 14);

            context.Sessions.Add(new Session { SessionId = 1, RoomId = 3, SubjectId = 1, ClazzId = 1, ApplicationUserId = "3", NumBerSession = 10, ListStudent = list, StartTime = StartTime, FinishTime = FinishTime, EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
>>>>>>> 8343e594ed494da6b90dc5bb7d684b97aabc3b50

            base.Seed(context);
        }
    }
}
