using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationAPI.Models
{
    public class NotificationMessage
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string NotificationText { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Username { get; set; }
    }
}
