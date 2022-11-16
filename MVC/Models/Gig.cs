using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Gig
    {
        [Key]
        [Column("GigId")]
        public int Id { get; set; }

        [ForeignKey(nameof(Artist))]
        public string? ArtistId { get; set; }
        public User? Artist { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string? Venue { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }




    }
}