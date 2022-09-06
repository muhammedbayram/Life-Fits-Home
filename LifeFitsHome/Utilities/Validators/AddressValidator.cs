using FluentValidation;
using LifeFitsHome.Model.DTOs;

namespace LifeFitsHome.Utilities.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("İsim formati hatalıdır");
            RuleFor(x => x.OpenAddress1).NotNull().WithMessage(" kurallara düzgün bir şekilde oluşturulmalıdır.");
            RuleFor(x => x.OpenAddress2).NotNull().MinimumLength(2).MaximumLength(50).WithMessage(" kurallara düzgün bir şekilde oluşturulmalıdır.");
        }
    }
}
