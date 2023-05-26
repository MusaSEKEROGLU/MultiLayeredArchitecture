using FluentValidation;
using MultiLayered.Core.Dtos;

namespace MultiLayered.Service.Validations
{
    public class TeamDtoValidator : AbstractValidator<TeamDto>
    {
        public TeamDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} bu alan gereklidir.")
                .NotEmpty().WithMessage("{PropertyName} bu alan boş olmamalı.").Length(0, 100)
                .WithMessage("{PropertyName} 0-100 aralığında olmalıdır.");

            RuleFor(x => x.TeamPrice).NotNull().WithMessage("{PropertyName} bu alan gereklidir.")
               .NotEmpty().WithMessage("{PropertyName} bu alan boş olmamalı.").ExclusiveBetween(10000, 5000000)
               .WithMessage("{PropertyName} 10000-5000000 aralığında olmalıdır.");

            //RuleFor(x => x.CountryId).ExclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} 0 olmamalı.");
        }
    }
}
