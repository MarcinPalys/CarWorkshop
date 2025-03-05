using AutoMapper;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Queries.GetCarWorkshopServices
{
    public class GetCarWorkshopServicesQueryHandler : IRequestHandler<GetCarWorkshopServicesQuery, IEnumerable<CarWorkshopServiceDto>>
    {
        ICarWorkshopServiceRepository carWorkshopServiceRepository;
        IMapper mapper;
        public GetCarWorkshopServicesQueryHandler(ICarWorkshopServiceRepository _carWorkshopServiceRepository, IMapper _mapper)
        {
            carWorkshopServiceRepository = _carWorkshopServiceRepository;
            mapper = _mapper;
        }

        public async Task<IEnumerable<CarWorkshopServiceDto>> Handle(GetCarWorkshopServicesQuery request, CancellationToken cancellationToken)
        {
            var result = await carWorkshopServiceRepository.GetAllByEncodedName(request.EncodedName);
            var dtos = mapper.Map<IEnumerable<CarWorkshopServiceDto>>(result);

            return dtos;
        }
    }
}
