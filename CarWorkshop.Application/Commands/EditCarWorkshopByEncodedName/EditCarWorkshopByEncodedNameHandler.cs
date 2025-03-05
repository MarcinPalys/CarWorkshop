using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Commands.EditCarWorkshopByEncodedName
{
    internal class EditCarWorkshopByEncodedNameHandler : IRequestHandler<EditCarWorkshopByEncodedNameCommand>
    {
        private readonly IUserContext userContext;
        private readonly ICarWorkshopRepository carWorkshopRepository;
        public EditCarWorkshopByEncodedNameHandler(ICarWorkshopRepository _carWorkshopRepository, IUserContext _userContext)
        {
            userContext = _userContext;
            carWorkshopRepository = _carWorkshopRepository;
        }
        public async Task<Unit> Handle(EditCarWorkshopByEncodedNameCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await carWorkshopRepository.GetByEncodedName(request.EncodedName!);

            var user = userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            carWorkshop.Description = request.Description;
            carWorkshop.About = request.About;
            carWorkshop.ContactDetails.City = request.City; 
            carWorkshop.ContactDetails.PostalCode = request.PostalCode; 
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.Street = request.Street;
            await carWorkshopRepository.Commit();

            return Unit.Value;
        }
    }
}
