using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Application.DSL.Commands.CreateDSL;
using WebApp.Domain.Interfaces;

namespace WebApp.Application.DSL.Commands.EditDSL
{
    public class EditDSLCommandValidator : AbstractValidator<EditDSLCommand>
    {

        public EditDSLCommandValidator(IDSLRepository repository) {
            RuleFor(c => c.ShopId)
               .NotEmpty().WithMessage("Numer drogerii jest wymagany")
               .GreaterThan(0).WithMessage("Podaj numer większy od 0")
               .LessThan(9999).WithMessage("Podaj numer mniejszy od 9999")
               .Custom((value, context) =>
               {
                   var existingDSL = repository.GetByShopID(value).Result;
                   if (existingDSL != null)
                   {
                       context.AddFailure("DSL dla tej drogerii już istnieje");
                   }
               });
        }
    }
}
