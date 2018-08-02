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

        public List<PersonalUser> PeopleIFollow = new List<PersonalUser>();
        public List<PersonalUser> PeopleThatFollowMe = new List<PersonalUser>();
        public List<Company> CompaniesIFollow = new List<Company>();
        public List<Company> CompaniesThatFollowMe = new List<Company>();
        public List<Event> HostedEvents = new List<Event>();

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}