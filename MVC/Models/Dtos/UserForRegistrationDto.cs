using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Dtos
{
    public class UserForRegistrationDto
    {
        [Key]
        [Column("RegistratioId")]
        public int Id { get; set; } = 0;
        public string? Name { get; set; }
        /*public string? FirstName { get; set; }
        public string? LastName { get; set; }*/

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
