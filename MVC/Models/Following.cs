using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    // Alternatively, this class could be called Relationship.
    public class Following
    {
        public Following(){

        }

        [Key]
        [Column("FollowingId")]
        public int Id { get; set; }

        [Required]
        //[ForeignKey(nameof(Follower))]
        public string? FollowerId { get; set; }
        //public User? Follower { get; set; }

        [Required]
        //[ForeignKey(nameof(Followee))]
        public string? FolloweeId { get; set; }
        //public User? Followee { get; set; }
    }
}