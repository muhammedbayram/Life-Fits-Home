using FluentValidation;
using LifeFitsHome.Model.Entity;

namespace LifeFitsHome.Utilities.Validators
{
    public class VaccineTypeValidator : AbstractValidator<VaccineType>
    {
        public VaccineTypeValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(2).MaximumLength(50).WithMessage("Vaccine type name can not be empty");
        }
    }
}