using FluentValidation;
using LifeFitsHome.Model.Entity;

namespace LifeFitsHome.Utilities.Validators
{
    public class VaccineValidator : AbstractValidator<Vaccine>
    {
        public VaccineValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(2).MaximumLength(50).WithMessage("Vaccine name can not be empty");
            RuleFor(x => x.Description).MaximumLength(140);
            RuleFor(x => x.VaccineTypeId).NotNull().WithMessage("Vaccine type must be specified");
        }
    }
}