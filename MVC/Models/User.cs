using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Following> Followers { get; set; }
        public ICollection<Following> Followees { get; set; }

        //public IEnumerable<Gig>? Gigs { get; set; }

        public User()
        {
            Followers = new HashSet<Following>();
            Followees = new HashSet<Following>();
        }
    }
}
