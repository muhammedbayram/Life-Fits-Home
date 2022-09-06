using FluentValidation;
using LifeFitsHome.Model.DTOs;

namespace LifeFitsHome.Utilities.Validators
{
    public class UserRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Email formati hatalıdır");
            RuleFor(x => x.Password).NotNull().WithMessage("Password kurallara düzgün bir şekilde oluşturulmalıdır.");
            RuleFor(x => x.FirstName).NotNull().MinimumLength(2).MaximumLength(50).WithMessage("İsim kurallara düzgün bir şekilde oluşturulmalıdır.");
            RuleFor(x => x.Password).NotNull().MinimumLength(2).MaximumLength(50).WithMessage("Soyisim kurallara düzgün bir şekilde oluşturulmalıdır.");
            RuleFor(x => x.IdentyNumber).NotNull().Length(11).WithMessage("Tc kurallara uygun bir şekilde oluşturulmalıdır.");
        }
    }
}
