using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GameCatalog.API.Domain.Entities;
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateGameInputModel gameInputModel)
        {
            try
            {
                if (id != gameInputModel.Id) return BadRequest();

                var gameExists = await _gameService.Exists(id);

                if (!gameExists) return NotFound();

                var game = _mapper.Map<Game>(gameInputModel);

                await _gameService.Update(game);

                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPatch("{id:guid}/price/{price:double}")]
        public async Task<IActionResult> PatchPrice(Guid id, double price)
        {
            try
            {
                var gameExists = await _gameService.Exists(id);
                if (!gameExists) return NotFound();
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPatch("{id:guid}/title/{title}")]
        public async Task<IActionResult> PatchPrice(Guid id, string title)
        {
            try
            {
                var gameExists = await _gameService.Exists(id);
                if (!gameExists) return NotFound();
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var gameExists = await _gameService.Exists(id);
                if (!gameExists) return NotFound();

                await _gameService.Delete(id);

                return NoContent();
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
                var games = await _gameService.Get(pg.Page, pg.Amount);
                var gamesViewModel = _mapper.Map<IEnumerable<GameViewModel>>(games);

                return Ok(gamesViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var game = await _gameService.GetById(id);
                if (game == null) return NotFound();

                var gameViewModel = _mapper.Map<GameViewModel>(game);

                return Ok(gameViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
