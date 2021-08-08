using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameCatalog.API.Domain.Entities;
using GameCatalog.API.Domain.Exceptions;
using GameCatalog.API.Domain.Interfaces.Services;
using GameCatalog.API.Models;
using GameCatalog.API.Models.Games.InputModels;
using GameCatalog.API.Models.Games.ViewModels;

namespace GameCatalog.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GamesController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddGameInputModel gameInputModel)
        {
            try
            {
                var game = _mapper.Map<Game>(gameInputModel);
                await _gameService.Add(game);

                var gameViewModel = _mapper.Map<GameViewModel>(game);
                
                return CreatedAtRoute(gameViewModel.Id, gameViewModel);
            }
            catch (GameExistsException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateGameInputModel gameInputModel)
        {
            try
            {
                if (id != gameInputModel.Id) return BadRequest();

                var game = _mapper.Map<Game>(gameInputModel);

                await _gameService.Update(game);

                return NoContent();
            }
            catch (GameNotExistsException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id:guid}/price/{price:double}")]
        public async Task<IActionResult> Patch(Guid id, double price)
        {
            try
            {
                await _gameService.UpdatePrice(id, price);

                return NoContent();
            }
            catch (GameNotExistsException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{id:guid}/title/{title}")]
        public async Task<IActionResult> Patch(Guid id, string title)
        {
            try
            {
                await _gameService.UpdateTitle(id, title);
                return NoContent();
            }
            catch (GameNotExistsException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _gameService.Delete(id);

                return NoContent();
            }
            catch (GameNotExistsException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationInputModel pg)
        {
            var games = await _gameService.Get(pg.Page, pg.Amount);
            var gamesViewModel = _mapper.Map<IEnumerable<GameViewModel>>(games);

            return Ok(gamesViewModel);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var game = await _gameService.GetById(id);

                var gameViewModel = _mapper.Map<GameViewModel>(game);

                return Ok(gameViewModel);
            }
            catch (GameNotExistsException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
