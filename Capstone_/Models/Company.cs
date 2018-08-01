using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool AcceptsTextNotifications { get; set; }
        public bool AcceptsEmailNotifications { get; set; }
        public List<ApplicationUser> Followers { get; set; }
        public List<ApplicationUser> Following { get; set; }


        //public List<PersonalUser> PersonalFollowwers { get; set; }
        //public List<PersonalUser> PersonalFollowing { get; set; }
        //public List<Company> CompanyFollowwers { get; set; }
        //public List<Company> CompanyFollowing { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}