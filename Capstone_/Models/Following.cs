using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_.Models
{
    public class Following
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PersonalUser")]
        public int PersonalUserId { get; set; } // follower Id
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; } // following Id
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
        public PersonalUser PersonalUser { get; set; }
    }
}