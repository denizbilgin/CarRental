using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).MinimumLength(3);
        }
    }
}
