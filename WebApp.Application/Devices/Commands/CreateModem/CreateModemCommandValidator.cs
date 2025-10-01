using FluentValidation;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.Devices.Commands.CreateModem
{
    public class CreateModemCommandValidator : AbstractValidator<CreateModemCommand>
    {
        public CreateModemCommandValidator(IDeviceRepository repository)
        {
            RuleFor(c => c.Model)
                .NotEmpty().WithMessage("Model jest wymagany")
                .MaximumLength(10);
            RuleFor(c => c.SerialNumber)
                .NotEmpty().WithMessage("SN jest wymagany")
                .MaximumLength(15)
                .MinimumLength(4)
                .Custom((value, context) =>
                {
                    var existingDSL = repository.GetSIMcardByIP(value).Result;
                    if (existingDSL != null)
                    {
                        context.AddFailure("Modem o takim SN istnieje");
                    }
                });
            ;
            RuleFor(c => c.ShopID)
                .NotEmpty().WithMessage("Wpisz numer drogerii lub centrala")
                .MaximumLength(10);
            RuleFor(c => c.Place)
                .MaximumLength(30);
            RuleFor(c => c.Description)
                .MaximumLength(100);
            RuleFor(c => c.RU)
                .MinimumLength(6).WithMessage("Długość między 6 a 10 znaków")
                .MaximumLength(10).WithMessage("Długość między 6 a 10 znaków")
                 .Custom((value, context) =>
                 {
                     var existingDSL = repository.GetModemByRUValidation(value).Result;
                     if (existingDSL != null)
                     {
                         context.AddFailure("Modem o takim RU istnieje");
                     }
                 });

        }   
    }
}
