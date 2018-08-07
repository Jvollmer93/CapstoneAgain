using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_.Models
{
    public class Invited
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string InvitedID { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
        public Event Event { get; set; }
    }
}