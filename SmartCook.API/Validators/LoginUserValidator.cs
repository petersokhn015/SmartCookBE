using FluentValidation;
using SmartCook.Application.DTO;

namespace SmartCook.API.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserDTO>
    {
        private CustomValidators customValidator;
        public LoginUserValidator()
        {
            customValidator = new();
            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is empty.")
                .Length(5, 100).WithMessage("Invalid length for {PropertyName}.")
                .Must(customValidator.BeAValidEmail).WithMessage("Invalid {PropertyName}.");

            RuleFor(u => u.Password)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("{PropertyName} is empty.")
               .Length(8, 100).WithMessage("Invalid length for {PropertyName}.")
               .Must(customValidator.BeAValidPassword).WithMessage("Invalid {PropertyName}, you can use at least uppercase or lowercase letters, one digit, one special character" +
               "and the length should be at least equal to 8");
        }
    }
}
