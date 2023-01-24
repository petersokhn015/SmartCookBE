using FluentValidation;
using SmartCook.Application.DTO;

namespace SmartCook.API.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDTO>
    {
        private CustomValidators customValidator;
        public RegisterUserValidator() 
        {
            customValidator = new();
            RuleFor(u => u.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("{PropertyName} is empty.")
                .Length(2, 100).WithMessage("Invalid length for {PropertyName}.")
                .Must(customValidator.BeAValidUsername).WithMessage("Invalid {PropertyName}, you can use letters only or a mix of letters, numbers and symbols");

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
