using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Job.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Job.Commands.Validatiors
{
    public class AddJobValidator : AbstractValidator<AddJobCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;


        public AddJobValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(255).WithMessage("Title must not exceed 255 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.MinBudget)
                .GreaterThan(0).WithMessage("MinBudget must be greater than 0.");

            RuleFor(x => x.MaxBudget)
                .GreaterThan(x => x.MinBudget).WithMessage("MaxBudget must be greater than MinBudget.");

            RuleFor(x => x.DurationInDays)
                .GreaterThan(0).WithMessage("DurationInDays must be greater than 0.");

            RuleFor(x => x.ExperienceLevel)
                .IsInEnum().WithMessage("Invalid ExperienceLevel.");

            RuleFor(x => x.SkillsIds)
                .Must(x => x == null || x.All(id => id > 0)).WithMessage("Invalid SkillsIds.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid Status.");

            RuleFor(x => x.ClientId)
                .GreaterThan(0).WithMessage("ClientId must be greater than 0.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");        }
    }
}