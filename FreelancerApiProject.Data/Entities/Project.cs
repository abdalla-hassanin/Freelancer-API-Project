using System.ComponentModel.DataAnnotations;

namespace FreelancerApiProject.Data.Entities
{
    // Represents a portfolio project created by a freelancer.
    public class Project
    {
        public int Id { get; set; } 

        // Title of the project. Required field.
        public string Title { get; set; }

        // Detailed description of the project. Optional.
        public string? Description { get; set; }

        // Link to the project, such as a website or repository. Optional.
        public string? Link { get; set; }

        // Poster image of the project.
        public string Poster { get; set; }

        // Additional images related to the project.
        public List<string>? Images { get; set; } = [];

        // Skills used in the project.
        public List<ProjectSkills>? Skills { get; set; } = new List<ProjectSkills>();

        // Time when the project was published. Optional.
        public DateTime? TimePublished { get; set; } = DateTime.Now;

        // Foreign key to the freelancer who created the project.
        public int FreelancerId { get; set; }

        // The freelancer who created the project.
        public Freelancer Freelancer { get; set; }
    }
}