using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalNote.Models
{
    public class WorkoutReport
    {
        [Key]
        public int Id { get; set;}

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime WorkoutDate { get; set; } = DateTime.Now;

        [Required]
        public string Category { get; set; }

    }
}
