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

            //user
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "1", Name = "Admin", Email = "admin@gmail.com", UserName = "admin@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Admin", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0962336610", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "Admin" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "2", Name = "Hong Hanh", Email = "honghanh@gmail.com", UserName = "honghanh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vu", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0989123321", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "2", RollNumber = "MSG1" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "3", Name = "Dao Hong Luyen", Email = "hongluyen@gmail.com", UserName = "hongluyen@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Giao Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0987654321", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "GV1" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "4", Name = "La Phuong", Email = "laphuong@gmail.com", UserName = "laphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0668456789", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00631" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "5", Name = "Van Hien", Email = "vanhien@gmail.com", UserName = "vanhien@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0325678432", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00632" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "6", Name = "Dinh Nam", Email = "dinhnam@gmail.com", UserName = "dinhnam@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0971235612", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00633" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "7", Name = "Van Quy", Email = "vanquy@gmail.com", UserName = "vanquy@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0966253123", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00634" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "8", Name = "Duc Tung", Email = "ductung@gmail.com", UserName = "ductung@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0979126712", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00635" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "9", Name = "Huy Cuong", Email = "huycuong@gmail.com", UserName = "huycuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0987651260", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00636" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "10", Name = "Van Loi", Email = "vanloi@gmail.com", UserName = "vanloi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0881231238", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00637" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "11", Name = "Le Vinh", Email = "levinh@gmail.com", UserName = "levinh@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0229933555", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00638" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "12", Name = "Duy Phuong", Email = "duyphuong@gmail.com", UserName = "duyphuong@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0962336610", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00639" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "13", Name = "Kim Nghi", Email = "kimnghi@gmail.com", UserName = "kimnghi@gmail.com", Address = "Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = true, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = "0989797979", PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00640" });

            context.Users.AddOrUpdate(new ApplicationUser() { Id = "14", Name = "Dinh Bao", Email = "dinhbao202001@gmail.com", UserName = "dinhbao202001@gmail.com", Address = "So 12 Phung Hung, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00641" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "15", Name = "Bui Ba Truong", Email = "buibatrinh202002@gmail.com", UserName = "buibatrinh202002@gmail.com", Address = "So 8 Ton That Thuyet, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00642" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "16", Name = "Dinh Xuan Phong", Email = "dinhxuanphong202003@gmail.com", UserName = "dinhxuanphong202003@gmail.com", Address = "So 2/23 An Lac, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00643" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "17", Name = "Dao Ba Loc", Email = "daobaloc202004@gmail.com", UserName = "daobaloc202004@gmail.com", Address = "So 8 Ton That Thuyet, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00644" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "18", Name = "Nguyen Thu Trang", Email = "ngyenthutrang202005@gmail.com", UserName = "ngyenthutrang202005@gmail.com", Address = "So 12 Phung Hung, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00645" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "19", Name = "Hai Yen", Email = "haiyen202006@gmail.com", UserName = "haiyen202006@gmail.com", Address = "8/32 Ngo 21 Lac Trung, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00646" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "20", Name = "Vu Trong Phung", Email = "vutrongphung202007@gmail.com", UserName = "vutrongphung202007@gmail.com", Address = "Ngo 21 Lac Long Quan, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00647" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "21", Name = "Duong Khang", Email = "duongkhang202008@gmail.com", UserName = "duongkhang202008@gmail.com", Address = "So 100 Pho Hue, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00648" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "22", Name = "Bui Le Binh", Email = "builebinh202009@gmail.com", UserName = "builebinh202009@gmail.com", Address = "8/32 Ngo 21 Lac Trung, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00649" });
            context.Users.AddOrUpdate(new ApplicationUser() { Id = "23", Name = "Duong Van Hung", Email = "duongvanhung202010@gmail.com", UserName = "duongvanhung202010@gmail.com", Address = "Ngo 21 Lac Long Quan, Ha Noi", Avatar = "https://www.fkbga.com/wp-content/uploads/2018/07/person-icon-6.png", Description = "Sinh Vien", EmailConfirmed = false, Status = ApplicationUser.StudentStatus.ACTIVE, PasswordHash = password, PhoneNumber = null, PhoneNumberConfirmed = false, LockoutEndDateUtc = null, LockoutEnabled = false, AccessFailedCount = 0, TwoFactorEnabled = false, SecurityStamp = "1", RollNumber = "D00650" });


            //role
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

            UserManager.AddToRole("14", "Student");
            UserManager.AddToRole("15", "Student");
            UserManager.AddToRole("16", "Student");
            UserManager.AddToRole("17", "Student");
            UserManager.AddToRole("18", "Student");
            UserManager.AddToRole("19", "Student");
            UserManager.AddToRole("20", "Student");
            UserManager.AddToRole("21", "Student");
            UserManager.AddToRole("22", "Student");
            UserManager.AddToRole("23", "Student");



            IList<Room> rooms = new List<Room>();
            IList<Clazz> clazzs = new List<Clazz>();
            IList<Subject> subjects = new List<Subject>();
            IList<string> listIdStudent = new List<string>();
            IList<string> listIdStudent2 = new List<string>();

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


            listIdStudent2.Add("14");
            listIdStudent2.Add("15");
            listIdStudent2.Add("16");
            listIdStudent2.Add("17");
            listIdStudent2.Add("18");
            listIdStudent2.Add("19");
            listIdStudent2.Add("20");
            listIdStudent2.Add("21");
            listIdStudent2.Add("22");
            listIdStudent2.Add("23");

            var list = "";
            foreach (var item in listIdStudent)
            {
                list += item + ",";
            }


            var list2 = "";
            foreach (var item in listIdStudent2)
            {
                list2 += item + ",";
            }


            //room
            rooms.Add(new Room() { RoomId = 1, RoomName = "Room C1", RoomCode = "C1", Description = "hello world", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 2, RoomName = "Room C2", RoomCode = "C2", Description = "", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 3, RoomName = "Room C3", RoomCode = "C3", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 4, RoomName = "Room C4", RoomCode = "C4", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 5, RoomName = "Room C5", RoomCode = "C5", Description = "", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 6, RoomName = "Room C6", RoomCode = "C6", Description = "sức chứa tối đa 20 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 7, RoomName = "Room C7", RoomCode = "C7", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 8, RoomName = "Room C8", RoomCode = "C8", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 9, RoomName = "Room B1", RoomCode = "B1", Description = "sức chứa tối đa 20 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 10, RoomName = "Room B2", RoomCode = "B2", Description = "sức chứa tối đa 18 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 11, RoomName = "Room B3", RoomCode = "B3", Description = "", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 12, RoomName = "Room B4", RoomCode = "B4", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 13, RoomName = "Room B5", RoomCode = "B5", Description = "sức chứa tối đa 15 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 14, RoomName = "Room B6", RoomCode = "B6", Description = "", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 15, RoomName = "Room B7", RoomCode = "B7", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 16, RoomName = "Room B8", RoomCode = "B8", Description = "đang tu sửa", Status = Room.RoomStatus.DEACTIVE });
            rooms.Add(new Room() { RoomId = 17, RoomName = "Room A1", RoomCode = "A1", Description = "dành cho các hội nhóm của trường", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 18, RoomName = "Room A2", RoomCode = "A2", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 19, RoomName = "Room A3", RoomCode = "A3", Description = "sức chứa tối đa 15 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 20, RoomName = "Room A4", RoomCode = "A4", Description = "dành cho các hội nhóm của trường", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 21, RoomName = "Room A5", RoomCode = "A5", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 22, RoomName = "Room A6", RoomCode = "A6", Description = "sức chứa tối đa 15 sinh viên", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 23, RoomName = "Room A7", RoomCode = "A7", Description = "dành cho các hội nhóm của trường", Status = Room.RoomStatus.ACTIVE });
            rooms.Add(new Room() { RoomId = 24, RoomName = "Room A8", RoomCode = "A8", Description = "sức chứa tối đa 30 sinh viên", Status = Room.RoomStatus.ACTIVE });

            //subjects
            subjects.Add(new Subject() { SubjectId = 1, SubjectCode = "ASPNETMVC", SubjectName = "ASP .Net MVC", Description = "", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 2, SubjectCode = "JAVAWEB", SubjectName = "Java Web", Description = "", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 3, SubjectCode = "C#", SubjectName = "C#", Description = "", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 4, SubjectCode = "ADI", SubjectName = "Analysis, Design, and Implementation", Description = "", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 5, SubjectCode = "WAD", SubjectName = "Web Application Development", Description = "", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 6, SubjectCode = "WFP", SubjectName = "Windows Forms Programming", Description = "", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 7, SubjectCode = "DW", SubjectName = "Dynamic Websites", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 8, SubjectCode = "WADP", SubjectName = "Web Application Development using PHP", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 9, SubjectCode = "AP", SubjectName = "Application Programming", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 10, SubjectCode = "ISA", SubjectName = "Information Systerms Analysis", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 11, SubjectCode = "MLJ", SubjectName = "Markup Language and JSON", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 12, SubjectCode = "ADF-II", SubjectName = "Application Development Fundamentals-II", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 13, SubjectCode = "ADF-I", SubjectName = "Application Development Fundamentals-I", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 14, SubjectCode = "EAP", SubjectName = "Enterprise Application Programming", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 15, SubjectCode = "PRJ2-FAT", SubjectName = "Project", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 16, SubjectCode = "AD", SubjectName = "Agile Development", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });
            subjects.Add(new Subject() { SubjectId = 17, SubjectCode = "DM", SubjectName = "Database Management (SQL Server)", Description = "hello world", Status = Subject.SubjectStatus.ACTIVE });

            //clazz
            clazzs.Add(new Clazz() { ClazzId = 1, ClazzName = "T1908T", ClazzCode = "T1908E", Description = "hello world", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });
            clazzs.Add(new Clazz() { ClazzId = 2, ClazzName = "T1908SA", ClazzCode = "T1908SA", Description = "hello world", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });
            clazzs.Add(new Clazz() { ClazzId = 3, ClazzName = "T2011T", ClazzCode = "T2011T", Description = "hello world", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });
            clazzs.Add(new Clazz() { ClazzId = 4, ClazzName = "T2001S", ClazzCode = "T2001S", Description = "hello world", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });
            clazzs.Add(new Clazz() { ClazzId = 5, ClazzName = "T1908V", ClazzCode = "T1908V", Description = "hello world", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });
            clazzs.Add(new Clazz() { ClazzId = 6, ClazzName = "T1810D", ClazzCode = "T1810D", Description = "hello world", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });
            clazzs.Add(new Clazz() { ClazzId = 7, ClazzName = "T5K8E", ClazzCode = "T5K8E", Description = "hello world", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });
            clazzs.Add(new Clazz() { ClazzId = 8, ClazzName = "H2Y90", ClazzCode = "H2Y90", Description = "", ListStudentId = list, Status = Clazz.ClazzStatus.ACTIVE });

            context.Rooms.AddRange(rooms);
            context.Clazzs.AddRange(clazzs);
            context.Subjects.AddRange(subjects);

            TimeSpan StartTime = new TimeSpan(6, 0, 0);
            TimeSpan FinishTime = new TimeSpan(9, 0, 0);

            //DateTime BeginTime = new DateTime(2021, 3, 7);
            DateTime dateNow = DateTime.Now;

            //session
            context.Sessions.Add(new Session { SessionId = 1, RoomId = 3, SubjectId = 1, ClazzId = 1, ApplicationUserId = "3", NumBerSession = 5, ListStudent = list, StartTime = new TimeSpan(6, 0, 0), FinishTime = new TimeSpan(9, 0, 0), EndTime = dateNow.AddDays(-2), BeginTime = dateNow.AddDays(-10), Status = Session.SessionStatus.ACTIVE });
            context.Sessions.Add(new Session { SessionId = 2, RoomId = 3, SubjectId = 2, ClazzId = 1, ApplicationUserId = "3", NumBerSession = 6, ListStudent = list, StartTime = new TimeSpan(17, 0, 0), FinishTime = new TimeSpan(21, 0, 0), EndTime = dateNow.AddDays(10), BeginTime = dateNow, Status = Session.SessionStatus.ACTIVE });
            context.Sessions.Add(new Session { SessionId = 3, RoomId = 4, SubjectId = 3, ClazzId = 1, ApplicationUserId = "3", NumBerSession = 5, ListStudent = list, StartTime = new TimeSpan(17, 0, 0), FinishTime = new TimeSpan(21, 0, 0), EndTime = dateNow.AddDays(-12), BeginTime = dateNow.AddDays(-20), Status = Session.SessionStatus.ACTIVE });


            //context.Sessions.Add(new Session { SessionId = 1, RoomId = 3, SubjectId = 1, ClazzId = 1, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(6, 0, 0), FinishTime = new TimeSpan(9, 0, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            //context.Sessions.Add(new Session { SessionId = 2, RoomId = 3, SubjectId = 2, ClazzId = 2, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(9, 15, 0), FinishTime = new TimeSpan(12, 15, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            //context.Sessions.Add(new Session { SessionId = 3, RoomId = 3, SubjectId = 3, ClazzId = 3, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(12, 30, 0), FinishTime = new TimeSpan(14, 30, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            //context.Sessions.Add(new Session { SessionId = 4, RoomId = 3, SubjectId = 4, ClazzId = 4, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(14, 45, 0), FinishTime = new TimeSpan(17, 45, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            //context.Sessions.Add(new Session { SessionId = 5, RoomId = 3, SubjectId = 5, ClazzId = 5, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(18, 0, 0), FinishTime = new TimeSpan(21, 0, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });

            //context.Sessions.Add(new Session { SessionId = 6, RoomId = 1, SubjectId = 1, ClazzId = 1, ApplicationUserId = "3", NumBerSession = 2, ListStudent = list, StartTime = new TimeSpan(18, 0, 0), FinishTime = new TimeSpan(21, 0, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            //context.Sessions.Add(new Session { SessionId = 7, RoomId = 2, SubjectId = 1, ClazzId = 2, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(18, 0, 0), FinishTime = new TimeSpan(21, 0, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            //context.Sessions.Add(new Session { SessionId = 8, RoomId = 4, SubjectId = 2, ClazzId = 3, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(18, 0, 0), FinishTime = new TimeSpan(21, 0, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            //context.Sessions.Add(new Session { SessionId = 9, RoomId = 5, SubjectId = 4, ClazzId = 4, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(18, 0, 0), FinishTime = new TimeSpan(21, 0, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });
            //context.Sessions.Add(new Session { SessionId = 10, RoomId = 6, SubjectId = 5, ClazzId = 5, ApplicationUserId = "3", NumBerSession = 1, ListStudent = list, StartTime = new TimeSpan(18, 0, 0), FinishTime = new TimeSpan(21, 0, 0), EndTime = EndTime, BeginTime = BeginTime, Status = Session.SessionStatus.ACTIVE });

            //sessiondetail
            //ssid = 1
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 1, SessionDetailCode = "ASP01", SessionDetailName = "ASP01", SessionId = 1, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(-10), Status = SessionDetail.SessionDetailStatus.DONE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 2, SessionDetailCode = "ASP02", SessionDetailName = "ASP02", SessionId = 1, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(-8), Status = SessionDetail.SessionDetailStatus.DONE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 3, SessionDetailCode = "ASP03", SessionDetailName = "ASP03", SessionId = 1, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(-6), Status = SessionDetail.SessionDetailStatus.DONE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 4, SessionDetailCode = "ASP04", SessionDetailName = "ASP04", SessionId = 1, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(-4), Status = SessionDetail.SessionDetailStatus.DONE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 5, SessionDetailCode = "ASP05", SessionDetailName = "ASP05", SessionId = 1, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(-2), Status = SessionDetail.SessionDetailStatus.DONE });

            //ssid = 2
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 6, SessionDetailCode = "DDL01", SessionDetailName = "DDL01", SessionId = 2, TeacherId = "3", RoomId = 3, DateStart = dateNow, Status = SessionDetail.SessionDetailStatus.UPCOMING });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 7, SessionDetailCode = "DDL02", SessionDetailName = "DDL02", SessionId = 2, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(2), Status = SessionDetail.SessionDetailStatus.UPCOMING });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 8, SessionDetailCode = "DDL03", SessionDetailName = "DDL03", SessionId = 2, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(4), Status = SessionDetail.SessionDetailStatus.UPCOMING });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 9, SessionDetailCode = "DDL04", SessionDetailName = "DDL04", SessionId = 2, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(6), Status = SessionDetail.SessionDetailStatus.UPCOMING });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 10, SessionDetailCode = "DDL05", SessionDetailName = "DDL05", SessionId = 2, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(8), Status = SessionDetail.SessionDetailStatus.UPCOMING });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 11, SessionDetailCode = "DDL06", SessionDetailName = "DDL06", SessionId = 2, TeacherId = "3", RoomId = 3, DateStart = dateNow.AddDays(10), Status = SessionDetail.SessionDetailStatus.UPCOMING });

            //ssid = 3
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 12, SessionDetailCode = "PHP01", SessionDetailName = "PHP01", SessionId = 3, TeacherId = "3", RoomId = 4, DateStart = dateNow.AddDays(-20), Status = SessionDetail.SessionDetailStatus.DONE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 13, SessionDetailCode = "PHP02", SessionDetailName = "PHP02", SessionId = 3, TeacherId = "3", RoomId = 4, DateStart = dateNow.AddDays(-18), Status = SessionDetail.SessionDetailStatus.DONE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 14, SessionDetailCode = "PHP03", SessionDetailName = "PHP03", SessionId = 3, TeacherId = "3", RoomId = 4, DateStart = dateNow.AddDays(-16), Status = SessionDetail.SessionDetailStatus.DONE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 15, SessionDetailCode = "PHP04", SessionDetailName = "PHP04", SessionId = 3, TeacherId = "3", RoomId = 4, DateStart = dateNow.AddDays(-14), Status = SessionDetail.SessionDetailStatus.DONE });
            context.SessionDetails.AddOrUpdate(new SessionDetail { SessionDetailId = 16, SessionDetailCode = "PHP05", SessionDetailName = "PHP05", SessionId = 3, TeacherId = "3", RoomId = 4, DateStart = dateNow.AddDays(-12), Status = SessionDetail.SessionDetailStatus.DONE });


            //attendance
            // lesson1 - ssid = 1
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 1, SessionDetailId = 1, ApplicationUserId = "4", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 2, SessionDetailId = 1, ApplicationUserId = "5", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 3, SessionDetailId = 1, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 4, SessionDetailId = 1, ApplicationUserId = "7", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 5, SessionDetailId = 1, ApplicationUserId = "8", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 6, SessionDetailId = 1, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 7, SessionDetailId = 1, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 8, SessionDetailId = 1, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 9, SessionDetailId = 1, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 10, SessionDetailId = 1, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            //lession2 - ssid = 1
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 11, SessionDetailId = 2, ApplicationUserId = "4", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 12, SessionDetailId = 2, ApplicationUserId = "5", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 13, SessionDetailId = 2, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 14, SessionDetailId = 2, ApplicationUserId = "7", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 15, SessionDetailId = 2, ApplicationUserId = "8", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 16, SessionDetailId = 2, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 17, SessionDetailId = 2, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 18, SessionDetailId = 2, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 19, SessionDetailId = 2, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 20, SessionDetailId = 2, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            //lession3 - ssid = 1
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 21, SessionDetailId = 3, ApplicationUserId = "4", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 22, SessionDetailId = 3, ApplicationUserId = "5", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 23, SessionDetailId = 3, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 24, SessionDetailId = 3, ApplicationUserId = "7", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 25, SessionDetailId = 3, ApplicationUserId = "8", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 26, SessionDetailId = 3, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 27, SessionDetailId = 3, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 28, SessionDetailId = 3, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 29, SessionDetailId = 3, ApplicationUserId = "12", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 30, SessionDetailId = 3, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            //lesson4 - ssid = 1
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 31, SessionDetailId = 4, ApplicationUserId = "4", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 32, SessionDetailId = 4, ApplicationUserId = "5", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 33, SessionDetailId = 4, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 34, SessionDetailId = 4, ApplicationUserId = "7", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 35, SessionDetailId = 4, ApplicationUserId = "8", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 36, SessionDetailId = 4, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 37, SessionDetailId = 4, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 38, SessionDetailId = 4, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 39, SessionDetailId = 4, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 40, SessionDetailId = 4, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            //lesson5 - ssid = 1
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 41, SessionDetailId = 5, ApplicationUserId = "4", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 42, SessionDetailId = 5, ApplicationUserId = "5", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 43, SessionDetailId = 5, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 44, SessionDetailId = 5, ApplicationUserId = "7", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 45, SessionDetailId = 5, ApplicationUserId = "8", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 46, SessionDetailId = 5, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 47, SessionDetailId = 5, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 48, SessionDetailId = 5, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 49, SessionDetailId = 5, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 50, SessionDetailId = 5, ApplicationUserId = "13", Attend = 1, Note = "hello world" });


            // lesson1 - ssid = 3
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 51, SessionDetailId = 12, ApplicationUserId = "4", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 52, SessionDetailId = 12, ApplicationUserId = "5", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 53, SessionDetailId = 12, ApplicationUserId = "6", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 54, SessionDetailId = 12, ApplicationUserId = "7", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 55, SessionDetailId = 12, ApplicationUserId = "8", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 56, SessionDetailId = 12, ApplicationUserId = "9", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 57, SessionDetailId = 12, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 58, SessionDetailId = 12, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 59, SessionDetailId = 12, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 60, SessionDetailId = 12, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            //lession2 - ssid = 3
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 61, SessionDetailId = 13, ApplicationUserId = "4", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 62, SessionDetailId = 13, ApplicationUserId = "5", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 63, SessionDetailId = 13, ApplicationUserId = "6", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 64, SessionDetailId = 13, ApplicationUserId = "7", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 65, SessionDetailId = 13, ApplicationUserId = "8", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 66, SessionDetailId = 13, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 67, SessionDetailId = 13, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 68, SessionDetailId = 13, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 69, SessionDetailId = 13, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 70, SessionDetailId = 13, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            //lession3 - ssid = 3
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 71, SessionDetailId = 14, ApplicationUserId = "4", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 72, SessionDetailId = 14, ApplicationUserId = "5", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 73, SessionDetailId = 14, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 74, SessionDetailId = 14, ApplicationUserId = "7", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 75, SessionDetailId = 14, ApplicationUserId = "8", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 76, SessionDetailId = 14, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 77, SessionDetailId = 14, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 78, SessionDetailId = 14, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 79, SessionDetailId = 14, ApplicationUserId = "12", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 80, SessionDetailId = 14, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            //lesson4 - ssid = 4
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 81, SessionDetailId = 15, ApplicationUserId = "4", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 82, SessionDetailId = 15, ApplicationUserId = "5", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 83, SessionDetailId = 15, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 84, SessionDetailId = 15, ApplicationUserId = "7", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 85, SessionDetailId = 15, ApplicationUserId = "8", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 86, SessionDetailId = 15, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 87, SessionDetailId = 15, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 88, SessionDetailId = 15, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 89, SessionDetailId = 15, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 90, SessionDetailId = 15, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            //lesson5 - ssid = 5
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 91, SessionDetailId = 16, ApplicationUserId = "4", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 92, SessionDetailId = 16, ApplicationUserId = "5", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 93, SessionDetailId = 16, ApplicationUserId = "6", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 94, SessionDetailId = 16, ApplicationUserId = "7", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 95, SessionDetailId = 16, ApplicationUserId = "8", Attend = 0, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 96, SessionDetailId = 16, ApplicationUserId = "9", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 97, SessionDetailId = 16, ApplicationUserId = "10", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 98, SessionDetailId = 16, ApplicationUserId = "11", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 99, SessionDetailId = 16, ApplicationUserId = "12", Attend = 1, Note = "hello world" });
            context.Attendances.AddOrUpdate(new Attendance { AttendanceId = 100, SessionDetailId = 16, ApplicationUserId = "13", Attend = 1, Note = "hello world" });

            base.Seed(context);
        }
    }
}
