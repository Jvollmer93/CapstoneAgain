using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone_.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsPublic { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
    }
}