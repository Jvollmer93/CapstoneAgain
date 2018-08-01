using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Capstone_.Models;

namespace Capstone_.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public string Role { get; set; }

        private List<Company> companiesIFollow;
        public List<Company> CompaniesIFollow { get { return CompaniesIFollow; } set { CompaniesIFollow = value; } }

        private List<PersonalUser> personsIFollow;
        public List<PersonalUser> PersonsIFollow { get { return PersonsIFollow; } set { PersonsIFollow = value; } }


        //public List<Company> CompanyFollowers { get; set; }
        //public List<Company> CompaniesIFollow { get; set; }
        //public List<PersonalUser> PersonalFollowers { get; set; }
        //public List<PersonalUser> PersonsIFollow { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PersonalUser> PersonalUsers { get; set; }
    }
}