using FluentValidation;
using WebApp.Application.DSL.Commands.CreateDSL;
using WebApp.Domain.Interfaces;

public class CreateDSLCommandValidator : AbstractValidator<CreateDSLCommand>
{
    public CreateDSLCommandValidator(IDSLRepository repository)
    {
        RuleFor(c => c.ShopId)
        .NotEmpty().WithMessage("Numer drogerii jest wymagany")
        .GreaterThan(0).WithMessage("Podaj numer większy od 0")
        .LessThan(9999).WithMessage("Podaj numer mniejszy od 9999")
        .Custom((value , context) => 
        {
           var existingDSL = repository.GetByShopID(value).Result;
            if (existingDSL != null)
            {
                context.AddFailure("DSL dla tej drogerii już istnieje");
            }
        });
        RuleFor(c => c.IP)
            .NotEmpty().WithMessage("Adres IP jest wymagany")
            .MaximumLength(15);

        RuleFor(c => c.ServiceName)
            .NotEmpty().WithMessage("Dostawca jest wymagany");
    }
}
