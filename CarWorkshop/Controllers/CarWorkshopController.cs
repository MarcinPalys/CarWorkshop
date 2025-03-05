using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshopService.Commands;
using CarWorkshop.Application.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Commands.EditCarWorkshopByEncodedName;
using CarWorkshop.Application.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.Queries.GetCarWrokshopByEncodedName;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Extensions;
using CarWorkshop.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarWorkshop.Application.CarWorkshopService.Queries.GetCarWorkshopServices;

namespace CarWorkshop.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public CarWorkshopController(IMediator _mediator, IMapper _mapper)
        {
            mediator = _mediator;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshops = await mediator.Send(new GetAllCarWorkShopsQuery());
            return View(carWorkshops);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await mediator.Send(command);
            this.SetNotification("success", $"Created carworkshop {command.Name}");
            return RedirectToAction(nameof(Index));
        }
        [Route("CarWorkshop/CarWorkshopService")]

        public async Task<IActionResult> CreateCarWorkshopService(CreateCarWorkshopServiceCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await mediator.Send(command);
            
            return Ok();
        }

        
        [HttpGet]
        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var CarWorkshopDetails = await mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            return View(CarWorkshopDetails);
        }

        [HttpGet]
        [Route("CarWorkshop/{encodedName}/Edit")]
        [Authorize]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditCarWorkshopByEncodedNameCommand command = mapper.Map<EditCarWorkshopByEncodedNameCommand>(dto);

            return View(command);
        }       
        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(EditCarWorkshopByEncodedNameCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await mediator.Send(command);
            

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("CarWorkshop/{encodedName}/CarWorkshopServices")]
        public async Task<IActionResult> GetCarWorkshopServices(string encodedName)
        {
            var data = await mediator.Send(new GetCarWorkshopServicesQuery() { EncodedName = encodedName});

            return Ok(data);
        }
    }
}
