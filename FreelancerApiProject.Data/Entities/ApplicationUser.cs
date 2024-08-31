using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FreelancerApiProject.Data.Entities
{
    // Extends IdentityUser to include potential associations with Client, Freelancer, and Admin entities.
    public class ApplicationUser : IdentityUser
    {
        // Foreign key for the associated client entity. Nullable.
        [ForeignKey(nameof(Client))]
        public int? ClientId { get; set; }
        public Client? Client { get; set; }

        // Foreign key for the associated freelancer entity. Nullable.
        [ForeignKey(nameof(Freelancer))]
        public int? FreelancerId { get; set; }
        public Freelancer? Freelancer { get; set; }

        // Foreign key for the associated admin entity. Nullable.
        [ForeignKey(nameof(Admin))]
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }

        // Collection of refresh tokens associated with this user.
        public List<RefreshToken>? RefreshTokens { get; set; }

        // Token used for password reset. Optional.
        public string? PasswordResetToken { get; set; }

        // Expiration time for the password reset token. Optional.
        public DateTime? ResetTokenExpires { get; set; }
    }
}