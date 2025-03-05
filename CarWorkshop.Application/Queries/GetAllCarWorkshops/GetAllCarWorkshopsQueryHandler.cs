using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQueryHandler : IRequestHandler<GetAllCarWorkShopsQuery, IEnumerable<CarWorkshopDto>>
    {
        ICarWorkshopRepository carWorkshopRepository;
        IMapper mapper;
        public GetAllCarWorkshopsQueryHandler(ICarWorkshopRepository _carWorkshopRepository, IMapper _mapper)
        {
            carWorkshopRepository = _carWorkshopRepository;
            mapper = _mapper;
        }
        public async Task<IEnumerable<CarWorkshopDto>> Handle(GetAllCarWorkShopsQuery request, CancellationToken cancellationToken)
        {
            var carWorkshops = await carWorkshopRepository.GetAll();
            var dtos = mapper.Map<IEnumerable<CarWorkshopDto>>(carWorkshops);

            return dtos;
        }
    }
}
