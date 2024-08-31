using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FreelancerApiProject.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace FreelancerApiProject.Infrustructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<FreelancerSkills> FreelancerSkills { get; set; }
        public DbSet<JobSkills> JobSkills { get; set; }
        public DbSet<ProjectSkills> ProjectSkills { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rate> Rates { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            // Seed roles using HasData
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Freelancer", NormalizedName = "FREELANCER" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Client", NormalizedName = "CLIENT" }
            );
        }

        public override int SaveChanges()
        {

            IEnumerable<object> entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Modified ||
                           e.State == EntityState.Added //&&( e.Entity is Employee)  => can use certain conditions also if needed
                           select e.Entity;

            bool isValid = true;
            foreach (var entity in entities)
            {
                ValidationContext validationContext = new(entity);
               isValid =  Validator.TryValidateObject(entity, validationContext , new List<ValidationResult>()); 
                //true: This parameter specifies whether to validate all properties (when true) or only required properties (when false). >> in case of using validate object()
            }
            if(isValid)
            {
                return base.SaveChanges();
            }
            return 0;  // indication for 0 entries added or updated >> saving didnot happen due to validation errors >> when call savechanges() check return != 0

        }

    }
}
