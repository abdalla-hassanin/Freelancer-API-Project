using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Rate.Commands.Validatiors
{
    public class AddRateValidator : AbstractValidator<AddRateCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        

        public AddRateValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer=localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Value)
                .InclusiveBetween(1, 5)
                .WithMessage(_localizer[SharedResourcesKeys.ValueRange1to5]);
            RuleFor(x => x.JobId)
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }
        

    }
}