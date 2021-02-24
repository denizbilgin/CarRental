using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(5);
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ModelYear).LessThan(DateTime.Now.Year);
            RuleFor(c => c.ModelYear).NotEmpty();
        }
    }
}
