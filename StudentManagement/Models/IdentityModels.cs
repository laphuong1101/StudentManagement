using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StudentManagement.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string RollNumber { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        public string Description { get; set; }

        public StudentStatus Status { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }

        public enum StudentStatus
        {
            ACTIVE, DEACTIVE, DELETED
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public int GetNumberAttend(string UserId, int sessionId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var sessionDetail = db.SessionDetails.Where(x => x.SessionId == sessionId).ToList();
                var numberAttend = 0;
                foreach (var item in sessionDetail)
                {
                    var result = db.Attendances.Where(x => x.ApplicationUserId == UserId && x.Attend == 1 && x.SessionDetailId == item.SessionDetailId).ToList();
                    if (result.Count > 0)
                    {
                        numberAttend += 1;
                    }
                }
                return numberAttend;
            }
        }

        public double CalculatorPercentAttend(int numberAttend, int numberSession)
        {
            var Percent = ((double)numberAttend / (double)numberSession) * 100;
            return Math.Round(Percent);
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Clazz> Clazzs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionDetail> SessionDetails { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}