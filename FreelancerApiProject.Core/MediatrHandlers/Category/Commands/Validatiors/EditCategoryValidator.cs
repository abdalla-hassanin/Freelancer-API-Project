﻿using FluentValidation;
using FreelancerApiProject.Core.Base.Resources;
using FreelancerApiProject.Core.MediatrHandlers.Category.Commands.Models;
using Microsoft.Extensions.Localization;

namespace FreelancerApiProject.Core.MediatrHandlers.Category.Commands.Validatiors
{
    public class EditCategoryValidator : AbstractValidator<EditCategoryCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;


        public EditCategoryValidator(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
        }


        private void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required]);

            // Validate Title: required and must have a reasonable length
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Length(3, 100).WithMessage(_localizer[SharedResourcesKeys.Required]);
            // Validate Description: required and must have a reasonable length
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage(_localizer[SharedResourcesKeys.Required]);

        }
    }
}