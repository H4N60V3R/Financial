using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financial.Models.Entities
{
    public class Calendar
    {
        [Key]
        [Column("CalendarID")]
        public int CalendarId { get; set; }

        [Column("CalendarGUID")]
        public Guid CalendarGuid { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
