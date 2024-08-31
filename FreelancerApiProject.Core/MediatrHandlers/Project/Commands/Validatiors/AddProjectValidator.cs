using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Project.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Project.Commands.Validatiors
{
    public class AddProjectValidator : AbstractValidator<AddProjectCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;


        public AddProjectValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            // Validate Title: required and must have a reasonable length
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);

            // Validate Description: optional, but if provided must have a reasonable length
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage(_localizer[SharedResourcesKeys.Required]);

            // Validate Link: optional, but if provided must be a valid URL
            RuleFor(x => x.Link)
                .Must(link => string.IsNullOrEmpty(link) || Uri.IsWellFormedUriString(link, UriKind.Absolute))
                .WithMessage(_localizer[SharedResourcesKeys.Required]);

            // Validate Poster: required and must be a valid URL
            RuleFor(x => x.Poster)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Must(IsValidUrl).WithMessage(_localizer[SharedResourcesKeys.Required]);

            // Validate Images: if provided, each must be a valid URL
            RuleForEach(x => x.Images)
                .Must(IsValidUrl).WithMessage(_localizer[SharedResourcesKeys.Required]);

            // Validate SkillIDs: must not be empty and each ID must be greater than zero
            RuleFor(x => x.SkillIds)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Must(skills => skills.All(id => id > 0)).WithMessage(_localizer[SharedResourcesKeys.Required]);

            // Validate FreelancerId: required and must be greater than zero
            RuleFor(x => x.FreelancerId)
                .GreaterThan(0).WithMessage(_localizer[SharedResourcesKeys.Required]);

            // Validate TimePublished: optional, but if provided must be a past or current date
            RuleFor(x => x.TimePublished)
                .LessThanOrEqualTo(DateTime.Now).WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        private bool IsValidUrl(string? url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}