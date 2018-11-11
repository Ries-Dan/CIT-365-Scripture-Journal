using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptureJournal.Models
{
    public class Scripture
    {
        // ID
        public int ID { get; set; }

        // Book
        [StringLength(20, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }

        // Chapter
        [RegularExpression(@"^[-+]?[0-9]*\.?[0-9]+$")]
        [Required]
        public int Chapter { get; set; }

        // Verse
        [RegularExpression(@"^[-+]?[0-9]*\.?[0-9]+$")]
        [Required]
        public int Verse { get; set; }

        // Note
        [Required]
        public string Note { get; set; }

        // Date Added
        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
