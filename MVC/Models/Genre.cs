using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Genre
    {
        [Key]
        [Column("GenreId")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        //
        //public virtual IEnumerable<Gig>? Gigs { get; set; }

    }
}