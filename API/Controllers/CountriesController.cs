using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain;
using Application.Countries;
using System;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> List() 
        {
            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Details(Guid id) 
        {
            return await _mediator.Send(new Details.DetailsID.Query{Id = id});
        }

        [HttpGet("{religion}")]
        public async Task<ActionResult<List<Country>>> Religion(string religion) 
        {
            return await _mediator.Send(new Details.DetailsReligion.Query{Religion = religion});
        }

        [HttpGet("{religion}")]
        public async Task<ActionResult<List<Country>>> ReligionAndRegion(string religion) 
        {
            return await _mediator.Send(new Details.DetailsReligion.Query{Religion = religion});
        }
    }
}