using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Commands.CreateCarWorkshop
{
    public class CreateCarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        ICarWorkshopRepository carWorkshopRepository;
        IMapper mapper;
        IUserContext userContext;
        public CreateCarWorkshopCommandHandler(ICarWorkshopRepository _carWorkshopRepository, IMapper _mapper, IUserContext _userContext)
        {
            carWorkshopRepository = _carWorkshopRepository;
            mapper = _mapper;
            userContext = _userContext;
        }
        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var currentUser = userContext.GetCurrentUser();
            if (currentUser == null) 
            { 
                return Unit.Value;
            }
            var carWorkshop = mapper.Map<Domain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();
            
            carWorkshop.CreatedById = currentUser.Id;

            await carWorkshopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
