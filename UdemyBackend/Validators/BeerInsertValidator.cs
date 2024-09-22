using FluentValidation;
using UdemyBackend.DTOs;

namespace UdemyBackend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto>
    {
        public BeerInsertValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es necesario");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe tener entre 2 a 20 carácteres");
            RuleFor(x => x.BrandId).GreaterThan(0);
        }
    }
}
