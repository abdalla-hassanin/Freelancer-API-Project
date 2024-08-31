using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Validatiors
{
    public class EditFreelancerValidator : AbstractValidator<EditFreelancerCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;


        public EditFreelancerValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Name)
                .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.PersonalImage)
                .Must(IsValidUrl).WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Title)
                .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Address)
                .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Overview)
                .MaximumLength(1000).WithMessage(_localizer[SharedResourcesKeys.Required]);


            // Validate SkillIDs: must not be empty and each ID must be greater than zero
            RuleFor(x => x.SkillIds)
                .Must(skills => skills.All(id => id > 0)).WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        private bool IsValidUrl(string? url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}