using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Queries.GetCarWrokshopByEncodedName
{
    public class GetCarWorkshopByEncodedNameQueryHandler : IRequestHandler<GetCarWorkshopByEncodedNameQuery, CarWorkshopDto>
    {
        ICarWorkshopRepository carWorkshopRepository;
        IMapper mapper;
        public GetCarWorkshopByEncodedNameQueryHandler(ICarWorkshopRepository _carWorkshopRepository, IMapper _mapper)
        {
            carWorkshopRepository = _carWorkshopRepository;
            mapper = _mapper;
        }
        public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await carWorkshopRepository.GetByEncodedName(request.EncodedName);
            var dtos = mapper.Map<CarWorkshopDto>(carWorkshop);

            return dtos;
        }
    }
}
