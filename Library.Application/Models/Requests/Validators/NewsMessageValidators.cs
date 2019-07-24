﻿using FluentValidation;

namespace Library.Application.Models.Requests.Validators
{
    public class CreateNewsMessageRequestValidator : AbstractValidator<CreateNewsMessageRequest>
    {
        public CreateNewsMessageRequestValidator()
        {
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Message).NotEmpty();
        }
    }

    public class UpdateNewsMessageRequestValidator : AbstractValidator<UpdateNewsMessageRequest>
    {
        public UpdateNewsMessageRequestValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.Message).NotEmpty();
        }
    }
}