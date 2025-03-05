using CarWorkshop.Application.CarWorkshop;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Queries.GetAllCarWorkshops
{
    public class GetAllCarWorkShopsQuery : IRequest<IEnumerable<CarWorkshopDto>>
    {

    }
}
