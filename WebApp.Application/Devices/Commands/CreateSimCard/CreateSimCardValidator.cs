using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.Devices.Commands.CreateSimCard
{
    public class CreateSimCardValidator : AbstractValidator<CreateSimCardCommand>
    {
        public CreateSimCardValidator(IDeviceRepository repository)
        {
            RuleFor(c => c.PIN)
                .Length(4).WithMessage("Podaj 4-cyfrowy PIN");
            RuleFor(c => c.USIM)
                .MinimumLength(8)
                .MaximumLength(25)
                  .Custom((value, context) =>
                  {
                      var existingDSL = repository.GetSIMByUSIM(value).Result;
                      if (existingDSL != null)
                      {
                          context.AddFailure("Karta sim o takim USIM istnieje");
                      }
                  });
            RuleFor(c => c.PUK)
                .Length(8).WithMessage("Podaj 8-cyfrowy PUK");
            RuleFor(c => c.Op)
                .NotEmpty();
            RuleFor(c => c.IP)
                .NotEmpty()
                .MaximumLength(15)
                .Matches(@"^(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                         @"(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                         @"(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                         @"(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
                .WithMessage("Adres IP musi być w formacie IPv4.")
                 .Custom((value, context) =>
                 {
                     var existingDSL = repository.GetSIMcardByIP(value).Result;
                     if (existingDSL != null)
                     {
                         context.AddFailure("Karta sim o takim IP istnieje");
                     }
                 });
            RuleFor(c => c.PhoneNumber)
                .Length(9).WithMessage("Podaj 9-cyfrowy Numer Telefonu")
                .Custom((value, context) =>
                {
                    var existingDSL = repository.GetSIMByPhoneNumber(value).Result;
                    if (existingDSL != null)
                    {
                        context.AddFailure("Karta sim o takim numerze telefonu istnieje");
                    }
                });
        }

    }
}
