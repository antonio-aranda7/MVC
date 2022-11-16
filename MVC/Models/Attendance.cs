using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class Attendance
    {
        [Key]
        [Column("AttendanceId")]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey(nameof(Gig))]
        public int GigId { get; set; }
        public Gig? Gig { get; set; }

        [Required]
        [ForeignKey(nameof(Attendee))]
        public string? AttendeeId { get; set; }
        public User? Attendee { get; set; }
    }
}