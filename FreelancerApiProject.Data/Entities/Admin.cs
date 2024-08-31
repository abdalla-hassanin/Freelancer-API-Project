using System.ComponentModel.DataAnnotations;

namespace FreelancerApiProject.Data.Entities
{
    // Represents an administrator in the system.
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        // Name of the administrator. Required field with a maximum length of 100 characters.
        [Required, MaxLength(100)]
        public string Name { get; set; }

        // Profile image in byte array format. This field is optional.
        public byte[]? Image { get; set; }

        // Country where the administrator is located. Optional with a maximum length of 50 characters.
        [MaxLength(50)]
        public string? Country { get; set; }

        // Contact phone number. Should be in valid phone number format. Optional and limited to 20 characters.
        [Phone, MaxLength(20)]
        public string? Phone { get; set; }

        // The associated user account linked to this administrator.
        public ApplicationUser? User { get; set; }
    }
}