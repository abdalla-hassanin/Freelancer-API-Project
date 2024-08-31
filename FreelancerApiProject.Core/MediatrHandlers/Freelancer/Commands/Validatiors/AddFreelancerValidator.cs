using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Freelancer.Commands.Validatiors
{
    public class AddFreelancerValidator : AbstractValidator<AddFreelancerCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;


        public AddFreelancerValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.PersonalImage)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Must(IsValidUrl).WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Address)
                .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);
            
            RuleFor(x => x.Overview)
                .MaximumLength(1000).WithMessage(_localizer[SharedResourcesKeys.Required]);

            

            // Validate SkillIDs: must not be empty and each ID must be greater than zero
            RuleFor(x => x.SkillIds)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Must(skills => skills.All(id => id > 0)).WithMessage(_localizer[SharedResourcesKeys.Required]);

         
        }

        private bool IsValidUrl(string? url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}