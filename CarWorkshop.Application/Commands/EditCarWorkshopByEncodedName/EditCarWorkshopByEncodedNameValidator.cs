using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Commands.EditCarWorkshopByEncodedName
{
    public class EditCarWorkshopByEncodedNameValidator : AbstractValidator<EditCarWorkshopByEncodedNameCommand>
    {
        public EditCarWorkshopByEncodedNameValidator(ICarWorkshopRepository carWorkshopRepository)
        {
            RuleFor(d => d.Description)
                .NotEmpty();

            RuleFor(p => p.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
