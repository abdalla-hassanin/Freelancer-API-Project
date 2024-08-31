using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Client.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Client.Commands.Validatiors
{
    public class EditClientValidator : AbstractValidator<EditClientCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;


        public EditClientValidator(IStringLocalizer<SharedResources> localizer)
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
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                    .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);
                RuleFor(x => x.Image)
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                    .Must(IsValidUrl).WithMessage(_localizer[SharedResourcesKeys.Required]);
                RuleFor(x => x.Country)
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                    .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);
            
                RuleFor(x => x.Description)
                    .MaximumLength(1000).WithMessage(_localizer[SharedResourcesKeys.Required]);

                //phone
                RuleFor(x => x.Phone)
                    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                    .Length(7, 15).WithMessage(_localizer[SharedResourcesKeys.Required]);
            }

            private bool IsValidUrl(string? url)
            {
                return Uri.IsWellFormedUriString(url, UriKind.Absolute);
            }
    }
}