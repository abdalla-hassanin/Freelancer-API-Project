using System.ComponentModel.DataAnnotations;

namespace FreelancerApiProject.Data.Entities
{
    // Represents a category that can be associated with multiple jobs.
    public class Category
    {
        public int Id { get; set; }

        // Title or name of the category. Required field.
        public string Title { get; set; }

        // Description of the category. Optional, with a default empty string.
        public string? Description { get; set; } = string.Empty;

        // List of jobs that belong to this category.
        public List<Job>? Jobs { get; set; }
    }
}