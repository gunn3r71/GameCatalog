using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Interfaces.Services;
using GameCatalog.API.Models;
using GameCatalog.API.Models.Developers.InputModels;
using GameCatalog.API.Models.Developers.ViewModels;

namespace GameCatalog.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDeveloperService _developerService;
        private readonly IMapper _mapper;

        public DevelopersController(IDeveloperService developerService, IMapper mapper)
        {
            _developerService = developerService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddDeveloperInputModel developerInputModel)
        {
            try
            {
                var developer = _mapper.Map<Developer>(developerInputModel);
                
                await _developerService.Add(developer);

                return CreatedAtRoute(nameof(Get), developer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationInputModel pg)
        {
            try
            {
                var developers = _mapper.Map<IEnumerable<DeveloperWithGamesViewModel>>(await _developerService.Get(pg.Page, pg.Amount));

                return Ok(developers);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
