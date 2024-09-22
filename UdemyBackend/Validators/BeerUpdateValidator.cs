using FluentValidation;
using UdemyBackend.DTOs;

namespace UdemyBackend.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("El id es obligatorio");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es necesario");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe tener entre 2 a 20 carácteres");
            RuleFor(x => x.BrandId).GreaterThan(0);
        }
    }
}
