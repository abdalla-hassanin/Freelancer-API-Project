using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Proposal.Commands.Validatiors
{
    public class AddProposalValidator : AbstractValidator<AddProposalCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;


        public AddProposalValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Duration)
                .GreaterThan(0)
                .WithMessage("Duration must be greater than 0");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");

            RuleFor(x => x.ReposLinks)
                .Must(links => links == null || links.All(link => Uri.IsWellFormedUriString(link, UriKind.Absolute)))
                .WithMessage("Each repository link must be a valid URL");

            RuleFor(x => x.Images)
                .Must(images =>
                    images == null || images.All(image => Uri.IsWellFormedUriString(image, UriKind.Absolute)))
                .WithMessage("Each image link must be a valid URL");

            RuleFor(x => x.FreelancerId)
                .GreaterThan(0)
                .WithMessage("FreelancerId must be greater than 0");

            RuleFor(x => x.JobId)
                .GreaterThan(0)
                .WithMessage("JobId must be greater than 0");
        }
    }
}