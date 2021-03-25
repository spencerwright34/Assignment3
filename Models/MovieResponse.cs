using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace Assignment3.Models
{
    public class MovieResponse
    {
        //Model for the movie inputs
        //MovieId is the primary key
        [Key, Required]
        public int MovieId { get; set; }
        
        [Required(ErrorMessage = "The title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The category is required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "The year is required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "The director is required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "The rating is required")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }
    }
}
