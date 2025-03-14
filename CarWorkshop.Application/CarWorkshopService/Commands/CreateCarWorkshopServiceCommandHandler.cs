﻿using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        IUserContext _userContext;
        ICarWorkshopRepository _carWorkshopRepository;
        ICarWorkshopServiceRepository _carWorkshopServiceRepository;
        public CreateCarWorkshopServiceCommandHandler(IUserContext userContext, ICarWorkshopRepository carWorkshopRepository, ICarWorkshopServiceRepository carWorkshopServiceRepository)
        {
            _userContext = userContext;
            _carWorkshopRepository = carWorkshopRepository;
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
        }
        public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            var CarWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
                CarWorkshopId = carWorkshop.Id,
            };

            await _carWorkshopServiceRepository.Create(CarWorkshopService);

            return Unit.Value;
        }
    }
}
