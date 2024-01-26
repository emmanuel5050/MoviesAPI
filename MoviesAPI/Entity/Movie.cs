using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Entity
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating is on a scale from 1 to 5.")]
        public int Rating { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public List<Genre> Genres { get; set; }
        [Required]
        public string Photo { get; set; }
    }
}
