using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Validatiors
{
    public class EditRateValidator : AbstractValidator<EditRateCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        

        public EditRateValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer=localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            RuleFor(x=>x.Id)
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);
            
            RuleFor(x => x.Value)
                .InclusiveBetween(1, 5)
                .WithMessage(_localizer[SharedResourcesKeys.ValueRange1to5]);
            RuleFor(x => x.JobId)
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        

    }
}
