using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalog.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        public GamesController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return null;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id)
        {
            return null;
        }

        [HttpPatch("{id:guid}/price/{price:double}")]
        public async Task<IActionResult> PatchPrice(Guid id, double price)
        {
            return null;
        }

        [HttpPatch("{id:guid}/title/{title}")]
        public async Task<IActionResult> PatchPrice(Guid id, string title)
        {
            return null;
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return null;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return null;
        }


    }
}
