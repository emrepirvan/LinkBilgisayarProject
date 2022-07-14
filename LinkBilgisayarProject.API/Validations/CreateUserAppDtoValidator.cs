using FluentValidation;
using LinkBilgisayarProject.Core.Dtos;

namespace LinkBilgisayarProject.API.Validations
{
    public class CreateUserAppDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserAppDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is wrong");


            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("username is required");


        }
    }
}
